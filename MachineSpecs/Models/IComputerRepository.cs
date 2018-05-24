using System.Linq;

namespace MachineSpecs.Models
{
    /// <summary>
    /// This interface represents a repository of computers extracted from an
    /// external data source. This implements the repository pattern that
    /// provides good decoupling between the database context and the 
    /// application. 
    /// </summary>
    public interface IComputerRepository
    {
        IQueryable<Computer> Computers { get; }
    }
}
