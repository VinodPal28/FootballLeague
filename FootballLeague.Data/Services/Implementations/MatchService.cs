using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballLeague.Resources.Resources;
using FootballLeague.Data.DomainContext;
using FootballLeague.EntityFramework.Entities;
using System.Data.SqlClient;
using System.Data;


namespace FootballLeague.Data.Services.Implementations
{

    public class MatchService : IMatchService
    {
        
        private readonly IFootballLeagueDomainContext _footballLeagueDomainContext;

        public MatchService(IFootballLeagueDomainContext footballLeagueDomainContext)
        {
            _footballLeagueDomainContext = footballLeagueDomainContext;
        }
        public bool isAddMatchesdetails(MatchesResource matchDTO)
        {
            var entity = new Matches
            {
                MatchNo = matchDTO.MatchNo,
                Team1 = matchDTO.Team1,
                Team2 = matchDTO.Team2,
                Score1 = matchDTO.Score1,
                Score2 = matchDTO.Score2,
                createdDate = DateTime.Now,
                updatedDate = DateTime.Now
            };
            _footballLeagueDomainContext.Add(entity);
            if (_footballLeagueDomainContext.SaveChanges() == 1) return true;
            return false;
        }

       

        public List<TeamsMatchesResource> getTeamsRanking()
        {
            var connection = new SqlConnection("Data Source=VINOD;Initial Catalog=FootballLeague;Integrated Security=SSPI;");          
            string procedureName = "[dbo].[SP_GetTeamsRanking]";
            var result = new List<TeamsMatchesResource>();
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;                
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string TeamName = reader[0].ToString();
                        int GP = Convert.ToInt32(reader[1].ToString());
                        int GF = Convert.ToInt32(reader[2].ToString());
                        int GA = Convert.ToInt32(reader[3].ToString());
                        int W = Convert.ToInt32(reader[4].ToString());
                        int L = Convert.ToInt32(reader[5].ToString());
                        int D = Convert.ToInt32(reader[6].ToString());
                        int Pts = Convert.ToInt32(reader[7].ToString());
                       

                        TeamsMatchesResource teamsMatches = new TeamsMatchesResource()
                        {
                            TeamName = TeamName,
                            GP = GP,
                            GF = GF,
                            GA = GA,
                            W=W,
                            L=L,
                            D=D,
                            Pts=Pts
                        };
                        result.Add(teamsMatches);
                    }
                }
            }
            return result;          
        }
    }
}
