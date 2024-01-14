using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace QaFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private IConfiguration _config;
        public BuyerController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("GetBuyer")]
        public JsonResult GetBuyer()
        {
            string query = "select * from estateagent.dbo.buyer";
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
    }
}
