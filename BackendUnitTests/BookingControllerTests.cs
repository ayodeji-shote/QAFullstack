using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QaFullStack.Controllers;
using QaFullStack.EF;
using QaFullStack.Model;

namespace BackendUnitTests
{
	/// <summary>
	/// Tests for the <see cref="BookingController"/> class.
	/// </summary>
	public class BookingControllerTests
	{
		/// <summary>
		/// Get service provider for the controller
		/// https://stackoverflow.com/questions/51119911/how-to-unit-test-a-controller-with-dbcontext
		/// creates the database context and the controller for tests
		/// can use the reral database if needed
		/// </summary>
		/// <returns></returns>
		private IServiceProvider GetServiceceProvider()
		{
			//create the interface object
			ServiceCollection services = new ServiceCollection();

			//create the in-memory database
			//services.AddDbContext<EstateDBContext>(options => options.UseInMemoryDatabase("MockData1"));
			services.AddDbContext<EstateDBContext>(options =>
			{
				options.UseInMemoryDatabase("MockData2");
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);//remove tracking in EF
			});
			//options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EstateAgentAppCon2;Trusted_Connection=True;MultipleActiveResultSets=true"));

			//add the controller
			services.AddScoped<BookingController>();

			//return the EstateDBContext object in the scope of BuyersController 
			return services.BuildServiceProvider();
		}

		[Fact]
		public void GetAllBookings_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the booking object for comaprisons
			var booking = new Booking { Id = 1, BUYER_ID = 1, PROPERTY_ID = 1, TIME = new DateTime(2024, 01, 10) };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				context.Bookings.Add(new Booking { Id = 1, BUYER_ID = 1, PROPERTY_ID = 1, TIME = new DateTime(2024, 01, 10) });
				context.Bookings.Add(new Booking { Id = 2, BUYER_ID = 2, PROPERTY_ID = 2, TIME = new DateTime(2024, 01, 11) });
				context.Bookings.Add(new Booking { Id = 3, BUYER_ID = 3, PROPERTY_ID = 3, TIME = new DateTime(2024, 01, 12) });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new BookingController(context);

				//Act
				//downnload all sellers from the datbase
				var result = controller.GetBookings();

