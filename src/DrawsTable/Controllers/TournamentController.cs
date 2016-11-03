using DrawsTable.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DrawsTable.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public TournamentController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult GetPlayers()
        {
            Tournament tournament = new Tournament("Torneio de Mafra", DateTime.Today);

            string webRootPath = _hostingEnvironment.WebRootPath;
            string filePath = webRootPath + "\\data\\PlayersAndTeams.txt";
            tournament.LoadPlayersFromTxt(filePath);
            return Json(tournament.Players);
        }

        public ActionResult GetMatches()
        {
            Tournament tournament = new Tournament("Torneio de Mafra", DateTime.Today);

            string webRootPath = _hostingEnvironment.WebRootPath;
            string filePath = webRootPath + "\\data\\PlayersAndTeams.txt";
            tournament.LoadPlayersFromTxt(filePath);
            tournament.MakeDraw(DrawMap.Sixteen, 16, 3);
            return Json(tournament.Matches);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
