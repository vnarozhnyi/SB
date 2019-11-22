using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeaBattle.Client.Models
{
    public class Ship
    {
        [Required(ErrorMessage = "Please enter id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter speed")]
        public int Speed { get; set; }

        [Required(ErrorMessage = "Please enter range")]
        public int Range { get; set; }

        [Required(ErrorMessage = "Please enter length")]
        public int Length { get; set; }

        [Required(ErrorMessage = "Please enter type id")]
        public int TypeID { get; set; }

        public Types Type { get; set; }

        [Required(ErrorMessage = "Please enter direction id")]
        public int DirectionID { get; set; }

        public Directions Direction { get; set; }
    }
}
