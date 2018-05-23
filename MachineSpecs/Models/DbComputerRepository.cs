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

        public IQueryable<Computer> Computers => context.Computers;
    }
}