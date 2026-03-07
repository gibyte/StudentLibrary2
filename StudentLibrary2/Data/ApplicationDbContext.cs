using Microsoft.EntityFrameworkCore;
using StudentLibrary2.Model;
using StudentLibrary2.Model.AuthApp;

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
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }

    }
}
