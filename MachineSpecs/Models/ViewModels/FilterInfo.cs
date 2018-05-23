using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineSpecs.Models.ViewModels
{
    public class FilterInfo
    {
        public string SearchWord { get; set; }
        public decimal OverallMemoryMax { get; set; }
        public int MemoryMin { get; set; }
        public int MemoryMax { get; set; }
        public IEnumerable<Port> Ports { get; set; }
        public string SelectedPort { get; set; }
        public string OrderBy { get; set; }
        public IEnumerable<string> OrderMethods { get; set; }
    }
}