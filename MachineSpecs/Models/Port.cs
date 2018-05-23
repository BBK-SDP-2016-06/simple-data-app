using System.Collections.Generic;

namespace MachineSpecs.Models
{
    public class Port
    {
        public int PortID { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Port)
            {
                Port that = (Port)obj;
                return this.Name.Equals(that.Name);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -922353319;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}