
using QaFullStack.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaFullStack.Model
{
    [Table("BUYER")]
    public class Buyer : EntityBase
    {
        [Key]
        [Column("BUYER_ID")]
        public override int Id { get; set; }
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
