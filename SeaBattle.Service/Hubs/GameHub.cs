using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BattleShip;
using Microsoft.AspNet.SignalR;
using SeaBattle.Service.Objects;

namespace SeaBattle.Service.Hubs
{
    public class GameHub : Hub
    {
        public void GetAddMainShip(int length, int range, int speed, Direction direction)
        {
            GameObjects.main = new MainShip(length, range, speed, direction);
        }

        public void GetShootMainShip(int x, int y)
        {
            GameObjects.main.Shoot(x, y);
        }

        public void GetRepairMainShip(int x, int y)
        {
            GameObjects.main.Repair(x, y);
        }

        public void GetMoveMainShip(Direction direction)
        {
            GameObjects.main.Move(direction);
        }

        public void GetAddCarrierShip(int length, int range, int speed, Direction direction)
        {
            GameObjects.carrier = new CarrierShip(length, range, speed, direction);
        }

        public void GetShootCarrierShip(int x, int y)
        {
            GameObjects.carrier.Shoot(x, y);
        }

        public void GetMoveCarrierShip(Direction direction)
        {
            GameObjects.carrier.Move(direction);
        }

        public void GetAddSupportingShip(int length, int range, int speed, Direction direction)
        {
            GameObjects.supporting = new SupportingShip(length, range, speed, direction);
        }

        public void GetRepairSupportingShip(int x, int y)
        {
            GameObjects.supporting.Repair(x, y);
        }

        public void GetMoveSupportingShip(Direction direction)
        {
            GameObjects.supporting.Move(direction);
        }

        public int GetInitMap()
        {
            int x = new Random().Next(50, 100);
            int y = new Random().Next(50, 100);
            GameObjects.battleField.InitMap(x, y);
            return GameObjects.battleField.GetHashCode();
        }

        public int GetAddShip(int x, int y, BaseShip ship)
        {
            GameObjects.battleField.AddShip(x, y, ship);
            return ship.GetHashCode();
        }

        public void GetMove(Direction direction, BaseShip ship)
        {
            ship.Move(direction);
            Clients.Caller.message($"MOVE {direction}");
        }

        public void GetShoot(int x, int y)
        {
            if (GameObjects.battleField.Map[x, y] == 1)
            {
                GameObjects.battleField.Map[x, y] = 2;
                GameObjects.shoot[GameObjects.X = x, GameObjects.Y = y] = 1;
                Clients.Others.message("HIT");
            }
            else
                Clients.Others.message("MISS");
            {
                GameObjects.shoot[GameObjects.X = x, GameObjects.Y = y] = 0;
            }
            for (int a = 0; a < (GameObjects.ship.Length + 1); a++)
            {
                if (GameObjects.battleField.Map[x, y] == 2)
                {
                    GameObjects.count++;
                }
            }
            if (GameObjects.ship.Length == GameObjects.count)
            {
                Clients.Others.message("SHIP DESTROYED");
            }
        }

        public void GetRepair(int x, int y)
        {
            if (GameObjects.battleField.Map[x, y] == 2)
            {
                GameObjects.battleField.Map[x, y] = 0;
                GameObjects.repair[GameObjects.X = x, GameObjects.Y = y] = 1;
                Clients.Others.message("REPAIRED");
            }
            else
            {
                GameObjects.repair[GameObjects.X = x, GameObjects.Y = y] = 0;
                Clients.Others.message("MISS");
            }
        }
    }
}