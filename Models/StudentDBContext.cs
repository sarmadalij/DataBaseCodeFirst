using Microsoft.EntityFrameworkCore;

namespace DataBaseCodeFirst.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options) //call parent class constructor
        {
            
        }

        //represents database tables
        public DbSet<Student> Students { get; set; }
    }
}
