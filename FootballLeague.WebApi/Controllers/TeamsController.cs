using FootballLeague.Data.Services;
using FootballLeague.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballLeague.WebApi.Controllers
{
    [RoutePrefix("api/Team")]
    public class TeamsController : ApiController
    {

        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]      
        [Route("getTeamsDetails", Name = "getTeamsDetails")]
        public HttpResponseMessage getTeamsDetails()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var teamDetails = _teamService.getTeamsDetails();
            if (teamDetails != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, teamDetails, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            
        }

        [HttpPost]
        [Route("addTeam", Name = "addTeam")]
        public HttpResponseMessage addTeam(TeamResource teamDTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            bool result = _teamService.isAddTeams(teamDTO);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]        
        [Route("updateTeamNameById", Name = "updateTeamNameById")]
        public HttpResponseMessage updateTeamNameById(TeamResource teamDTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var result = _teamService.isUpdated(teamDTO);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [Route("deleteTeamNameById", Name = "deleteTeamNameById")]
        public HttpResponseMessage deleteTeamNameById(TeamResource teamDTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var result = _teamService.isDeleted(teamDTO);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}
