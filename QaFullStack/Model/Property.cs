using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QaFullStack.Model
{
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
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public int? NUMBER_OF_BEDROOMS { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public int? NUMBER_OF_BATHROOMS { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public int? GARDEN { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public decimal? PRICE { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public decimal? STATUS { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        [ForeignKey("SELLER_ID")]
        public decimal? SELLER_ID { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        [ForeignKey("BUYER_ID")]
        public decimal? BUYER_ID { get; set; }

    }
}
