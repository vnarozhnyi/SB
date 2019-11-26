using BattleShip;
using CreateAttribute;
using ORM.Model;
using SeaBattle.Service.Objects;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SeaBattle.Service.Models
{
    [GuidAttribute(guid)]
    [Encryption(className: "CreateAttribute.EncryptionService", parametrs: new object[] { guid })]
    public static class DataBase
    {
        public const string guid = "6E97CA2F-CB30-4554-9088-830A79CACD1B";
        public static void GetDBInitMap(int x, int y)
        {
            GameObjects.UnitOfWork.repository.Insert(new Field { X = x, Y = y });
        }

        public static void GetDBAddShip(BaseShip ship)
        {
            int id = 1;
            GameObjects.UnitOfWork.repository.Insert(new Directions { Id = id++, Direction = ship.Direction.ToString() });
            GameObjects.UnitOfWork.repository.Insert(new Types { Id = id++, TypeOf = ship.ShipType.ToString() });
            GameObjects.UnitOfWork.repository.Insert(new Ship { Speed = ship.Speed, Range = ship.Range, Length = ship.Length, DirectionID = id, TypeID = id });
        }

        public static void GetDBUpdateDirection(Direction direction)
        {
            GameObjects.UnitOfWork.repository.Update(new Directions { Direction = direction.ToString() });
        }

        //public static List<Ship> GetDBShips()
        //{
        //    return GameObjects.UnitOfWork.repository.Select(new Ship { });
        //}
    }
}