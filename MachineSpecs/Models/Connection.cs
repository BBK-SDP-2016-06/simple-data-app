namespace MachineSpecs.Models
{
    public class Connection
    {
        public int ConnectionID { get; set; }
        public Computer Computer { get; set; }
        public Port Port { get; set; }
        public int Quantity { get; set; }
    }
}