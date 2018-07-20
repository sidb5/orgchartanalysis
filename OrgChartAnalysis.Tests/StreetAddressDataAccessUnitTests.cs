using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrgChartAnalysis.Controllers;
using OrgChartAnalysis.Models;
using System.Web.Http.Results;
using System.Web.Http;
using Newtonsoft.Json;
using DataAccess.BO;
using DataAccess;

namespace OrgChartAnalysis.Tests
{
    [TestClass]
    public class StreeAddressDataAccessUnitTests
    {
        private StreetStreetAddressData _streetAddressData;

        public StreeAddressDataAccessUnitTests()
        {
            _streetAddressData = new StreetStreetAddressData();


        }

        #region Tests for GetStreetAddressByPersonId
        [TestMethod]
        public void ShouldReturnCorrectStreetAddressListWhenValidPersonIdisPassed()
        {

            var streetAddresses = _streetAddressData.GetStreetAddressByPersonId(1);


            Assert.IsNotNull(streetAddresses);
            Assert.IsInstanceOfType(streetAddresses, typeof(List<StreetAddress>));
            Assert.AreEqual(3, streetAddresses.Count());
            List<StreetAddress> streetAddressList = streetAddresses.ToList();
            Assert.AreEqual(1, streetAddressList[0].PersonId);
            Assert.AreEqual(1, streetAddressList[0].Id);
            Assert.AreEqual(2, streetAddressList[1].Id);
            Assert.AreEqual(3, streetAddressList[2].Id);
            Assert.AreEqual("07026", streetAddressList[0].Zip);
            Assert.AreEqual("54729", streetAddressList[1].Zip);
            Assert.AreEqual("38106", streetAddressList[2].Zip);

            

        }

        [TestMethod]
        public void ShouldReturnEmptyListWhenNonExistantPositivePersonIdisPassed()
        {

            var streetAddresses = _streetAddressData.GetStreetAddressByPersonId(100);
            Assert.IsNotNull(streetAddresses);
            Assert.AreEqual(0, streetAddresses.Count());

        }

        [TestMethod]
        public void ShouldReturnEmptyListWhenNonExistantNegativePersonIdisPassed()
        {

            var streetAddresses = _streetAddressData.GetStreetAddressByPersonId(-1);
            Assert.IsNotNull(streetAddresses);
            Assert.AreEqual(0, streetAddresses.Count());

        }
        #endregion


 


    }
}