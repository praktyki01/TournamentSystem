using Microsoft.AspNetCore.Identity;

namespace TournamentSystem.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }      
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? Nickname { get; set; }
        public bool IsLeader { get; set; }
        
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public string PlayerUserId { get; set; }
        public IdentityUser? PlayerUser { get; set; }
    }
}
