using Microsoft.AspNetCore.Mvc;
using QaFullStack.EF;
using QaFullStack.Model;
using System.Text.Json.Serialization;

namespace QaFullStack.Controllers
{

	public class PropertyController : ControllerBase
	{
		private readonly EstateDBContext _dbContext;

		public PropertyController(EstateDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		[Route("GetProperties")]
		public IEnumerable<Property> Get()
		{
			try
			{
				var properties = _dbContext.Properties.ToList();
				return properties;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching properties: {ex.Message}");
				throw;
			}
		}

		[HttpGet]
		[Route("GetProperty/{id}")]
		public ActionResult<Property> Get(int? id)
		{

			var property = _dbContext.Properties.Find(id);
			return property;

		}

		[HttpPost]
		[Route("CreateProperty")]
		public ActionResult<Property> Post([FromBody] Property property)
		{
			

			_dbContext.Add(property);
			_dbContext.SaveChanges();

			return CreatedAtAction("Get", new { id = property.Id }, property);
		}

		[HttpPut]
		[Route("EditProperty/{id}")]
		public ActionResult<Property> Put([FromBody] Property updatedProperty)
		{
			/*			var currentproperty = _dbContext.Properties.FirstOrDefault(p => p.Id == id);
						if (currentproperty == null)
						{
							return NoContent();
						}*/

			// Update the existing property with the data from the request
			/*			currentproperty.ADDRESS = updatedProperty.ADDRESS;
						currentproperty.POSTCODE = updatedProperty.POSTCODE;
						currentproperty.TYPE = updatedProperty.TYPE;
						currentproperty.NUMBER_OF_BEDROOMS = updatedProperty.NUMBER_OF_BEDROOMS;
						currentproperty.NUMBER_OF_BATHROOMS = updatedProperty.NUMBER_OF_BATHROOMS;
						currentproperty.GARDEN = updatedProperty.GARDEN;
						currentproperty.PRICE = updatedProperty.PRICE;
						currentproperty.STATUS = updatedProperty.STATUS;
						currentproperty.SELLER_ID = updatedProperty.SELLER_ID;
						currentproperty.BUYER_ID = updatedProperty.BUYER_ID;*/
			_dbContext.Update(updatedProperty);
			dbContext.SaveChanges();
			return NoContent();
		}

		[HttpDelete]
		[Route("DeleteProperty/{id}")]
		public ActionResult<Property> Delete(int id)
		{
			var property = _dbContext.Properties.Find(id);
			if (property == null)
			{
				return NoContent();
			}
			_dbContext.Remove(property);
			_dbContext.SaveChanges();
			return NoContent();
		}

	}
}
