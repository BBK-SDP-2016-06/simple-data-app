using MachineSpecs.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineSpecs.Controllers
{
    public class ComputerController : Controller
    {
        private IComputerRepository repository;

        public ComputerController(IComputerRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List() => View(repository.Computers);
    }
}