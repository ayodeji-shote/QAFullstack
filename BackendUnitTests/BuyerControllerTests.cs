using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QaFullStack.Controllers;
using QaFullStack.EF;
using QaFullStack.Model;

namespace BackendUnitTests
{
	/// <summary>
	/// Tests in the BuyerController class
	/// </summary>
	public class BuyerControllerTests
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
				options.UseInMemoryDatabase("MockData1");
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);//remove tracking in EF
			});
			//options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EstateAgentAppCon2;Trusted_Connection=True;MultipleActiveResultSets=true"));

			//add the controller
			services.AddScoped<BuyersController>();

			//return the EstateDBContext object in the scope of BuyersController 
			return services.BuildServiceProvider();
		}

		[Fact]
		public void GetAllBuyers_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the buyer object for comaprisons
			var buyer = new Buyer { Id = 1, FIRST_NAME = "Buyer1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				context.Buyers.Add(new Buyer { Id = 1, FIRST_NAME = "Buyer1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" });
				context.Buyers.Add(new Buyer { Id = 2, FIRST_NAME = "Buyer2", SURNAME = "Surname2", ADDRESS = "Address2", POSTCODE = "Postcode2", PHONE = "Phone2" });
				context.Buyers.Add(new Buyer { Id = 3, FIRST_NAME = "Buyer3", SURNAME = "Surname3", ADDRESS = "Address3", POSTCODE = "Postcode3", PHONE = "Phone3" });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new BuyersController(context);

				//Act
				//downnload all sellers from the datbase
				var result = controller.Index();

				//Assert
				Assert.NotNull(result);
				Assert.IsType<ActionResult<IEnumerable<Buyer>>>(result);
				Assert.Equal(3, result.Value.Count());
				Assert.Equal(buyer.Id, result.Value.FirstOrDefault().Id);
				Assert.Equal(buyer.FIRST_NAME, result.Value.FirstOrDefault().FIRST_NAME);
				Assert.Equal(buyer.SURNAME, result.Value.FirstOrDefault().SURNAME);
				Assert.Equal(buyer.ADDRESS, result.Value.FirstOrDefault().ADDRESS);
				Assert.Equal(buyer.POSTCODE, result.Value.FirstOrDefault().POSTCODE);
				Assert.Equal(buyer.PHONE, result.Value.FirstOrDefault().PHONE);
				Assert.Equal(1, result.Value.FirstOrDefault().Id);
			}
		}

		[Fact]
		public void GetBuyerById_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the buyer object for comaprisons
			var buyer = new Buyer { Id = 1, FIRST_NAME = "Buyer1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				context.Buyers.Add(new Buyer { Id = 1, FIRST_NAME = "Buyer1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" });
				context.Buyers.Add(new Buyer { Id = 2, FIRST_NAME = "Buyer2", SURNAME = "Surname2", ADDRESS = "Address2", POSTCODE = "Postcode2", PHONE = "Phone2" });
				context.Buyers.Add(new Buyer { Id = 3, FIRST_NAME = "Buyer3", SURNAME = "Surname3", ADDRESS = "Address3", POSTCODE = "Postcode3", PHONE = "Phone3" });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new BuyersController(context);

				//Act
				//downnload all sellers from the datbase
				var result = controller.Details(1);

				//Assert
				Assert.NotNull(result);
				Assert.IsType<ActionResult<Buyer>>(result);
				Assert.Equal(buyer.Id, result.Value.Id);
				Assert.Equal(buyer.FIRST_NAME, result.Value.FIRST_NAME);
				Assert.Equal(buyer.SURNAME, result.Value.SURNAME);
				Assert.Equal(buyer.ADDRESS, result.Value.ADDRESS);
				Assert.Equal(buyer.POSTCODE, result.Value.POSTCODE);
				Assert.Equal(buyer.PHONE, result.Value.PHONE);
				Assert.Equal(1, result.Value.Id);
			}

		}

		[Fact]
		public void CreateBuyer_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the buyer object for comaprisons
			var buyer = new Buyer { Id = 1, FIRST_NAME = "Buyer", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//create the controller allowing to access the methods
				var controller = new BuyersController(context);

				//Act
				//downnload all sellers from the datbase
				var result = controller.Create(buyer);
				var comparison = controller.Details(1);

				//Assert
				Assert.NotNull(result);
				Assert.IsType<ActionResult<Buyer>>(comparison);
				Assert.Equal(buyer.Id, comparison.Value.Id);
				Assert.Equal(buyer.FIRST_NAME, comparison.Value.FIRST_NAME);
				Assert.Equal(buyer.SURNAME, comparison.Value.SURNAME);
				Assert.Equal(buyer.ADDRESS, comparison.Value.ADDRESS);
				Assert.Equal(buyer.POSTCODE, comparison.Value.POSTCODE);
				Assert.Equal(buyer.PHONE, comparison.Value.PHONE);
				Assert.Equal(1, comparison.Value.Id);
			}
		}

		[Fact]
		public void UpdateBuyer_ValidCall()
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
				context.Buyers.Add(new Buyer { Id = 1, FIRST_NAME = "Buyer1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" });
				context.Buyers.Add(new Buyer { Id = 2, FIRST_NAME = "Buyer", SURNAME = "Surname", ADDRESS = "Address", POSTCODE = "Postcode", PHONE = "Phone" });
				context.Buyers.Add(new Buyer { Id = 3, FIRST_NAME = "Buyer", SURNAME = "Surname3", ADDRESS = "Address3", POSTCODE = "Postcode3", PHONE = "Phone3" });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new BuyersController(context);

				//create the buyer object for comaprisons
				//var buyer = new Buyer { Id = 2, FIRST_NAME = "Buyer2", SURNAME = "Surname2", ADDRESS = "Address2", POSTCODE = "Postcode2", PHONE = "Phone2" };
				Buyer buyer = controller.Details(2).Value;
				buyer.FIRST_NAME = "Seller2";
				buyer.SURNAME = "Surname2";
				buyer.ADDRESS = "Address2";
				buyer.POSTCODE = "Postcode2";
				buyer.PHONE = "Phone2";

				//Act
				//downnload all buyers from the datbase
				controller.Edit(buyer);

				Buyer comparison = controller.Details(2).Value;

				//Assert
				Assert.NotNull(buyer);
				Assert.NotNull(comparison);
				Assert.IsType<Buyer>(buyer);
				Assert.IsType<Buyer>(comparison);
				Assert.Equal(buyer.Id, comparison.Id);
				Assert.Equal(buyer.FIRST_NAME, comparison.FIRST_NAME);
				Assert.Equal(buyer.SURNAME, comparison.SURNAME);
				Assert.Equal(buyer.ADDRESS, comparison.ADDRESS);
				Assert.Equal(buyer.POSTCODE, comparison.POSTCODE);
				Assert.Equal(buyer.PHONE, comparison.PHONE);
			}
		}

		[Fact]
		public void DeleteSeller_ValidCall()
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
				context.Buyers.Add(new Buyer { Id = 1, FIRST_NAME = "Buyer1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" });
				context.Buyers.Add(new Buyer { Id = 2, FIRST_NAME = "Buyer2", SURNAME = "Surname2", ADDRESS = "Address2", POSTCODE = "Postcode2", PHONE = "Phone2" });
				context.Buyers.Add(new Buyer { Id = 3, FIRST_NAME = "Buyer3", SURNAME = "Surname3", ADDRESS = "Address3", POSTCODE = "Postcode3", PHONE = "Phone3" });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new BuyersController(context);

				//Act
				//downnload all buyers from the datbase
				controller.Delete(2);
				List<Buyer> buyers = controller.Index().Value.ToList();

				//Assert
				Assert.NotNull(buyers);
				Assert.IsType<List<Buyer>>(buyers);
				Assert.Equal(2, context.Buyers.Count());
				Assert.Equal(1, buyers[0].Id);
				Assert.Equal("Buyer1", buyers[0].FIRST_NAME);
				Assert.Equal("Surname1", buyers[0].SURNAME);
				Assert.Equal("Address1", buyers[0].ADDRESS);
				Assert.Equal("Postcode1", buyers[0].POSTCODE);
				Assert.Equal("Phone1", buyers[0].PHONE);
				Assert.Equal(3, buyers[1].Id);
				Assert.Equal("Buyer3", buyers[1].FIRST_NAME);
				Assert.Equal("Surname3", buyers[1].SURNAME);
				Assert.Equal("Address3", buyers[1].ADDRESS);
				Assert.Equal("Postcode3", buyers[1].POSTCODE);
				Assert.Equal("Phone3", buyers[1].PHONE);
			}
		}
	}
}
