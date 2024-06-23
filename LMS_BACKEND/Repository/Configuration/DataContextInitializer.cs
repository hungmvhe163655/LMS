using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Repository.Configuration
{
    public static class DataContextInitializer
    {
        public static void SeedData(this Microsoft.EntityFrameworkCore.ModelBuilder builder)
        {
            PasswordHasher<Account> passwordHasher = new PasswordHasher<Account>();

            Account user1 = new Account()
            {
                Id = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
                UserName = "minhtche161354",
                NormalizedUserName = ("minhtche161354").ToUpper(),
                Email = "minhtche161354@fpt.edu.vn",
                NormalizedEmail = ("minhtche161354@fpt.edu.vn").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0963661093",
                CreatedDate = DateTime.Now,
                Gender = false,
                isDeleted = false,
                isBanned = false,
                isVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAELgUn5wJH9empSyZm7MdUy84spVESi+LvNCV8nDY9PMgoY0fOBYhfZO/MPZHjSZimA==",
            };

            Account user2 = new Account()
            {
                Id = "6c6abe62-f811-4a8b-96eb-ed326c47d209",
                UserName = "thailshe160614",
                NormalizedUserName = ("thailshe160614").ToUpper(),
                Email = "thailshe160614@fpt.edu.vn",
                NormalizedEmail = ("thailshe160614@fpt.edu.vn").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0497461220",
                CreatedDate = DateTime.Now,
                Gender = false,
                isDeleted = false,
                isBanned = false,
                isVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEO5SGANyOkCieJN+MspCJeIbBLjDruXYD5omO5+7u9NVKctIo979jEts1uoDaalzTw==",
            };

            Account user3 = new Account()
            {
                Id = "a687bb04-4f19-49d5-a60f-2db52044767c",
                UserName = "hungmvhe163655",
                NormalizedUserName = ("hungmvhe163655").ToUpper(),
                Email = "hungmvhe163655@fpt.edu.vn",
                NormalizedEmail = ("hungmvhe163655@fpt.edu.vn").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0975461220",
                CreatedDate = DateTime.Now,
                Gender = false,
                isDeleted = false,
                isBanned = false,
                isVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHaY3BZO2ooRDvclwsiVvksAaPExz0GAXkEHlfwAtwfVBfRcw9gQTR02USItL9NrSg==",

            };

            Account user4 = new Account()
            {
                Id = "603600b5-ca65-4fa7-817e-4583ef22b330",
                UserName = "cuongndhe163098",
                NormalizedUserName = ("cuongndhe163098").ToUpper(),
                Email = "cuongndhe163098@fpt.edu.vn",
                NormalizedEmail = ("cuongndhe163098@fpt.edu.vn").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0975465220",
                CreatedDate = DateTime.Now,
                Gender = false,
                isDeleted = false,
                isBanned = false,
                isVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAENVZ95qV36S0GH4gzip/nSmI9JKDA1CAGuL2+t1ysccrtPgGLrSZ6k9v/tS37ojoSw==",
            };

            Account user5 = new Account()
            {
                Id = "68fdf17c-7cbe-4a4c-a674-c530ffc77667",
                UserName = "hoangnmhe163884",
                NormalizedUserName = ("hoangnmhe163884").ToUpper(),
                Email = "hoangnmhe163884@fpt.edu.vn",
                NormalizedEmail = ("hoangnmhe163884@fpt.edu.vn").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0975765220",
                CreatedDate = DateTime.Now,
                Gender = false,
                isDeleted = false,
                isBanned = false,
                isVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEBSeWGYcWJzo0jTXDBqXgYkMmzdQCRKsLrFMaaqieAdCHchkvB2oa1eRy3gsuvWyVw==",
            };

            Account user6 = new Account()
            {
                Id = "7397c854-194b-4749-9205-f46e4f2fccf8",
                UserName = "littlejohn",
                NormalizedUserName = ("littlejohn").ToUpper(),
                Email = "littlejohn123@gmail.com",
                NormalizedEmail = ("littlejohn123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965765228",
                CreatedDate = DateTime.Now,
                Gender = false,
                isDeleted = false,
                isBanned = false,
                isVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };

            Account user7 = new Account()
            {
                Id = "6ad0a020-e6a6-4e66-8f4a-d815594ba862",
                UserName = "kenshiyonezu",
                NormalizedUserName = ("kenshiyonezu").ToUpper(),
                Email = "kenshiyonezu123@gmail.com",
                NormalizedEmail = ("kenshiyonezu123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965765120",
                CreatedDate = DateTime.Now,
                Gender = false,
                isDeleted = false,
                isBanned = false,
                isVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };

            Account user8 = new Account()
            {
                Id = "1c5c3b44-7164-4232-a49a-10ab367d5102",
                UserName = "gakkou",
                NormalizedUserName = ("gakkou").ToUpper(),
                Email = "gakkou123@gmail.com",
                NormalizedEmail = ("gakkou123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965795220",
                CreatedDate = DateTime.Now,
                Gender = false,
                isDeleted = false,
                isBanned = false,
                isVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };

            builder.Entity<Account>().HasData(user1, user2, user3, user4, user5, user6, user7, user8);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "c55924f5-4cf4-4a29-9820-b5d0d9bdf3c5",
                    UserId = user1.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user2.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user3.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d",
                    UserId = user4.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d",
                    UserId = user5.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d",
                    UserId = user6.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d",
                    UserId = user7.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d",
                    UserId = user8.Id,
                }

            );

            builder.Entity<StudentDetail>().HasData(
                new StudentDetail()
                {
                    AccountId = user4.Id,
                    Major = "Software Engineering",
                    Specialized = "ASP.NET",
                    RollNumber = "HE163098"
                },
                new StudentDetail()
                {
                    AccountId = user5.Id,
                    Major = "Data Engineer",
                    Specialized = "Data Analyst",
                    RollNumber = "HE163884"
                },
                new StudentDetail()
                {
                    AccountId = user6.Id,
                    Major = "Artifact Intelligent",
                    Specialized = "C",
                    RollNumber = "HE163956"
                },
                new StudentDetail()
                {
                    AccountId = user7.Id,
                    Major = "Iot",
                    Specialized = "Python",
                    RollNumber = "HE145689"
                },
                new StudentDetail()
                {
                    AccountId = user8.Id,
                    Major = "Software Engineering",
                    Specialized = "PHP",
                    RollNumber = "HE156894"
                }
            );
        }
    }
}
