using FootballLeague.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Services
{
    public interface IMatchService
    {
        bool isAddMatchesdetails(MatchesResource matchDTO);

        List<TeamsMatches> getTeamsRanking();
    }
}
