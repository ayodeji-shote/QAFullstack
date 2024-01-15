using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QaFullStack.Model
{
	[Table("BOOKING")]
	public class Booking
	{
		[Key]
		[Required]
		public int BOOKING_ID { get; set; }
		[Column(TypeName = "int")]
		[ForeignKey("BUYER_ID")]
		[Required]
		public int? BUYER_ID { get; set; }
		[Column(TypeName = "int")]
		[Required]
		[ForeignKey("PROPERTY_ID")]
		public int? PROPERTY_ID { get; set; }
		[Column(TypeName = "int")]
		[Required]
		public DateTime? TIME { get; set; }
		//[NotMapped]
		//[Column(TypeName = "datetime")]

	}
}
