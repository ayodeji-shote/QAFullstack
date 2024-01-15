﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaFullStack.Model
{
    public class Buyer
    {
        [Key]
        [Column("BUYER_ID")]
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