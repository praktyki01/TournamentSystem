namespace TournamentSystem.Models
{
    public class TeamTournament
    {
        public int TeamTournamentID { get; set; }
        public int TeamID { get; set; }
        public int TournamentID { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Confirmed { get; set; }

        public Team Team { get; set; }
        public Tournament Tournament { get; set; }
    }
}
