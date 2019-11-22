using BattleShip;
using ORM;
using ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaBattle.Service.Objects
{
    public class GameObjects
    {
        public static string connectionString { get; } = @"Data Source=.\SQLEXPRESS;Initial Catalog=BattleShipDB;Integrated Security=True";
        public static string guid { get; set; }
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int[,] shoot { get; set; }
        public static int[,] repair { get; set; }
        public static int count { get; set; }
        public static Field field { get; set; } = new Field();
        public static Directions directions { get; set; } = new Directions();
        public static Ship ship { get; set; } = new Ship();
        public static CarrierShip carrier { get; set; }
        public static SupportingShip supporting { get; set; }
        public static MainShip main { get; set; }
        public static UnitOfWork unitOfWork { get; }
        public static BattleField battleField { get; set; } = new BattleField();
    }
}