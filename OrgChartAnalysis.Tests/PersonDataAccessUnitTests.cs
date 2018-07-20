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
using Moq;

namespace OrgChartAnalysis.Tests
{
    [TestClass]
    public class PersonDataAccessUnitTests
    {
        private PersonDataAccess _personData;

        public PersonDataAccessUnitTests()
        {
            _personData = new PersonDataAccess();


        }

        #region Tests for GetPersonById
        [TestMethod]
        public void ShouldReturnCorrectPersonWhenValidPersonIdisPassed()
        {

            var person = _personData.GetPersonById(1);


            Assert.IsNotNull(person);
            Assert.IsInstanceOfType(person, typeof(Person));
            
            // Assert.AreEqual(4, contentResult.Content);
            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("CEO", person.Title);
            Assert.AreEqual("Winfred", person.GivenName);
            Assert.AreEqual("Fetzer", person.FamilyName);
            Assert.AreEqual(Gender.Unspecified,person.Gender );
            Assert.AreEqual(DateTime.Parse("1927-01-29"), person.DateOfBirth);


        }


        [TestMethod]
        public void ShouldReturnNullWhenNullPersonIdisPassed()
        {

            var person = _personData.GetPersonById(null);
            Assert.IsNull(person);

        }

        [TestMethod]
        public void ShouldReturnNullWhenNonExistantPositivePersonIdisPassed()
        {

            var person = _personData.GetPersonById(100);
            Assert.IsNull(person);

        }

        [TestMethod]
        public void ShouldReturnNullWhenNonExistantNegativePersonIdisPassed()
        {

            var person = _personData.GetPersonById(-1);
            Assert.IsNull(person);

        }
        #endregion


        #region GetOrgChart Tests

        [TestMethod]
        public void GetOrgChartForExistingPersonWithMOQ()
        {
            Mock<PersonDataAccess> mockPersonDataAccess = new Mock<PersonDataAccess>();
            UserController _controller = new UserController(mockPersonDataAccess.Object);

            var orgChart = new OrgChart();
            int depth;
            mockPersonDataAccess.Setup(i => i.GetOrgChart(1, out depth)).Returns(orgChart);

            var orgChartFromController = _controller.GetOrgChart(1) as JsonResult<OrgChart>;
            Assert.AreEqual(orgChart, orgChartFromController.Content);
        }

        [TestMethod]
        public void ShouldReturnCorrectOrgChartWhenValidPersonIdisPassed()
        {
            int depth = 0;
            var orgChart = _personData.GetOrgChart(9,out depth);


            Assert.IsNotNull(orgChart);
            Assert.IsInstanceOfType(orgChart, typeof(OrgChart));
            Assert.AreEqual("Norah Maslowski(Tech Manager)", orgChart.Name);
            Assert.IsNotNull(orgChart.Subordinates);
            Assert.AreEqual(2, orgChart.Subordinates.Count());
            Assert.AreEqual("Rich Vermeulen(Trainer Lead)", orgChart.Subordinates[0].Name);
            Assert.AreEqual("Santo Knupp(HR Manager)", orgChart.Subordinates[1].Name);
            Assert.IsNotNull(orgChart.Subordinates[0].Subordinates);
            Assert.IsNotNull(orgChart.Subordinates[1].Subordinates);
            Assert.AreEqual(2, orgChart.Subordinates[0].Subordinates.Count());
            Assert.AreEqual(1, orgChart.Subordinates[1].Subordinates.Count());
            Assert.AreEqual("Jazmin Grooms(Trainer)", orgChart.Subordinates[0].Subordinates[0].Name);
            Assert.AreEqual("Eliza Harshaw(Trainer)", orgChart.Subordinates[0].Subordinates[1].Name);
            Assert.AreEqual("Annelle Cheeks(Recruiter)", orgChart.Subordinates[1].Subordinates[0].Name);
            Assert.AreEqual(2, depth);

        }

        [TestMethod]
        public void ShouldReturnNullWhenInValidPositivePersonIdisPassed()
        {
            int depth = 0;
            var orgChart = _personData.GetOrgChart(50, out depth);
            Assert.IsNull(orgChart);
            Assert.AreEqual(0, depth);

        }

        [TestMethod]
        public void ShouldReturnNullWhenInValidNegativePersonIdisPassed()
        {
            int depth = 0;
            var orgChart = _personData.GetOrgChart(-1, out depth);
            Assert.IsNull(orgChart);
            Assert.AreEqual(0, depth);

        }

        #endregion


    }
}