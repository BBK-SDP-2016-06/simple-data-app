namespace MachineSpecs.Models
{
    public class Connection
    {
        public int ConnectionID { get; set; }
        public int ComputerID { get; set; }
        public int PortID { get; set; }
        public int Quantity { get; set; }

        //Each connection contains a reference to its computer and the type of port
        public Computer Computer { get; set; }
        public Port Port { get; set; }
    }
}