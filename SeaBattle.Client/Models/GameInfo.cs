using ORM.Models;
using System.Collections.Generic;

namespace SeaBattle.Client.Models
{
    public class GameInfo
    {
        public static List<User> Users { get; } = new List<User>();

        public static Field Field { get; set; } = new Field();

        public static List<Ship> Ships { get; set; } = new List<Ship>();

        public static GameState GameState { get; set; }
    }
}