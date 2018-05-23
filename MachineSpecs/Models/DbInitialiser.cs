using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MachineSpecs.Models
{
    public static class DbInitialiser
    {
        public static void Initialise(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Computers.Any())
            {
                string[] rows = File.ReadAllLines("wwwroot/data/SeedData.txt");

                foreach(string row in rows)
                {
                    string[] cells = row.Split("\t".ToCharArray());
                    string rawMemory = cells[0];
                    string rawStorage = cells[1];
                    string rawConnections = cells[2];
                    string rawGraphicsCard = cells[3];
                    string rawWeight = cells[4];
                    string rawPower = cells[5];
                    string rawProcessor = cells[6];

                    Processor processor = new Processor
                    {
                        Manufacturer = rawProcessor.Split(' ')[0],
                        Model = rawProcessor.Substring(rawProcessor.IndexOf(' ') + 1)
                    };
                    

                    GraphicsCard graphicsCard = new GraphicsCard
                    {
                        Manufacturer = rawGraphicsCard.Split(' ')[0],
                        Model = rawProcessor.Substring(rawGraphicsCard.IndexOf(' ') + 1)
                    };

                    Computer computer = new Computer
                    {
                        Processor = processor,
                        GraphicsCard = graphicsCard
                    };
                    context.Computers.Add(computer);
                }
                context.SaveChanges();
            }
        }
    }
}