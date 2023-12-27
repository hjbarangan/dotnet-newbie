using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet_newbie.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dotnet_newbie.Data
{
    public class dotnet_newbieContext : DbContext
    {
        public dotnet_newbieContext(DbContextOptions<dotnet_newbieContext> options)
            : base(options)
        {
        }

        public DbSet<dotnet_newbie.Models.Role> Role { get; set; } = default!;
        public DbSet<dotnet_newbie.Models.User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // default behavior to always store and retrieve DateTime values in UTC
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                            v => v.ToUniversalTime(),
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
                    }
                }
            }
        }

    }
}
