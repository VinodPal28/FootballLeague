using FootballLeague.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Services
{
    public interface ITeamService
    {
        List<TeamResource> getTeamsDetails();
        bool isAddTeams(TeamResource model);
        bool isUpdated(TeamResource model);
        bool isDeleted(TeamResource model);
    }
}
