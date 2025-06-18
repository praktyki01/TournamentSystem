using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationEndDate { get; set; }
        [Display(Name="Game")]
        public int? GameId { get; set; }
        public Game? Game { get; set; } = null!;
        public ICollection<Match> Matches { get; set; }
        public ICollection<TeamTournament> TeamTournaments { get; set; }
    }
}
