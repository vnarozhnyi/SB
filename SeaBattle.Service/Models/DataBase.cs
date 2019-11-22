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
    public class DataBase
    {
        public const string guid = "6E97CA2F-CB30-4554-9088-830A79CACD1B";
        public void GetDBInitMap(int x, int y)
        {
            GameObjects.UnitOfWork.repository.Insert(new Field { X = x, Y = y });
        }

        public void GetDBAddShip(int id, BaseShip ship)
        {
            GameObjects.UnitOfWork.repository.Insert(new Directions { Id = id, Direction = ship.Direction.ToString() });
            GameObjects.UnitOfWork.repository.Insert(new Types { Id = id, TypeOf = ship.ShipType.ToString() });
            GameObjects.UnitOfWork.repository.Insert(new Ship { Id = id, Speed = ship.Speed, Range = ship.Range, Length = ship.Length, DirectionID = id, TypeID = id });
        }

        public void GetDBUpdateDirection(int id, Direction direction)
        {
            GameObjects.UnitOfWork.repository.Update(new Directions { Id = id, Direction = direction.ToString() });
        }

        public List<Ship> GetDBShips()
        {
            return GameObjects.UnitOfWork.repository.Select(new Ship { });
        }
    }
}