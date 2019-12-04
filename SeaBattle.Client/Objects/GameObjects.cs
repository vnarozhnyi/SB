using ORM.Models;
using System.Runtime.InteropServices;

namespace SeaBattle.Client.Objects
{
    [GuidAttribute(guid)]
    // [Encryption(className: "CreateAttribute.EncryptionService", parametrs: new object[] { guid })]
    public static class GameObjects
    {
        private const string guid = "C4CD33D6-8AC4-4034-b273-0E236D932A57";
        public static Field FieldMap { get; set; } = new Field();
        public static Ship Ships { get; set; } = new Ship();
    }
}