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

        //Each computer contains a reference to its processor, graphics card
        //and connections.
        public Processor Processor { get; set; }
        public GraphicsCard GraphicsCard { get; set; }
        public List<Connection> Connections { get; set; }

        /// <summary>
        /// Retrieves the text components of this Computer's
        /// properties so that key word searching in enabled.
        /// </summary>
        /// <returns></returns>
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