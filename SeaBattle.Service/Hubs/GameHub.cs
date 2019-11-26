using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using BattleShip;
using CreateAttribute;
using Microsoft.AspNet.SignalR;
using SeaBattle.Service.Objects;
using SeaBattle.Service.Models;

namespace SeaBattle.Service.Hubs
{
    [Guid(guid)]
    [Encryption(className: "CreateAttribute.EncryptionService", parametrs: new object[] { guid })]
    public class GameHub : Hub
    {
        private const string guid = "2BA764B7-B02B-49F7-9F21-34FF72Ef8C9A";
        public static string GetAttributeEnc(string guid)
        {
            var filedInfo = typeof(GameHub).GetField(guid);
            var encryptionAttribute = filedInfo.GetCustomAttribute(typeof(EncryptionAttribute)) as EncryptionAttribute;

            return encryptionAttribute.Encryption<string>();
        }

        public static string GetAttributeDec(string data)
        {
            var filedInfo = typeof(GameHub).GetField(data);
            var encryptionAttribute = filedInfo.GetCustomAttribute(typeof(EncryptionAttribute)) as EncryptionAttribute;

            return encryptionAttribute.Decryption<string>();
        }
        public static void GetAddMainShip(int length, int range, int speed, Direction direction)
        {
            GameObjects.Main = new MainShip(length, range, speed, direction);
        }

        public static void GetShootMainShip(int x, int y)
        {
            GameObjects.Main.Shoot(x, y);
        }

        public static void GetRepairMainShip(int x, int y)
        {
            GameObjects.Main.Repair(x, y);
        }

        public static void GetMoveMainShip(Direction direction)
        {
            GameObjects.Main.Move(direction);
        }

        public static void GetAddCarrierShip(int length, int range, int speed, Direction direction)
        {
            GameObjects.Carrier = new CarrierShip(length, range, speed, direction);
        }

        public static void GetShootCarrierShip(int x, int y)
        {
            GameObjects.Carrier.Shoot(x, y);
        }

        public static void GetMoveCarrierShip(Direction direction)
        {
            GameObjects.Carrier.Move(direction);
        }

        public static void GetAddSupportingShip(int length, int range, int speed, Direction direction)
        {
            GameObjects.Supporting = new SupportingShip(length, range, speed, direction);
        }

        public static void GetRepairSupportingShip(int x, int y)
        {
            GameObjects.Supporting.Repair(x, y);
        }

        public static void GetMoveSupportingShip(Direction direction)
        {
            GameObjects.Supporting.Move(direction);
        }

        public static int GetInitMap()
        {
            int x = new Random().Next(50, 100);
            int y = new Random().Next(50, 100);
            GameObjects.BattleField.InitMap(x, y);
            DataBase.GetDBInitMap(x, y);
            return GameObjects.BattleField.GetHashCode();
        }

        public static int GetAddShip(int x, int y, BaseShip ship)
        {
            DataBase.GetDBAddShip(ship);
            GameObjects.BattleField.AddShip(x, y, ship);

            return ship.GetHashCode();
        }

        public void GetMove(Direction direction, BaseShip ship)
        {
            ship.Move(direction);
            DataBase.GetDBUpdateDirection(direction);
            Clients.Caller.message($"MOVE {direction}");
        }

        public void GetShoot(int x, int y)
        {
            if (GameObjects.BattleField.Map[x, y] == 1)
            {
                GameObjects.BattleField.Map[x, y] = 2;
                GameObjects.Shoot[GameObjects.X = x, GameObjects.Y = y] = 1;
                Clients.Others.message("HIT");
            }
            else
                Clients.Others.message("MISS");
            {
                GameObjects.Shoot[GameObjects.X = x, GameObjects.Y = y] = 0;
            }
            for (int a = 0; a < (GameObjects.Ship.Length + 1); a++)
            {
                if (GameObjects.BattleField.Map[x, y] == 2)
                {
                    GameObjects.Count++;
                }
            }
            if (GameObjects.Ship.Length == GameObjects.Count)
            {
                Clients.Others.message("SHIP DESTROYED");
            }
        }

        public void GetRepair(int x, int y)
        {
            if (GameObjects.BattleField.Map[x, y] == 2)
            {
                GameObjects.BattleField.Map[x, y] = 0;
                GameObjects.Repair[GameObjects.X = x, GameObjects.Y = y] = 1;
                Clients.Others.message("REPAIRED");
            }
            else
            {
                GameObjects.Repair[GameObjects.X = x, GameObjects.Y = y] = 0;
                Clients.Others.message("MISS");
            }
        }
    }
}