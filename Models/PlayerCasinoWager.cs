using APIAssessment.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIAssessment.Models
{
    public class PlayerCasinoWager
    {
        public Guid WagerId { get; set; }

        [ForeignKey("PlayerAccount")]
        public Guid AccountId { get; set; } // Foreign key to PlayerAccount
        //public string? Username { get; set; }       
        public string Theme { get; set; }
        public string GameName { get; set; }
        public string Provider { get; set; }
        public decimal Amount { get; set; }      
        public WagerStatus Status { get; set; } 
        public DateTime CreatedDateTime { get; set; }
        public Guid TransactionId { get; set; }
        public Guid BrandId { get; set; }       
        public Guid ExternalReferenceId { get; set; }
        public Guid TransactionTypeId { get; set; }     
        public int NumberOfBets { get; set; }
        public string? SessionData { get; set; }
        public string CountryCode { get; set; }
        public long Duration { get; set; }
        public virtual PlayerAccount PlayerAccount { get; set; }

    }
}
