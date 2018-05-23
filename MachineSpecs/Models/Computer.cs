using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineSpecs.Models
{
    public class Computer
    {
        public int ComputerID { get; set; }
        public decimal Memory { get; set; }
        public decimal StorageCapacity { get; set; }
        public string StorageType { get; set; }
        public decimal Weight { get; set; }
        public int Power { get; set; }
    }
}
