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
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Host.HttpListener;
using System.Net.Http;
using System.Threading;
using Microsoft.Owin.Testing;
using Owin;
using System.Web.Http.Dispatcher;
using OrgChartAnalysis.App_Start;
using Newtonsoft.Json.Linq;
using System.Net;

namespace OrgChartAnalysis.Tests
{

    /// <summary>
    /// These integration tests use OWIN to launch a self hosted HTTP server.
    /// The server gets hosted locally on port number 12345. Http Web API requests are sent
    /// to this server and its response is analysed to check for expected results
    /// </summary>

    

    [TestClass]
    public class IntegrationTests
    {

       
        private static IDisposable _webApp;
        private static string baseAddress = "http://localhost:12345/";

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
             _webApp = WebApp.Start<Startup>(url: baseAddress);
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            _webApp.Dispose();
        }
        

        [TestMethod]
        public void IntegrationTest_ShouldReturnCorrectOrgChartDepth()
        {
 
            HttpClient client = new HttpClient();
            var response = client.GetAsync(baseAddress + "api/v1/user/GetOrgChartDepth").Result;
            Assert.AreEqual("4", response.Content.ReadAsStringAsync().Result);
        }

        [TestMethod]
        public void IntegrationTest_ShouldReturnCorrectJSONFormatDetailsOfPersonForValidPersonId()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(baseAddress + "api/v1/user/GetPersonWithAddress?personId=1").Result;
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string returnVal = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(returnVal);
            var personDetails = JsonConvert.DeserializeObject<User>(returnVal);
            Assert.IsNotNull(personDetails);
            Assert.AreEqual(3, personDetails.Addresses.Count());
            Assert.AreEqual("Winfred", personDetails.FirstName);

        }


        [TestMethod]
        public void IntegrationTest_ShouldReturnNotFoundStatusForInvalidPositivePersonIdForGetPersonWithAddressOperation()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(baseAddress + "api/v1/user/GetPersonWithAddress?personId=100").Result;
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }



        [TestMethod]
        public void IntegrationTest_ShouldReturnNotFoundStatusForInvalidNegativePersonIdForGetPersonWithAddressOperation()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(baseAddress + "api/v1/user/GetPersonWithAddress?personId=-1").Result;
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }


        [TestMethod]
        public void IntegrationTest_ShouldReturnCorrectJSONFormatOrgChartReportingToSpecifiedPersonForValidPersonId()
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync(baseAddress + "api/v1/user/GetOrgChart?personId=3").Result;
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string returnVal = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(returnVal);
            var orgChart = JsonConvert.DeserializeObject<OrgChart>(returnVal);
            Assert.IsNotNull(orgChart);
            Assert.AreEqual(3, orgChart.Subordinates.Count());
            Assert.AreEqual("Reinaldo Nisbet(VP of Technology)", orgChart.Name);
        }

        [TestMethod]
        public void IntegrationTest_ShouldReturnNotFoundStatusForInvalidNegativePersonIdForGetOrgChartOperation()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(baseAddress + "api/v1/user/GetOrgChart?personId=-1").Result;
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void IntegrationTest_ShouldReturnNotFoundStatusForInvalidPositivePersonIdForGetOrgChartOperation()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(baseAddress + "api/v1/user/GetOrgChart?personId=300").Result;
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}

