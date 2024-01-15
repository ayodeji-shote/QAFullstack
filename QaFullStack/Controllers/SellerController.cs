using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace QaFullStack.Controllers
{
	/// <summary>
	/// SellerController class logic
	/// </summary>
	public class SellerController : ControllerBase
	{
		#region Fileds
		/// <summary>
		/// Variables
		/// </summary>
		private IConfiguration _config;
		#endregion

		#region Class Constructor
		public SellerController(IConfiguration config)
		{
			_config = config;
		}
		#endregion

		#region Routes
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

		}

		#endregion
	}
}
