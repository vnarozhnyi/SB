using BattleShip;
using CreateAttribute;
using ORM;
using ORM.Models;

namespace SeaBattle.Service.Objects
{
    public static class GameObjects
    {
        [Encryption(className: "CreateAttribute.EncryptionService", guid)]
        private const string guid = "C4CD33D6-8AC4-4034-b273-0E236D93";
        public static string ConnectionString { get; } = @"Data Source=.\SQLEXPRESS;Initial Catalog=BattleShipDB;Integrated Security=True";
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int[,] Shoot { get; set; }
        public static int[,] Repair { get; set; }
        public static int Count { get; set; }
        public static Field Field { get; set; } = new Field();
        public static Ship Ship { get; set; } = new Ship();
        //public static CarrierShip Carrier { get; set; }
        //public static SupportingShip Supporting { get; set; }
        //public static MainShip Main { get; set; }
        public static UnitOfWork UnitOfWork { get; set; } = new UnitOfWork(ConnectionString);
        public static BattleField BattleField { get; set; } = new BattleField();
    }
}