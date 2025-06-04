namespace TournamentSystem.Models
{
    public class TeamTournament
    {
        public int TeamTournamentId { get; set; }                
        public DateTime RegistrationDate { get; set; }
        public bool Confirmed { get; set; }

        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public int TournamentId { get; set; }
        public Tournament? Tournament { get; set; }
    }
}
