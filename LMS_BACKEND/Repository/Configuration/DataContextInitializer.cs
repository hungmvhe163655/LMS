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
                    RoleId = "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d",
                    UserId = user1.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d",
                    UserId = user2.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d",
                    UserId = user3.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user4.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user5.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user6.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user7.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
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
                CreatedDate = new DateTime(2024, 6, 29, 21,39, 0),
                Content = "Phòng khảo thí thông báo đã có điểm thi lần 2 các môn ENT104, TRS401, TRS501, TRS601, VOV114, VOV124, VOV134 Part 1 HK Summer2024. Các em đăng nhập FAP để xem điểm chi tiết.",
                Title = "Thông báo điểm thi lần 2 các môn ENT104, TRS401, TRS501, TRS601 HK Summer2024."
            };

            News news2 = new News
            {
                Id = new Guid("7c712eff-f7d8-41af-a36c-9d7ce1439e3b"),
                CreatedBy = user2.Id,
                CreatedDate = new DateTime(2024, 5, 2),
                Content = "Phòng Dịch vụ sinh viên xin thông báo sẽ ngừng làm việc trong thời gian nghỉ hè kéo dài từ 01/07 đến hết ngày 05/07/2024.\r\n\r\nThời gian quay trở lại làm việc bình thường: 08/07/2024\r\n\r\nMọi yêu cầu hỗ trợ, giải đáp thắc mắc vui lòng gửi tới email: dichvusinhvien@fe.edu.vn\r\n\r\nTrân trọng thông báo,",
                Title = "Thông báo về việc phòng Dịch vụ sinh viên ngừng làm việc trong thời gian nghỉ hè"
            };

            News news3 = new News
            {
                Id = new Guid("cfc8a241-628f-4fab-acaf-60ffd42f97cd"),
                CreatedBy = user3.Id,
                CreatedDate = new DateTime(2024, 6, 27, 16,25,0),
                Content = "This is the content of news item 3.",
                Title = "News Title 3"
            };

            News news4 = new News
            {
                Id = new Guid("650204d7-0be6-4f91-89f7-d80572d4f76a"),
                CreatedBy = user3.Id,
                CreatedDate = new DateTime(2024, 6, 26, 22, 7, 0),
                Content = "Phòng Khảo thí thông báo đã có điểm thi kết thúc học phần lần 2 môn SSL101c học kỳ Spring 2024. Môn COV111, COV121, AET102, MLN111, HCM202, IOT102, MLN131 học kỳ Summer 2024, các em đăng nhập FAP để xem chi tiết..",
                Title = "Thông báo điểm thi kết thúc học phần lần 2 môn SSL101c học kỳ Spring 2024."
            };

            News news5 = new News
            {
                Id = new Guid("049d2c9c-f550-4e21-8911-efc5789106ec"),
                CreatedBy = user3.Id,
                CreatedDate = new DateTime(2024, 6, 24, 15, 16, 0),
                Content = "Thân gửi các bạn sinh viên,\r\n\r\nPhòng Phát triển bền vững trường Đại học FPT (FSDG) sẽ tiến hành khảo sát với sinh viên trên cổng thông tin đào tạo FAP.\r\n\r\nKhảo sát về các hành động thúc đẩy 17 mục tiêu phát triển bền vững toàn cầu của sinh viên đã thực hiện trong thời gian một năm qua.\r\n\r\nKhảo sát sẽ bắt đầu từ ngày 25/06/2024, sinh viên vui lòng truy cập vào địa chỉ FAP (https://fap.fpt.edu.vn/) và tham gia khảo sát đầy đủ. Sau khi hoàn thành khảo sát, sinh viên sẽ tiếp tục vào FAP bình thường.\r\n\r\nThân mến!.",
                Title = "[Phòng Phát triển bền vững] Chuẩn bị khảo sát SV toàn trường về PTBV"
            };

            News news6 = new News
            {
                Id = new Guid("6798cf4d-8399-4572-955e-595ddf13f292"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 6, 18, 9, 45, 0),
                Content = "\r\nThông báo về việc thay đổi tem kiểm soát ô tô ra/vào cổng Trường tại Hòa Lạc\r\nPost by hangntt6 on 18/06/24 09:45\r\nTrường Đại học FPT cơ sở Hà Nội thông báo về việc thay đổi tem kiểm soát ô tô ra/vào cổng trường, cụ thể:\r\n\r\nI. Đối tượng: Chỉ áp dụng ô tô đăng ký ra vào trường với 2 trường hợp:\r\n\r\nXe chính chủ của sinh viên, CBGV\r\nXe của người thân trong gia đình sinh viên, CBGV\r\nII. Hình thức triển khai:\r\n\r\nĐối với các trường hợp đã đăng ký từ ngày 15/06/2024 trở về trước:\r\nBổ sung thông tin theo link: https://forms.gle/HSjMfrJwSJH8t4Wi8\r\nMang theo biển cũ đổi lấy tem mới tại phòng Dịch vụ sinh viên từ ngày 18.06 đến 21.06/2024\r\nĐối với các trường hợp đăng ký mới:\r\nĐăng ký thông tin qua link: https://forms.gle/HSjMfrJwSJH8t4Wi8\r\nDự kiến nhận tem sau 07 ngày làm việc kể từ thời điểm đăng ký\r\n*Thời gian áp dụng kiểm soát xe ra/vào bằng Tem từ ngày 01/7/2024.\r\n\r\nSau thời gian bổ sung thêm, tất cả các xe chưa dán tem sẽ bắt buộc phải đăng ký tại cổng bảo vệ trước khi vào Trường.",
                Title = "Thông báo về việc thay đổi tem kiểm soát ô tô ra/vào cổng Trường tại Hòa Lạc"
            };

            News news7 = new News
            {
                Id = new Guid("a491e3db-344e-4f16-a051-1ed491901340"),
                CreatedBy = user2.Id,
                CreatedDate = new DateTime(2024, 6, 12, 16, 1, 0),
                Content = "Phòng Tổ chức và Quản lý Đào tạo thông báo kế hoạch học tập Half 2 - Học kỳ Summer 2024 đối với sinh viên giai đoạn Tiếng Anh chuẩn bị tại cơ sở Hà Nội như sau:\r\n\r\n \r\n\r\nTHỜI GIAN HỌC:\r\n \r\n\r\nSinh viên học chương trình Little UK và Transition bắt đầu học Half 2 từ ngày 08/7/2024.",
                Title = "KẾ HOẠCH HỌC TẬP HALF 2 KỲ SUMMER 2024 DÀNH CHO SINH VIÊN GIAI ĐOẠN TIẾNG ANH CHUẨN BỊ TẠI ĐH FPT HÀ NỘI"
            };

            News news8 = new News
            {
                Id = new Guid("c0268d79-cfd7-44c3-9b13-709869ae00e2"),
                CreatedBy = user3.Id,
                CreatedDate = new DateTime(2024, 6, 12, 12, 40, 0),
                Content = "Phòng Công tác sinh viên thông báo:\r\n\r\nBảng điểm phong trào tháng 1-2-3-4 và điểm Tổng kết học kỳ Spring 2024 (final): Tại đây\r\n\r\nMọi thắc mắc vui lòng gửi về hòm mail sro.hn@fpt.edu.vn trước 14h ngày 13/06/2024\r\n\r\nTrân trọng thông báo,",
                Title = "[CTSV] - Thông báo Điểm Rèn Luyện Học Kỳ Spring 2024"
            };

            News news9 = new News
            {
                Id = new Guid("f3e39c12-df43-4e2a-b84e-92374739e0e9"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 6, 8, 21, 29, 0),
                Content = "Phòng Tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Super Sunday Workshop “Chia sẻ về Testing”.",
                Title = "V/v: Tham dự Super Sunday Workshop “Chia sẻ về Testing”"
            };

            News news10 = new News
            {
                Id = new Guid("663c5d19-d3ed-4d6a-aff6-3997dd0c43c4"),
                CreatedBy = user2.Id,
                CreatedDate = new DateTime(2024, 6, 12, 9, 26,0),
                Content = "Theo kế hoạch của phòng Quản lý Đào tạo, học kỳ SUMMER 2024 H2 sẽ bắt đầu vào ngày 08/07/2024:\r\n\r\nBan Kế toán gửi tới các bạn sinh viên thông tin về học phí kỳ SUMMER 2024 H2, chi tiết như sau:\r\n\r\nHạn nộp tiền (ngày nhà trường nhận được tiền): 26/06/2024\r\n \r\n\r\nSố tiền cần nộp: SV đăng nhập vào fap.fpt.edu.vn, số tiền học phí phải nộp kỳ tới sẽ hiển thị trên màn chính. Ban Kế toán cập nhật hóa đơn học phí lên hệ thống từ ngày 12/06/2024. \r\nĐối tượng loại trừ: - Sinh viên có học bổng 100%\r\n\r\n                                            - Sinh viên đã hoàn thành thủ tục tạm ngưng học phần Tiếng Anh hoặc bảo lưu kỳ.\r\n\r\n \r\n\r\nHướng dẫn thanh toán học phí:\r\nSinh viên đăng nhập vào fap.fpt.edu.vn → Choose paid items → Học phí và phụ trội KTX đã được mặc định tick chọn → nhấn Add to Card → nhấn Submit Order → Sinh viên thực hiện thanh toán theo nguyên tắc sau\r\n\r\nNếu ví FAP đủ số dư → Hệ thống tự động trừ tiền.\r\nNếu ví FAP có số dư bằng 0 → Tạo khoản thanh toán → Sinh viên quét QRCode để thanh toán\r\nNếu ví FAP có số dư lớn hơn 0 nhưng không đủ số tiền thanh toán học phí, phụ trội KTX → Sinh viên quét QRCode thanh toán số tiền còn thiếu.\r\nLưu ý: Sau khi SV nộp đủ học phí, hệ thống sẽ tự động quét trừ học phí kỳ này ngay lập tức.\r\n\r\nSinh viên không thấy xuất hiện học phí phải nộp trên FAP nếu rơi vào các trường hợp sau: Sinh viên bảo lưu kỳ, tạm ngưng học phần, sinh viên đã nộp đủ học phí kỳ SU24H2, chờ lớp.",
                Title = "THÔNG BÁO NỘP HỌC PHÍ KỲ SUMMER 2024 H2"
            };

            News news11 = new News
            {
                Id = new Guid("6e08720f-d73a-4ae1-be83-559dbb96a344"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 6, 6, 14, 10, 0),
                Content = "Chương trình Thạc sĩ Quản trị kinh doanh Cao cấp (SeMBA) và Chương trình Thạc sĩ Kỹ thuật phần mềm gửi chính sách đặc biệt dành riêng cho Cựu sinh viên Đại học FPT như sau:\r\n\r\nĐối tượng hưởng ưu đãi: Sinh viên tốt nghiệp Đại học FPT các chuyên ngành.\r\nMức ưu đãi đặc biệt: \r\nƯu đãi giảm 20% học phí khi đăng ký các khóa học\r\nMiễn chứng chỉ ngoại ngữ đầu vào\r\nVới kinh nghiệm hơn 20 năm đào tạo quản trị kinh doanh và công nghệ, top 3 Trường đào tạo kinh doanh tốt nhất Việt Nam, top 25 chương trình MBA tốt nhất Đông Á, Viện Quản trị & Công nghệ FSB (Đại học FPT) đã nghiên cứu và triển khai 2 chương trình đào tạo ưu việt, cập nhật xu hướng mới nhất nhằm đáp ứng những nhu cầu của Doanh nghiệp như sau:\r\n\r\nThạc sĩ Quản trị kinh doanh (SeMBA): được thiết kế theo mô hình STEM MBA đang là xu hướng trên toàn cầu, chương trình hướng đến mục tiêu đào tạo những nhà quản lý có tư duy nhạy bén và khả năng ứng dụng công nghệ, phân tích dữ liệu vào quản trị để đưa ra các quyết định kinh doanh mang tính đột phá.\r\nThạc sĩ Kỹ thuật phần mềm (MSE): chương trình trang bị cho học viên kiến thức chuyên sâu về AI và phân tích dữ liệu lớn, cùng các kỹ năng cần thiết để nhanh chóng nắm bắt, làm chủ những xu hướng công nghệ mới. Từ đó, học viên có thể vận dụng kiến thức về công nghệ vào xây dựng các hệ thống phần mềm thông minh, phù hợp với thời đại kinh doanh số.\r\nThời gian đào tạo: 18 tháng\r\nLịch học: Tối 2-4-6 | Từ 18h00 – 21h00\r\nĐịa điểm học: Nhà C, tòa nhà Việt Úc, KĐT Mỹ Đình 1, Nam Từ Liêm, Hà Nội.",
                Title = "Chương trình Thạc sĩ Quản trị kinh doanh Cao cấp (SeMBA) và Chương trình Thạc sĩ Kỹ thuật phần mềm dành tặng ưu đãi cho Cựu sinh viên FPT"
            };

            News news12 = new News
            {
                Id = new Guid("14764db6-10f1-48e6-a4e8-3ae063814acf"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 27, 16, 11, 0),
                Content = "Phòng Tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Seminar “Điệu nhảy của các con số trong thiết kế phần mềm của đồ án tốt nghiệp​”. Thông tin chi tiết như sau:\r\n\r\n·       Thời gian:  20:30 – 22:00 - Thứ 3 ngày 28/05/2024.\r\n\r\n·       Địa điểm (Online qua link): https://zoom.us/j/9836098489 - ID cuộc họp: 983 609 8489, Passcode: 1\r\n\r\n·       Diễn giả: Giảng viên Nguyễn Tất Trung\r\n\r\nLưu ý: Đây là một trong năm buổi chia sẻ mà nhà trường và bộ môn sẽ trang bị thêm kiến thức, kĩ năng giúp các em có thể hoàn thành tốt đồ án tốt nghiệp. Phòng TC&QLDT không recording lại buổi seminar để gửi sinh viên, đề nghị sinh viên các nhóm có mặt đầy đủ và đúng giờ.",
                Title = "V/v: Tham dự Seminar “Điệu nhảy của các con số trong thiết kế phần mềm của đồ án tốt nghiệp​”"
            };

            News news13 = new News
            {
                Id = new Guid("f0c49374-4c7d-464a-9f38-e6f59b20344d"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 24, 23, 15, 0),
                Content = "Nhằm khắc phục sự cố và bảo trì trạm biến áp số 1 Trường Đại học FPT.\r\n\r\nPhòng hành chính tổng hợp - Trường Đại học FPT cơ sở Hà Nội thông báo lịch tạm ngưng cấp điện như sau:\r\n\r\nThời gian dự kiến từ: Từ 08 giờ 00 phút đến 10 giờ 00 phút ngày 25/5/2024. \r\n\r\nKhu vực ảnh hưởng: Dom A, B, C, D, Nhà Dịch 1, Tòa Beta.\r\n\r\n Sinh viên lưu ý về thời gian tạm ngừng cắt điện để chủ động trong công việc của mình. \r\n\r\nRất mong các bạn thông cảm vì sự bất tiện này. ",
                Title = "TB. V/v cắt điện ngày 25/05/2024"
            };

            News news14 = new News
            {
                Id = new Guid("0da0b088-1b08-404b-9696-eb539d31c9e5"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 29, 14, 58, 0 ),
                Content = "Phòng Dịch vụ sinh viên thông báo hướng dẫn đăng ký mua BHYT hiệu lực trong năm 2024 đợt bổ sung dành cho sinh viên, cụ thể như sau:\r\n\r\n1/ Đối tượng áp dụng: tất cả sinh viên chưa mua BHYT năm 2024\r\n\r\n(Nếu không biết mình đã có thẻ BHYT năm 2024 hay chưa, sinh viên có thể tra cứu tại đây: tracuuhieulucthe)\r\n\r\n2/ Hiệu lực thẻ: 7 tháng (Từ tháng 20/06/2024 – 31/12/2024) – Mức phí: 397,000 VNĐ",
                Title = "Thông báo về việc đăng ký mua BHYT đợt bổ sung"
            };

            News news15 = new News
            {
                Id = new Guid("5d0bfb1c-d68d-450e-8fe9-e7d94be4eaac"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 20, 22, 23, 0),
                Content = "Phòng Tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Seminar “Hướng dẫn lập kế hoạch và đặc tả yêu cầu dự án Đồ án tốt nghiệp ( ~ Report 2&3 )​”. Thông tin chi tiết như sau:\r\n\r\n·       Thời gian:  20:30 – 22:00 - Thứ 3 ngày 21/05/2024.\r\n\r\n·       Địa điểm (Online qua link): https://zoom.us/j/9836098489 - ID cuộc họp: 983 609 8489, Passcode: 1\r\n\r\n·       Diễn giả: Giảng viên Nguyễn Trung Kiên\r\n\r\nLưu ý: Đây là một trong năm buổi chia sẻ mà nhà trường và bộ môn sẽ trang bị thêm kiến thức, kĩ năng giúp các em có thể hoàn thành tốt đồ án tốt nghiệp. Đề nghị sinh viên có mặt đầy đủ và đúng giờ.",
                Title = "V/v: Tham dự Seminar “Hướng dẫn lập kế hoạch và đặc tả yêu cầu dự án Đồ án tốt nghiệp”"
            };

            News news16 = new News
            {
                Id = new Guid("0985634f-496f-4480-83f0-14ff0c30b002"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 25, 11, 34, 0),
                Content = "Từ ngày 14/8/2023, phòng Đào tạo bổ sung chức năng cho sinh viên tự đăng ký lớp/ hủy các môn đã đăng ký trong danh sách chờ trên fap.fpt.edu.vn. Các bước thực hiện như sau:\r\n\r\nSinh viên đăng nhập vào trang Fap.fpt.edu.vn\r\nVào Academic Information/ Registration/Application(Thủ tục/đơn từ)/ Wishlist Course (Danh các môn học chờ xếp lớp)",
                Title = "Hướng dẫn sinh viên các bước tự đăng ký/ hủy các môn đã đăng ký trong danh sách chờ"
            };

            News news17 = new News
            {
                Id = new Guid("245b3c4d-ba95-4040-818d-23da69f08e9b"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 14, 14, 5, 0),
                Content = "Phòng tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Seminar “Cách thức đặt vấn đề khi xác định bài toán của đồ án”. Thông tin chi tiết như sau:\r\n\r\n·       Thời gian:  20:30 – 22:00 - Thứ 3 ngày 14/05/2024.\r\n\r\n·       Địa điểm (Online qua link): https://zoom.us/j/9836098489 - ID cuộc họp: 983 609 8489, Passcode: 1\r\n\r\n·       Diễn giả: Tiến sĩ Ngô Tùng Sơn - Chủ nhiệm bộ môn An toàn thông tin.\r\n\r\nLưu ý: Đây là một trong năm buổi chia sẻ mà nhà trường và bộ môn sẽ trang bị thêm kiến thức, kĩ năng giúp các em có thể hoàn thành tốt đồ án tốt nghiệp. Đề nghị sinh viên có mặt đầy đủ và đúng giờ.",
                Title = "V/v: Tham dự Seminar “Cách thức đặt vấn đề khi xác định bài toán của đồ án”"
            };

            News news18 = new News
            {
                Id = new Guid("e277ec7f-14cf-47a2-a234-1265920647a4"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 4, 25, 20, 21, 0),
                Content = "Gửi các bạn,\r\n\r\nPhòng HCTH xin gửi thông báo tới bạn thủ tục đăng ký/hủy phòng cho kỳ Summer 2024 như sau:\r\n\r\nĐăng ký ở tiếp:\r\nØ Thời gian giữ chỗ: Từ ngày 11/4 – 21/4/2024. Gia hạn 22/4/2024.\r\n\r\n Ø Thời gian đăng ký phòng mới: Từ ngày 23/4 đến ngày 27/4/2024.\r\n\r\n(Trường hợp không đăng ký giữ chỗ được hiểu là bạn không còn nhu cầu sử dụng và bạn khác có thể đăng ký)  \r\n\r\n         Ø Đối tượng ưu tiên đăng ký KTX\r\n\r\n- Sinh viên học tập tại cơ sở Hòa Lạc trước kỳ OJT (xét tại thời điểm đăng ký phòng)\r\n\r\n- Các đối tượng sinh viên sinh viên khác có nhu cầu đăng ký phòng, Nhà trường sẽ hỗ trợ giải quyết đặt phòng qua hòm thư ktx@fpt.edu.vn.\r\n\r\n   Phương thức nộp phí và đăng ký phòng KTX qua Hệ thống OCD http://ocd.fpt.edu.vn/\r\n\r\nBước 1: Đặt phòng\r\n\r\n- Sinh viên truy cập http://ocd.fpt.edu.vn/  thực hiện đặt phòng tại chức năng  Booking Bed.\r\n\r\n- Lựa chọn đặt phòng Giữ chỗ cũ hoặc đăng ký mới theo nhu cầu.\r\n\r\nSinh viên chuyển phòng/đăng ký mới cần thao tác chọn chính xác thông tin tại các mục: Loại phòng/Dom/Tầng.\r\n\r\nBước 2: Thanh toán\r\n\r\nSau khi hoàn tất chọn phòng, sinh viên tiến hành thanh toán bằng một trong 2 hình thức sau:\r\n\r\n- Booking with FAP (nếu trên ví FAP còn đủ tiền)\r\n\r\n- Booking with DNG (Sinh viên vào App ngân hàng quét QR code để thanh toán).\r\n\r\nà Đặt phòng thành công.\r\n\r\nLưu ý: KTX sẽ gửi thư xác nhận và thông báo số phòng sau 48 giờ kể từ khi nhận booking.\r\n\r\nThời gian giữ chỗ cho SV thanh toán DNG là 10 phút. Nếu thanh toán chậm sau 10 phút thì OCD hủy giữ chỗ và tiền SV đã nộp sẽ trả về FAP. Sinh viên truy cập Hệ thống OCD đăng ký lại với hình thức sử dụng tiền dư trong ví FAP (Booking with FAP).",
                Title = "THÔNG BÁO V/V ĐĂNG KÝ/HỦY PHÒNG KTX KỲ SU24"
            };

            News news19 = new News
            {
                Id = new Guid("fb4d071c-c460-4a01-8ee4-9247a97214a6"),
                CreatedBy = user1.Id,
                CreatedDate = new DateTime(2024, 5, 9, 23, 37, 0),
                Content = "Chào các em,\r\n\r\nĐiều kiện để được miễn điểm danh kỳ SU24 như sau:\r\n\r\nSV đã hoàn thành kỳ OJT và đang học ở 1 trong số các kỳ sau: 7,8,9,10 (kỳ 10: hoàn thành các môn học còn thiếu)\r\nYêu cầu chung cho tất cả các loại HĐ làm việc hợp lệ.\r\n=>Thời gian làm việc: fulltime 8h/ngày (không nhận HĐ bán thời gian, part time) – Hợp đồng làm việc full kỳ SU2024 (từ tháng 5=>tháng 8/2024)\r\n=>Làm việc có lương và chịu sự quản lý, giám sát của nhà tuyển dụng.\r\n=>HĐ có đủ con dấu & chữ ký tươi/chữ ký số nhà tuyển dụng.\r\nThời gian mở đơn miễn điểm danh : 2 tuần trước khi vào kỳ SU24  (16/4 – 30/04/2024)  - đơn đã được gia hạn đến 20/5/2024\r\n\r\nSau thời gian trên phòng TC&QLĐT sẽ không nhận hỗ trợ bất kỳ trường hợp nào.\r\n\r\nThời gian mở đơn Block 5 : Tuần 12 của kỳ SU2024\r\n\r\nKhi làm đơn xin miễn điểm danh SV lưu ý cần làm theo chỉ dẫn sau:\r\n\r\n- SV đăng nhập FAP, vào phần HOME -> GỬI ĐƠN\r\n\r\n =>Application type: chọn Đơn miễn điểm danh\r\n\r\n=> Reason: Ghi rõ lý do làm đơn (ví dụ: Đã hoàn thành kỳ OJT – đang học kỳ … được ký HĐ làm việc fulltime với công ty…)\r\n\r\nFile Attach bao gồm:      \r\n\r\nGửi full file HĐ làm việc & giấy xác nhận nhân viên\r\nKhi gửi file nếu dung lượng file HĐLĐ nặng >2MB các em cần giảm dung lượng , nén file <2MB  hoặc các em có thể gửi HĐ qua link google drive…\r\n   LƯU Ý: \r\n\r\nPhòng TC&QLĐT chỉ nhận hỗ trợ những SV có HĐ làm việc (thời gian làm việc full kỳ SU2024). Trong trường hợp HĐ có thời gian làm việc chỉ còn 1 đến 2 tháng; HĐ thử việc ngắn hạn trong đơn cần ghi rõ thời gian sẽ bổ sung HĐ làm việc mới, HĐ làm việc chính thức để phòng Đào tạo xem xét. Những HĐ không đủ thời gian làm việc full kỳ SU24, không cam kết thời gian nộp HĐ mới sẽ bị từ chối không hỗ trợ.\r\nCác HĐ làm việc cũ nhưng còn thời gian làm việc full kỳ SU2024: SV gửi nộp file HĐ và Giấy xác nhận nhân viên (giấy xác nhận nhân viên phải được cấp quản lý ký và đóng dấu xác nhận trước khi nộp đơn miễn điểm danh kỳ SU24 khoảng 1 tuần làm việc)\r\nThư mời làm việc không phải là HĐLĐ do vậy không đủ ĐK để làm đơn miễn điểm danh, SV có thể làm đơn và phòng ĐT sẽ note vào danh sách chờ, phải bổ sung HĐ chính thức trước ngày 20/5/2024.\r\nCác loại Hợp đồng khoán gọn, Hợp đồng dịch vụ, Hợp đồng hợp tác, Hợp đồng với các công ty nhà đất, chứng khoán...: cần nộp file HĐ và giấy xác nhận nhân viên, trong giấy xác nhận nhân viên cần ghi rõ SV đang làm việc fulltime (8h/ngày) - có hưởng lương tại doanh nghiệp\r\nĐƠN MIỄN ĐIỂM DANH sẽ bị hủy NẾU PHÒNG TC&QLĐT phát hiện SV đã được duyệt miễn điểm danh trong kỳ SU24 nhưng nghỉ làm giữa chừng, không hoàn thành thời gian làm việc ghi trên HĐ làm việc đã nộp (sẽ chuyển trạng thái từ miễn điểm danh => chỉ được phép nghỉ 20% theo quy định của SV)\r\nThời gian duyệt đơn miễn điểm danh từ 5 ngày làm việc tùy thuộc vào số lượng đơn phòng TC&QLĐT nhận được. (không tính thứ 7 và CN)\r\nCHÚ Ý:\r\n\r\n- Các em chỉ gửi đơn Miễn điểm danh 1 lần và vui lòng chờ kết quả trả lời ở phần Xem đơn – KHÔNG GỬI TRÙNG ĐƠN  để tránh làm loãng thông tin. (Bạn nào gửi từ 2 lần đơn trở lên thời gian chờ duyệt đơn sẽ tăng theo số lần gửi đơn )\r\n\r\n- Đơn miễn điểm danh kỳ SU2024 được duyệt, SV sẽ được miễn điểm danh full cả 2 block ( block1-4 và block5) do vậy những SV đã được duyệt đơn miễn điểm danh đầu kỳ SU24 nếu học block 5 không cần làm đơn xin miễn điểm danh block5-SU2024.\r\n\r\n- Đơn miễn điểm danh này chỉ có giá trị trong kỳ SU2024\r\n\r\n- Phòng TC&QLĐT chỉ nhận ĐƠN MIỄN ĐIỂM DANH ONLINE – KHÔNG NHẬN ĐƠN MIỄN ĐIỂM DANH GỬI QUA MAIL\r\n\r\n- SV miễn điểm danh được phép vắng mặt >20% (không giới hạn %) và phòng TC&QLĐT quản lý SV miễn điểm danh độc lập do vậy SV không gửi mail thắc mắc khi chưa thấy chữ Attendance Exemption\r\n\r\n- Trường hợp hiếm gặp: Nếu các em làm đơn miễn điểm danh đã được duyệt nhưng vẫn có tên trong DSSV không đủ điều kiện dự thi, các em cần gửi mail tới phòng TC&QLĐT (acad.hl@fpt.edu.vn ) để được hỗ trợ.\r\n\r\n. Do các em bận đi làm, ít đến lớp nên điểm chuyên cần sẽ giảm tùy theo cách đánh giá của giảng viên.\r\n\r\n- Không được miễn điểm danh các môn GDQP và khóa luận tốt nghiệp.\r\n\r\nCác em đọc kỹ thông báo này và làm theo hướng dẫn để được hỗ trợ chính xác nhất.\r\n\r\nTrân trọng thông báo\r\n\r\nPhòng TC&QL Đào tạo",
                Title = "HƯỚNG DẪN LÀM VÀ GỬI ĐƠN MIỄN ĐIỂM DANH KỲ SU2024"
            };

            News news20 = new News
            {
                Id = new Guid("97755739-5cc9-49f7-bcf7-a66765be0571"),
                CreatedBy = user3.Id,
                CreatedDate = new DateTime(2024, 4, 18, 23, 37, 0),
                Content = "Phòng Khảo thi thông báo đã có điểm thi kết thúc học phần lần 1 các môn AIG201c, ASR301c, BDI302c, CHN132c, CMC201c, ECC301c, ENM211c, ENM221c, FIM302c, FRS401c, HOM301c, IAO201c, IAR401c, ITE303c, LAB221c, MKT205c, SEO201c, SSC302c, AIG202c, CRY303c, DWP301c, EBC301c, EDT202c, ENG302c, HRM201c, IFT201c, ITA203c, ITB301c, ITE302c, LAW201c, NWC203c, OBE102c, PMG201c, PMG202c, PRC391c, PRC392c, PRE201c, PRN292c, SSL101c, WDU203c, WDU202c, PRO192c học kỳ Spring 2024, các em đăng nhập FAP để xem chi tiết điểm.\r\n\r\n",
                Title = "Thông báo điểm thi kết thúc học phần lần 1 các môn học online trên Coursera học kỳ Spring 2024"
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
