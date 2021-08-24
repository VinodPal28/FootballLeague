using FootballLeague.Data.DomainContext;
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
    [RoutePrefix("api/Matches")]
    public class MatchesController : ApiController
    {
        private readonly IMatchService _matchService;
        private readonly IFootballLeagueDomainContext _footballLeagueDomainContext;
        public MatchesController(IMatchService matchService, IFootballLeagueDomainContext footballLeagueDomainContext)
        {
            _matchService = matchService;
            _footballLeagueDomainContext = footballLeagueDomainContext;
        }

        [HttpPost]
        [Route("addMatchesName", Name = "addMatchesName")]
        public HttpResponseMessage addMatchesName(MatchesResource matchDTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            bool result = _matchService.isAddMatchesdetails(matchDTO);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [Route("getTeamsPlayedMatches", Name = "getTeamsPlayedMatches")]
        public HttpResponseMessage getTeamsPlayedMatches()
        {            
            var result = _matchService.getTeamsRanking();
            if (result != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }


    }
}
