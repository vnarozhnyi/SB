using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreateAttribute;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using ORM.Models;
using SeaBattle.Client.Hubs;
using SeaBattle.Client.Models;

namespace SeaBattle.Client.Controllers
{
    [Encryption(className: "CreateAttribute.EncryptionService", guid)]
    public class HomeController : Controller
    {
        private const string guid = "C4CD33D6-8AC4-4034-b273-0E236D93";

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult AddShip()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult InitMap(Field field)
        {
            var gameHub = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
            gameHub.Clients.All.addShip(JsonConvert.SerializeObject(field));

            return this.View();
        }

        [HttpPost]
        public ActionResult AddShip(Ship ship)
        {
            var gameHub = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
            gameHub.Clients.All.addShip(JsonConvert.SerializeObject(ship));

            return this.View();
        }

        [HttpPost]
        public ActionResult GetShoot(Shoot shoot)
        {
            var gameHub = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
            gameHub.Clients.All.addShip(JsonConvert.SerializeObject(shoot));

            return this.View();
        }

        [HttpPost]
        public ActionResult GetRepair(Repair repair)
        {
            var gameHub = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
            gameHub.Clients.All.addShip(JsonConvert.SerializeObject(repair));

            return this.View();
        }
    }
}