				//Assert
				Assert.NotNull(result);
				Assert.IsType<ActionResult<IEnumerable<Booking>>>(result);
				Assert.Equal(3, result.Value.Count());
				Assert.Equal(booking.Id, result.Value.FirstOrDefault().Id);
				Assert.Equal(booking.BUYER_ID, result.Value.FirstOrDefault().BUYER_ID);
				Assert.Equal(booking.PROPERTY_ID, result.Value.FirstOrDefault().PROPERTY_ID);
				Assert.Equal(booking.TIME, result.Value.FirstOrDefault().TIME);
				Assert.Equal(1, result.Value.FirstOrDefault().Id);
			}
		}

		[Fact]
		private void GetBookingById_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the booking object for comaprisons
			var booking = new Booking { Id = 1, BUYER_ID = 1, PROPERTY_ID = 1, TIME = new DateTime(2024, 01, 10) };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				context.Bookings.Add(new Booking { Id = 1, BUYER_ID = 1, PROPERTY_ID = 1, TIME = new DateTime(2024, 01, 10) });
				context.Bookings.Add(new Booking { Id = 2, BUYER_ID = 2, PROPERTY_ID = 2, TIME = new DateTime(2024, 01, 11) });
				context.Bookings.Add(new Booking { Id = 3, BUYER_ID = 3, PROPERTY_ID = 3, TIME = new DateTime(2024, 01, 12) });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new BookingController(context);

				//Act
				//downnload all sellers from the datbase
				var result = controller.GetBooking(1);

				//Assert
				Assert.NotNull(result);
				Assert.IsType<ActionResult<Booking>>(result);
				Assert.Equal(booking.Id, result.Value.Id);
				Assert.Equal(booking.BUYER_ID, result.Value.BUYER_ID);
				Assert.Equal(booking.PROPERTY_ID, result.Value.PROPERTY_ID);
				Assert.Equal(booking.TIME, result.Value.TIME);
				Assert.Equal(1, result.Value.Id);
			}
		}

		[Fact]
		private void CreateBooking_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the booking object for comaprisons
			var booking = new Booking { Id = 1, BUYER_ID = 1, PROPERTY_ID = 1, TIME = new DateTime(2024, 01, 10) };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				//context.Bookings.Add(new Booking { Id = 1, BUYER_ID = 1, PROPERTY_ID = 1, TIME = new DateTime(2024, 01, 10) });
				context.Bookings.Add(new Booking { Id = 2, BUYER_ID = 2, PROPERTY_ID = 2, TIME = new DateTime(2024, 01, 11) });
				context.Bookings.Add(new Booking { Id = 3, BUYER_ID = 3, PROPERTY_ID = 3, TIME = new DateTime(2024, 01, 12) });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new BookingController(context);

				//Act
				//create a new booking object in the database
				var result = controller.CreateBooking(booking);

				//create the booking object for comaprisons
				var comparison = controller.GetBooking(1);

				//Assert
				Assert.NotNull(result);
				Assert.IsType<ActionResult<Booking>>(result);
				Assert.Equal(booking.Id, comparison.Value.Id);
				Assert.Equal(booking.BUYER_ID, comparison.Value.BUYER_ID);
				Assert.Equal(booking.PROPERTY_ID, comparison.Value.PROPERTY_ID);
				Assert.Equal(booking.TIME, comparison.Value.TIME);
			}
		}

		[Fact]
		private void UpdateBooking_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				context.Bookings.Add(new Booking { Id = 1, BUYER_ID = 1, PROPERTY_ID = 1, TIME = new DateTime(2024, 01, 10) });
				context.Bookings.Add(new Booking { Id = 2, BUYER_ID = 4, PROPERTY_ID = 4, TIME = new DateTime(2024, 01, 14) });
				context.Bookings.Add(new Booking { Id = 3, BUYER_ID = 3, PROPERTY_ID = 3, TIME = new DateTime(2024, 01, 12) });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new BookingController(context);

				//create the booking object for comaprisons
				var booking = controller.GetBooking(2);
				booking.Value.BUYER_ID = 2;
				booking.Value.PROPERTY_ID = 2;
				booking.Value.TIME = new DateTime(2024, 01, 11);

				//Act

				//updtae the row in the DB
				controller.UpdateBooking(booking.Value);


				//download object for comaprison
				var comparison = controller.GetBooking(2);

				//Assert
				Assert.NotNull(comparison);
				Assert.IsType<ActionResult<Booking>>(comparison);
				Assert.Equal(booking.Value.Id, comparison.Value.Id);
				Assert.Equal(booking.Value.BUYER_ID, comparison.Value.BUYER_ID);
				Assert.Equal(booking.Value.PROPERTY_ID, comparison.Value.PROPERTY_ID);
				Assert.Equal(booking.Value.TIME, comparison.Value.TIME);
			}
		}

		[Fact]
		private void DeleteBooking_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				context.Bookings.Add(new Booking { Id = 1, BUYER_ID = 1, PROPERTY_ID = 1, TIME = new DateTime(2024, 01, 10) });
				context.Bookings.Add(new Booking { Id = 2, BUYER_ID = 4, PROPERTY_ID = 4, TIME = new DateTime(2024, 01, 14) });
				context.Bookings.Add(new Booking { Id = 3, BUYER_ID = 3, PROPERTY_ID = 3, TIME = new DateTime(2024, 01, 12) });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new BookingController(context);

				//Act
				//remove the row in the DB
				controller.DeleteBooking(2);

				//download the objects from the DB
				List<Booking> comparison = controller.GetBookings().Value.ToList();

				//Assert
				Assert.NotNull(comparison);
				Assert.Equal(2, comparison.Count());
				Assert.Equal(1, comparison[0].Id);
				Assert.Equal(1, comparison[0].BUYER_ID);
				Assert.Equal(1, comparison[0].PROPERTY_ID);
				Assert.Equal(new DateTime(2024, 01, 10), comparison[0].TIME);
				Assert.Equal(3, comparison[1].Id);
				Assert.Equal(3, comparison[1].BUYER_ID);
				Assert.Equal(3, comparison[1].PROPERTY_ID);
				Assert.Equal(new DateTime(2024, 01, 12), comparison[1].TIME);
			}
		}
	}
}
