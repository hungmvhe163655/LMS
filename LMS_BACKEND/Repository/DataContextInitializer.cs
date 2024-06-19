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
                        Id = "db1782c7-bf14-41f7-bc1f-950128ecb3bd",
                        Name = "User",
                        NormalizedName = Uppercase("User"),
                        ConcurrencyStamp = "b11bbed6-4919-4f52-a4b1-c45091a8fbf0"
                    },
                    new IdentityRole
                    {
                        Id = "db5782c7-bf14-41f7-bc1f-950128ecb3bb",
                        Name = "Blog Owner",
                        NormalizedName = Uppercase("Blog Owner"),
                        ConcurrencyStamp = "b31bbed6-4919-4f52-a4b1-c45091a8fbf0"
                    },
                     new IdentityRole
                     {
                         Id = "e94a9bca-5a7a-4806-b8cd-97e9075ff13a",
                         Name = "Contributor",
                         NormalizedName = Uppercase("Contributor"),
                         ConcurrencyStamp = "e22ebaa4-db51-4cb3-8f37-ad4ba73b0e1e"
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
                     PhoneNumber = "0985695635",

                 }
             );

            builder.Entity<IdentityUserRole<string>>().HasData
                (
                    new IdentityUserRole<string>
                    {
                        RoleId = "e94a9bca-5a7a-4806-b8cd-97e9075ff13a",
                        UserId = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d"
                    }
                    //,
                    //new IdentityUserRole<string>
                    //{
                    //    RoleId = "db5782c7-bf14-41f7-bc1f-950128ecb3bb",
                    //    UserId = "21842bcb-fae8-4c00-9c33-de997d4e8103"
                    //},
                    //new IdentityUserRole<string>
                    //{
                    //    RoleId = "db1782c7-bf14-41f7-bc1f-950128ecb3bd",
                    //    UserId = "21811bcb-fae8-4c00-9c33-de997d4e8107"
                    //},
                    //new IdentityUserRole<string>
                    //{
                    //    RoleId = "db1782c7-bf14-41f7-bc1f-950128ecb3bd",
                    //    UserId = "b0446349-235d-4b0f-a8e9-87382a82923f"
                    //}
                );
        }
    }
}
