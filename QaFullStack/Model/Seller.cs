using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QaFullStack.Model
{
    public class Seller
    {
        [Key]
        [Column("SELLER_ID")]
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string? FIRST_NAME { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string? SURNAME { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string? ADDRESS { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string? POSTCODE { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string? PHONE { get; set; }
    }
}
