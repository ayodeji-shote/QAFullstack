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
                var property = _dbContext.Properties.FirstOrDefault(p=>p.Id==id);
                return property;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching properties: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public ActionResult<Property> Post([FromBody]Property property)
        {
            _dbContext.Add(property);
            _dbContext.SaveChanges();

            return CreatedAtAction("Get", new { id = property.Id },property);
        }

    }
}
