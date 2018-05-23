using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineSpecs.Models
{
    public class FakeComputerRepository : IComputerRepository
    {
        public IQueryable<Computer> Computers => new List<Computer> {
            new Computer {ComputerID = 1, Memory = 8, StorageCapacity = 1, StorageType = StorageType.SSD, Weight = 8.1M, Power = 500 },
            new Computer {ComputerID = 2, Memory = 16, StorageCapacity = 2, StorageType = StorageType.HDD, Weight = 12, Power = 500 },
            new Computer {ComputerID = 3, Memory = 8, StorageCapacity = 3, StorageType = StorageType.HDD, Weight = 7.3M, Power = 450 }
        }.AsQueryable();
    }
}
