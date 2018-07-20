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

namespace OrgChartAnalysis.Tests
{
    [TestClass]
    public class ControllerUnitTests
    {
        private UserController _controller;

        public ControllerUnitTests()
        {
            _controller = new UserController();
        }


        #region Org Chart Depth
        [TestMethod]
        public void ShouldReturnCorrectOrgChartDepthWhenGetOrgChartDepthIsInvoked()
        {

            // var actionResult = controller.GetOrgChartDepth() as JsonResult<int>;
            var actionResult = _controller.GetOrgChartDepth() as NegotiatedContentResult<int>;


            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.IsNotNull(actionResult.Content);
            // Assert.AreEqual(4, contentResult.Content);
            Assert.IsInstanceOfType(actionResult.Content, typeof(int));

            Assert.AreEqual(4, actionResult.Content);



        }
        #endregion


        #region Org Chart

        [TestMethod]
        public void ShouldReturnCorrectOrgChartWhenGetOrgChartWithValidPersonIDIsInvoked()
        {

            var actionResult = _controller.GetOrgChart(3) as JsonResult<OrgChart>;
            //var actionResult = controller.GetOrgChart(3) as NegotiatedContentResult<OrgChart>;
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Content);
            Assert.IsInstanceOfType(actionResult.Content, typeof(OrgChart));
            Assert.AreEqual("Reinaldo Nisbet(VP of Technology)", actionResult.Content.Name);

        }


        [TestMethod]
        public void ShouldReturnNotFoundStatusWhenGetOrgChartWithInvalidPositivePersonIdIsInvoked()
        {

            //var actionResult = controller.GetOrgChart(3) as JsonResult<OrgChart>;
            var actionResult = _controller.GetOrgChart(1000) as NegotiatedContentResult<string>;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, System.Net.HttpStatusCode.NotFound);
            Assert.IsNotNull(actionResult.Content);
            Assert.IsInstanceOfType(actionResult.Content, typeof(string));
            Assert.AreEqual("The Org Chart could not be found", actionResult.Content);

        }

        [TestMethod]
        public void ShouldReturnNotFoundStatusWhenGetOrgChartWithInvalidNegativePersonIdIsInvoked()
        {


        
            var actionResult = _controller.GetOrgChart(-1000) as NegotiatedContentResult<string>;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, System.Net.HttpStatusCode.NotFound);
            Assert.IsNotNull(actionResult.Content);
            Assert.IsInstanceOfType(actionResult.Content, typeof(string));
            Assert.AreEqual("The Org Chart could not be found", actionResult.Content);

        }


        #endregion

        #region Get Person Details with Address

        [TestMethod]
        public void ShouldReturnNotFoundStatusWhenGetPersonIsInvokedWithInvalidNegativePersonId()
        {

        
            var actionResult = _controller.GetPersonWithAddress(-1000) as NegotiatedContentResult<string>;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, System.Net.HttpStatusCode.NotFound);
            Assert.IsNotNull(actionResult.Content);
            Assert.IsInstanceOfType(actionResult.Content, typeof(string));
            Assert.AreEqual("The person could not be found", actionResult.Content);

        }

        [TestMethod]
        public void ShouldReturnNotFoundStatusWhenGetPersonIsInvokedWithInvalidPositivePersonId()
        {

        
            var actionResult = _controller.GetPersonWithAddress(1000) as NegotiatedContentResult<string>;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, System.Net.HttpStatusCode.NotFound);
            Assert.IsNotNull(actionResult.Content);
            Assert.IsInstanceOfType(actionResult.Content, typeof(string));
            Assert.AreEqual("The person could not be found", actionResult.Content);

        }

        [TestMethod]
        public void ShouldReturnValidPersonWhenGetPersonIsInvokedWithValidPersonId()
        {

            var actionResult = _controller.GetPersonWithAddress(1) as JsonResult<User>;
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Content);
            Assert.IsInstanceOfType(actionResult.Content, typeof(User));
            Assert.AreEqual(1, actionResult.Content.Id);
            Assert.AreEqual("Winfred", actionResult.Content.FirstName);
            Assert.AreEqual("CEO", actionResult.Content.Title);
            Assert.AreEqual(3, actionResult.Content.Addresses.Count());

        }

        [TestMethod]
        public void ShouldReturnCorrectAddresesForPeronWhenValidPersonIdIsSpecified()
        {

            var actionResult = _controller.GetPersonWithAddress(1) as JsonResult<User>;
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Content);
            Assert.IsInstanceOfType(actionResult.Content, typeof(User));
            Assert.AreEqual(1, actionResult.Content.Id);
            Assert.AreEqual(3, actionResult.Content.Addresses.Count());
            Assert.AreEqual(1, actionResult.Content.Addresses.ElementAt(0).Id);
            Assert.AreEqual("62 Durham Court", actionResult.Content.Addresses.ElementAt(0).Street);
            Assert.AreEqual("Garfield", actionResult.Content.Addresses.ElementAt(0).City);
            Assert.AreEqual("NJ", actionResult.Content.Addresses.ElementAt(0).State);
            Assert.AreEqual("07026", actionResult.Content.Addresses.ElementAt(0).Zip);

        }
        #endregion
    }
}