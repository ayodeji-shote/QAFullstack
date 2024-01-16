using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QaFullStack.Model
{
    [Table("PROPERTY")]
    public class Property
    {
        [Key]
        [Column("PROPERTY_ID")]
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string? ADDRESS { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string? POSTCODE { get; set; }
        [Column(TypeName = "nvarchar(9)")]
        [Required]
        public string? TYPE { get; set; }
        [Required]
        public int? NUMBER_OF_BEDROOMS { get; set; }
        [Required]
        public int? NUMBER_OF_BATHROOMS { get; set; }
        [Required]
        public bool? GARDEN { get; set; }
        [Required]
        public decimal? PRICE { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string? STATUS { get; set; }
        [Required]
        [ForeignKey("SELLER_ID")]
        public int? SELLER_ID { get; set; }
        [Required]
        [ForeignKey("BUYER_ID")]
        public int? BUYER_ID { get; set; }

    }
}