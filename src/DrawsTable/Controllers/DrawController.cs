using DrawsTable.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrawsTable.Controllers
{
   
    public class DrawController : Controller
    {
        public class Data
        {
            public string name;
            public string position;
        }


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
