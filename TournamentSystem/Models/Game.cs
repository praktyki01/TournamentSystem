namespace TournamentSystem.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Tournament> Tournaments { get; set; }
    }
}
