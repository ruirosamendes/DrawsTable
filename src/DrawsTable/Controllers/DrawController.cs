using DrawsTable.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrawsTable.Controllers
{
   
    public class DrawController : Controller
    {

        public ActionResult Get()
        {
            DrawTable draw = new DrawTable(16);
            return Json(draw);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
