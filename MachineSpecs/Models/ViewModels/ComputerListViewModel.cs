using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineSpecs.Models.ViewModels
{
    public class ComputerListViewModel
    {
        public IEnumerable<Computer> Computers { get; set; }
        public FilterInfo FilterInfo { get; set; }
    }
}
