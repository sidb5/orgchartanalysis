using DataAccess.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace OrgChartAnalysis.Models
{
    //Note: Automapper can be used for mapping between the BO classes and the model classes but simplicity
    //I am not using the Automapper package.

    /// <summary>
    /// Model class representing the person in the data access layer.
    /// This is done to abstract any change in how Web API serves the results f
    /// from the data access layer thus keeping it isolated from impact of changes
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BossName { get; set; }
        public string Title { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }

        public  IEnumerable<Address> Addresses { get; set; }


    }

    

    


 


}