using System.Collections.Generic;
using System.Linq;

namespace MachineSpecs.Models
{
    /// <summary>
    /// Repository that bridges the databse context and main application
    /// </summary>
    public class DbComputerRepository : IComputerRepository
    {
        private ApplicationDbContext context;

        //Database context injected via dependancy injection
        public DbComputerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Computer> Computers => GetPopulatedComputers();

        /// <summary>
        /// Constructs each computer object found in the database and returns
        /// these in an IQueryable data structure.
        /// </summary>
        /// <returns>List of computers from the underlying database</returns>
        private IQueryable<Computer> GetPopulatedComputers()
        {
            List<Computer> comps = new List<Computer>();

            /*
             * In order to construct each computer we first have to build its 
             * connections, graphics card and processor. Then we need to build
             * each port represented by a connection and assign them. Once the
             * components have been assembled, we can then construct the Computer
             * objects.
             */
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