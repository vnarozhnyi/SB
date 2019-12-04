using System;
using System.ComponentModel.DataAnnotations;

namespace ORM.Models
{
    [Serializable]
    [System.Data.Linq.Mapping.Table(Name = "[Ship]")]
    public class Ship : ORMModel
    {
        public enum Types { Carrier, Main, Support }
        public enum Directions { Up, Down, Left, Right }
        public int X { get; set; }
        public int Y { get; set; }

        //[SqlColumn("Id", "INT NOT NULL", IsPrimaryKey = true)]
        //public int Id { get; set; }

        [SqlColumn("Speed", "INT NOT NULL")]
        public int Speed { get; set; }

        [SqlColumn("Range", "INT NOT NULL")]
        public int Range { get; set; }

        [SqlColumn("Length", "INT NOT NULL")]
        public int Length { get; set; }

        [SqlColumn("Type", "INT NOT NULL")]
        public Types Type { get; set; }

        [SqlColumn("Direction", "INT NOT NULL")]
        public Directions Direction { get; set; }
    }
}
