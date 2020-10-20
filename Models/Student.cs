using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTApi.Models
{
    public class Student
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
        public string DateOfBirth { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        [Key]
        public string Registration { get; set; }
        public int Session { get; set; }
        public string Department { get; set; }
        public string HallRoll { get; set; }

        public int? Room_Id { get; set; }
        [ForeignKey("Room_Id")]
        public Room Room { get; set; }

       public ICollection<User> User { get; set; }


    }
}