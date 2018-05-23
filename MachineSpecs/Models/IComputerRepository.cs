using System.Linq;

namespace MachineSpecs.Models
{
    public interface IComputerRepository
    {
        IQueryable<Computer> Computers { get; }
    }
}
