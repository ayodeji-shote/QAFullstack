using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QaFullStack.Controllers;
using QaFullStack.EF;
using QaFullStack.Model;

namespace BackendUnitTests
{
	/// <summary>
	/// Tests the SellerController class
	/// </summary>
	public class SellerControllerTests
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
			//services.AddDbContext<EstateDBContext>(options => options.UseInMemoryDatabase("MockData"));
			services.AddDbContext<EstateDBContext>(options =>
			{
				options.UseInMemoryDatabase("MockData");
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			});
			//options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EstateAgentAppCon2;Trusted_Connection=True;MultipleActiveResultSets=true"));

			//add the controller
			services.AddScoped<SellerController>();

			//return the EstateDBContext object in the scope of SellerController 
			return services.BuildServiceProvider();
		}

		[Fact]
		public void GetAllSellers_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the seller object for comaprisons
			var seller = new Seller { Id = 1, FIRST_NAME = "Seller1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				context.Sellers.Add(new Seller { Id = 1, FIRST_NAME = "Seller1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" });
				context.Sellers.Add(new Seller { Id = 2, FIRST_NAME = "Seller2", SURNAME = "Surname2", ADDRESS = "Address2", POSTCODE = "Postcode2", PHONE = "Phone2" });
				context.Sellers.Add(new Seller { Id = 3, FIRST_NAME = "Seller3", SURNAME = "Surname3", ADDRESS = "Address3", POSTCODE = "Postcode3", PHONE = "Phone3" });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new SellerController(context);

				//Act
				//downnload all sellers from the datbase
				var result = controller.GetSellers();

				//Assert
				Assert.NotNull(result);
				Assert.IsType<ActionResult<IEnumerable<Seller>>>(result);
				Assert.Equal(3, result.Value.Count());
				Assert.Equal(seller.Id, result.Value.FirstOrDefault().Id);
				Assert.Equal(seller.FIRST_NAME, result.Value.FirstOrDefault().FIRST_NAME);
				Assert.Equal(seller.SURNAME, result.Value.FirstOrDefault().SURNAME);
				Assert.Equal(seller.ADDRESS, result.Value.FirstOrDefault().ADDRESS);
				Assert.Equal(seller.POSTCODE, result.Value.FirstOrDefault().POSTCODE);
				Assert.Equal(seller.PHONE, result.Value.FirstOrDefault().PHONE);
				Assert.Equal(1, result.Value.FirstOrDefault().Id);
			}
		}

		[Fact]
		public void GetSellerById_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the seller object for comaprisons
			var seller = new Seller { Id = 1, FIRST_NAME = "Seller1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				context.Sellers.Add(new Seller { Id = 1, FIRST_NAME = "Seller1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" });
				context.Sellers.Add(new Seller { Id = 2, FIRST_NAME = "Seller2", SURNAME = "Surname2", ADDRESS = "Address2", POSTCODE = "Postcode2", PHONE = "Phone2" });
				context.Sellers.Add(new Seller { Id = 3, FIRST_NAME = "Seller3", SURNAME = "Surname3", ADDRESS = "Address3", POSTCODE = "Postcode3", PHONE = "Phone3" });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new SellerController(context);

				//Act
				//downnload all sellers from the datbase
				var result = controller.GetSeller(1);

				//Assert
				Assert.NotNull(result);
				Assert.IsType<ActionResult<Seller>>(result);
				Assert.Equal(seller.Id, result.Value.Id);
				Assert.Equal(seller.FIRST_NAME, result.Value.FIRST_NAME);
				Assert.Equal(seller.SURNAME, result.Value.SURNAME);
				Assert.Equal(seller.ADDRESS, result.Value.ADDRESS);
				Assert.Equal(seller.POSTCODE, result.Value.POSTCODE);
				Assert.Equal(seller.PHONE, result.Value.PHONE);
				Assert.Equal(1, result.Value.Id);
			}

		}

		[Fact]
		public void CreateSeller_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the seller object for comaprisons
			var seller = new Seller { Id = 1, FIRST_NAME = "Seller1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//create the controller allowing to access the methods
				var controller = new SellerController(context);

				//Act
				//downnload all sellers from the datbase
				var result = controller.CreateSeller(seller);
				var comparison = controller.GetSeller(1);

				//Assert
				Assert.NotNull(result);
				Assert.IsType<ActionResult<Seller>>(comparison);
				Assert.Equal(seller.Id, comparison.Value.Id);
				Assert.Equal(seller.FIRST_NAME, comparison.Value.FIRST_NAME);
				Assert.Equal(seller.SURNAME, comparison.Value.SURNAME);
				Assert.Equal(seller.ADDRESS, comparison.Value.ADDRESS);
				Assert.Equal(seller.POSTCODE, comparison.Value.POSTCODE);
				Assert.Equal(seller.PHONE, comparison.Value.PHONE);
				Assert.Equal(1, comparison.Value.Id);
			}
		}

		[Fact]
		public void UpdateSeller_ValidCall()
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
				context.Sellers.Add(new Seller { Id = 1, FIRST_NAME = "Seller1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" });
				context.Sellers.Add(new Seller { Id = 2, FIRST_NAME = "Seller", SURNAME = "Surname", ADDRESS = "Address", POSTCODE = "Postcode", PHONE = "Phone" });
				context.Sellers.Add(new Seller { Id = 3, FIRST_NAME = "Seller3", SURNAME = "Surname3", ADDRESS = "Address3", POSTCODE = "Postcode3", PHONE = "Phone3" });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new SellerController(context);

				//create the seller object for comaprisons
				//var seller = new Seller { Id = 2, FIRST_NAME = "Seller2", SURNAME = "Surname2", ADDRESS = "Address2", POSTCODE = "Postcode2", PHONE = "Phone2" };
				Seller seller = controller.GetSeller(2).Value;
				seller.FIRST_NAME = "Seller2";
				seller.SURNAME = "Surname2";
				seller.ADDRESS = "Address2";
				seller.POSTCODE = "Postcode2";
				seller.PHONE = "Phone2";

				//Act
				//downnload all sellers from the datbase
				controller.UpdateSeller(seller);

				Seller comparison = controller.GetSeller(2).Value;

				//Assert
				Assert.NotNull(seller);
				Assert.NotNull(comparison);
				Assert.IsType<Seller>(seller);
				Assert.IsType<Seller>(comparison);
				Assert.Equal(seller.Id, comparison.Id);
				Assert.Equal(seller.FIRST_NAME, comparison.FIRST_NAME);
				Assert.Equal(seller.SURNAME, comparison.SURNAME);
				Assert.Equal(seller.ADDRESS, comparison.ADDRESS);
				Assert.Equal(seller.POSTCODE, comparison.POSTCODE);
				Assert.Equal(seller.PHONE, comparison.PHONE);
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
				context.Sellers.Add(new Seller { Id = 1, FIRST_NAME = "Seller1", SURNAME = "Surname1", ADDRESS = "Address1", POSTCODE = "Postcode1", PHONE = "Phone1" });
				context.Sellers.Add(new Seller { Id = 2, FIRST_NAME = "Seller2", SURNAME = "Surname2", ADDRESS = "Address2", POSTCODE = "Postcode2", PHONE = "Phone2" });
				context.Sellers.Add(new Seller { Id = 3, FIRST_NAME = "Seller3", SURNAME = "Surname3", ADDRESS = "Address3", POSTCODE = "Postcode3", PHONE = "Phone3" });

				//do not forget to save
				context.SaveChanges();

				//create the controller allowing to access the methods
				var controller = new SellerController(context);

				//Act
				//downnload all sellers from the datbase
				controller.DeleteSeller(2);
				List<Seller> sellers = controller.GetSellers().Value.ToList();

				//Assert
				Assert.NotNull(sellers);
				Assert.IsType<List<Seller>>(sellers);
				Assert.Equal(2, context.Sellers.Count());
				Assert.Equal(1, sellers[0].Id);
				Assert.Equal("Seller1", sellers[0].FIRST_NAME);
				Assert.Equal("Surname1", sellers[0].SURNAME);
				Assert.Equal("Address1", sellers[0].ADDRESS);
				Assert.Equal("Postcode1", sellers[0].POSTCODE);
				Assert.Equal("Phone1", sellers[0].PHONE);
				Assert.Equal(3, sellers[1].Id);
				Assert.Equal("Seller3", sellers[1].FIRST_NAME);
				Assert.Equal("Surname3", sellers[1].SURNAME);
				Assert.Equal("Address3", sellers[1].ADDRESS);
				Assert.Equal("Postcode3", sellers[1].POSTCODE);
				Assert.Equal("Phone3", sellers[1].PHONE);
			}
		}
	}
}