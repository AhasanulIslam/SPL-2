using Microsoft.EntityFrameworkCore;

namespace JWTApi.Models.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}


            public DbSet<Values> Values{get; set; }
        
    
         
    }
}