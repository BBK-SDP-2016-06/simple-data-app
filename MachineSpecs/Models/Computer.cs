using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MachineSpecs.Models
{
    public class Computer
    {
        public int ComputerID { get; set; }
        public decimal Memory { get; set; }
        public decimal StorageCapacity { get; set; }
        public string StorageType { get; set; }
        public int GraphicsCardID { get; set; }  
        public decimal Weight { get; set; }
        public int Power { get; set; }
        public int ProcessorID { get; set; }

        public Processor Processor { get; set; }
        public GraphicsCard GraphicsCard { get; set; }
        public List<Connection> Connections { get; set; }

        public string GetFullText()
        {
            return string.Join(' ', new List<string>
            {
                GraphicsCard.Manufacturer,
                GraphicsCard.Model,
                Processor.Manufacturer,
                Processor.Model,
                StorageType
            }).ToLower();
        }
    }
}