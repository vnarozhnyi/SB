using CreateAttribute;
using ORM.Models;
using SeaBattle.Service.Objects;

namespace SeaBattle.Service.Models
{
    [Encryption(className: "CreateAttribute.EncryptionService", guid)]
    public static class DataBase
    {
        private const string guid = "6E97CA2F-CB30-4554-9088-830A79CA";
        public static void GetDBInitMap(int x, int y)
        {
            GameObjects.UnitOfWork.repository.Insert(new Field { X = x, Y = y });
        }

        public static void GetDBAddShip(Ship ship)
        {
            //GameObjects.Ships.Add(ship);
            GameObjects.UnitOfWork.repository.Insert(new Field { X = ship.X, Y = ship.Y });
            GameObjects.UnitOfWork.repository.Insert(new Ship { Speed = ship.Speed, Range = ship.Range, Length = ship.Length, Direction = ship.Direction, Type = ship.Type });
        }
    }
}