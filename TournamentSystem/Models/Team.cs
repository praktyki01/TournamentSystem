using System.Numerics;

namespace TournamentSystem.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? TeamTag { get; set; }
        public string? LogoURL { get; set; }

        public ICollection<Player> Players { get; set; }
        public ICollection<Match> MatchTeam1 { get; set; }
        public ICollection<Match> MatchTeam2 { get; set; }
        public ICollection<TeamTournament> TeamTournaments { get; set; }
    }
}
