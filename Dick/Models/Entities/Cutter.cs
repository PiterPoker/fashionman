using System.Collections.Generic;

namespace Dick.Models.Entities
{
    public class Cutter
    {
        public Cutter()
        {
            Order = new List<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<Order> Order { get; set; }
    }
}