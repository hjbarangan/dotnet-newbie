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

            if (context.Role.Any())
                // if (context.Role.Any() && context.User.Any())
                {
                    return;   // DB has been seeded
                }
            context.Role.AddRange(
                new Role
                {
                    Name = "Admin",
                    CreatedAt = DateTime.Parse("2023-12-28")
                },
                new Role
                {
                    Name = "Secretary",
                    CreatedAt = DateTime.Parse("2023-12-28")
                }

            );

            // context.User.AddRange(
            //     new User
            //     {
            //         Firstname = "Herzlia Jane",
            //         Lastname = "Barangan",
            //         Birthdate = DateTime.Parse("2000-03-02"),
            //         Email = "admin@gmail.com",
            //         Password = "123456",
            //         RoleId = 1,
            //         CreatedAt = DateTime.Parse("2023-12-28")
            //     }
            // );
            context.SaveChanges();
        }
    }
}
