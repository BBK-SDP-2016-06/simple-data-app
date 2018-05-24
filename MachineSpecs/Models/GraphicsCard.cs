using System.Collections.Generic;

namespace MachineSpecs.Models
{
    public class GraphicsCard
    {
        public int GraphicsCardID { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// Determines whether this GraphicsCard object is equal to the GraphicsCard
        /// argument object. Both are deemed equal if they both have the same 
        /// manufacturer and model. Once two GraphicsCards have been declared equal,
        /// then they are both assigned the same ID elsewhere in the application.
        /// </summary>
        /// <param name="obj">The object this one will be compared to.</param>
        /// <returns>True if the GraphicsCard object is equal to this, false otherwise.</returns>
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

        /// <summary>
        /// Generates a hash code for this object using the Manufacturer and Model properties.
        /// </summary>
        /// <returns>The hash code for this object.</returns>
        public override int GetHashCode()
        {
            var hashCode = -1606514614;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Manufacturer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }
    }
}