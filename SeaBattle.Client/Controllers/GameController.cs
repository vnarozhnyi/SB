using ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaBattle.Client.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetShoot(int x, int y)
        {

            return View();
        }

        public ActionResult GetRepair(int x, int y)
        {
            return View();
        }

        public ActionResult GetMove(Directions direction)
        {
            return View();
        }

        public ActionResult AddShip(Ship ship)
        {
            return View();
        }

        public ActionResult InitMap(Field field)
        {
            return View();
        }
    }
}