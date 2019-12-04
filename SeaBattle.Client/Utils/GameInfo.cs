using CreateAttribute;
using ORM.Models;
using SeaBattle.Client.Models;
using System.Collections.Generic;

namespace Battleship.Client.Utils
{
    public static class GameInfo
    {
        [Encryption(className: "CreateAttribute.EncryptionService", guid)]
        private const string guid = "C4CD33D6-8AC4-4034-b273-0E236D93";
        public static List<User> Users { get; } = new List<User>();

        public static Field Field { get; set; }

        public static GameState GameState { get; set; }
    }
}