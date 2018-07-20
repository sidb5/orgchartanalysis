using DataAccess.BO;
using OrgChartAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgChartAnalysis.Models { 

    /// <summary>
    /// Factory class to generate object of differnt kinds of models
    /// </summary>
    public class ModelFactory
    {
        /// <summary>
        /// Create model object for street address from street object from data access layer.
        /// We need to define and create this to meet the unique format requirements for results that WebAPI will
        /// send to the client.Also future request of changes in format of accepetance wont affect the business and data access layer
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public Address Create(StreetAddress address)
        {
            if (address != null)
            {
                return new Address
                {
                    Id = address.Id,
                    Street = address.Street,
                    City = address.City,
                    State = address.State,
                    Zip = address.Zip
                };
            }
            return null;

        }

        /// <summary>
        /// Convenience factory method to create list of street addresses from equivalent objects from data access layer
        /// </summary>
        /// <param name="streetAddresses"></param>
        /// <returns></returns>
        public List<Address> Create(List<StreetAddress> streetAddresses)
        {
            if (streetAddresses != null)
            {
                List<Address> addresses = new List<Address>();
                foreach (StreetAddress streetAddress in streetAddresses)
                {
                    addresses.Add(Create(streetAddress));
                }
                return addresses;
            }
            return null;
        
        }

        /// <summary>
        /// Create an model object describing a preson equivalent defined in the data access layer
        /// </summary>
        /// <param name="person"></param>
        /// <param name="bossName"></param>
        /// <param name="streetAddresses"></param>
        /// <returns></returns>
        public User Create(Person person, string bossName, List<StreetAddress> streetAddresses)
        {
            if (person != null)
            {
                return new User
                {
                    Id = person.Id,
                    FirstName = person.GivenName,
                    LastName = person.FamilyName,
                    BossName = bossName,
                    Title = person.Title,
                    DateOfBirth = person.DateOfBirth.ToShortDateString(),
                    Gender = person.Gender.ToString(),
                    Addresses = Create(streetAddresses)
                };
            }
            return null;

        }


    }
}