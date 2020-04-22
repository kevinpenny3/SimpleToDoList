using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ToDoStatus> ToDoStatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Rose",
                LastName = "Wiz",
                UserName = "r@r.com",
                NormalizedUserName = "R@R.COM",
                Email = "r@r.com",
                NormalizedEmail = "R@R.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };

            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);


            modelBuilder.Entity<ToDoStatus>().HasData(
                new ToDoStatus()
                {
                    Id = 2,
                    Title = "ToDo",
                },
                new ToDoStatus()
                {
                    Id = 3,
                    Title = "InProgress",
                },
                 new ToDoStatus()
                 {
                     Id = 4,
                     Title = "Completed",
                 }

                 );
        }
    }
}
