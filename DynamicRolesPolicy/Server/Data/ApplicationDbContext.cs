using Duende.IdentityServer.EntityFramework.Options;
using DynamicRolesPolicy.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DynamicRolesPolicy.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var seedUser in this.GetSeedUsers())
            {
                builder.Entity<ApplicationUser>()
                    .HasData(data: new ApplicationUser
                    {
                        Id = seedUser.Id,
                        UserName = seedUser.UserName,
                        NormalizedUserName = seedUser.UserName.ToUpper(),
                        Email = seedUser.UserName,
                        NormalizedEmail = seedUser.UserName.ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = seedUser.PasswordHash,
                        SecurityStamp = seedUser.SecurityStamp,
                        LockoutEnabled = true
                    });
            }

            foreach (var seedRole in this.GetSeedRoles())
            {
                builder.Entity<IdentityRole>()
                    .HasData(data: new IdentityRole
                    {
                        Id = seedRole.Id,
                        Name = seedRole.Name,
                        NormalizedName = seedRole.Name.ToUpper()
                    });
            }


            foreach (var seedUserRole in this.GetSeedUserRoles())
            {
                builder.Entity<IdentityUserRole<string>>()
                    .HasData(data: new IdentityUserRole<string>
                    {
                        UserId = seedUserRole.UserId,
                        RoleId = seedUserRole.RoleId
                    });
            }
        }
    }
}