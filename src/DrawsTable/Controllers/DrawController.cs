using DrawsTable.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DrawsTable.Controllers
{
   
    public class DrawController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public DrawController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Get()
        {
            DrawTable draw = new DrawTable((int)DrawMap.SixtyFour);

            Tournament tournament = new Tournament("Torneio de Mafra", DateTime.Today);
            //string webRootPath = _hostingEnvironment.WebRootPath;
            //string filePath = webRootPath + "\\data\\PlayersAndTeams.txt";
            //tournament.LoadPlayersFromTxt(filePath);
            //tournament.MakeDraw(DrawMap.Sixteen, 4, 3);


            //draw.Matches = tournament.Matches;

            return Json(draw);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
