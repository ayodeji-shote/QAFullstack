using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QaFullStack.Model;

namespace QaFullStack.Controllers
{
	/// <summary>
	/// BookingController class logic
	/// </summary>
	public class BookingController : Controller
	{
		#region Fieleds
		/// <summary>
		/// Variables
		/// </summary>
		EstateDBContext _dBContext;

		#endregion

		#region Class Constructor
		public BookingController(EstateDBContext dBContext)
		{
			_dBContext = dBContext;
		}
		#endregion

		#region Routes
		/// <summary>
		///	Get all bookings
		///	</summary>

		[HttpGet]
		[Route("GetBookings")]
		// GET:BookingController
		public ActionResult<IEnumerable<Booking>> GetBookings()
		{
			var bookings = _dBContext.Bookings;
			return bookings;
		}

		/// <summary>
		/// Get booking by id
		/// </summary>
		/// <param name="id"></param>

		[HttpGet]
		[Route("GetBooking/{id}")]
		// GET:BookingController/Details
		public ActionResult<Booking> GetBooking(int id)
		{
			var booking = _dBContext.Bookings.Find(id);
			if (booking == null)
			{
				return NotFound();
			}
			return booking;
		}

		/// <summary>
		/// Create new booking
		/// </summary>
		[HttpPost]
		[Route("CreateBooking")]
		// POST:BookingController/Create
		public ActionResult<Booking> CreateBooking([FromBody] Booking booking)
		{
			_dBContext.Bookings.Add(booking);
			_dBContext.SaveChanges();
			return CreatedAtAction(nameof(GetBooking), new { id = booking.BOOKING_ID }, booking);
		}

		/// <summary>
		/// Update booking by id
		/// </summary>
		[HttpPut]
		[Route("UpdateBooking/{id}")]
		// PUT:BookingController/Edit
		public ActionResult UpdateBooking(int id, [FromBody] Booking booking)
		{
			if (id != booking.BOOKING_ID)
			{
				return BadRequest();
			}
			_dBContext.Entry(booking).State = EntityState.Modified;
			_dBContext.SaveChanges();
			return NoContent();
		}

		/// <summary>
		/// Delete booking by id
		/// </summary>
		[HttpDelete]
		[Route("DeleteBooking/{id}")]
		// DELETE:BookingController/Delete
		public ActionResult DeleteBooking(int id)
		{
			var booking = _dBContext.Bookings.Find(id);
			if (booking == null)
			{
				return NotFound();
			}
			_dBContext.Bookings.Remove(booking);
			_dBContext.SaveChanges();
			return NoContent();
		}
		#endregion
	}

}
