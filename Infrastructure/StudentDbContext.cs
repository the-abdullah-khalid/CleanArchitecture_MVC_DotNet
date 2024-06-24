using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
