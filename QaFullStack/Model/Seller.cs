using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using QaFullStack.Repositories;

namespace QaFullStack.Model
{
	[Table("SELLER")]
	public class Seller : EntityBase
    {
		[Key]
		[Column("SELLER_ID")]
		[Required]
		public override int Id { get; set; }

		[Required]
		public string? FIRST_NAME { get; set; }

		[Required]
		public string? SURNAME { get; set; }

		[Required]
		public string? ADDRESS { get; set; }

		[Required]
		public string? POSTCODE { get; set; }

		[Required]
		public string? PHONE { get; set; }
	}
}
