using MachineSpecs.Models;
using MachineSpecs.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineSpecs.Controllers
{
    public class ComputerController : Controller
    {
        private IComputerRepository repository;
        private ApplicationDbContext context;

        public ComputerController(IComputerRepository repository, ApplicationDbContext context)
        {
            this.repository = repository;
            this.context = context;
        }

        public ViewResult List(string search, string selectedPort = "All", int memoryMin = 0, int memoryMax = 50, string orderBy = "ID")
        {
            var computers = repository.Computers;
            if (!string.IsNullOrEmpty(search))
            {
                computers = computers.Where(c => c.GetFullText().Contains(search.ToLower()));
            }

            computers = computers.Where(c => selectedPort.Equals("All") || c.Connections.Select(con => con.Port.Name).Contains(selectedPort));
            decimal overallMemoryMax = repository.Computers.Select(c => c.Memory).Max();

            switch(orderBy)
            {
                case "ID":
                    computers = computers.OrderBy(c => c.ComputerID);
                    break;
                case "Most Ports First":
                    computers = computers.OrderByDescending(c => c.Connections.Sum(con => con.Quantity));
                    break;
                case "Lightest First":
                    computers = computers.OrderBy(c => c.Weight);
                    break;
                default:
                    break;
            }

            return View(new ComputerListViewModel
            {
                Computers = computers.Where(c => c.Memory >= memoryMin && c.Memory <= memoryMax),
                FilterInfo = new FilterInfo {
                    SearchWord = search,
                    OverallMemoryMax = overallMemoryMax,
                    MemoryMin = memoryMin,
                    MemoryMax = memoryMax,
                    Ports = context.Ports,
                    SelectedPort = selectedPort,
                    OrderBy = orderBy,
                    OrderMethods = new List<string>{ "ID", "Most Ports First", "Lightest First" }
                }
            });
        }

        public ViewResult Edit(int id) {
            ViewBag.GraphicsCardManufacturers = context.GraphicsCards.Select(gc => new SelectListItem() { Text = gc.Manufacturer.Trim() }).Distinct();
            ViewBag.GraphicsCardModels = context.GraphicsCards.Select(gc => new SelectListItem() { Text = gc.Model.Trim() }).Distinct();
            ViewBag.ProcessorManufacturers = context.Processors.Select(p => new SelectListItem() { Text = p.Manufacturer.Trim() }).Distinct();
            ViewBag.ProcessorModels = context.Processors.Select(p => new SelectListItem() { Text = p.Model.Trim() }).Distinct();

            return View(
            repository.Computers.Where(c => c.ComputerID.Equals(id)).FirstOrDefault()
            );
        }

        public async Task<ActionResult> Save(Computer computer)
        {
            Computer old = context.Computers.SingleOrDefault(c => c.ComputerID == computer.ComputerID);
            if (await TryUpdateModelAsync(old))
            {
                await context.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}