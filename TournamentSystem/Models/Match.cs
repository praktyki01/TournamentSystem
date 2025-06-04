namespace TournamentSystem.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public int TournamentId { get; set; }
        public DateTime MatchDate { get; set; }               
        
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
        public bool IsFinished {  get; set; }

        public Tournament Tournament { get; set; }
        public int Team1Id { get; set; }
        public Team? Team1 { get; set; }

        public int Team2Id { get; set; }
        public Team? Team2 { get; set; }

        public ICollection<MatchDetail> MatchDetails { get; set; }

    }
}
