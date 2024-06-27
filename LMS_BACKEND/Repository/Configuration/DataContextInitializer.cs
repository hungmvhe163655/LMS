using Entities.Models;
using Microsoft.AspNetCore.Identity;

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
                CreatedBy = "MinhTC"
            };

            Notification noti2 = new Notification
            {
                Id = new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"),
                Title = "Maintenance Notice",
                Content = "Scheduled maintenance will occur this weekend.",
                CreatedDate = DateTime.Now.AddDays(-2),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = "MinhTC"
            };

            Notification noti3 = new Notification
            {
                Id = new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"),
                Title = "New Feature Release",
                Content = "We are excited to announce a new feature in our application.",
                CreatedDate = DateTime.Now.AddDays(-3),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = "Admin"
            };

            Notification noti4 = new Notification
            {
                Id = new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"),
                Title = "Security Alert",
                Content = "Please update your password to enhance security.",
                CreatedDate = DateTime.Now.AddDays(-4),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = "ThaiLS"
            };

            Notification noti5 = new Notification
            {
                Id = new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"),
                Title = "Downtime Notification",
                Content = "The system will be down for maintenance tonight.",
                CreatedDate = DateTime.Now.AddDays(-5),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = "HungMV"
            };

            Notification noti6 = new Notification
            {
                Id = new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"),
                Title = "Weekly Meeting",
                Content = "Join weekly meeting.",
                CreatedDate = DateTime.Now.AddDays(-6),
                Url = "",
                NotificationTypeId = 2,
                CreatedBy = "HungMV"
            };

            Notification noti7 = new Notification
            {
                Id = new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"),
                Title = "Promotion Alert",
                Content = "Don't miss out on our latest promotions!",
                CreatedDate = DateTime.Now.AddDays(-7),
                Url = "",
                NotificationTypeId = 2,
                CreatedBy = "HungMV"
            };

            Notification noti8 = new Notification
            {
                Id = new Guid("931129a9-986f-4560-99f1-a06b692c71a1"),
                Title = "Survey Request",
                Content = "Please take a moment to complete our user survey.",
                CreatedDate = DateTime.Now.AddDays(-8),
                Url = "",
                NotificationTypeId = 2,
                CreatedBy = "ThaiLS"
            };

            Notification noti9 = new Notification
            {
                Id = new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"),
                Title = "Account Notice",
                Content = "Your account details have been updated.",
                CreatedDate = DateTime.Now.AddDays(-9),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = "MinhTC"
            };

            Notification noti10 = new Notification
            {
                Id = new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"),
                Title = "Event Reminder",
                Content = "Don't forget about the event tomorrow!",
                CreatedDate = DateTime.Now.AddDays(-10),
                Url = "",
                NotificationTypeId = 1,
                CreatedBy = "MinhTC"
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
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti1.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti1.Id,
                    IsRead = true,
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
                    AccountId = user5.Id,
                    NotificationId = noti2.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user6.Id,
                    NotificationId = noti2.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user1.Id,
                    NotificationId = noti3.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user3.Id,
                    NotificationId = noti3.Id,
                    IsRead = true,
                },
                new NotificationAccount
                {
                    AccountId = user4.Id,
                    NotificationId = noti3.Id,
                    IsRead = true,
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
                    AccountId = user6.Id,
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
                    AccountId = user3.Id,
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
                    AccountId = user3.Id,
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
                    AccountId = user7.Id,
                    NotificationId = noti9.Id,
                    IsRead = true,
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
                    IsRead = true,
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
        }
    }
}
