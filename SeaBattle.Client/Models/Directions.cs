using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeaBattle.Client.Models
{
    public class Directions
    {
        [Required(ErrorMessage = "Please enter direction")]
        public string Direction { get; set; }
    }
}