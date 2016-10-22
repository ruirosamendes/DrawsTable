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


        public ActionResult Get1()
        {
            //DrawTable draw = new DrawTable(8);
            //return draw.Json;
            Data[] data = new Data[2];
            Data current = new Data();
            current.name = "Tiger Nixon";
            current.position = "System Architect";
            data[0] = current;
            current = new Data();
            current.name = "Garrett Winters";
            current.position = "Accountant";
            data[1] = current;

            return Json(data);


        }


        public ActionResult Get()
        {
            DrawTable draw = new DrawTable(8);
            return Json(draw);


        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
