namespace TournamentSystem.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PlayerUserID { get; set; }
        public int TeamID { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Nickname { get; set; }
        public bool IsLeader { get; set; }

        public Team Team { get; set; }
    }
}
