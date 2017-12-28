using Microsoft.EntityFrameworkCore;

using AspNetIdentityExample.Models;

namespace AspNetIdentityExample
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoleJoin>().HasOne(j => j.User).WithMany(u => u.RoleJoins);
            modelBuilder.Entity<UserRoleJoin>().HasOne(j => j.Role).WithMany();
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
