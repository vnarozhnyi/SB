using CreateAttribute;
using Newtonsoft.Json;
using ORM.Models;
using SeaBattle.Service.Models;
using System;
using System.Collections.Generic;

namespace SeaBattle.Service.Objects
{
   
    public static class GameHub
    {
        static string message;


        //public static void GetAddMainShip(int length, int range, int speed, Direction direction)
        //{
        //    GameObjects.Main = new MainShip(length, range, speed, direction);
        //}

        //public static void GetShootMainShip(int x, int y)
        //{
        //    GameObjects.Main.Shoot(x, y);
        //}

        //public static void GetRepairMainShip(int x, int y)
        //{
        //    GameObjects.Main.Repair(x, y);
        //}

        //public static void GetMoveMainShip(Direction direction)
        //{
        //    GameObjects.Main.Move(direction);
        //}

        //public static void GetAddCarrierShip(int length, int range, int speed, Direction direction)
        //{
        //    GameObjects.Carrier = new CarrierShip(length, range, speed, direction);
        //}

        //public static void GetShootCarrierShip(int x, int y)
        //{
        //    GameObjects.Carrier.Shoot(x, y);
        //}

        //public static void GetMoveCarrierShip(Direction direction)
        //{
        //    GameObjects.Carrier.Move(direction);
        //}

        //public static void GetAddSupportingShip(int length, int range, int speed, Direction direction)
        //{
        //    GameObjects.Supporting = new SupportingShip(length, range, speed, direction);
        //}

        //public static void GetRepairSupportingShip(int x, int y)
        //{
        //    GameObjects.Supporting.Repair(x, y);
        //}

        //public static void GetMoveSupportingShip(Direction direction)
        //{
        //    GameObjects.Supporting.Move(direction);
        //}

        public static string GetInitMap(Field field)
        {
            //int x = 100;
            //int y = new Random().Next(50, 100);
            GameObjects.BattleField.InitMap(field.X, field.Y);
            DataBase.GetDBInitMap(field.X, field.Y);
            var serialized = JsonConvert.SerializeObject(GameObjects.BattleField.Map[field.X, field.Y], new EncryptionJsonConverter());
            return serialized;
        }

        public static string GetAddShip(Ship ship)
        {
            if (GameObjects.BattleField.Map[ship.X, ship.Y] == 1)
            {
                return "You can not add a ship";
            }
            else
            {
                DataBase.GetDBAddShip(ship);
                var serialized = JsonConvert.SerializeObject(ship, new EncryptionJsonConverter());
                return serialized;
            }
        }

        public static string GetShoot(Shoot shoot)
        {
            GameObjects.Shoot[GameObjects.X = shoot.X, GameObjects.Y = shoot.Y] = 0;
            for (int a = 0; a < (GameObjects.Ship.Length + 1); a++)
            {
                if (GameObjects.BattleField.Map[shoot.X, shoot.Y] == 2)
                {
                    GameObjects.Count++;
                }
            }
            if (GameObjects.Ship.Length == GameObjects.Count)
            {
                message = "SHIP DESTROYED";
            }
            if (GameObjects.BattleField.Map[shoot.X, shoot.Y] == 1)
            {
                GameObjects.BattleField.Map[shoot.X, shoot.Y] = 2;
                GameObjects.Shoot[GameObjects.X = shoot.X, GameObjects.Y = shoot.Y] = 1;
                message = "HIT";
            }
            else
            {
                message = "MISS";
            }
            return message;

        }

        public static string GetRepair(Repair repair)
        {
            if (GameObjects.BattleField.Map[repair.X, repair.Y] == 2)
            {
                GameObjects.BattleField.Map[repair.X, repair.Y] = 0;
                GameObjects.Repair[GameObjects.X = repair.X, GameObjects.Y = repair.Y] = 1;
                message = "REPAIRED";
            }
            else
            {
                GameObjects.Repair[GameObjects.X = repair.X, GameObjects.Y = repair.Y] = 0;
                message = "MISS";
            }
            return message;
        }
    }
}