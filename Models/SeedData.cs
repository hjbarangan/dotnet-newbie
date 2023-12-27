using dotnet_newbie.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dotnet_newbie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new dotnet_newbieContext(
             serviceProvider.GetRequiredService<
                 DbContextOptions<dotnet_newbieContext>>()))
        {
            // Look for any movies.
            if (context.Role.Any())
            {
                return;   // DB has been seeded
            }
            context.Role.AddRange(
                new Role
                {
                    Name = "Admin",
                    CreatedAt = DateTime.Parse("1989-2-12")
                },
                new Role
                {
                    Name = "Secretary",
                    CreatedAt = DateTime.Parse("1989-2-12")
                }

            );
            context.SaveChanges();
        }
    }
}
