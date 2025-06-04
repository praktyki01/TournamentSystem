namespace TournamentSystem.Models
{
    public class Tournament
    {
        public int TournamentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public int GameID { get; set; }

        public Game Game { get; set; }
        public ICollection<Match> Matches { get; set; }
        public ICollection<TeamTournament> TeamTournaments { get; set; }
    }
}
