using ORM.Model;
using SeaBattle.Client.Hubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using SeaBattle.Client.Objects;

namespace SeaBattle.Client.Controllers
{
    public class GameController : Controller
    {
        static HttpClient client = new HttpClient();
        //// GET: Game
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetShoot(int x, int y)
        {
            for (int i = x; i < GameObjects.Shoot.Length; i++)
            {
                for (int j = y; j < GameObjects.Shoot[i].Length; j++)
                {
                    GameObjects.Shoot[x][y] = 1 ;
                }
            }
            GameHub.GetShoot(x, y);
            return View();
        }

        public ActionResult GetRepair(int x, int y)
        {
            GameHub.GetRepair(x, y);
            gameHub.Clients.Others.repair(x, y);
            return View();
        }

        public ActionResult GetMove(Directions direction)
        {
            GameHub.GetMove(direction);
            return View();
        }

        public ActionResult AddShip(Ship ship)
        {
            GameHub.AddShip(ship);
            using (client)
            {
                var _response = client.GetStringAsync("https://localhost:44386/api/AddShip");


            }
            return View();
        }

        [HttpGet]
        public ActionResult InitMap(Field field)
        {
            GameHub.InitMap();
            //HttpResponseMessage response = new HttpResponseMessage();
            //response.Content();//client.Get("api/InitializeMap");
            //if (response.IsSuccessStatusCode)
            //{
            //    var data = response.Content.ReadAsAsync<Field>();
            //}
            using (client)
            {
                var _response = client.GetStringAsync("https://localhost:44386/api/InitializeMap");
                //Console.WriteLine(_response);

            }
            return View();
        }
    }
}