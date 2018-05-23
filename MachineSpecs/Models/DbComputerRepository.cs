using System.Collections.Generic;
using System.Linq;

namespace MachineSpecs.Models
{
    public class DbComputerRepository : IComputerRepository
    {
        private ApplicationDbContext context;

        public DbComputerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Computer> Computers => GetPopulatedComputers();

        private IQueryable<Computer> GetPopulatedComputers()
        {
            List<Computer> comps = new List<Computer>();

            foreach(var c in context.Computers)
            {
                c.Connections = context.Connections.Where(con => con.ComputerID.Equals(c.ComputerID)).ToList();
                c.GraphicsCard = context.GraphicsCards.Where(gc => c.GraphicsCardID.Equals(gc.GraphicsCardID)).FirstOrDefault();
                c.Processor = context.Processors.Where(p => c.ProcessorID.Equals(p.ProcessorID)).FirstOrDefault();

                foreach (var connection in c.Connections)
                {
                    connection.Port = context.Ports.Where(p => p.PortID.Equals(connection.PortID)).FirstOrDefault();
                }

                comps.Add(c);
            }
            return comps.AsQueryable();
        }
    }
}