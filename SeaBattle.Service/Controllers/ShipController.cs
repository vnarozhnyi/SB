using CreateAttribute;
using Newtonsoft.Json;
using ORM.Models;
using SeaBattle.Service.Models;
using SeaBattle.Service.Objects;
using System.Diagnostics;
using System.Web.Http;

namespace SeaBattle.Service.Controllers
{
    public class ShipController : ApiController
    {
        [Encryption(className: "CreateAttribute.EncryptionService", guid)]
        private const string guid = "C4CD33D6-8AC4-4034-b273-0E236D93";
        [HttpPost]
        public IHttpActionResult Init([FromBody]string data)
        {
            var deserialized = JsonConvert.DeserializeObject<Field>(data, new EncryptionJsonConverter());
            var _data = GameHub.GetInitMap(deserialized);

            return Ok(_data);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] string data)
        {
            var deserialized = JsonConvert.DeserializeObject<Ship>(data, new EncryptionJsonConverter());
            var _data = GameHub.GetAddShip(deserialized);

            return Ok(_data);
        }

        [HttpPost]
        public IHttpActionResult Shoot([FromBody] string data)
        {
            var deserialized = JsonConvert.DeserializeObject<Shoot>(data, new EncryptionJsonConverter());
            object _data = GameHub.GetShoot(deserialized);

            return Ok(_data);
        }

        [HttpPost]
        public IHttpActionResult Repair([FromBody] string data)
        {
            var deserialized = JsonConvert.DeserializeObject<Repair>(data, new EncryptionJsonConverter());
            object _data = GameHub.GetRepair(deserialized);

            return Ok(_data);
        }
    }
}
