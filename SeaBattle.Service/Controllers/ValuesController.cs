using BattleShip;
using Newtonsoft.Json;
using SeaBattle.Service.Hubs;
using System.Web.Http;

namespace SeaBattle.Service.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("api/InitializeMap")]
        [HttpGet]
        public string InitMap(string data)
        {
            var _data = GameHub.GetInitMap();
            return GameHub.GetAttributeEnc(_data.ToString());
        }

        [Route("api/AddShip")]
        [HttpPost]
        public string AddShip(int x, int y, BaseShip ship)
        {
            var _data = GameHub.GetAddShip(x, y, ship);
            return GameHub.GetAttributeEnc(_data.ToString());
        }

        [Route("api/GetMove")]
        [HttpGet]
        public string GetMove(Direction direction, BaseShip ship)
        {
            object _data = GameHub.GetMove(direction, ship);
            return GameHub.GetAttributeEnc(JsonConvert.SerializeObject(_data));
        }

        [Route("api/GetShoot")]
        [HttpGet]
        public string GetShoot(int x, int y)
        {
            object _data = GameHub.GetShoot(x, y);
            return GameHub.GetAttributeEnc(_data.ToString());
        }

        [Route("api/GetRepair")]
        [HttpGet]
        public string GetRepair(int x, int y)
        {
            object _data = GameHub.GetRepair(x, y);
            return GameHub.GetAttributeEnc(_data.ToString());
        }
    }
}
