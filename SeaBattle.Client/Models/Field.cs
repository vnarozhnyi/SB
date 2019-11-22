using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaBattle.Client.Models
{
    public class Field
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<Ship> ShipsList { get; set; }
    }
}