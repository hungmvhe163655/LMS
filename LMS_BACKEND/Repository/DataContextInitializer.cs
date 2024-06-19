using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Repository
{
    public static class DataContextInitializer
    {
        private static string Uppercase(string name) { return name.ToUpper(); }
        public static void SeedData(this Microsoft.EntityFrameworkCore.ModelBuilder builder)
        {
            // Thêm data tương ứng
            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = "355f5fcf-92f6-4ef8-b7c6-28aab481da76",
                        Name = "Teacher",
                        NormalizedName = Uppercase("SUPERVISOR"),
                        ConcurrencyStamp = ""
                    },
                    new IdentityRole
                    {
                        Id = "97f0f3bd-394b-462e-b7b0-0018b129a9db",
                        Name = "Student",
                        NormalizedName = Uppercase("STUDENT"),
                        ConcurrencyStamp = ""
                    },
                     new IdentityRole
                     {
                         Id = "b2ab0e08-6661-4deb-a531-6241b02e1170",
                         Name = "LabLead",
                         NormalizedName = Uppercase("LABADMIN"),
                         ConcurrencyStamp = ""
                     }
                );
            builder.Entity<Account>().HasData
             (
                 // mật khẩu Abc@123

                 new Account
                 {
                     Id = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
                     UserName = "minhContributor@gmail.com",
                     NormalizedUserName = Uppercase("minhContributor@gmail.com"),
                     Email = "minhContributor@gmail.com",
                     NormalizedEmail = Uppercase("minhContributor@gmail.com"),
                     EmailConfirmed = true,
                     PasswordHash = "AQAAAAEAACcQAAAAEJ51SmQrANatorjKkODvG7wRz8i73uIAUIHAmXRldg8ikayfZiaDQvbSOuY+XFPiJQ==",
                     PhoneNumberConfirmed = true,
                     TwoFactorEnabled = false,
                     LockoutEnabled = false,
                     AccessFailedCount = 0,
                     PhoneNumber = "0963661093",

                 }
             );

            builder.Entity<IdentityUserRole<string>>().HasData
                (
                    new IdentityUserRole<string>
                    {
                        RoleId = "355f5fcf-92f6-4ef8-b7c6-28aab481da76", //supervisor
                        UserId = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d"
                    }
                );
            builder.Entity<News>().HasData
                (
                   new News
                   {
                       Id = 1,
                       Title = "First News Title",
                       Content = "This is the content of the first news item.",
                       CreatedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", // Assuming 1 is a valid UserId in the Accounts table
                       CreatedDate = new DateTime(2023, 6, 18)
                   },
                new News
                {
                    Id = 2,
                    Title = "Second News Title",
                    Content = "This is the content of the second news item.",
                    CreatedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", // Assuming 2 is a valid UserId in the Accounts table
                    CreatedDate = new DateTime(2023, 6, 19)
                },
                new News
                {
                    Id = 3,
                    Title = "Third News Title",
                    Content = "This is the content of the second news item.",
                    CreatedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", // Assuming 2 is a valid UserId in the Accounts table
                    CreatedDate = new DateTime(2023, 6, 19)
                },
                new News
                {
                    Id = 4,
                    Title = "Fourth News Title",
                    Content = "This is the content of the second news item.",
                    CreatedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", // Assuming 2 is a valid UserId in the Accounts table
                    CreatedDate = new DateTime(2023, 6, 19)
                }
                );
        }
    }
}
