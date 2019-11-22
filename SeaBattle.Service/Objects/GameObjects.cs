using BattleShip;
using CreateAttribute;
using ORM;
using ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace SeaBattle.Service.Objects
{
    [GuidAttribute(guid)]
    [Encryption(className: "CreateAttribute.EncryptionService", parametrs: new object[] { guid })]
    public static class GameObjects
    {
        public const string guid = "640E6FD5-9DAD-41C1-8965-A769061145D7";
        public static string ConnectionString { get; } = @"Data Source=.\SQLEXPRESS;Initial Catalog=BattleShipDB;Integrated Security=True";
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int[,] Shoot { get; set; }
        public static int[,] Repair { get; set; }
        public static int Count { get; set; }
        public static Field Field { get; set; } = new Field();
        public static Directions Direction { get; set; } = new Directions();
        public static Ship Ship { get; set; } = new Ship();
        public static CarrierShip Carrier { get; set; }
        public static SupportingShip Supporting { get; set; }
        public static MainShip Main { get; set; }
        public static UnitOfWork UnitOfWork { get; set; } = new UnitOfWork(ConnectionString);
        public static BattleField BattleField { get; set; } = new BattleField();
    }
}