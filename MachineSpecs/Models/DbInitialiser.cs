using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MachineSpecs.Models
{
    /// <summary>
    /// Initialises a database by seeding with data (if not already done so).
    /// This class and static method are called by the startup class on
    /// application execution.
    /// </summary>
    public static class DbInitialiser
    {
        private static List<Processor> SeedProcessors = new List<Processor>();
        private static List<GraphicsCard> SeedGraphicsCards = new List<GraphicsCard>();
        private static List<Port> SeedPorts = new List<Port>();

        public static void Initialise(IApplicationBuilder app)
        {
            //Obtain application database context
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            //Only perform seeding operation if no domain objects exist in the database
            if (!context.Computers.Any())
            {
                //Extract raw data rows from flat text file
                string[] rows = File.ReadAllLines("wwwroot/data/SeedData.txt");

                foreach(string row in rows)
                {
                    //Parse each column
                    string[] cells = row.Split("\t".ToCharArray());
                    string rawMemory = cells[0];
                    string rawStorage = cells[1];
                    string rawConnections = cells[2];
                    string rawGraphicsCard = cells[3];
                    string rawWeight = cells[4];
                    string rawPower = cells[5];
                    string rawProcessor = cells[6];

                    //Create processor object
                    Processor processor = new Processor
                    {
                        Manufacturer = rawProcessor.Split(' ')[0],
                        Model = rawProcessor.Substring(rawProcessor.IndexOf(' ') + 1)
                    };
                    if (!SeedProcessors.Contains(processor)) SeedProcessors.Add(processor);
                    
                    //Create graphics card object
                    GraphicsCard graphicsCard = new GraphicsCard
                    {
                        Manufacturer = rawGraphicsCard.Split(' ')[0],
                        Model = rawGraphicsCard.Substring(rawGraphicsCard.IndexOf(' ') + 1)
                    };
                    if (!SeedGraphicsCards.Contains(graphicsCard)) SeedGraphicsCards.Add(graphicsCard);

                    //Construction connection objects and add to database context
                    string[] connectionInstances = rawConnections.Split(',').Select(s => s.Trim()).ToArray();
                    SeedPorts.AddRange(connectionInstances
                        .Select(c => new Port { Name = c.Split("x")[1].Trim() })
                        .Where(p => !SeedPorts.Contains(p)));

                    List<Connection> connections = connectionInstances
                        .Select(c => new Connection {
                            Quantity = int.Parse(c.Split("x")[0].Trim()),
                            Port = SeedPorts.Where(p => c.Split("x")[1].Trim().Equals(p.Name)).FirstOrDefault()
                        }).ToList();

                    //Construct computer object and add to database context
                    Computer computer = new Computer
                    {
                        Memory = CalculateMemory(rawMemory),
                        Power = CalculatePower(rawPower),
                        StorageCapacity = CalculateStorageCapacity(rawStorage),
                        StorageType = rawStorage.Split(' ')[2],
                        Weight = CalculateWeight(rawWeight),
                        Processor = SeedProcessors.Where(p => p.Equals(processor)).FirstOrDefault(),
                        GraphicsCard = SeedGraphicsCards.Where(gc => gc.Equals(graphicsCard)).FirstOrDefault(),
                        Connections = connections
                    };
                    context.Computers.Add(computer);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Extracts the Memory component of the data cell as a decimal. This method
        /// can fail if the raw data is not formatted correctly- need to change to
        /// create more robust error handling.
        /// </summary>
        /// <param name="data">Raw data obtained from seed flat file.</param>
        /// <returns>The memory of the computer instance that this data represents 
        /// as a decimal.</returns>
        private static decimal CalculateMemory(string data)
        {
            string[] segments = data.Split(' ');
            if (segments[1].Equals("GB"))
                return decimal.Parse(segments[0]);
            else
                //Convert MB to GB - data specific not good practice
                return decimal.Parse(segments[0]) / 1024M;
        }

        /// <summary>
        /// Extracts the Power rating from the raw data cell. This method
        /// can fail if the raw data is not formatted correctly- need to change to
        /// create more robust error handling.
        /// </summary>
        /// <param name="data">Raw data obtained from the seed flat file.</param>
        /// <returns>The Power rating of the computer instance that this data represents
        /// as an integer.</returns>
        private static int CalculatePower(string data) => int.Parse(data.Split(' ')[0]);

        /// <summary>
        /// Calculates the storage capacity in TB of the raw data cell. This method
        /// can fail if the raw data is not formatted correctly- need to change to
        /// create more robust error handling.
        /// </summary>
        /// <param name="data">Raw data obtained from the seed flat file.</param>
        /// <returns>The storage capacity of this computer instance.</returns>
        private static decimal CalculateStorageCapacity(string data)
        {
            string[] segments = data.Split(' ');
            if (segments[1].Equals("TB"))
                return decimal.Parse(segments[0]);
            else
                return decimal.Parse(segments[0]) / 1000M;
        }

        /// <summary>
        /// Extracts the weight in kg from the raw data cell. This method
        /// can fail if the raw data is not formatted correctly- need to change to
        /// create more robust error handling.
        /// </summary>
        /// <param name="data">Raw data obtained from the seed flat file.</param>
        /// <returns>The weight of the computer instance.</returns>
        private static decimal CalculateWeight(string data)
        {
            string[] segments = data.Split(' ');
            if (segments[1].Equals("kg"))
                //return value as is if in kg
                return decimal.Parse(segments[0]);
            else
                //return the value converted to kg from lb
                return decimal.Parse(segments[0]) * 0.453592M;
        }
    }
}