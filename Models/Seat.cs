using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Seat
    {
        public int SeatId { get; set; }

        [RegularExpression("[0-9]+,[0-9]+", ErrorMessage = "Invalid Value, Pos must be in int,int format")]
        public string Pos { get; set; }
        public bool Occupied { get; set; }
    }
}
