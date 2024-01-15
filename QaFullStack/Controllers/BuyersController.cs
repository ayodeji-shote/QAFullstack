using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QaFullStack.Model;

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
		[Route("GetBuyer")]
		// GET: BuyersController
		public ActionResult<IEnumerable<Buyer>> Index()
		{
			var buyers = _dBContext.Buyers;
			return buyers;
		}

		//// GET: BuyersController/Details/5
		//public ActionResult Details(int id)
		//{
		//    return ();
		//}

		//// GET: BuyersController/Create
		//public ActionResult Create()
		//{
		//    return ();
		//}

		//// POST: BuyersController/Create
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Create(IFormCollection collection)
		//{
		//    try
		//    {
		//        return RedirectToAction(nameof(Index));
		//    }
		//    catch
		//    {
		//        return ();
		//    }
		//}

		//// GET: BuyersController/Edit/5
		//public ActionResult Edit(int id)
		//{
		//    return ();
		//}

		//// POST: BuyersController/Edit/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit(int id, IFormCollection collection)
		//{
		//    try
		//    {
		//        return RedirectToAction(nameof(Index));
		//    }
		//    catch
		//    {
		//        return ();
		//    }
		//}

		//// GET: BuyersController/Delete/5
		//public ActionResult Delete(int id)
		//{
		//    return ();
		//}

		//// POST: BuyersController/Delete/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Delete(int id, IFormCollection collection)
		//{
		//    try
		//    {
		//        return RedirectToAction(nameof(Index));
		//    }
		//    catch
		//    {
		//        return ();
		//    }
		//}
	}
}
