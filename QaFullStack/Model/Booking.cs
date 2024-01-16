using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using QaFullStack.Repositories;

namespace QaFullStack.Model
{
	[Table("BOOKING")]
	public class Booking : EntityBase
    {
		[Key]
		[Required]
        [Column("BOOKING_ID")]
        public override int Id { get; set; }
		[ForeignKey("BUYER_ID")]
		[Required]
		public int? BUYER_ID { get; set; }

		[Required]
		[ForeignKey("PROPERTY_ID")]
		public int? PROPERTY_ID { get; set; }

		[Required]
		public DateTime? TIME { get; set; }
	}
}
