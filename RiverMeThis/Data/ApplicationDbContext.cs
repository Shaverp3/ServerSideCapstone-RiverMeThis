using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RiverMeThis.Models;

namespace RiverMeThis.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<River> River { get; set; }
        public DbSet<Sherpa> Sherpa { get; set; }
        public DbSet<AccessPoint> AccessPoint { get; set; }
        public DbSet<FloatTrip> FloatTrip { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                StreetAddress = "123 Infinity Way",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            // Create devices
            modelBuilder.Entity<Device>().HasData(
                new Device()
                {
                    DeviceId = 1,
                    Type = "Inner Tube/Pool Float"
                },
                new Device()
                {
                    DeviceId = 2,
                    Type = "Kayak/Canoe"
                },
                new Device()
                {
                    DeviceId = 3,
                    Type = "S.U.P."
                }
            );

            // Create Rivers
            modelBuilder.Entity<River>().HasData(
                new River()
                {
                    RiverId = 1,
                    Name = "Big Coal to Coal River",
                    TotalLength = 60,
                    NumAPs = 12,
                    MapPath = "CoalRiverWaterTrailMap.jpg"
                },
                new River()
                {
                    RiverId = 2,
                    Name = "Little Coal to Coal River",
                    TotalLength = 47,
                    NumAPs = 14,
                    MapPath = "CoalRiverWaterTrailMap.jpg"
                },
                new River()
                {
                    RiverId = 3,
                    Name = "Coal River",
                    TotalLength = 20,
                    NumAPs = 6,
                    MapPath = "CoalRiverWaterTrailMap.jpg"
                },
                new River()
                {
                    RiverId = 4,
                    Name = "Elk River",
                    TotalLength = 172,
                    NumAPs = 17,
                    MapPath = "ElkRiverWaterTrailMap.jpg"
                },
                new River()
                {
                    RiverId = 5,
                    Name = "Gyandotte River",
                    TotalLength = 166,
                    NumAPs = 24,
                    MapPath = "GyandotteRiverTrailMap.jpg"

                }
            );

            // Create AccessPoints
            modelBuilder.Entity<AccessPoint>().HasData(
                new AccessPoint()
                {
                    AccessPointId = 1,
                    Name = "Whitesville Public Access",
                    Location = "Whitesville, WV",
                    APIndex = 1,
                    ClassRapids = "I",
                    RiverId = 1
                },
                new AccessPoint()
                {
                    AccessPointId = 2,
                    Name = "JM Protan Community Center Public Access",
                    Location = "Orgas, WV",
                    APIndex = 2,
                    ClassRapids = "I",
                    RiverId = 1
                },
                new AccessPoint()
                {
                    AccessPointId = 3,
                    Name = "Madison City Park Public Access",
                    Location = "Madison, WV",
                    APIndex = 1,
                    ClassRapids = "I",
                    RiverId = 2
                },
                new AccessPoint()
                {
                    AccessPointId = 4,
                    Name = "Danville Community Center Public Access",
                    Location = "Danville, WV",
                    APIndex = 2,
                    ClassRapids = "I",
                    RiverId = 2
                },
                new AccessPoint()
                {
                    AccessPointId = 5,
                    Name = "Lock 4 Launch",
                    Location = "Alum Creek, WV",
                    APIndex = 1,
                    ClassRapids = "I",
                    RiverId = 3
                },
                new AccessPoint()
                {
                    AccessPointId = 6,
                    Name = "Lions Park Public Access",
                    Location = "Alum Creek, WV",
                    APIndex = 2,
                    ClassRapids = "I",
                    RiverId = 3
                },
                new AccessPoint()
                {
                    AccessPointId = 7,
                    Name = "Sutton Dam Tailwaters",
                    Location = "Sutton, WV",
                    APIndex = 1,
                    ClassRapids = "II",
                    RiverId = 4
                },
                new AccessPoint()
                {
                    AccessPointId = 8,
                    Name = "Cafe Cimino",
                    Location = "Sutton, WV",
                    APIndex = 2,
                    ClassRapids = "II",
                    RiverId = 4
                },
                new AccessPoint()
                {
                    AccessPointId = 9,
                    Name = "Three Mile Curve Access",
                    Location = "Mullens, WV",
                    APIndex = 1,
                    ClassRapids = "I",
                    RiverId = 5
                },
                new AccessPoint()
                {
                    AccessPointId = 10,
                    Name = "U.S. Post Office Access",
                    Location = "Stollings, WV",
                    APIndex = 2,
                    ClassRapids = "I",
                    RiverId = 5
                },
                new AccessPoint()
                {
                    AccessPointId = 11,
                    Name = "Donald Kuhn Juvenile Center Public Access",
                    Location = "Julian, WV",
                    APIndex = 3,
                    ClassRapids = "I",
                    RiverId = 2
                },
                new AccessPoint()
                {
                    AccessPointId = 12,
                    Name = "Big Earl's Campground",
                    Location = "Julian, WV",
                    APIndex = 4,
                    ClassRapids = "I",
                    RiverId = 2
                }
            );
        }
    }
}

