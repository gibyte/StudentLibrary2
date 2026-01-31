using Microsoft.EntityFrameworkCore;
using StudentLibrary2.Model;

namespace StudentLibrary2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
