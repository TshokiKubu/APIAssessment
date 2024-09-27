namespace APIAssessment.Models
{
    public class PlayerAccount
    {
        public Guid AccountId { get; set; }
        public string? Username { get; set; }

        // Navigation properties
        public ICollection<PlayerCasinoWager> PlayerCasinoWagers { get; set; } = new List<PlayerCasinoWager>();
    }
}
