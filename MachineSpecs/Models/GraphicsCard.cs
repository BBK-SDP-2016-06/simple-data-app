using System.Collections.Generic;

namespace MachineSpecs.Models
{
    public class GraphicsCard
    {
        public int GraphicsCardID { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is GraphicsCard)
            {
                GraphicsCard that = (GraphicsCard)obj;
                return this.Manufacturer.Equals(that.Manufacturer) && this.Model.Equals(that.Model);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -1606514614;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Manufacturer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }
    }
}