using System.Collections.Generic;

namespace MachineSpecs.Models
{
    public class Port
    {
        public int PortID { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Determines whether this port is equal to another. Two ports are deemed
        /// equal if they both have the same name - in addition to both being of type Port.
        /// </summary>
        /// <param name="obj">The other domain object to compare this one to.</param>
        /// <returns>True if both ports are equal, false otherwise.</returns>
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

        /// <summary>
        /// Generates a hash code for this object, using the name property.
        /// </summary>
        /// <returns>The hash code for this object.</returns>
        public override int GetHashCode()
        {
            var hashCode = -922353319;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}