using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QaFullStack.Model
{
    public class Booking
    {
        [Key]
        [Required]
        public int BOOKING_ID { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [ForeignKey("BUYER_ID")]
        [Required]
        public int? BUYER_ID { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        [ForeignKey("PROPERTY_ID")]
        public int? PROPERTY_ID { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public DateTime? TIME { get; set; }
        
    }
}
