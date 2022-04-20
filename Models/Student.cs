using System;
namespace FinalProject.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public Seat? Seat { get; set; }
    }
}
