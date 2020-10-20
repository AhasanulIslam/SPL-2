using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JWTApi.Models
{
    public class Room
    {
        [Key]
        public int Room_Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public string Building { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}