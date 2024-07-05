using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration
{
    public static class DataContextInitializer
    {
        public static void SeedData(this Microsoft.EntityFrameworkCore.ModelBuilder builder)
        {
            Account user1 = new Account()
            {
                Id = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
                UserName = "minhtche161354",
                FullName = "Tran Cong Minh",
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
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAELgUn5wJH9empSyZm7MdUy84spVESi+LvNCV8nDY9PMgoY0fOBYhfZO/MPZHjSZimA==",
            };

            Account user2 = new Account()
            {
                Id = "6c6abe62-f811-4a8b-96eb-ed326c47d209",
                UserName = "thailshe160614",
                FullName = "Le Sy Thai",
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
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEO5SGANyOkCieJN+MspCJeIbBLjDruXYD5omO5+7u9NVKctIo979jEts1uoDaalzTw==",
            };

            Account user3 = new Account()
            {
                Id = "a687bb04-4f19-49d5-a60f-2db52044767c",
                UserName = "hungmvhe163655",
                FullName = "Mai Viet Hung",
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
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHaY3BZO2ooRDvclwsiVvksAaPExz0GAXkEHlfwAtwfVBfRcw9gQTR02USItL9NrSg==",

            };

            Account user4 = new Account()
            {
                Id = "603600b5-ca65-4fa7-817e-4583ef22b330",
                UserName = "cuongndhe163098",
                FullName = "Nguyen Duc Cuong",
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
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
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
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEBSeWGYcWJzo0jTXDBqXgYkMmzdQCRKsLrFMaaqieAdCHchkvB2oa1eRy3gsuvWyVw==",
            };

            Account user6 = new Account()
            {
                Id = "7397c854-194b-4749-9205-f46e4f2fccf8",
                UserName = "littlejohn",
                NormalizedUserName = ("littlejohn").ToUpper(),
                FullName = "John",
                Email = "littlejohn123@gmail.com",
                NormalizedEmail = ("littlejohn123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965765228",
                CreatedDate = DateTime.Now,
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };

            Account user7 = new Account()
            {
                Id = "6ad0a020-e6a6-4e66-8f4a-d815594ba862",
                UserName = "kenshiyonezu",
                FullName = "Kenshi Yonezu",
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
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };

            Account user8 = new Account()
            {
                Id = "1c5c3b44-7164-4232-a49a-10ab367d5102",
                UserName = "gakkou",
                FullName = "Gakkou Atarashi",
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
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
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

            Notification noti1 = new Notification
            {
                Id = new Guid("e331de18-289c-403d-8028-26c4b595587a"),
                Title = "System Update",
                Content = "A new system update will be available tomorrow.",
                CreatedDate = DateTime.Now.AddDays(-1),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = user1.Id,
            };

            Notification noti2 = new Notification
            {
                Id = new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"),
                Title = "Maintenance Notice",
                Content = "Scheduled maintenance will occur this weekend.",
                CreatedDate = DateTime.Now.AddDays(-2),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = user1.Id,
            };

            Notification noti3 = new Notification
            {
                Id = new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"),
                Title = "New Feature Release",
                Content = "We are excited to announce a new feature in our application.",
                CreatedDate = DateTime.Now.AddDays(-3),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = user1.Id,
            };

            Notification noti4 = new Notification
            {
                Id = new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"),
                Title = "Security Alert",
                Content = "Please update your password to enhance security.",
                CreatedDate = DateTime.Now.AddDays(-4),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = user2.Id,
            };

            Notification noti5 = new Notification
            {
                Id = new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"),
                Title = "Downtime Notification",
                Content = "The system will be down for maintenance tonight.",
                CreatedDate = DateTime.Now.AddDays(-5),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = user3.Id,
            };

            Notification noti6 = new Notification
            {
                Id = new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"),
                Title = "Weekly Meeting",
                Content = "Join weekly meeting.",
                CreatedDate = DateTime.Now.AddDays(-6),
                Url = "",
                NotificationTypeId = 2,
                CreatedBy = user3.Id,
            };

            Notification noti7 = new Notification
            {
                Id = new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"),
                Title = "Promotion Alert",
                Content = "Don't miss out on our latest promotions!",
                CreatedDate = DateTime.Now.AddDays(-7),
                Url = "",
                NotificationTypeId = 2,
                CreatedBy = user3.Id,
            };

            Notification noti8 = new Notification
            {
                Id = new Guid("931129a9-986f-4560-99f1-a06b692c71a1"),
                Title = "Survey Request",
                Content = "Please take a moment to complete our user survey.",
                CreatedDate = DateTime.Now.AddDays(-8),
                Url = "",
                NotificationTypeId = 2,
                CreatedBy = user2.Id,
            };

            Notification noti9 = new Notification
            {
                Id = new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"),
                Title = "Account Notice",
                Content = "Your account details have been updated.",
                CreatedDate = DateTime.Now.AddDays(-9),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = user1.Id,
            };

            Notification noti10 = new Notification
            {
                Id = new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"),
                Title = "Event Reminder",
                Content = "Don't forget about the event tomorrow!",
                CreatedDate = DateTime.Now.AddDays(-10),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = user1.Id,
            };

            builder.Entity<Notification>().HasData(noti1, noti2, noti3, noti4, noti5, noti6, noti7, noti8, noti9, noti10);
            builder.Entity<NotificationType>().HasData(
                new NotificationType
                {
                    Id= 1,
                    Name = "System",
                },
                new NotificationType
                {
                    Id = 2,
                    Name = "Project",
                }
            );
            builder.Entity<NotificationAccount>().HasData(
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti1.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user2.Id,
                    NotificationId = noti1.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti1.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti1.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user5.Id,
                    NotificationId = noti1.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti1.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user7.Id,
                    NotificationId = noti1.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user8.Id,
                    NotificationId = noti1.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti2.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user2.Id,
                    NotificationId = noti2.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti2.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti2.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user5.Id,
                    NotificationId = noti2.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti2.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user7.Id,
                    NotificationId = noti2.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user8.Id,
                    NotificationId = noti2.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti3.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user2.Id,
                    NotificationId = noti3.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti3.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti3.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user5.Id,
                    NotificationId = noti3.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti3.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user7.Id,
                    NotificationId = noti3.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user8.Id,
                    NotificationId = noti3.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti4.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user2.Id,
                    NotificationId = noti4.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti4.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti4.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user5.Id,
                    NotificationId = noti4.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti4.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user7.Id,
                    NotificationId = noti4.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user8.Id,
                    NotificationId = noti4.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti5.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user2.Id,
                    NotificationId = noti5.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti5.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti5.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user5.Id,
                    NotificationId = noti5.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti5.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user7.Id,
                    NotificationId = noti5.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user8.Id,
                    NotificationId = noti5.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti6.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user2.Id,
                    NotificationId = noti6.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti6.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti6.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user5.Id,
                    NotificationId = noti6.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti6.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user7.Id,
                    NotificationId = noti6.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user8.Id,
                    NotificationId = noti6.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti7.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user2.Id,
                    NotificationId = noti7.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti7.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti7.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user5.Id,
                    NotificationId = noti7.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti7.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user7.Id,
                    NotificationId = noti7.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user8.Id,
                    NotificationId = noti7.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti8.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user2.Id,
                    NotificationId = noti8.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti8.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti8.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user5.Id,
                    NotificationId = noti8.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti8.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user7.Id,
                    NotificationId = noti8.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user8.Id,
                    NotificationId = noti8.Id,
                    IsRead = true,
                }, 
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti9.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user2.Id,
                    NotificationId = noti9.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti9.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti9.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user5.Id,
                    NotificationId = noti9.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti9.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user7.Id,
                    NotificationId = noti9.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user8.Id,
                    NotificationId = noti9.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti10.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user2.Id,
                    NotificationId = noti10.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti10.Id,
                    IsRead = false,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti10.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user5.Id,
                    NotificationId = noti10.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti10.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user7.Id,
                    NotificationId = noti10.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user8.Id,
                    NotificationId = noti10.Id,
                    IsRead = true,
                }
            );

            News news1 = new News
            {
                Id = new Guid("efb06517-4673-4b44-bf11-ee12198c26a7"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 1),
                Content = "This is the content of news item 1.",
                Title = "News Title 1"
            };

            News news2 = new News
            {
                Id = new Guid("7c712eff-f7d8-41af-a36c-9d7ce1439e3b"),
                CreatedBy = user2.Id,
                CreatedDate = new DateTime(2024, 5, 2),
                Content = "This is the content of news item 2.",
                Title = "News Title 2"
            };

            News news3 = new News
            {
                Id = new Guid("cfc8a241-628f-4fab-acaf-60ffd42f97cd"),
                CreatedBy = user3.Id,
                CreatedDate = new DateTime(2024, 5, 3),
                Content = "This is the content of news item 3.",
                Title = "News Title 3"
            };

            News news4 = new News
            {
                Id = new Guid("650204d7-0be6-4f91-89f7-d80572d4f76a"),
                CreatedBy = user3.Id,
                CreatedDate = new DateTime(2024, 5, 4),
                Content = "This is the content of news item 4.",
                Title = "News Title 4"
            };

            News news5 = new News
            {
                Id = new Guid("049d2c9c-f550-4e21-8911-efc5789106ec"),
                CreatedBy = user3.Id,
                CreatedDate = new DateTime(2024, 5, 5),
                Content = "This is the content of news item 5.",
                Title = "News Title 5"
            };

            News news6 = new News
            {
                Id = new Guid("6798cf4d-8399-4572-955e-595ddf13f292"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 6),
                Content = "This is the content of news item 6.",
                Title = "News Title 6"
            };

            News news7 = new News
            {
                Id = new Guid("a491e3db-344e-4f16-a051-1ed491901340"),
                CreatedBy = user2.Id,
                CreatedDate = new DateTime(2024, 5, 7),
                Content = "This is the content of news item 7.",
                Title = "News Title 7"
            };

            News news8 = new News
            {
                Id = new Guid("c0268d79-cfd7-44c3-9b13-709869ae00e2"),
                CreatedBy = user3.Id,
                CreatedDate = new DateTime(2024, 5, 8),
                Content = "This is the content of news item 8.",
                Title = "News Title 8"
            };

            News news9 = new News
            {
                Id = new Guid("f3e39c12-df43-4e2a-b84e-92374739e0e9"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 9),
                Content = "This is the content of news item 9.",
                Title = "News Title 9"
            };

            News news10 = new News
            {
                Id = new Guid("663c5d19-d3ed-4d6a-aff6-3997dd0c43c4"),
                CreatedBy = user2.Id,
                CreatedDate = new DateTime(2024, 5, 10),
                Content = "This is the content of news item 10.",
                Title = "News Title 10"
            };

            News news11 = new News
            {
                Id = new Guid("6e08720f-d73a-4ae1-be83-559dbb96a344"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 11),
                Content = "This is the content of news item 11.",
                Title = "News Title 11"
            };

            News news12 = new News
            {
                Id = new Guid("14764db6-10f1-48e6-a4e8-3ae063814acf"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 12),
                Content = "This is the content of news item 12.",
                Title = "News Title 12"
            };

            News news13 = new News
            {
                Id = new Guid("f0c49374-4c7d-464a-9f38-e6f59b20344d"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 13),
                Content = "This is the content of news item 13.",
                Title = "News Title 13"
            };

            News news14 = new News
            {
                Id = new Guid("0da0b088-1b08-404b-9696-eb539d31c9e5"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 14),
                Content = "This is the content of news item 14.",
                Title = "News Title 14"
            };

            News news15 = new News
            {
                Id = new Guid("5d0bfb1c-d68d-450e-8fe9-e7d94be4eaac"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 15),
                Content = "This is the content of news item 15.",
                Title = "News Title 15"
            };

            News news16 = new News
            {
                Id = new Guid("0985634f-496f-4480-83f0-14ff0c30b002"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 16),
                Content = "This is the content of news item 16.",
                Title = "News Title 16"
            };

            News news17 = new News
            {
                Id = new Guid("245b3c4d-ba95-4040-818d-23da69f08e9b"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 17),
                Content = "This is the content of news item 17.",
                Title = "News Title 17"
            };

            News news18 = new News
            {
                Id = new Guid("e277ec7f-14cf-47a2-a234-1265920647a4"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 18),
                Content = "This is the content of news item 18.",
                Title = "News Title 18"
            };

            News news19 = new News
            {
                Id = new Guid("fb4d071c-c460-4a01-8ee4-9247a97214a6"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 19),
                Content = "This is the content of news item 19.",
                Title = "News Title 19"
            };

            News news20 = new News
            {
                Id = new Guid("97755739-5cc9-49f7-bcf7-a66765be0571"),
                CreatedBy = user3.Id,
                CreatedDate = new DateTime(2024, 5, 20),
                Content = "This is the content of news item 20.",
                Title = "News Title 20"
            };

            builder.Entity<News>().HasData(news1, news2, news10, news11, news12, news13, news14, news15, news16, news17, news18, news19, news20, news3, news4, news5, news6, news7, news8, news9);

            builder.Entity<DeviceStatus>().HasData(
                new DeviceStatus { Id = 1, Name = "Available" },
                new DeviceStatus { Id = 2, Name = "In Use" },
                new DeviceStatus { Id = 3, Name = "Disable" }
            );

            Device device1 = new Device
            {
                Id = new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"),
                DeviceStatusId = 1,
                OwnedBy = user1.Id,
                Name = "Server",
                Description = "Primary server",
                LastUsed = DateTime.Now.AddDays(-1),
                IsDeleted = false
            };

            Device device2 = new Device
            {
                Id = new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"),
                DeviceStatusId = 2,
                OwnedBy = user2.Id,
                Name = "Screen",
                Description = "Dell UltraSharp U2723QE 27 inch",
                LastUsed = DateTime.Now.AddDays(-2),
                IsDeleted = false
            };

            Device device3 = new Device
            {
                Id = new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"),
                DeviceStatusId = 1,
                OwnedBy = user3.Id,
                Name = "PC",
                Description = "Thai's PC",
                LastUsed = DateTime.Now.AddDays(-3),
                IsDeleted = false
            };

            Device device4 = new Device
            {
                Id = new Guid("11d331b4-136c-4844-a686-ffc38c103268"),
                DeviceStatusId = 3,
                OwnedBy = user1.Id,
                Name = "Router",
                Description = "Main office router",
                LastUsed = DateTime.Now.AddDays(-10),
                IsDeleted = false
            };

            Device device5 = new Device
            {
                Id = new Guid("b4dc2d48-482a-48a2-bad6-7a1e0e3139b7"),
                DeviceStatusId = 1,
                OwnedBy = user3.Id,
                Name = "Desktop",
                Description = "Development desktop",
                LastUsed = DateTime.Now.AddDays(-1),
                IsDeleted = false
            };

            Device device6 = new Device
            {
                Id = new Guid("0a395b72-ae0d-4a49-b7f8-1763de733068"),
                DeviceStatusId = 2,
                OwnedBy = user2.Id,
                Name = "Monitor",
                Description = "High resolution monitor",
                LastUsed = DateTime.Now.AddDays(-5),
                IsDeleted = false
            };

            Device device7 = new Device
            {
                Id = new Guid("5947a22f-0191-419c-873b-4324b5b95e84"),
                DeviceStatusId = 1,
                OwnedBy = user1.Id,
                Name = "Printer",
                Description = "Office printer",
                LastUsed = DateTime.Now.AddDays(-7),
                IsDeleted = false
            };

            Device device8 = new Device
            {
                Id = new Guid("a1d65f8a-f7fd-4995-940f-6ab254523f90"),
                DeviceStatusId = 2,
                OwnedBy = user3.Id,
                Name = "Tablet",
                Description = "Designer's tablet",
                LastUsed = DateTime.Now.AddDays(-2),
                IsDeleted = false
            };

            Device device9 = new Device
            {
                Id = new Guid("eb934470-4e73-41a8-8304-3bcb1ea18502"),
                DeviceStatusId = 1,
                OwnedBy = user1.Id,
                Name = "Projector",
                Description = "Conference room projector",
                LastUsed = DateTime.Now.AddDays(-4),
                IsDeleted = false
            };

            Device device10 = new Device
            {
                Id = new Guid("51e6edb8-0a1f-4c26-afb7-fcf95ea0965f"),
                DeviceStatusId = 3,
                OwnedBy = user1.Id,
                Name = "Switch",
                Description = "Network switch",
                LastUsed = DateTime.Now.AddDays(-15),
                IsDeleted = false
            };

            builder.Entity<Device>().HasData(device1, device10, device2, device3, device4, device5, device6, device7, device8, device9);

            Schedule schedule1 = new Schedule
            {
                Id = new Guid("44efa2a7-4f64-4fc6-bbbe-869099817d4f"),
                DeviceId = device1.Id,
                AccountId = user4.Id,
                ScheduledDate = DateTime.Now,
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(2),
                Purpose = "Testing"
            };

            Schedule schedule2 = new Schedule
            {
                Id = new Guid("e377b750-0b20-4943-9e5d-6909d4810f13"),
                DeviceId = device1.Id,
                AccountId = user5.Id,
                ScheduledDate = DateTime.Now,
                StartDate = DateTime.Now.AddHours(3),
                EndDate = DateTime.Now.AddHours(4),
                Purpose = "Development"
            };

            Schedule schedule3 = new Schedule
            {
                Id = new Guid("37d2c7b3-7406-418d-9062-e81dfff02d9a"),
                DeviceId = device2.Id,
                AccountId = user5.Id,
                ScheduledDate = DateTime.Now.AddDays(-1),
                StartDate = DateTime.Now.AddDays(-1).AddHours(1),
                EndDate = DateTime.Now.AddDays(-1).AddHours(2),
                Purpose = "Testing"
            };

            Schedule schedule4 = new Schedule
            {
                Id = new Guid("e0fa81b1-9eea-4b4b-93a7-b7a34aae4014"),
                DeviceId = device2.Id,
                AccountId = user6.Id,
                ScheduledDate = DateTime.Now.AddDays(-1),
                StartDate = DateTime.Now.AddDays(-1).AddHours(3),
                EndDate = DateTime.Now.AddDays(-1).AddHours(4),
                Purpose = "Development"
            };

            Schedule schedule5 = new Schedule
            {
                Id = new Guid("db1fcaa0-e934-4429-a567-2ac802d0b453"),
                DeviceId = device2.Id,
                AccountId = user7.Id,
                ScheduledDate = DateTime.Now.AddDays(-1),
                StartDate = DateTime.Now.AddDays(-1).AddHours(5),
                EndDate = DateTime.Now.AddDays(-1).AddHours(6),
                Purpose = "Testing"
            };

            Schedule schedule6 = new Schedule
            {
                Id = new Guid("27f1b969-1b68-4cf8-8a51-c8be5356f7f8"),
                DeviceId = device3.Id,
                AccountId = user8.Id,
                ScheduledDate = DateTime.Now.AddDays(-2),
                StartDate = DateTime.Now.AddDays(-2).AddHours(3),
                EndDate = DateTime.Now.AddDays(-2).AddHours(4),
                Purpose = "Development"
            };

            Schedule schedule7 = new Schedule
            {
                Id = new Guid("4da0b3f8-95aa-40cd-ab32-75876ca13900"),
                DeviceId = device3.Id,
                AccountId = user4.Id,
                ScheduledDate = DateTime.Now.AddDays(-2),
                StartDate = DateTime.Now.AddDays(-2).AddHours(5),
                EndDate = DateTime.Now.AddDays(-2).AddHours(6),
                Purpose = "Development"
            };

            Schedule schedule8 = new Schedule
            {
                Id = new Guid("80d34442-7c14-4060-ae8f-24cda38e63f9"),
                DeviceId = device3.Id,
                AccountId = user8.Id,
                ScheduledDate = DateTime.Now.AddDays(-1),
                StartDate = DateTime.Now.AddDays(-1).AddHours(1),
                EndDate = DateTime.Now.AddDays(-1).AddHours(2),
                Purpose = "Development"
            };

            Schedule schedule9 = new Schedule
            {
                Id = new Guid("5dc94e7f-845b-480b-8c81-f1d50c359491"),
                DeviceId = device3.Id,
                AccountId = user5.Id,
                ScheduledDate = DateTime.Now.AddDays(-3),
                StartDate = DateTime.Now.AddDays(-3).AddHours(3),
                EndDate = DateTime.Now.AddDays(-3).AddHours(4),
                Purpose = "Development"
            };

            Schedule schedule10 = new Schedule
            {
                Id = new Guid("70f625f4-33f5-4c62-9718-d3e2c420e703"),
                DeviceId = device3.Id,
                AccountId = user6.Id,
                ScheduledDate = DateTime.Now.AddDays(-3),
                StartDate = DateTime.Now.AddDays(-3).AddHours(5),
                EndDate = DateTime.Now.AddDays(-3).AddHours(6),
                Purpose = "Development"
            };
            Schedule schedule11 = new Schedule
            {
                Id = new Guid("77153502-8631-4b5f-b05d-76d4796c06d4"),
                DeviceId = device3.Id,
                AccountId = user8.Id,
                ScheduledDate = DateTime.Now.AddDays(-4),
                StartDate = DateTime.Now.AddDays(-4).AddHours(3),
                EndDate = DateTime.Now.AddDays(-4).AddHours(4),
                Purpose = "Development"
            };
            Schedule schedule12 = new Schedule
            {
                Id = new Guid("8bb44d07-f470-4434-a023-6bdffb4311cc"),
                DeviceId = device3.Id,
                AccountId = user4.Id,
                ScheduledDate = DateTime.Now.AddDays(-5),
                StartDate = DateTime.Now.AddDays(-5).AddHours(5),
                EndDate = DateTime.Now.AddDays(-5).AddHours(6),
                Purpose = "Development"
            };
            Schedule schedule13 = new Schedule
            {
                Id = new Guid("4fa30f09-e82a-4375-a28f-8190a8667a09"),
                DeviceId = device3.Id,
                AccountId = user6.Id,
                ScheduledDate = DateTime.Now.AddDays(-6),
                StartDate = DateTime.Now.AddDays(-6).AddHours(3),
                EndDate = DateTime.Now.AddDays(-6).AddHours(6),
                Purpose = "Development"
            };
            Schedule schedule14 = new Schedule
            {
                Id = new Guid("77790ba9-1f3c-4943-9e39-097000fc6fa2"),
                DeviceId = device3.Id,
                AccountId = user8.Id,
                ScheduledDate = DateTime.Now.AddDays(-7),
                StartDate = DateTime.Now.AddDays(-7).AddHours(3),
                EndDate = DateTime.Now.AddDays(-7).AddHours(4),
                Purpose = "Development"
            };

            Schedule schedule15 = new Schedule
            {
                Id = new Guid("5b1615a6-b870-456a-a483-e99a3f9122dc"),
                DeviceId = device4.Id,
                AccountId = user4.Id,
                ScheduledDate = DateTime.Now.AddDays(-2),
                StartDate = DateTime.Now.AddDays(-2).AddHours(3),
                EndDate = DateTime.Now.AddDays(-2).AddHours(4),
                Purpose = "Development"
            };
            Schedule schedule16 = new Schedule
            {
                Id = new Guid("ff18bb51-3c4e-4fcb-a73e-39f60996be8c"),
                DeviceId = device5.Id,
                AccountId = user7.Id,
                ScheduledDate = DateTime.Now.AddDays(-1),
                StartDate = DateTime.Now.AddDays(-1).AddHours(3),
                EndDate = DateTime.Now.AddDays(-1).AddHours(4),
                Purpose = "Development"
            };
            Schedule schedule17 = new Schedule
            {
                Id = new Guid("eb607a7a-2572-4a16-bbbd-99f3db25d40b"),
                DeviceId = device6.Id,
                AccountId = user5.Id,
                ScheduledDate = DateTime.Now,
                StartDate = DateTime.Now.AddHours(3),
                EndDate = DateTime.Now.AddHours(4),
                Purpose = "Development"
            };
            Schedule schedule18 = new Schedule
            {
                Id = new Guid("5547314b-521a-47e9-ad60-5e376e686636"),
                DeviceId = device7.Id,
                AccountId = user5.Id,
                ScheduledDate = DateTime.Now,
                StartDate = DateTime.Now.AddHours(3),
                EndDate = DateTime.Now.AddHours(4),
                Purpose = "Development"
            };

            Schedule schedule19 = new Schedule
            {
                Id = new Guid("9bfeb5df-03a4-4ae5-904e-1779c19a5313"),
                DeviceId = device8.Id,
                AccountId = user8.Id,
                ScheduledDate = DateTime.Now.AddDays(-1),
                StartDate = DateTime.Now.AddDays(-1).AddHours(3),
                EndDate = DateTime.Now.AddDays(-1).AddHours(4),
                Purpose = "Development"
            };

            Schedule schedule20 = new Schedule
            {
                Id = new Guid("6500363e-6574-42e7-8577-6dc87a55ce15"),
                DeviceId = device9.Id,
                AccountId = user5.Id,
                ScheduledDate = DateTime.Now.AddDays(-2),
                StartDate = DateTime.Now.AddDays(-2).AddHours(3),
                EndDate = DateTime.Now.AddDays(-2).AddHours(4),
                Purpose = "Development"
            };

            builder.Entity<Schedule>().HasData(schedule1, schedule10, schedule11, schedule12, schedule13, schedule14, schedule15, schedule16, schedule17, schedule18, schedule19, schedule2, schedule20, schedule3, schedule4, schedule5, schedule6, schedule7, schedule8, schedule9);

            Report rp1 = new Report
            {
                Id = new Guid("75fb870f-e344-40c9-ab85-101631f22505"),
                ScheduleId = schedule1.Id,
                DeviceStatusId = 1,
                Description = "Device was used for setting up a new development environment."
            };

            Report rp2 = new Report
            {
                Id = new Guid("d3b039bd-813c-4b33-af98-2264dcb440c0"),
                ScheduleId = schedule2.Id,
                DeviceStatusId = 2,
                Description = "The laptop was utilized for testing the latest software build."
            };

            Report rp3 = new Report
            {
                Id = new Guid("c8fb056c-cff8-4db2-b951-01859431a35e"),
                ScheduleId = schedule3.Id,
                DeviceStatusId = 1,
                Description = "Router firmware was updated and tested."
            };

            Report rp4 = new Report
            {
                Id = new Guid("8455c9b0-c2ca-4de4-bdee-3070dc8af954"),
                ScheduleId = schedule4.Id,
                DeviceStatusId = 1,
                Description = "The desktop was used for backend development tasks."
            };

            Report rp5 = new Report
            {
                Id = new Guid("426c57ce-68aa-498b-b603-16cf1e7a238d"),
                ScheduleId = schedule5.Id,
                DeviceStatusId = 1,
                Description = "Monitor calibrated for color accuracy."
            };

            Report rp6 = new Report
            {
                Id = new Guid("285ce1fd-470c-4474-ad1b-ba273c0e8653"),
                ScheduleId = schedule6.Id,
                DeviceStatusId = 1,
                Description = "Printer serviced and toner replaced."
            };

            Report rp7 = new Report
            {
                Id = new Guid("dd8ac1ac-0f4f-45af-825e-e74e531b66dc"),
                ScheduleId = schedule7.Id,
                DeviceStatusId = 1,
                Description = "Tablet used for sketching new UI designs."
            };


            Report rp8 = new Report
            {
                Id = new Guid("f1dcaea6-1670-47d7-b8cb-398b89ca09d0"),
                ScheduleId = schedule8.Id,
                DeviceStatusId = 1,
                Description = "Projector used in a client presentation."
            };

            Report rp9 = new Report
            {
                Id = new Guid("0e287e15-6c9f-44ab-9fb3-dc183f5e5e92"),
                ScheduleId = schedule9.Id,
                DeviceStatusId = 1,
                Description = "Network switch configuration updated."
            };

            Report rp10 = new Report
            {
                Id = new Guid("78d4e5bd-d685-49b5-8b12-e71df921ec65"),
                ScheduleId = schedule10.Id,
                DeviceStatusId = 1,
                Description = "Server performance was monitored during load testing."
            };

            Report rp11 = new Report
            {
                Id = new Guid("b9d04c5f-2ec0-4da1-92ab-7ef9bdcd82e4"),
                ScheduleId = schedule11.Id,
                DeviceStatusId = 2,
                Description = "Developer's laptop used for bug fixing."
            };

            Report rp12 = new Report
            {
                Id = new Guid("5faf118e-4687-47c2-9b83-ecb389b8b6d5"),
                ScheduleId = schedule12.Id,
                DeviceStatusId = 1,
                Description = "Router settings optimized for network traffic."
            };

            Report rp13 = new Report
            {
                Id = new Guid("76199946-58bd-473a-95a7-9da8afcb9fc7"),
                ScheduleId = schedule13.Id,
                DeviceStatusId = 1,
                Description = "Desktop setup for new project development."
            };

            Report rp14 = new Report
            {
                Id = new Guid("e4880a12-6d1d-4e9b-8832-89c5982b1346"),
                ScheduleId = schedule14.Id,
                DeviceStatusId = 2,
                Description = "High-resolution monitor tested with graphic design software."
            };

            Report rp15 = new Report
            {
                Id = new Guid("06a6fcd7-eb30-4728-9856-ee8d00f84810"),
                ScheduleId = schedule15.Id,
                DeviceStatusId = 1,
                Description = "Designer's tablet updated with latest design apps."
            };

            Report rp16 = new Report
            {
                Id = new Guid("cf4dfffd-74e9-46dd-b9b5-2a9d09001564"),
                ScheduleId = schedule16.Id,
                DeviceStatusId = 1,
                Description = "Projector used for team meeting presentations."
            };

            Report rp17 = new Report
            {
                Id = new Guid("19f6bcc1-2a8d-4c5d-ab3b-d5d3b21da159"),
                ScheduleId = schedule17.Id,
                DeviceStatusId = 2,
                Description = "Network switch maintenance and inspection."
            };

            Report rp18 = new Report
            {
                Id = new Guid("697817b7-9d65-47dd-a39b-909f89e25bce"),
                ScheduleId = schedule18.Id,
                DeviceStatusId = 1,
                Description = "The desktop was used for backend development tasks."
            };

            Report rp19 = new Report
            {
                Id = new Guid("b774e795-3469-4b58-afe0-5f6e9e0a6aec"),
                ScheduleId = schedule19.Id,
                DeviceStatusId = 2,
                Description = "The desktop was used for backend development tasks."
            };

            Report rp20 = new Report
            {
                Id = new Guid("5e2385b4-08f6-4e9e-888b-5d94c4b7fb78"),
                ScheduleId = schedule20.Id,
                DeviceStatusId = 2,
                Description = "The desktop was used for backend development tasks."
            };

            builder.Entity<Report>().HasData(rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16, rp17, rp18, rp19, rp20);

        }
    }
}
