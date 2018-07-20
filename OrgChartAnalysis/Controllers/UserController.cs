using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using DataAccess;
using DataAccess.BO;

namespace OrgChartAnalysis.Controllers
{
    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
        private readonly PersonDataAccess _personDataAccess;
        private readonly StreetStreetAddressData _streetAddressData;
        private readonly Models.ModelFactory _factory;
        //TODO:  Implement calls according to README
 
        public UserController()
        {
            _personDataAccess = new PersonDataAccess();
            _streetAddressData = new StreetStreetAddressData();
            _factory = new Models.ModelFactory();
        }

        // For Unit testing purposes.
        public UserController(PersonDataAccess personDataAccess)
        {
            _personDataAccess = personDataAccess;
            _streetAddressData = new StreetStreetAddressData();
            _factory = new Models.ModelFactory();
        }


        /// <summary>
        /// Web API method that serves up information describing a person and all his/her addresses in JSON format
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PersonWithAddress/{personId:int}")]
        public IHttpActionResult GetPersonWithAddress(int personId)
        {
            try
            {
                string bossName = string.Empty;
                var person = _personDataAccess.GetPersonById(personId);
                if (person != null)
                {
                    var boss = _personDataAccess.GetPersonById(person.BossId);
                    bossName = boss != null ? boss.GivenName + boss.FamilyName : string.Empty;
                    var result = _factory.Create(person, bossName, _streetAddressData.GetStreetAddressByPersonId(personId).ToList());
                    return Json(result);
                }

                return Content(HttpStatusCode.NotFound, "The person could not be found");
            }
            catch (Exception ex)
            {
                //We can add some logging here in production environment
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Web API method that returns the organization hierarchy below a specified employee in JSON format
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("orgchart/{personId:int}")]
        public IHttpActionResult GetOrgChart(int personId)
        {
            try
            {
                int orgDepth = 0;
                OrgChart orgChart = _personDataAccess.GetOrgChart(personId, out orgDepth);
                if(orgChart == null)
                    return Content(HttpStatusCode.NotFound, "The Org Chart could not be found");
                return Json(orgChart);
                
            }
            catch (Exception ex)
            {
                //We can add some logging here in production environment
                return InternalServerError(ex);
            }

        
        }

        /// <summary>
        /// Web API methos that return the depth of the organization structure in JSON format
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("orgchartdepth")]
        public IHttpActionResult GetOrgChartDepth()
        {
            try
            {
                int depth = 0;
                OrgChart orgChart = _personDataAccess.GetOrgChart(1, out depth);
                if (orgChart == null)
                    return Content(HttpStatusCode.NotFound,"The Org Chart depth could not be found");

                //return Json(new { Depth = depth });
                //return Json(depth);
                return Content(HttpStatusCode.OK, depth);
            }
            catch (Exception ex)
            {
                //We can add some logging here in production environment
                return InternalServerError(ex);
            }


        }



    }
}
