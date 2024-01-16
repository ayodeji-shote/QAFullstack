using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QaFullStack.Model;

namespace QaFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAPIController : ControllerBase
    {
        private readonly EstateDBContext _dbContext;

        public PropertyAPIController(EstateDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Property> Get() {
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

        [HttpGet("{id}")]
        public ActionResult<Property> Get(int? id)
        {
            try
            {
                var property = _dbContext.Properties.FirstOrDefault(p => p.Id == id);
                return property;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching properties: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public ActionResult<Property> Post([FromBody] Property property)
        {
            _dbContext.Add(property);
            _dbContext.SaveChanges();

            return CreatedAtAction("Get", new { id = property.Id }, property);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody]Property updatedProperty)
        {
            var currentproperty = _dbContext.Properties.FirstOrDefault(p=>p.Id==id);
            if (currentproperty == null)
            {
                return NoContent();
            }

            // Update the existing property with the data from the request
            currentproperty.ADDRESS = updatedProperty.ADDRESS;
            currentproperty.POSTCODE = updatedProperty.POSTCODE;
            currentproperty.TYPE = updatedProperty.TYPE;
            currentproperty.NUMBER_OF_BEDROOMS = updatedProperty.NUMBER_OF_BEDROOMS;
            currentproperty.NUMBER_OF_BATHROOMS = updatedProperty.NUMBER_OF_BATHROOMS;
            currentproperty.GARDEN = updatedProperty.GARDEN;
            currentproperty.PRICE = updatedProperty.PRICE;
            currentproperty.STATUS = updatedProperty.STATUS;
            currentproperty.SELLER_ID = updatedProperty.SELLER_ID;
            currentproperty.BUYER_ID = updatedProperty.BUYER_ID;

            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("id")]
        public ActionResult Delete(int id) {
            var property = _dbContext.Properties.FirstOrDefault(p => p.Id == id);
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
