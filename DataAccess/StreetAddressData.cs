using System.Collections.Generic;
using System.Linq;
using DataAccess.BO;

namespace DataAccess
{
    public class StreetStreetAddressData
    {
        #region
        private static readonly List<StreetAddress> Addresses = new List<StreetAddress>
        {
            new StreetAddress{ Id = 1, PersonId = 1, Street = "62 Durham Court", City = "Garfield", State="NJ", Zip ="07026" },
            new StreetAddress{ Id = 2, PersonId = 1, Street = "179 Cambridge Court", City = "Chippewa Falls", State="WI", Zip ="54729" },
            new StreetAddress{ Id = 3, PersonId = 1, Street = "573 Route 5", City = "Memphis", State="TN", Zip ="38106" },
            new StreetAddress{ Id = 4, PersonId = 2, Street = "173 Monroe Street", City = "Powhatan", State="VA", Zip ="23139" },
            new StreetAddress{ Id = 5, PersonId = 5, Street = "47 Brookside Drive", City = "Westport", State="CT", Zip ="06880" },
            new StreetAddress{ Id = 6, PersonId = 6, Street = "628 Creekside Drive", City = "Mankato", State="MN", Zip ="56001" },
            new StreetAddress{ Id = 7, PersonId = 7, Street = "581 Lexington Court", City = "Sykesville", State="MD", Zip ="21784" },
            new StreetAddress{ Id = 8, PersonId = 11, Street = "860 Deerfield Drive", City = "Muskego", State="WI", Zip ="53150" },
            new StreetAddress{ Id = 9, PersonId = 13, Street = "189 Elizabeth Street", City = "Ashtabula", State="OH", Zip ="44004" },
            new StreetAddress{ Id = 10, PersonId = 13, Street = "945 Rosewood Drive", City = "Fairfield", State="CT", Zip ="06824" },
            new StreetAddress{ Id = 11, PersonId = 13, Street = "958 Hill Street", City = "Roy", State="UT", Zip ="84067" },
            new StreetAddress{ Id = 12, PersonId = 14, Street = "687 Westminster Drive", City = "Desoto", State="TX", Zip ="75115" },
            new StreetAddress{ Id = 13, PersonId = 15, Street = "530 Forest Drive", City = "Mc Lean", State="VA", Zip ="22101" },
            new StreetAddress{ Id = 14, PersonId = 17, Street = "766 Cambridge Road", City = "Portage", State="IN", Zip ="46368" },
            new StreetAddress{ Id = 15, PersonId = 17, Street = "788 Ivy Court", City = "Sunnyside", State="NY", Zip ="11104" },
            new StreetAddress{ Id = 16, PersonId = 19, Street = "750 Ashley Court", City = "Selden", State="NY", Zip ="11784" },
            new StreetAddress{ Id = 17, PersonId = 20, Street = "612 Harrison Street", City = "Winter Haven", State="FL", Zip ="33880" },
            new StreetAddress{ Id = 18, PersonId = 22, Street = "780 Locust Lane", City = "Saint Petersburg", State="FL", Zip ="33702" },
            new StreetAddress{ Id = 19, PersonId = 22, Street = "896 Chestnut Street", City = "Tallahassee", State="FL", Zip ="32303" },
            new StreetAddress{ Id = 20, PersonId = 24, Street = "321 Roosevelt Avenue", City = "Dunedin", State="FL", Zip ="34698" },
        };
        #endregion

        //TODO:  Implement necessary methods to accomplish the tasks in the README
        #region DataAccessRepository

        // Basic CRUD operations
        public IEnumerable<StreetAddress> GetStreetAddressByPersonId(int personId)
        {
            return Addresses.FindAll(x => x.PersonId == personId);
        }
        #endregion
    }
}