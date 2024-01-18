using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QaFullStack.Controllers;
using QaFullStack.EF;
using QaFullStack.Model;
using System.Threading.Tasks;

namespace BackendUnitTests
{
	/// <summary>
	/// PropertyControllerTests class logic
	/// </summary>
	public class PropertyControllerTests
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
				options.UseInMemoryDatabase("MockData4");
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);//remove tracking in EF
			});
			//options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EstateAgentAppCon2;Trusted_Connection=True;MultipleActiveResultSets=true"));

			//add the controller
			services.AddScoped<PropertyController>();

			//return the EstateDBContext object in the scope of BuyersController 
			return services.BuildServiceProvider();
		}

		[Fact]
		public void GetAllProperties_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the propeety object for comaprisons
			var property1 = new Property { Id = 1, ADDRESS = "Address1", POSTCODE = "Postcode1", PRICE = 1000, TYPE = "Type1", NUMBER_OF_BEDROOMS = 1, NUMBER_OF_BATHROOMS = 1, GARDEN = false, STATUS = "Status1", BUYER_ID = 1, SELLER_ID = 1 };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				context.Properties.Add(new Property { Id = 1, ADDRESS = "Address1", POSTCODE = "Postcode1", PRICE = 1000, TYPE = "Type1", NUMBER_OF_BEDROOMS = 1, NUMBER_OF_BATHROOMS = 1, GARDEN = false, STATUS = "Status1", BUYER_ID = 1, SELLER_ID = 1 });
				context.Properties.Add(new Property { Id = 2, ADDRESS = "Address2", POSTCODE = "Postcode2", PRICE = 2000, TYPE = "Type2", NUMBER_OF_BEDROOMS = 2, NUMBER_OF_BATHROOMS = 2, GARDEN = true, STATUS = "Status2", BUYER_ID = 2, SELLER_ID = 2 });
				context.Properties.Add(new Property { Id = 3, ADDRESS = "Address3", POSTCODE = "Postcode3", PRICE = 3000, TYPE = "Type3", NUMBER_OF_BEDROOMS = 3, NUMBER_OF_BATHROOMS = 3, GARDEN = false, STATUS = "Status3", BUYER_ID = 3, SELLER_ID = 3 });


				//do not forget to save
				context.SaveChanges();

				//create the controller
				var controller = new PropertyController(context);

				//Act
				//downnload all bookings from the datbase
				var result = controller.Get();

				// Assert
				Assert.NotNull(result);
				Assert.IsType<List<Property>>(result);
				Assert.Equal(3, result.Count());
				Assert.Equal(property1.Id, result.FirstOrDefault().Id);
				Assert.Equal(property1.ADDRESS, result.FirstOrDefault().ADDRESS);
				Assert.Equal(property1.POSTCODE, result.FirstOrDefault().POSTCODE);
				Assert.Equal(property1.PRICE, result.FirstOrDefault().PRICE);
				Assert.Equal(property1.TYPE, result.FirstOrDefault().TYPE);
				Assert.Equal(property1.NUMBER_OF_BEDROOMS, result.FirstOrDefault().NUMBER_OF_BEDROOMS);
				Assert.Equal(property1.NUMBER_OF_BATHROOMS, result.FirstOrDefault().NUMBER_OF_BATHROOMS);
				Assert.Equal(property1.GARDEN, result.FirstOrDefault().GARDEN);
				Assert.Equal(property1.STATUS, result.FirstOrDefault().STATUS);
				Assert.Equal(property1.BUYER_ID, result.FirstOrDefault().BUYER_ID);
				Assert.Equal(property1.SELLER_ID, result.FirstOrDefault().SELLER_ID);
			}
		}

		[Fact]
		public void GetPropertyById_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the propeety object for comaprisons
			var property1 = new Property { Id = 1, ADDRESS = "Address1", POSTCODE = "Postcode1", PRICE = 1000, TYPE = "Type1", NUMBER_OF_BEDROOMS = 1, NUMBER_OF_BATHROOMS = 1, GARDEN = false, STATUS = "Status1", BUYER_ID = 1, SELLER_ID = 1 };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				context.Properties.Add(new Property { Id = 1, ADDRESS = "Address1", POSTCODE = "Postcode1", PRICE = 1000, TYPE = "Type1", NUMBER_OF_BEDROOMS = 1, NUMBER_OF_BATHROOMS = 1, GARDEN = false, STATUS = "Status1", BUYER_ID = 1, SELLER_ID = 1 });
				context.Properties.Add(new Property { Id = 2, ADDRESS = "Address2", POSTCODE = "Postcode2", PRICE = 2000, TYPE = "Type2", NUMBER_OF_BEDROOMS = 2, NUMBER_OF_BATHROOMS = 2, GARDEN = true, STATUS = "Status2", BUYER_ID = 2, SELLER_ID = 2 });
				context.Properties.Add(new Property { Id = 3, ADDRESS = "Address3", POSTCODE = "Postcode3", PRICE = 3000, TYPE = "Type3", NUMBER_OF_BEDROOMS = 3, NUMBER_OF_BATHROOMS = 3, GARDEN = false, STATUS = "Status3", BUYER_ID = 3, SELLER_ID = 3 });

				//do not forget to save
				context.SaveChanges();

				//create the controller
				var controller = new PropertyController(context);

				//Act
				//donload a particular property from the database
				var result = controller.Get(1);

				// Assert
				Assert.NotNull(result);
				Assert.IsType<ActionResult<Property>>(result);
				Assert.Equal(property1.Id, result.Value.Id);
				Assert.Equal(property1.ADDRESS, result.Value.ADDRESS);
				Assert.Equal(property1.POSTCODE, result.Value.POSTCODE);
				Assert.Equal(property1.PRICE, result.Value.PRICE);
				Assert.Equal(property1.TYPE, result.Value.TYPE);
				Assert.Equal(property1.NUMBER_OF_BEDROOMS, result.Value.NUMBER_OF_BEDROOMS);
				Assert.Equal(property1.NUMBER_OF_BATHROOMS, result.Value.NUMBER_OF_BATHROOMS);
				Assert.Equal(property1.GARDEN, result.Value.GARDEN);
				Assert.Equal(property1.STATUS, result.Value.STATUS);
				Assert.Equal(property1.BUYER_ID, result.Value.BUYER_ID);
				Assert.Equal(property1.SELLER_ID, result.Value.SELLER_ID);
			}
		}

		[Fact]
		public void CreateProperty_ValidCall()
		{
			//Arrange
			//create the local service provider
			var serviceProvider = GetServiceceProvider();

			//create the propeety object for comaprisons
			var property1 = new Property { Id = 1, ADDRESS = "Address1", POSTCODE = "Postcode1", PRICE = 1000, TYPE = "Type1", NUMBER_OF_BEDROOMS = 1, NUMBER_OF_BATHROOMS = 1, GARDEN = false, STATUS = "Status1", BUYER_ID = 1, SELLER_ID = 1 };

			//create the scope for the service provider
			using (var scope = serviceProvider.CreateScope())
			{
				//create the database context allowing to add elements to the database
				var context = scope.ServiceProvider.GetService<EstateDBContext>();

				//remember to remove the database from previus tests
				context.Database.EnsureDeleted();

				//load the database with data
				//context.Properties.Add(new Property { Id = 1, ADDRESS = "Address1", POSTCODE = "Postcode1", PRICE = 1000, TYPE = "Type1", NUMBER_OF_BEDROOMS = 1, NUMBER_OF_BATHROOMS = 1, GARDEN = false, STATUS = "Status1", BUYER_ID = 1, SELLER_ID = 1 });
				context.Properties.Add(new Property { Id = 2, ADDRESS = "Address2", POSTCODE = "Postcode2", PRICE = 2000, TYPE = "Type2", NUMBER_OF_BEDROOMS = 2, NUMBER_OF_BATHROOMS = 2, GARDEN = true, STATUS = "Status2", BUYER_ID = 2, SELLER_ID = 2 });
				context.Properties.Add(new Property { Id = 3, ADDRESS = "Address3", POSTCODE = "Postcode3", PRICE = 3000, TYPE = "Type3", NUMBER_OF_BEDROOMS = 3, NUMBER_OF_BATHROOMS = 3, GARDEN = false, STATUS = "Status3", BUYER_ID = 3, SELLER_ID = 3 });

				//do not forget to save
				context.SaveChanges();

				//create the controller
				var controller = new PropertyController(context);

				//Act
				//create a new property object in the database
				controller.Post(property1);

				//create the property object for comaprisons
				var comparison = controller.Get(1);

				// Assert
				Assert.NotNull(comparison);
				Assert.IsType<ActionResult<Property>>(comparison);
				Assert.Equal(property1.Id, comparison.Value.Id);
				Assert.Equal(property1.ADDRESS, comparison.Value.ADDRESS);
				Assert.Equal(property1.POSTCODE, comparison.Value.POSTCODE);
				Assert.Equal(property1.PRICE, comparison.Value.PRICE);
				Assert.Equal(property1.TYPE, comparison.Value.TYPE);
				Assert.Equal(property1.NUMBER_OF_BEDROOMS, comparison.Value.NUMBER_OF_BEDROOMS);
				Assert.Equal(property1.NUMBER_OF_BATHROOMS, comparison.Value.NUMBER_OF_BATHROOMS);
				Assert.Equal(property1.GARDEN, comparison.Value.GARDEN);
				Assert.Equal(property1.STATUS, comparison.Value.STATUS);
				Assert.Equal(property1.BUYER_ID, comparison.Value.BUYER_ID);
				Assert.Equal(property1.SELLER_ID, comparison.Value.SELLER_ID);
			}
		}

		[Fact]
		public void UpdateProperty_ValidCall()
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
				context.Properties.Add(new Property { Id = 1, ADDRESS = "Address1", POSTCODE = "Postcode1", PRICE = 1000, TYPE = "Type1", NUMBER_OF_BEDROOMS = 1, NUMBER_OF_BATHROOMS = 1, GARDEN = false, STATUS = "Status1", BUYER_ID = 1, SELLER_ID = 1 });
				context.Properties.Add(new Property { Id = 2, ADDRESS = "Address", POSTCODE = "Postcode", PRICE = 200, TYPE = "Type", NUMBER_OF_BEDROOMS = 4, NUMBER_OF_BATHROOMS = 4, GARDEN = false, STATUS = "Status", BUYER_ID = 4, SELLER_ID = 4 });
				context.Properties.Add(new Property { Id = 3, ADDRESS = "Address3", POSTCODE = "Postcode3", PRICE = 3000, TYPE = "Type3", NUMBER_OF_BEDROOMS = 3, NUMBER_OF_BATHROOMS = 3, GARDEN = false, STATUS = "Status3", BUYER_ID = 3, SELLER_ID = 3 });

				//do not forget to save
				context.SaveChanges();

				//create the controller
				var controller = new PropertyController(context);

				//create the property object for comaprisons
				Property property = controller.Get(2).Value;
				property.ADDRESS = "Address2";
				property.POSTCODE = "Postcode2";
				property.PRICE = 2000;
				property.TYPE = "Type2";
				property.NUMBER_OF_BEDROOMS = 2;
				property.NUMBER_OF_BATHROOMS = 2;
				property.GARDEN = true;
				property.STATUS = "Status2";
				property.BUYER_ID = 2;
				property.SELLER_ID = 2;

				//Act
				//update the property object in the database
				controller.Put(property);

				//download the property object from the database
				var comparison = controller.Get(2);

				//Assert	
				Assert.NotNull(comparison);
				Assert.IsType<ActionResult<Property>>(comparison);
				Assert.Equal(2, comparison.Value.Id);
				Assert.Equal("Address2", comparison.Value.ADDRESS);
				Assert.Equal("Postcode2", comparison.Value.POSTCODE);
				Assert.Equal(2000, comparison.Value.PRICE);
				Assert.Equal("Type2", comparison.Value.TYPE);
				Assert.Equal(2, comparison.Value.NUMBER_OF_BEDROOMS);
				Assert.Equal(2, comparison.Value.NUMBER_OF_BATHROOMS);
				Assert.Equal(true, comparison.Value.GARDEN);
				Assert.Equal("Status2", comparison.Value.STATUS);
				Assert.Equal(2, comparison.Value.BUYER_ID);
				Assert.Equal(2, comparison.Value.SELLER_ID);
			}
		}

		[Fact]
		public void DeleteBooking_ValidCall()
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
				context.Properties.Add(new Property { Id = 1, ADDRESS = "Address1", POSTCODE = "Postcode1", PRICE = 1000, TYPE = "Type1", NUMBER_OF_BEDROOMS = 1, NUMBER_OF_BATHROOMS = 1, GARDEN = false, STATUS = "Status1", BUYER_ID = 1, SELLER_ID = 1 });
				context.Properties.Add(new Property { Id = 2, ADDRESS = "Address", POSTCODE = "Postcode", PRICE = 200, TYPE = "Type", NUMBER_OF_BEDROOMS = 4, NUMBER_OF_BATHROOMS = 4, GARDEN = false, STATUS = "Status", BUYER_ID = 4, SELLER_ID = 4 });
				context.Properties.Add(new Property { Id = 3, ADDRESS = "Address3", POSTCODE = "Postcode3", PRICE = 3000, TYPE = "Type3", NUMBER_OF_BEDROOMS = 3, NUMBER_OF_BATHROOMS = 3, GARDEN = false, STATUS = "Status3", BUYER_ID = 3, SELLER_ID = 3 });

				//do not forget to save
				context.SaveChanges();

				//create the controller
				var controller = new PropertyController(context);

				//Act
				//delete the property object from the database
				controller.Delete(2);

				//download the objects from the DB
				List<Property> comparison = controller.Get().ToList();

				//Assert

				Assert.NotNull(comparison);
				Assert.IsType<List<Property>>(comparison);
				Assert.Equal(2, comparison.Count());
				Assert.True(comparison.Count() == 2);
				Assert.True(controller.Get(2).Value == null);
				Assert.Equal(1, comparison[0].Id);
				Assert.Equal("Address1", comparison[0].ADDRESS);
				Assert.Equal("Postcode1", comparison[0].POSTCODE);
				Assert.Equal(1000, comparison[0].PRICE);
				Assert.Equal("Type1", comparison[0].TYPE);
				Assert.Equal(1, comparison[0].NUMBER_OF_BEDROOMS);
				Assert.Equal(1, comparison[0].NUMBER_OF_BATHROOMS);
				Assert.Equal(false, comparison[0].GARDEN);
				Assert.Equal("Status1", comparison[0].STATUS);
				Assert.Equal(1, comparison[0].BUYER_ID);
				Assert.Equal(1, comparison[0].SELLER_ID);
				Assert.Equal(3, comparison[1].Id);
				Assert.Equal("Address3", comparison[1].ADDRESS);
				Assert.Equal("Postcode3", comparison[1].POSTCODE);
				Assert.Equal(3000, comparison[1].PRICE);
				Assert.Equal("Type3", comparison[1].TYPE);
				Assert.Equal(3, comparison[1].NUMBER_OF_BEDROOMS);
				Assert.Equal(3, comparison[1].NUMBER_OF_BATHROOMS);
				Assert.Equal(false, comparison[1].GARDEN);
				Assert.Equal("Status3", comparison[1].STATUS);
				Assert.Equal(3, comparison[1].BUYER_ID);
				Assert.Equal(3, comparison[1].SELLER_ID);
			}
		}
	}
}
