using System.Collections.Generic;
namespace MachineSpecs.Models
{
    public class Computer
    {
        public int ComputerID { get; set; }
        public decimal Memory { get; set; }
        public decimal StorageCapacity { get; set; }
        public StorageType StorageType { get; set; }
        public int GraphicsCardID { get; set; }  
        public decimal Weight { get; set; }
        public int Power { get; set; }
        public int ProcessorID { get; set; }

        public Processor Processor { get; set; }
        public GraphicsCard GraphicsCard { get; set; }
        public List<Connection> Connections { get; set; }
    }

    public enum StorageType
    {
        SSD, HDD
    }
}