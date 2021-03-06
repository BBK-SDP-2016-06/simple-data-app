﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineSpecs.Models
{
    /// <summary>
    /// Used for initial testing purposes before a database migration and
    /// connection were established. Used to ensure razor views and controllers
    /// behaved as expected.
    /// </summary>
    public class FakeComputerRepository : IComputerRepository
    {
        public IQueryable<Computer> Computers => new List<Computer> {
            new Computer {ComputerID = 1, Memory = 8, StorageCapacity = 1, StorageType = "SSD", Weight = 8.1M, Power = 500 },
            new Computer {ComputerID = 2, Memory = 16, StorageCapacity = 2, StorageType = "HDD", Weight = 12, Power = 500 },
            new Computer {ComputerID = 3, Memory = 8, StorageCapacity = 3, StorageType = "HDD", Weight = 7.3M, Power = 450 }
        }.AsQueryable();
    }
}
