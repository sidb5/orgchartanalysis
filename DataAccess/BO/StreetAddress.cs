using System;

namespace DataAccess.BO
{
    public class StreetAddress
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}