using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QaFullStack.Model
{
	[Table("SELLER")]
	public class Seller
	{
		[Key]
		[Column("SELLER_ID")]
		[Required]
		public int Id { get; set; }

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
