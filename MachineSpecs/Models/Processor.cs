using System.Collections.Generic;

namespace MachineSpecs.Models
{
    public class Processor
    {
        public int ProcessorID { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// Determines whether this processor is equal to another. Two processors are deemed
        /// equal if they both have the same manufacturer and model - in addition to both
        /// being of type Processor.
        /// </summary>
        /// <param name="obj">The other domain object to compare this one to.</param>
        /// <returns>True if both processors are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Processor)
            {
                Processor that = (Processor)obj;
                return this.Manufacturer.Equals(that.Manufacturer) && this.Model.Equals(that.Model);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Generates a hash code for this object, using the model and manufacturer properties.
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
