using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DesafioManipulae.Domain.Indentity;
using DesafioManipulae.Domain;

namespace DesafioManipulae.Repository
{
    public class DesafioManipulaeContext : IdentityDbContext<User, Role, int,
                                           IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                           IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DesafioManipulaeContext(DbContextOptions<DesafioManipulaeContext> options) : base(options) { }
        public DbSet<VideoList> VideosLists {get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}