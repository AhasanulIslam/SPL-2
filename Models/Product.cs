using System.Collections.Generic;

namespace JWTApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Invertory> Invertory { get; set; }


    }
}