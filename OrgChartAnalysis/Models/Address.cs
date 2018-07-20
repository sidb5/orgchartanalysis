using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgChartAnalysis.Models
{
    /// <summary>
    /// Class to describe the address of a person defined in the data access layer
    /// This is done to abstract any change in how Web API serves the results 
    /// from the data access layer thus keeping it isolated from impact of changes
    /// </summary>
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

}