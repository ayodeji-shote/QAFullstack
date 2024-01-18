using Microsoft.EntityFrameworkCore;
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QaFullStack.EF;
using QaFullStack.Model;

namespace QaFullStack.Controllers
{
	/// <summary>
	/// SellerController class logic
	/// </summary>
	[Authorize]
    public class SellerController : ControllerBase
	{
		#region Fieleds
		/// <summary>
		/// Variables
		/// </summary>
		EstateDBContext _dBContext;

		#endregion

		#region Class Constructor

		public SellerController(EstateDBContext dBContext)
		{
			_dBContext = dBContext;
		}
		#endregion

		#region Routes
		/// <summary>
		/// Get all sellers	
		/// </summary>
		/// <returns></returns>
		[AllowAnonymous]
		[HttpGet]
		[Route("GetSellers")]
		// GET:SellerController
		public ActionResult<IEnumerable<Seller>> GetSellers()
		{
			var sellers = _dBContext.Sellers;
			return sellers;
		}

		/// <summary>
		/// Get seller by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("GetSeller/{id}")]
		//GET: SellerController/Details
		public ActionResult<Seller> GetSeller(int id)
		{
			var seller = _dBContext.Sellers.Find(id);
			if (seller == null)
			{
				return NotFound();
			}
			return seller;
		}

		/// <summary>
		/// Create new seller
		/// </summary>
		/// <param name="seller"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("CreateSeller")]
		// POST: SellerController/Create
		public ActionResult CreateSeller([FromBody] Seller seller)
		{
			if (ModelState.IsValid)
			{
				_dBContext.Sellers.Add(seller);
				_dBContext.SaveChanges();
				return new JsonResult("Seller created successfully");
			}
			return BadRequest(ModelState);
		}

		[HttpPut]
		[Route("UpdateSeller/{id}")]
		// PUT: SellerController/Edit
		public ActionResult UpdateSeller([FromBody] Seller seller)
		{
			if (ModelState.IsValid)
			{
				//_dBContext.Entry(seller).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				_dBContext.Update(seller);
				_dBContext.SaveChanges();
				return new JsonResult("Seller updated successfully");
			}
			return BadRequest(ModelState);
		}

		[HttpDelete]
		[Route("DeleteSeller/{id}")]
		// DELETE: SellerController/Delete
		public ActionResult DeleteSeller(int id)
		{
			var seller = _dBContext.Sellers.Find(id);
			if (seller == null)
			{
				return NotFound();
			}
			_dBContext.Sellers.Remove(seller);
			_dBContext.SaveChanges();
			return new JsonResult("Seller deleted successfully");
		}

		/*		
		[HttpGet]
		[Route("GetSeller")]
		public JsonResult GetSeller()
		{
			string query = "select * from estateagent.dbo.seller";
			DataTable table = new DataTable();
			string sqlDataSource = _config.GetConnectionString("EstateAgentAppCon");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myReader = myCommand.ExecuteReader();
					table.Load(myReader);
					myReader.Close();
					myCon.Close();
				}
			}
			return new JsonResult(table);
		}*/

		#endregion
	}
}
