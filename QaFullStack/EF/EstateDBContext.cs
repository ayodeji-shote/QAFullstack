// https://www.youtube.com/watch?v=NemyDIUcC64&list=PLjC4UKOOcfDSA06HsjJK4ZBr1tnPaOOpq youtube video that was helping
using Microsoft.EntityFrameworkCore;
using QaFullStack.Model;
namespace QaFullStack.EF

{
	public class EstateDBContext : DbContext
	{
		public EstateDBContext()
		{
		}
		public EstateDBContext(DbContextOptions<EstateDBContext> options) : base(options)
		{
		}
		public DbSet<Property> Properties { get; set; }
		public DbSet<Seller> Sellers { get; set; }
		public DbSet<Buyer> Buyers { get; set; }
		public DbSet<Booking> Bookings { get; set; }
	}
}
