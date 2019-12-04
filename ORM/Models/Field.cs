using CreateAttribute;
using System;
using System.Collections.Generic;

namespace ORM.Models
{
    [Serializable]
    [System.Data.Linq.Mapping.Table(Name = "[Field]")]
    public class Field : ORMModel
    {
        [Encryption(className: "CreateAttribute.EncryptionService", guid)]
        private const string guid = "2BA764B7-B02B-49F7-9F21-34FF72Ef";
        //[SqlColumn("Id", "INT NOT NULL", IsPrimaryKey = true)]
        //public int Id { get; set; }

        [SqlColumn("X", "INT NOT NULL")]
        public int X { get; set; }

        [SqlColumn("Y", "INT NOT NULL")]
        public int Y { get; set; }

        //public List<Ship> ShipsList { get; set; }
    }
}