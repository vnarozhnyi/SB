using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using CreateAttribute;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using ORM.Model;
using SeaBattle.Client.Objects;

namespace SeaBattle.Client.Hubs
{
    [GuidAttribute(guid)]
    [Encryption(className: "CreateAttribute.EncryptionService", parametrs: new object[] { guid })]
    public class GameHub : Hub
    {
        private const string guid = "F4E0560B-1F57-4E14-91ED-B998A0976F31";
        public string GetAttributeEnc()
        {
            var filedInfo = typeof(GameHub).GetField(guid);
            var encryptionAttribute = filedInfo.GetCustomAttribute(typeof(EncryptionAttribute)) as EncryptionAttribute;

            return encryptionAttribute.Encryption<string>();
        }

        public string GetAttributeDec(string data)
        {
            var filedInfo = typeof(GameHub).GetField(data);
            var encryptionAttribute = filedInfo.GetCustomAttribute(typeof(EncryptionAttribute)) as EncryptionAttribute;

            return encryptionAttribute.Decryption<string>();
        }

        public void GetShoot(int x, int y)
        {
            GameObjects.Shoot[x, y] = 0;
            Clients.Others.shoot(x, y);
        }

        public static void GetRepair(int x, int y)
        {
            GameObjects.Repair[x, y] = 0;
        }

        public void GetMove(Directions direction)
        {

            Clients.Caller.message("Move");
            Clients.Caller.move(JsonConvert.SerializeObject(direction));
        }

        public void InitMap()
        {
            Clients.Others.message("Map initialization...");
        }

        public void AddShip(Ship ship)
        {
            GameObjects.FieldMap.ShipsList.Add(ship);
            Clients.Caller.message("Ship added");
            Clients.Caller.addShip(JsonConvert.SerializeObject(ship));
        }
    }
}