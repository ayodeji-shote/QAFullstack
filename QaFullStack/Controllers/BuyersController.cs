using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using QaFullStack.EF;
using QaFullStack.Model;
using System.Net;
namespace QaFullStack.Controllers
{
    public class BuyersController : ControllerBase
    {
        EstateDBContext _dBContext;
        public BuyersController(EstateDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        [HttpGet]
        [Route("GetBuyers")]
        // GET: BuyersController
        public ActionResult<IEnumerable<Buyer>> Index()
        {
            var buyers = _dBContext.Buyers;
            return buyers;
        }

        // GET: BuyersController/Details/5
        [HttpGet]
        [Route("GetBuyer/{id}")]
        public ActionResult<Buyer> Details(int id)
        {
            try
            {
                var buyer = _dBContext.Buyers.Find(id);
                return buyer;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: BuyersController/Create
        [HttpPost]
        [Route("CreateBuyer")]
        public ActionResult<Buyer> Create(Buyer bnbuyer)
        {
           _dBContext.Buyers.Add(bnbuyer);
            _dBContext.SaveChanges();
            return CreatedAtAction(nameof(Details), new { id = bnbuyer.Id }, bnbuyer);
        }



        // POST: BuyersController/Edit/5
        [HttpPut]
        [Route("EditBuyer/{id}")]
        public ActionResult<Buyer> Edit(int id , Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                _dBContext.Entry(buyer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dBContext.SaveChanges();
                return new JsonResult("buyer updated successfully");
            }
            return BadRequest(ModelState);


        }



        // POST: BuyersController/Delete/5
        [HttpDelete]
        [Route("DeleteBuyer/{id}")]
        public HttpStatusCode Delete(int id)
        {
            var Buyer = _dBContext.Buyers.Find(id);
            if (Buyer == null)
                return HttpStatusCode.NotFound;
            _dBContext.Remove(Buyer);
            _dBContext.SaveChanges();
            return HttpStatusCode.NoContent;
        }
    }
}
