using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shared.GlobalVariables;

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
                VerifiedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
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
                VerifiedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
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
                VerifiedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
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
                VerifiedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAENVZ95qV36S0GH4gzip/nSmI9JKDA1CAGuL2+t1ysccrtPgGLrSZ6k9v/tS37ojoSw==",
            };

            Account user5 = new Account()
            {
                Id = "68fdf17c-7cbe-4a4c-a674-c530ffc77667",
                UserName = "hoangnmhe163884",
                NormalizedUserName = ("hoangnmhe163884").ToUpper(),
                FullName = "Nguyen Minh Hoang",
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
                VerifiedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
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
                VerifiedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
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
                VerifiedBy = "6c6abe62-f811-4a8b-96eb-ed326c47d209",
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
                VerifiedBy = "6c6abe62-f811-4a8b-96eb-ed326c47d209",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user9 = new Account()
            {
                Id = "d4325be4-cb11-4f2f-b29e-dc52024d6c65",
                UserName = "hieunthe168975",
                FullName = "Nguyen Trung Hieu",
                NormalizedUserName = ("hieunthe168975").ToUpper(),
                Email = "nguyentrunghieu123@gmail.com",
                NormalizedEmail = ("nguyentrunghieu123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965795220",
                CreatedDate = DateTime.Now,
                Gender = true,
                IsDeleted = false,
                IsBanned = true,
                IsVerified = true,
                VerifiedBy = "6c6abe62-f811-4a8b-96eb-ed326c47d209",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user10 = new Account()
            {
                Id = "b745d464-f213-487c-8469-1f0d10d32224",
                UserName = "anhchhe161236",
                FullName = "Cao Hoang Anh",
                NormalizedUserName = ("anhchhe161236").ToUpper(),
                Email = "caohoanganh123@gmail.com",
                NormalizedEmail = ("caohoanganh123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965795220",
                CreatedDate = DateTime.Now,
                Gender = true,
                IsDeleted = true,
                IsBanned = false,
                IsVerified = true,
                VerifiedBy = "6c6abe62-f811-4a8b-96eb-ed326c47d209",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user11 = new Account()
            {
                Id = "d7d2f268-eea4-4299-9342-800564cc6411",
                UserName = "namdthe159865",
                FullName = "Doan Trung Nam",
                NormalizedUserName = ("namdthe159865").ToUpper(),
                Email = "doantrungnam123@gmail.com",
                NormalizedEmail = ("doantrungnam123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965795220",
                CreatedDate = DateTime.Now,
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = false,
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user12 = new Account()
            {
                Id = "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832",
                UserName = "chilp",
                FullName = "Le Phuong Chi",
                NormalizedUserName = ("chilp").ToUpper(),
                Email = "chilp123@gmail.com",
                NormalizedEmail = ("chilp123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965796856",
                CreatedDate = DateTime.Now,
                Gender = false,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                VerifiedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user13 = new Account()
            {
                Id = "c4a15b23-9d00-4ec5-acc9-493354e91973",
                UserName = "tientd",
                FullName = "Ta Dinh Tien",
                NormalizedUserName = ("tientd").ToUpper(),
                Email = "tientd123@gmail.com",
                NormalizedEmail = ("tientd123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965796963",
                CreatedDate = DateTime.Now,
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                VerifiedBy = "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user14 = new Account()
            {
                Id = "29df78da-8830-4bb3-8ece-f11cf9f5cc34",
                UserName = "lamndt",
                FullName = "Nguyen Duc Tung Lam",
                NormalizedUserName = ("lamndt").ToUpper(),
                Email = "lamndt123@gmail.com",
                NormalizedEmail = ("lamndt123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965796741",
                CreatedDate = DateTime.Now,
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                VerifiedBy = "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user15 = new Account()
            {
                Id = "e214c150-f35c-4567-aaf0-c103d4e4d198",
                UserName = "duongdd",
                FullName = "Do Duc Duong",
                NormalizedUserName = ("duongdd").ToUpper(),
                Email = "duongdd123@gmail.com",
                NormalizedEmail = ("duongdd123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965796852",
                CreatedDate = DateTime.Now,
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                VerifiedBy = "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user16 = new Account()
            {
                Id = "72339042-5a5d-46f1-9b24-c5446332a29c",
                UserName = "hungpv",
                FullName = "Pham Van Hung",
                NormalizedUserName = ("hungpv").ToUpper(),
                Email = "hungpv123@gmail.com",
                NormalizedEmail = ("hungpv123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965796741",
                CreatedDate = DateTime.Now,
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                VerifiedBy = "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user17 = new Account()
            {
                Id = "89d0ed33-21e5-401e-b3b4-963ef6e6be16",
                UserName = "longpt",
                FullName = "Phi Thang Long",
                NormalizedUserName = ("longpt").ToUpper(),
                Email = "longpt123@gmail.com",
                NormalizedEmail = ("longpt123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965796123",
                CreatedDate = DateTime.Now,
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                VerifiedBy = "c4a15b23-9d00-4ec5-acc9-493354e91973",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user18 = new Account()
            {
                Id = "75beaf54-8c16-4464-9cd5-fa272d942f43",
                UserName = "thanhkn",
                FullName = "Kim Nhat Thanh",
                NormalizedUserName = ("thanhkn").ToUpper(),
                Email = "thanhkn123@gmail.com",
                NormalizedEmail = ("thanhkn123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965796456",
                CreatedDate = DateTime.Now,
                Gender = true,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                VerifiedBy = "c4a15b23-9d00-4ec5-acc9-493354e91973",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user19 = new Account()
            {
                Id = "85b70a16-20bb-400f-a478-78c6f8c6d067",
                UserName = "linltm",
                FullName = "Le Thi Mai Linh",
                NormalizedUserName = ("linhlmt").ToUpper(),
                Email = "linhltm123@gmail.com",
                NormalizedEmail = ("linhltm123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965796789",
                CreatedDate = DateTime.Now,
                Gender = false,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                VerifiedBy = "c4a15b23-9d00-4ec5-acc9-493354e91973",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };
            Account user20 = new Account()
            {
                Id = "094505b2-4be4-43c6-ac2f-53428f706d19",
                UserName = "phuongdb",
                FullName = "Dao Bich Phuong",
                NormalizedUserName = ("phuongdb").ToUpper(),
                Email = "phuongdb123@gmail.com",
                NormalizedEmail = ("phuongdb123@gmail.com").ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                PhoneNumber = "0965796789",
                CreatedDate = DateTime.Now,
                Gender = false,
                IsDeleted = false,
                IsBanned = false,
                IsVerified = true,
                VerifiedBy = "c4a15b23-9d00-4ec5-acc9-493354e91973",
                EmailVerifyCodeAge = DateTime.UtcNow,
                UserRefreshTokenExpiryTime = DateTime.UtcNow,
                PasswordHash = "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==",
            };


            builder.Entity<Account>().HasData(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10, user11, user12, user13, user14, user15, user16, user17, user18, user19, user20);

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
                    UserId = user12.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d",
                    UserId = user13.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
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
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user9.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user10.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user11.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user14.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user15.Id,
                },

                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user16.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user17.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user18.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user19.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                    UserId = user20.Id,
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
                },
                new StudentDetail()
                {
                    AccountId = user9.Id,
                    Major = "Software Engineering",
                    Specialized = "PHP",
                    RollNumber = "HE156824"
                },
                new StudentDetail()
                {
                    AccountId = user10.Id,
                    Major = "Software Engineering",
                    Specialized = "PHP",
                    RollNumber = "HE156844"
                },
                new StudentDetail()
                {
                    AccountId = user14.Id,
                    Major = "SE",
                    Specialized = "C#",
                    RollNumber = "HE150032"
                },
                new StudentDetail()
                {
                    AccountId = user15.Id,
                    Major = "AI",
                    Specialized = "Python",
                    RollNumber = "HE150190"
                },
                new StudentDetail()
                {
                    AccountId = user16.Id,
                    Major = "Iot",
                    Specialized = "Java",
                    RollNumber = "HE150210"
                },
                new StudentDetail()
                {
                    AccountId = user17.Id,
                    Major = "IA",
                    Specialized = "Java",
                    RollNumber = "HE150253"
                },
                new StudentDetail()
                {
                    AccountId = user18.Id,
                    Major = "SE",
                    Specialized = "Java",
                    RollNumber = "HE150263"
                },
                new StudentDetail()
                {
                    AccountId = user19.Id,
                    Major = "AI",
                    Specialized = "Python",
                    RollNumber = "HE150555"
                },
                new StudentDetail()
                {
                    AccountId = user20.Id,
                    Major = "Iot",
                    Specialized = "Java",
                    RollNumber = "HE153098"
                }
            );

            Notification noti1 = new Notification
            {
                Id = new Guid("e331de18-289c-403d-8028-26c4b595587a"),
                Title = "System Update",
                Content = "A new system update will be available tomorrow.",
                CreatedDate = DateTime.Now.AddDays(-1),
                Url = "",
                NotificationType = NOTIFICATION_TYPE.SYSTEM,
                CreatedBy = user1.Id,
            };

            Notification noti2 = new Notification
            {
                Id = new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"),
                Title = "Maintenance Notice",
                Content = "Scheduled maintenance will occur this weekend.",
                CreatedDate = DateTime.Now.AddDays(-2),
                Url = "",
                NotificationType = NOTIFICATION_TYPE.SYSTEM,
                CreatedBy = user1.Id,
            };

            Notification noti3 = new Notification
            {
                Id = new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"),
                Title = "New Feature Release",
                Content = "We are excited to announce a new feature in our application.",
                CreatedDate = DateTime.Now.AddDays(-3),
                Url = "",
                NotificationType = NOTIFICATION_TYPE.SYSTEM,
                CreatedBy = user1.Id,
            };

            Notification noti4 = new Notification
            {
                Id = new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"),
                Title = "Security Alert",
                Content = "Please update your password to enhance security.",
                CreatedDate = DateTime.Now.AddDays(-4),
                Url = "",
                NotificationType = NOTIFICATION_TYPE.SYSTEM,
                CreatedBy = user2.Id,
            };

            Notification noti5 = new Notification
            {
                Id = new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"),
                Title = "Downtime Notification",
                Content = "The system will be down for maintenance tonight.",
                CreatedDate = DateTime.Now.AddDays(-5),
                Url = "",
                NotificationType = NOTIFICATION_TYPE.SYSTEM,
                CreatedBy = user3.Id,
            };

            Notification noti6 = new Notification
            {
                Id = new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"),
                Title = "Weekly Meeting",
                Content = "Join weekly meeting.",
                CreatedDate = DateTime.Now.AddDays(-6),
                Url = "",
                NotificationType = NOTIFICATION_TYPE.PROJECT,
                CreatedBy = user3.Id,
            };

            Notification noti7 = new Notification
            {
                Id = new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"),
                Title = "Promotion Alert",
                Content = "Don't miss out on our latest promotions!",
                CreatedDate = DateTime.Now.AddDays(-7),
                Url = "",
                NotificationType = NOTIFICATION_TYPE.PROJECT,
                CreatedBy = user3.Id,
            };

            Notification noti8 = new Notification
            {
                Id = new Guid("931129a9-986f-4560-99f1-a06b692c71a1"),
                Title = "Survey Request",
                Content = "Please take a moment to complete our user survey.",
                CreatedDate = DateTime.Now.AddDays(-8),
                Url = "",
                NotificationType = NOTIFICATION_TYPE.PROJECT,
                CreatedBy = user2.Id,
            };

            Notification noti9 = new Notification
            {
                Id = new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"),
                Title = "Account Notice",
                Content = "Your account details have been updated.",
                CreatedDate = DateTime.Now.AddDays(-9),
                Url = "",
                NotificationType = NOTIFICATION_TYPE.SYSTEM,
                CreatedBy = user1.Id,
            };

            Notification noti10 = new Notification
            {
                Id = new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"),
                Title = "Event Reminder",
                Content = "Don't forget about the event tomorrow!",
                CreatedDate = DateTime.Now.AddDays(-10),
                Url = "",
                
                NotificationType = NOTIFICATION_TYPE.SYSTEM,
                CreatedBy = user1.Id,
            };

            builder.Entity<Notification>().HasData(noti1, noti2, noti3, noti4, noti5, noti6, noti7, noti8, noti9, noti10);
            //builder.Entity<NotificationType>().HasData(
            //    new NotificationType
            //    {
            //        Id = 1,
            //        Name = "System",
            //    },
            //    new NotificationType
            //    {
            //        Id = 2,
            //        Name = "Project",
            //    }
            //);
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
                CreatedDate = new DateTime(2024, 6, 29, 21, 39, 0),
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
                CreatedDate = new DateTime(2024, 6, 27, 16, 25, 0),
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
                CreatedDate = new DateTime(2024, 6, 12, 9, 26, 0),
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
                CreatedDate = new DateTime(2024, 5, 29, 14, 58, 0),
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

            //builder.Entity<DeviceStatus>().HasData(
            //    new DeviceStatus { Id = 1, Name = "Available" },
            //    new DeviceStatus { Id = 2, Name = "In Use" },
            //    new DeviceStatus { Id = 3, Name = "Disable" }
            //);

            Device device1 = new Device
            {
                Id = new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"),
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                OwnedBy = user1.Id,
                Name = "Server",
                Description = "Primary server",
                LastUsed = DateTime.Now.AddDays(-1),
                IsDeleted = false
            };

            Device device2 = new Device
            {
                Id = new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"),
                DeviceStatus = DEVICE_STATUS.INUSE,
                OwnedBy = user2.Id,
                Name = "Screen",
                Description = "Dell UltraSharp U2723QE 27 inch",
                LastUsed = DateTime.Now.AddDays(-2),
                IsDeleted = false
            };

            Device device3 = new Device
            {
                Id = new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"),
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                OwnedBy = user3.Id,
                Name = "PC",
                Description = "Thai's PC",
                LastUsed = DateTime.Now.AddDays(-3),
                IsDeleted = false
            };

            Device device4 = new Device
            {
                Id = new Guid("11d331b4-136c-4844-a686-ffc38c103268"),
                DeviceStatus = DEVICE_STATUS.DISABLE,
                OwnedBy = user1.Id,
                Name = "Router",
                Description = "Main office router",
                LastUsed = DateTime.Now.AddDays(-10),
                IsDeleted = false
            };

            Device device5 = new Device
            {
                Id = new Guid("b4dc2d48-482a-48a2-bad6-7a1e0e3139b7"),
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                OwnedBy = user3.Id,
                Name = "Desktop",
                Description = "Development desktop",
                LastUsed = DateTime.Now.AddDays(-1),
                IsDeleted = false
            };

            Device device6 = new Device
            {
                Id = new Guid("0a395b72-ae0d-4a49-b7f8-1763de733068"),
                DeviceStatus = DEVICE_STATUS.INUSE,
                OwnedBy = user2.Id,
                Name = "Monitor",
                Description = "High resolution monitor",
                LastUsed = DateTime.Now.AddDays(-5),
                IsDeleted = false
            };

            Device device7 = new Device
            {
                Id = new Guid("5947a22f-0191-419c-873b-4324b5b95e84"),
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                OwnedBy = user1.Id,
                Name = "Printer",
                Description = "Office printer",
                LastUsed = DateTime.Now.AddDays(-7),
                IsDeleted = false
            };

            Device device8 = new Device
            {
                Id = new Guid("a1d65f8a-f7fd-4995-940f-6ab254523f90"),
                DeviceStatus = DEVICE_STATUS.INUSE,
                OwnedBy = user3.Id,
                Name = "Tablet",
                Description = "Designer's tablet",
                LastUsed = DateTime.Now.AddDays(-2),
                IsDeleted = false
            };

            Device device9 = new Device
            {
                Id = new Guid("eb934470-4e73-41a8-8304-3bcb1ea18502"),
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                OwnedBy = user1.Id,
                Name = "Projector",
                Description = "Conference room projector",
                LastUsed = DateTime.Now.AddDays(-4),
                IsDeleted = false
            };

            Device device10 = new Device
            {
                Id = new Guid("51e6edb8-0a1f-4c26-afb7-fcf95ea0965f"),
                DeviceStatus = DEVICE_STATUS.DISABLE,
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
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Device was used for setting up a new development environment."
            };

            Report rp2 = new Report
            {
                Id = new Guid("d3b039bd-813c-4b33-af98-2264dcb440c0"),
                ScheduleId = schedule2.Id,
                DeviceStatus = DEVICE_STATUS.INUSE,
                Description = "The laptop was utilized for testing the latest software build."
            };

            Report rp3 = new Report
            {
                Id = new Guid("c8fb056c-cff8-4db2-b951-01859431a35e"),
                ScheduleId = schedule3.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Router firmware was updated and tested."
            };

            Report rp4 = new Report
            {
                Id = new Guid("8455c9b0-c2ca-4de4-bdee-3070dc8af954"),
                ScheduleId = schedule4.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "The desktop was used for backend development tasks."
            };

            Report rp5 = new Report
            {
                Id = new Guid("426c57ce-68aa-498b-b603-16cf1e7a238d"),
                ScheduleId = schedule5.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Monitor calibrated for color accuracy."
            };

            Report rp6 = new Report
            {
                Id = new Guid("285ce1fd-470c-4474-ad1b-ba273c0e8653"),
                ScheduleId = schedule6.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Printer serviced and toner replaced."
            };

            Report rp7 = new Report
            {
                Id = new Guid("dd8ac1ac-0f4f-45af-825e-e74e531b66dc"),
                ScheduleId = schedule7.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Tablet used for sketching new UI designs."
            };


            Report rp8 = new Report
            {
                Id = new Guid("f1dcaea6-1670-47d7-b8cb-398b89ca09d0"),
                ScheduleId = schedule8.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Projector used in a client presentation."
            };

            Report rp9 = new Report
            {
                Id = new Guid("0e287e15-6c9f-44ab-9fb3-dc183f5e5e92"),
                ScheduleId = schedule9.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Network switch configuration updated."
            };

            Report rp10 = new Report
            {
                Id = new Guid("78d4e5bd-d685-49b5-8b12-e71df921ec65"),
                ScheduleId = schedule10.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Server performance was monitored during load testing."
            };

            Report rp11 = new Report
            {
                Id = new Guid("b9d04c5f-2ec0-4da1-92ab-7ef9bdcd82e4"),
                ScheduleId = schedule11.Id,
                DeviceStatus = DEVICE_STATUS.INUSE,
                Description = "Developer's laptop used for bug fixing."
            };

            Report rp12 = new Report
            {
                Id = new Guid("5faf118e-4687-47c2-9b83-ecb389b8b6d5"),
                ScheduleId = schedule12.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Router settings optimized for network traffic."
            };

            Report rp13 = new Report
            {
                Id = new Guid("76199946-58bd-473a-95a7-9da8afcb9fc7"),
                ScheduleId = schedule13.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Desktop setup for new project development."
            };

            Report rp14 = new Report
            {
                Id = new Guid("e4880a12-6d1d-4e9b-8832-89c5982b1346"),
                ScheduleId = schedule14.Id,
                DeviceStatus = DEVICE_STATUS.INUSE,
                Description = "High-resolution monitor tested with graphic design software."
            };

            Report rp15 = new Report
            {
                Id = new Guid("06a6fcd7-eb30-4728-9856-ee8d00f84810"),
                ScheduleId = schedule15.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Designer's tablet updated with latest design apps."
            };

            Report rp16 = new Report
            {
                Id = new Guid("cf4dfffd-74e9-46dd-b9b5-2a9d09001564"),
                ScheduleId = schedule16.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "Projector used for team meeting presentations."
            };

            Report rp17 = new Report
            {
                Id = new Guid("19f6bcc1-2a8d-4c5d-ab3b-d5d3b21da159"),
                ScheduleId = schedule17.Id,
                DeviceStatus = DEVICE_STATUS.INUSE,
                Description = "Network switch maintenance and inspection."
            };

            Report rp18 = new Report
            {
                Id = new Guid("697817b7-9d65-47dd-a39b-909f89e25bce"),
                ScheduleId = schedule18.Id,
                DeviceStatus = DEVICE_STATUS.AVAILABLE,
                Description = "The desktop was used for backend development tasks."
            };

            Report rp19 = new Report
            {
                Id = new Guid("b774e795-3469-4b58-afe0-5f6e9e0a6aec"),
                ScheduleId = schedule19.Id,
                DeviceStatus = DEVICE_STATUS.INUSE,
                Description = "The desktop was used for backend development tasks."
            };

            Report rp20 = new Report
            {
                Id = new Guid("5e2385b4-08f6-4e9e-888b-5d94c4b7fb78"),
                ScheduleId = schedule20.Id,
                DeviceStatus = DEVICE_STATUS.INUSE,
                Description = "The desktop was used for backend development tasks."
            };

            builder.Entity<Report>().HasData(rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16, rp17, rp18, rp19, rp20);

            //builder.Entity<ProjectStatus>().HasData(
            //    new ProjectStatus
            //    {
            //        Id = 1,
            //        Name = "Initializing",
            //    },
            //    new ProjectStatus
            //    {
            //        Id = 2,
            //        Name = "On-going",
            //    },
            //    new ProjectStatus
            //    {
            //        Id = 3,
            //        Name = "Completed",
            //    },
            //    new ProjectStatus
            //    {
            //        Id = 4,
            //        Name = "Cancel",
            //    }
            //);

            builder.Entity<ProjectType>().HasData(
                new ProjectType
                {
                    Id = 1,
                    Name = "Web Application",
                },
                new ProjectType
                {
                    Id = 2,
                    Name = "Research Paper",
                },
                new ProjectType
                {
                    Id = 3,
                    Name = "Iot"
                },
                new ProjectType
                {
                    Id = 4,
                    Name = "Mobile App"
                },
                new ProjectType
                {
                    Id = 5,
                    Name = "AI"
                },
                new ProjectType
                {
                    Id = 6,
                    Name = "VR"
                }
            );

            Project prj1 = new Project
            {
                Id = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                Name = "LIMS",
                Description = "Implementing LIMS system for laboratory management.",
                CreatedDate = new DateTime(2024, 05, 01),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 5,
                IsRecruiting = false,
                ProjectTypeId = 1
            };

            Project prj2 = new Project
            {
                Id = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                Name = "VR application for patient",
                Description = "Developing application for occupational therapy",
                CreatedDate = new DateTime(2024, 06, 12),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = false,
                ProjectTypeId = 6
            };
            Project prj3 = new Project
            {
                Id = new Guid("1b3c2e9a-c77c-417e-a093-8d701d2b4821"),
                Name = "Research Paper on Quantum Computing",
                Description = "A comprehensive research paper on the applications of quantum computing in cryptography.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 3,
                IsRecruiting = false,
                ProjectTypeId = 2
            };
            Project prj4 = new Project
            {
                Id = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                Name = "AI in Healthcare",
                Description = "Using AI to improve healthcare outcomes.",
                CreatedDate = new DateTime(2023, 12, 06),
                ProjectStatus = PROJECT_STATUS.COMPLETED,
                MaxMember = 5,
                IsRecruiting = false,
                ProjectTypeId = 5
            };
            Project prj5 = new Project
            {
                Id = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                Name = "Environmental Monitoring",
                Description = "Monitoring environmental parameters using IoT.",
                CreatedDate = new DateTime(2024, 01, 16),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 5,
                IsRecruiting = false,
                ProjectTypeId = 3
            };
            Project prj6 = new Project
            {
                Id = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                Name = "Mobile Health App",
                Description = "A mobile application for monitoring and managing personal health data.",
                CreatedDate = new DateTime(2024, 01, 06),
                ProjectStatus = PROJECT_STATUS.COMPLETED,
                MaxMember = 4,
                IsRecruiting = false,
                ProjectTypeId = 4
            };
            Project prj7 = new Project
            {
                Id = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                Name = "AI-based Image Recognition",
                Description = "Developing an AI system for recognizing and classifying images with high accuracy.",
                CreatedDate = new DateTime(2023, 12, 09),
                ProjectStatus = PROJECT_STATUS.CANCEL,
                MaxMember = 5,
                IsRecruiting = false,
                ProjectTypeId = 5
            };
            Project prj8 = new Project
            {
                Id = new Guid("f2cc754b-fd44-45db-b3d8-32db885ba9bd"),
                Name = "Virtual Reality Training Platform",
                Description = "Creating a VR platform for training professionals in various fields.",
                CreatedDate = new DateTime(2024, 07, 05),
                ProjectStatus = PROJECT_STATUS.INITIALIZING,
                MaxMember = 5,
                IsRecruiting = true,
                ProjectTypeId = 6
            };
            Project prj9 = new Project
            {
                Id = new Guid("4e3b54cf-8b56-4590-adca-73112fa8b9e7"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.INITIALIZING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            /// ******************************************************************************************************************************************************
            Project prj10 = new Project
            {
                Id = new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj11 = new Project
            {
                Id = new Guid("94985ddd-ca1f-402f-a389-f1e1df169f75"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj12 = new Project
            {
                Id = new Guid("20a39a90-b376-477d-a2c2-1973cd347092"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj13 = new Project
            {
                Id = new Guid("0e175a98-f6f3-4fbf-aa2f-c7f0f8446d60"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj14 = new Project
            {
                Id = new Guid("2f404ee3-9fe2-407f-a07e-0b100e268c0e"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj15 = new Project
            {
                Id = new Guid("fc88de4a-d833-40a5-a9e5-e5b1b1f0718f"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj16 = new Project
            {
                Id = new Guid("aaa1e013-1aa8-44ef-adaa-298a8d81b2d0"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj17 = new Project
            {
                Id = new Guid("bbbdb7db-bf17-4d42-bb22-beebe83f6f34"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj18 = new Project
            {
                Id = new Guid("c6187862-b687-4c00-9f5a-4d5c6b52d87d"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj19 = new Project
            {
                Id = new Guid("8c76d5f2-2f87-4cf0-820f-f81284cbb10b"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj20 = new Project
            {
                Id = new Guid("2bc0fef9-3000-48ec-82e9-de4dc0494056"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj21 = new Project
            {
                Id = new Guid("390dba55-cdc1-4b12-88b8-0e3c257253c5"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj22 = new Project
            {
                Id = new Guid("da45413f-3263-4076-b186-03c9a5f9220f"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj23 = new Project
            {
                Id = new Guid("a210682e-f41e-4e01-af7c-43cd942ac9df"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj24 = new Project
            {
                Id = new Guid("88d39e7e-3952-43ef-8e15-57116d276d59"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj25 = new Project
            {
                Id = new Guid("a474440d-4a24-4e27-9863-99fb0d0ec189"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj26 = new Project
            {
                Id = new Guid("0d59a77e-14b0-441f-9c66-240b1f4ce144"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj27 = new Project
            {
                Id = new Guid("b915e80e-2894-4443-92ea-1fcfbf3fd851"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj28 = new Project
            {
                Id = new Guid("16e98a28-511a-49b1-9c04-d60626a889ee"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj29 = new Project
            {
                Id = new Guid("b5c6dbc1-8e92-4667-8627-8772ffbd09d0"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };
            Project prj30 = new Project
            {
                Id = new Guid("4b400907-f70f-453e-b8ae-92c522a69805"),
                Name = "Data Analytics for Public Health",
                Description = "Using data analytics to improve public health policies.",
                CreatedDate = new DateTime(2024, 06, 30),
                ProjectStatus = PROJECT_STATUS.ONGOING,
                MaxMember = 4,
                IsRecruiting = true,
                ProjectTypeId = 1
            };

            builder.Entity<Project>().HasData(prj1, prj10, prj11, prj12, prj13, prj14, prj15, prj16, prj17, prj18, prj19, prj2, prj20, prj21, prj22, prj23, prj24, prj25, prj26, prj27, prj28, prj29, prj3, prj30, prj4, prj5, prj6, prj7, prj8, prj9);

            builder.Entity<Member>().HasData(
                new Member
                {
                    ProjectId = prj1.Id,
                    UserId = user1.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 05, 01),
                },
                new Member
                {
                    ProjectId = prj1.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 05, 01),
                },
                new Member
                {
                    ProjectId = prj1.Id,
                    UserId = user4.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 05, 01),
                },
                new Member
                {
                    ProjectId = prj1.Id,
                    UserId = user5.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 05, 01),
                },
                new Member
                {
                    ProjectId = prj1.Id,
                    UserId = user6.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 05, 01),
                },
                new Member
                {
                    ProjectId = prj2.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 12),
                },
                new Member
                {
                    ProjectId = prj2.Id,
                    UserId = user3.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 06, 12),
                },
                new Member
                {
                    ProjectId = prj2.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 12),
                },
                new Member
                {
                    ProjectId = prj2.Id,
                    UserId = user8.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 06, 12),
                },
                new Member
                {
                    ProjectId = prj3.Id,
                    UserId = user12.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 30),
                },
                new Member
                {
                    ProjectId = prj3.Id,
                    UserId = user7.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 30),
                },
                new Member
                {
                    ProjectId = prj3.Id,
                    UserId = user16.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 06, 30),
                },
                new Member
                {
                    ProjectId = prj4.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2023, 12, 06),
                },
                new Member
                {
                    ProjectId = prj4.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2023, 12, 06),

                },
                new Member
                {
                    ProjectId = prj4.Id,
                    UserId = user20.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2023, 12, 06),
                },
                new Member
                {
                    ProjectId = prj4.Id,
                    UserId = user19.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2023, 12, 06),
                },
                new Member
                {
                    ProjectId = prj4.Id,
                    UserId = user18.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2023, 12, 06),
                },
                new Member
                {
                    ProjectId = prj5.Id,
                    UserId = user13.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 01, 16),
                },
                new Member
                {
                    ProjectId = prj5.Id,
                    UserId = user20.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 01, 16),
                },
                new Member
                {
                    ProjectId = prj5.Id,
                    UserId = user17.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 01, 16),
                },
                new Member
                {
                    ProjectId = prj5.Id,
                    UserId = user16.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 01, 16),
                },
                new Member
                {
                    ProjectId = prj5.Id,
                    UserId = user15.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 01, 16),
                },
                new Member
                {
                    ProjectId = prj6.Id,
                    UserId = user12.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 01, 06),
                },
                new Member
                {
                    ProjectId = prj6.Id,
                    UserId = user15.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 01, 06),
                },
                new Member
                {
                    ProjectId = prj6.Id,
                    UserId = user14.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 01, 06),
                },
                new Member
                {
                    ProjectId = prj6.Id,
                    UserId = user7.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 01, 06),
                },
                new Member
                {
                    ProjectId = prj7.Id,
                    UserId = user1.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2023, 12, 09),
                },
                new Member
                {
                    ProjectId = prj7.Id,
                    UserId = user6.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2023, 12, 09),
                },
                new Member
                {
                    ProjectId = prj7.Id,
                    UserId = user5.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2023, 12, 09),
                },
                new Member
                {
                    ProjectId = prj7.Id,
                    UserId = user4.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2023, 12, 09),
                },
                new Member
                {
                    ProjectId = prj7.Id,
                    UserId = user16.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2023, 12, 09),
                },
                new Member
                {
                    ProjectId = prj9.Id,
                    UserId = user13.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 30),
                },
                new Member
                {
                    ProjectId = prj9.Id,
                    UserId = user19.Id,
                    IsLeader = false,
                    JoinDate = new DateTime(2024, 06, 30),
                },
                new Member
                {
                    ProjectId = prj10.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj10.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj10.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj10.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj11.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj11.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj11.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj11.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj12.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj12.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj12.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj12.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj13.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj13.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj13.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj13.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj14.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj14.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj14.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj14.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj15.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj15.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj15.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj15.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj16.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj16.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj16.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj16.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj17.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj17.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj17.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj17.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj18.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj18.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj18.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj18.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj19.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj19.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj19.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj19.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj20.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj20.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj20.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj20.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj21.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj21.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj21.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj21.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj22.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj22.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj22.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj22.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj23.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj23.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj23.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj23.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj24.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj24.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj24.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj24.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj25.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj25.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj25.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj25.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj26.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj26.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj26.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj26.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj27.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj27.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj27.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj27.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj28.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj28.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj28.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj28.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj29.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj29.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj29.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj29.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj30.Id,
                    UserId = user2.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj30.Id,
                    UserId = user3.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj30.Id,
                    UserId = user4.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                },
                new Member
                {
                    ProjectId = prj30.Id,
                    UserId = user5.Id,
                    IsLeader = true,
                    JoinDate = new DateTime(2024, 06, 20),
                }
            );

            TaskList tl1 = new TaskList
            {
                Id = new Guid("0bb2e364-d05d-4128-b24d-0f69725b85f3"),
                Name = "Requirement Analysis",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj1.Id
            };
            TaskList tl2 = new TaskList
            {
                Id = new Guid("8866bcb2-198a-4fcd-b0c0-8090444b8722"),
                Name = "System Design",
                MaxTasks = 4,
                Order = 2,
                ProjectId = prj1.Id,
            };
            TaskList tl3 = new TaskList
            {
                Id = new Guid("94420810-4a35-4f33-a7df-6078ab4efb1c"),
                Name = "Implementation",
                MaxTasks = 10,
                Order = 3,
                ProjectId = prj1.Id
            };
            TaskList tl4 = new TaskList
            {
                Id = new Guid("816ebcd1-124d-4b5c-810e-b0e8aeedb501"),
                Name = "Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj1.Id
            };
            TaskList tl5 = new TaskList
            {
                Id = new Guid("e86a5ffe-7b06-4f06-94a4-698cb58161db"),
                Name = "Deployment",
                MaxTasks = 2,
                Order = 5,
                ProjectId = prj1.Id
            };

            // Task lists for Project "VR application for patient"
            TaskList tl6 = new TaskList
            {
                Id = new Guid("2c81e116-5120-4920-bf51-092081bfc67d"),
                Name = "Initial Research",
                MaxTasks = 3,
                Order = 1,
                ProjectId = prj2.Id
            };
            TaskList tl7 = new TaskList
            {
                Id = new Guid("a88a1f4e-d3dd-42f0-a0e7-3a7f6affa301"),
                Name = "Prototype Development",
                MaxTasks = 5,
                Order = 2,
                ProjectId = prj2.Id
            };
            TaskList tl8 = new TaskList
            {
                Id = new Guid("8de05be7-f7d1-425e-9c5e-b1a965456935"),
                Name = "User Testing",
                MaxTasks = 4,
                Order = 3,
                ProjectId = prj2.Id
            };
            TaskList tl9 = new TaskList
            {
                Id = new Guid("95be764c-437f-42c8-bd26-bf0aff147218"),
                Name = "Final Development",
                MaxTasks = 5,
                Order = 4,
                ProjectId = prj2.Id
            };

            // Task lists for Project "Research Paper on Quantum Computing"
            TaskList tl10 = new TaskList
            {
                Id = new Guid("84f2c617-35e0-4343-a7c8-35226cb4c6a1"),
                Name = "Literature Review",
                MaxTasks = 4,
                Order = 1,
                ProjectId = prj3.Id
            };
            TaskList tl11 = new TaskList
            {
                Id = new Guid("3a339b14-8f9e-413d-97d0-7ce36aafee58"),
                Name = "Experimentation",
                MaxTasks = 6,
                Order = 2,
                ProjectId = prj3.Id
            };
            TaskList tl12 = new TaskList
            {
                Id = new Guid("67a4dd09-f119-4c82-921e-597279ef412d"),
                Name = "Data Analysis",
                MaxTasks = 5,
                Order = 3,
                ProjectId = prj3.Id
            };
            TaskList tl13 = new TaskList
            {
                Id = new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"),
                Name = "Paper Writing",
                MaxTasks = 5,
                Order = 4,
                ProjectId = prj3.Id
            };

            // Task lists for Project "AI in Healthcare"
            TaskList tl14 = new TaskList
            {
                Id = new Guid("5b24898d-dddc-4c99-8c69-5e43a370e45c"),
                Name = "Data Collection",
                MaxTasks = 6,
                Order = 1,
                ProjectId = prj4.Id
            };
            TaskList tl15 = new TaskList
            {
                Id = new Guid("f5840e34-49e8-435f-bbb4-e403c53642b1"),
                Name = "Model Training",
                MaxTasks = 7,
                Order = 2,
                ProjectId = prj4.Id
            };
            TaskList tl16 = new TaskList
            {
                Id = new Guid("4c238c20-5106-4ca5-88a7-9980892a5455"),
                Name = "Model Evaluation",
                MaxTasks = 5,
                Order = 3,
                ProjectId = prj4.Id
            };
            TaskList tl17 = new TaskList
            {
                Id = new Guid("ac829962-0360-44d2-a766-bb50e3e2001e"),
                Name = "Deployment",
                MaxTasks = 4,
                Order = 4,
                ProjectId = prj4.Id
            };

            // Task lists for Project "Environmental Monitoring"
            TaskList tl18 = new TaskList
            {
                Id = new Guid("c07b395a-cbf6-49a4-aeaa-ef28de9517ff"),
                Name = "Sensor Installation",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj5.Id
            };
            TaskList tl19 = new TaskList
            {
                Id = new Guid("24d9bd4f-d960-4081-87a8-6be032290863"),
                Name = "Data Collection",
                MaxTasks = 6,
                Order = 2,
                ProjectId = prj5.Id
            };
            TaskList tl20 = new TaskList
            {
                Id = new Guid("455d5a96-2d52-4aa8-a98f-ac27f4f321c3"),
                Name = "Data Analysis",
                MaxTasks = 5,
                Order = 3,
                ProjectId = prj5.Id
            };
            TaskList tl21 = new TaskList
            {
                Id = new Guid("a37790d5-0113-491b-98af-5060ff8aa26c"),
                Name = "Reporting",
                MaxTasks = 4,
                Order = 4,
                ProjectId = prj5.Id
            };

            // Task lists for Project "Mobile Health App"
            TaskList tl22 = new TaskList
            {
                Id = new Guid("41640d60-1134-45c3-a7c4-2e7f306ec967"),
                Name = "Requirement Gathering",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj6.Id
            };
            TaskList tl23 = new TaskList
            {
                Id = new Guid("5618a016-156a-449c-92e6-926eabe0cf8a"),
                Name = "UI/UX Design",
                MaxTasks = 4,
                Order= 2,
                ProjectId = prj6.Id
            };
            TaskList tl24 = new TaskList
            {
                Id = new Guid("431dd63b-469e-4589-b1c6-4b4af20a7728"),
                Name = "Development",
                MaxTasks = 6,
                Order= 3,
                ProjectId = prj6.Id
            };
            TaskList tl25 = new TaskList
            {
                Id = new Guid("60ac6a0a-2788-4326-ad31-fdd899d7b80f"),
                Name = "Testing",
                MaxTasks = 4,
                Order = 4,
                ProjectId = prj6.Id
            };
            TaskList tl26 = new TaskList
            {
                Id = new Guid("75f606e3-f12a-4257-b486-a15ef2aad23b"),
                Name = "Deployment",
                MaxTasks = 3,
                Order = 5,
                ProjectId = prj6.Id
            };

            // Task lists for Project "AI-based Image Recognition"
            TaskList tl27 = new TaskList
            {
                Id = new Guid("5f54b6b6-614e-46d2-a64e-10d91db2f516"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj7.Id
            };
            TaskList tl28 = new TaskList
            {
                Id = new Guid("b351e4b2-8b16-4c0c-b37b-630bcf661e4b"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj7.Id
            };
            TaskList tl29 = new TaskList
            {
                Id = new Guid("0008056c-1d86-45f8-ae4e-b0512284472d"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj7.Id
            };
            TaskList tl30 = new TaskList
            {
                Id = new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj7.Id
            };
            // Task lists for Project ""
            TaskList tl31 = new TaskList
            {
                Id = new Guid("00085297-3c05-4062-a240-bb1b4c6b4a38"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj10.Id
            };
            TaskList tl32 = new TaskList
            {
                Id = new Guid("d91d4391-852d-4e06-b122-0374b8b5d854"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj10.Id
            };
            TaskList tl33 = new TaskList
            {
                Id = new Guid("b3f0e11a-2e7e-438b-8905-4b02a5028f95"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj10.Id
            };
            TaskList tl34 = new TaskList
            {
                Id = new Guid("75072b8e-0a97-470a-86d8-1f105994df83"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj10.Id
            };
            // Task lists for Project ""
            TaskList tl35 = new TaskList
            {
                Id = new Guid("6b9652a0-3923-4885-bdee-a31f15e9e855"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj10.Id
            };
            TaskList tl36 = new TaskList
            {
                Id = new Guid("a35f0d22-bf97-436f-9aee-a33edf8e26d3"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj10.Id
            };
            TaskList tl37 = new TaskList
            {
                Id = new Guid("31da73d3-4de1-49c4-be8b-80a8c0b9d30b"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj10.Id
            };
            TaskList tl38 = new TaskList
            {
                Id = new Guid("4e4d83da-580a-438d-954f-c4a57dcbbf60"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj10.Id
            };
            // Task lists for Project ""
            TaskList tl39 = new TaskList
            {
                Id = new Guid("b1cf6c5a-81a5-495d-9071-335b629f29d0"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj11.Id
            };
            TaskList tl40 = new TaskList
            {
                Id = new Guid("d2220ea0-8e34-4ccf-a8e4-a2b77364a1f8"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj11.Id
            };
            TaskList tl41 = new TaskList
            {
                Id = new Guid("a88e6bc8-51e6-43b1-955b-66d132791b85"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj11.Id
            };
            TaskList tl42 = new TaskList
            {
                Id = new Guid("daf064c6-75ff-4590-a3b8-a996468e19d8"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj11.Id
            };
            // Task lists for Project ""
            TaskList tl43 = new TaskList
            {
                Id = new Guid("9fe99984-6667-4011-9be6-ec588a437e26"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj12.Id
            };
            TaskList tl44 = new TaskList
            {
                Id = new Guid("c17941d1-a1b7-4a31-9b9e-729449214f30"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj12.Id
            };
            TaskList tl45 = new TaskList
            {
                Id = new Guid("41a17fc7-3de1-4033-8732-c24849eae75c"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj12.Id
            };
            TaskList tl46 = new TaskList
            {
                Id = new Guid("fa15a081-aeae-425c-b9c3-06c2646aa4c6"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj12.Id
            };
            // Task lists for Project ""
            TaskList tl47 = new TaskList
            {
                Id = new Guid("b5a32109-454a-48f3-b298-712238b91483"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj13.Id
            };
            TaskList tl48 = new TaskList
            {
                Id = new Guid("420ee8e5-71b3-49e4-b809-296e3058349e"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj13.Id
            };
            TaskList tl49 = new TaskList
            {
                Id = new Guid("2b140863-8557-4ad9-b2c1-ee9ee7381a2c"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj13.Id
            };
            TaskList tl50 = new TaskList
            {
                Id = new Guid("b1d1ceed-5120-4c84-aed7-ecaf2da41f88"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj13.Id
            };
            // Task lists for Project ""
            TaskList tl51 = new TaskList
            {
                Id = new Guid("b5884262-3510-44b5-95ca-82420dc4ba15"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj14.Id
            };
            TaskList tl52 = new TaskList
            {
                Id = new Guid("8dec80db-c938-4030-94c7-2e7fe6821cac"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj14.Id
            };
            TaskList tl53 = new TaskList
            {
                Id = new Guid("9c8b594c-a4b1-428d-a017-27b78704307a"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj14.Id
            };
            TaskList tl54 = new TaskList
            {
                Id = new Guid("913951cc-4679-46e7-bea9-64092bd733d0"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj14.Id
            };
            // Task lists for Project ""
            TaskList tl55 = new TaskList
            {
                Id = new Guid("5f6f2583-ace4-48b6-98e5-69c400c5f983"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj15.Id
            };
            TaskList tl56 = new TaskList
            {
                Id = new Guid("67cda2c4-355f-4690-ae22-d595fe4c7ae5"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj15.Id
            };
            TaskList tl57 = new TaskList
            {
                Id = new Guid("b5cae679-8459-4214-a9d6-02e9c2f427bb"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj15.Id
            };
            TaskList tl58 = new TaskList
            {
                Id = new Guid("9f4bf898-f8f5-4d7f-8bf5-c3769059060e"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj15.Id
            };
            // Task lists for Project ""
            TaskList tl59 = new TaskList
            {
                Id = new Guid("4fb411c2-c2fe-4dc0-904b-2c711ee8a085"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj16.Id
            };
            TaskList tl60 = new TaskList
            {
                Id = new Guid("556dbbe7-9f99-4c1f-b7a5-44392ad1ae81"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj16.Id
            };
            TaskList tl61 = new TaskList
            {
                Id = new Guid("4473ec89-7805-41b9-8364-d2b35a501636"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj16.Id
            };
            TaskList tl62 = new TaskList
            {
                Id = new Guid("7965e5b0-b9a9-41c7-9d23-55507f84478b"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj16.Id
            };
            // Task lists for Project ""
            TaskList tl63 = new TaskList
            {
                Id = new Guid("3d30d2e9-2fc9-467b-a2a2-030280f534ce"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj17.Id
            };
            TaskList tl64 = new TaskList
            {
                Id = new Guid("ce7bd183-f8e9-4472-b967-6a8548c40323"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj17.Id
            };
            TaskList tl65 = new TaskList
            {
                Id = new Guid("8203bcf4-60d3-4593-9934-32df5f18da43"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj17.Id
            };
            TaskList tl66 = new TaskList
            {
                Id = new Guid("88ccda68-cf6d-4468-a5dc-49474fd2537c"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj17.Id
            };
            // Task lists for Project ""
            TaskList tl67 = new TaskList
            {
                Id = new Guid("b213e848-0190-42af-82ce-143847dfe69a"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj18.Id
            };
            TaskList tl68 = new TaskList
            {
                Id = new Guid("db3c0bd2-aed1-4e4e-bd25-e24080a1e0c8"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj18.Id
            };
            TaskList tl69 = new TaskList
            {
                Id = new Guid("2f7ff47f-c1e2-4e10-b472-298e5dd1e312"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj18.Id
            };
            TaskList tl70 = new TaskList
            {
                Id = new Guid("cdd20bb7-6562-416f-9138-fef2d097cc62"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj18.Id
            };
            // Task lists for Project ""
            TaskList tl71 = new TaskList
            {
                Id = new Guid("bc28df54-9252-46fa-9ec1-7e0c4d92ea16"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj19.Id
            };
            TaskList tl72 = new TaskList
            {
                Id = new Guid("cd75e5bb-185f-41c8-9038-fa77b0e15346"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj19.Id
            };
            TaskList tl73 = new TaskList
            {
                Id = new Guid("2cfc3aab-2f03-4f6f-b532-1cb65cf505bd"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj19.Id
            };
            TaskList tl74 = new TaskList
            {
                Id = new Guid("708358a5-efbb-451d-926c-af4d4f65bb72"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj19.Id
            };
            // Task lists for Project ""
            TaskList tl75 = new TaskList
            {
                Id = new Guid("d3b8b9a5-a488-43c4-8d3a-2ceb948e770f"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj20.Id
            };
            TaskList tl76 = new TaskList
            {
                Id = new Guid("3f3af254-7792-467e-83d4-19c0d2835750"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj20.Id
            };
            TaskList tl77 = new TaskList
            {
                Id = new Guid("b6dd29bd-ff67-4574-8409-f72bf454b5b1"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj20.Id
            };
            TaskList tl78 = new TaskList
            {
                Id = new Guid("0c988920-3d90-4131-b93e-9a50a5b83c8b"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj20.Id
            };
            // Task lists for Project ""
            TaskList tl79 = new TaskList
            {
                Id = new Guid("31b43d03-c250-4b85-b86f-7f106af51f4e"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj21.Id
            };
            TaskList tl80 = new TaskList
            {
                Id = new Guid("b12d7375-dc9f-46a3-a315-eb02cbf0f371"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj21.Id
            };
            TaskList tl81 = new TaskList
            {
                Id = new Guid("60c72e99-ff91-4312-8405-83243c0fd4a8"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj21.Id
            };
            TaskList tl82 = new TaskList
            {
                Id = new Guid("5702d933-e34f-41c9-b9a1-fb64999f3e27"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj21.Id
            };
            // Task lists for Project ""
            TaskList tl83 = new TaskList
            {
                Id = new Guid("072f6ce9-76d8-4d49-95d4-893802b4c49e"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj22.Id
            };
            TaskList tl84 = new TaskList
            {
                Id = new Guid("c059bb8a-b7ba-445d-9f93-3034c64a16b6"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj22.Id
            };
            TaskList tl85 = new TaskList
            {
                Id = new Guid("63f4b512-c46c-4cf4-ad61-5e665735f82b"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj22.Id
            };
            TaskList tl86 = new TaskList
            {
                Id = new Guid("126f3145-dfa9-4c94-aa27-669a70a73dab"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj22.Id
            };
            // Task lists for Project ""
            TaskList tl87 = new TaskList
            {
                Id = new Guid("706fc57b-286f-419e-99a5-3734634bf9e8"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj23.Id
            };
            TaskList tl88 = new TaskList
            {
                Id = new Guid("71ecf7a0-92a9-40f8-9bbf-45a871bea3c3"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj23.Id
            };
            TaskList tl89 = new TaskList
            {
                Id = new Guid("ccc01136-2fc2-4a76-aa88-c943994ea3ed"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj23.Id
            };
            TaskList tl90 = new TaskList
            {
                Id = new Guid("1e8ed824-cfcb-4ec2-8f8b-e3c46067cdff"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj23.Id
            };
            // Task lists for Project ""
            TaskList tl91 = new TaskList
            {
                Id = new Guid("53f24f9c-fe0c-4ded-91ef-2d52d18463b6"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj24.Id
            };
            TaskList tl92 = new TaskList
            {
                Id = new Guid("faa974a0-4bb3-495e-a9a5-195e8516bd44"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj24.Id
            };
            TaskList tl93 = new TaskList
            {
                Id = new Guid("08267faa-a7f9-48b3-bdd1-5ff95d9d500a"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj24.Id
            };
            TaskList tl94 = new TaskList
            {
                Id = new Guid("ace555ec-8088-4219-be76-dc6eb76dc4fd"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj24.Id
            };
            // Task lists for Project ""
            TaskList tl95 = new TaskList
            {
                Id = new Guid("855ee363-b3cc-4628-ac7d-7016fee75dcd"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj25.Id
            };
            TaskList tl96 = new TaskList
            {
                Id = new Guid("f1ccd0d5-7e64-4740-a44d-b89430d6a1fb"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj25.Id
            };
            TaskList tl97 = new TaskList
            {
                Id = new Guid("d3381095-da10-40fd-82ac-75f981774a29"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj25.Id
            };
            TaskList tl98 = new TaskList
            {
                Id = new Guid("d5cd0716-7854-46c2-9909-e20668836094"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj25.Id
            };
            // Task lists for Project ""
            TaskList tl99 = new TaskList
            {
                Id = new Guid("0c370783-e453-471d-8518-4c42b681ff0d"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj26.Id
            };
            TaskList tl100 = new TaskList
            {
                Id = new Guid("327ed869-4449-41ae-84d1-8eeb11d890ac"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj26.Id
            };
            TaskList tl101 = new TaskList
            {
                Id = new Guid("0169efa4-85d1-4e90-a8a2-c14a742c80eb"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj26.Id
            };
            TaskList tl102 = new TaskList
            {
                Id = new Guid("065898cb-e8f8-4305-b8e8-0c69ad7273e4"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj26.Id
            };
            // Task lists for Project ""
            TaskList tl103 = new TaskList
            {
                Id = new Guid("0626e30e-f0a1-40af-a3a0-51edbbd88d03"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj27.Id
            };
            TaskList tl104 = new TaskList
            {
                Id = new Guid("d33a98d8-b806-430c-9c6a-e142d2992379"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj27.Id
            };
            TaskList tl105 = new TaskList
            {
                Id = new Guid("4852130d-ab5f-4979-aa8e-37cce9335e13"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj27.Id
            };
            TaskList tl106 = new TaskList
            {
                Id = new Guid("044978f5-431a-4fd2-aa4e-35fde9b9083b"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj27.Id
            };
            // Task lists for Project ""
            TaskList tl107 = new TaskList
            {
                Id = new Guid("6a772965-aae4-4b04-8e89-fe14dee28b88"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj28.Id
            };
            TaskList tl108 = new TaskList
            {
                Id = new Guid("a1a1142b-22df-49c6-b46f-649dd1345989"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj28.Id
            };
            TaskList tl109 = new TaskList
            {
                Id = new Guid("073e7608-8fc4-4b30-9f92-994c6e3552e9"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj28.Id
            };
            TaskList tl110 = new TaskList
            {
                Id = new Guid("78282fba-7ef4-4f16-89e3-93a097271cc7"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj28.Id
            };
            // Task lists for Project ""
            TaskList tl111 = new TaskList
            {
                Id = new Guid("a373d48c-7a4b-4cc8-a879-19b4b5ff3c41"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj29.Id
            };
            TaskList tl112 = new TaskList
            {
                Id = new Guid("fe2ff4d0-732e-433b-b05d-7a985edc6fe5"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj29.Id
            };
            TaskList tl113 = new TaskList
            {
                Id = new Guid("438858f4-203a-4de5-ab75-20292a481a50"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj29.Id
            };
            TaskList tl114 = new TaskList
            {
                Id = new Guid("b98058fd-7ee5-4430-8a25-c2d86aa80e44"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj29.Id
            };
            // Task lists for Project ""
            TaskList tl115 = new TaskList
            {
                Id = new Guid("e819d6c6-cec6-493a-8e8d-2129a259c634"),
                Name = "Data Collection",
                MaxTasks = 5,
                Order = 1,
                ProjectId = prj30.Id
            };
            TaskList tl116 = new TaskList
            {
                Id = new Guid("d954bf2a-bb9e-4e90-8e43-a4cce635ded3"),
                Name = "Model Development",
                MaxTasks = 3,
                Order = 2,
                ProjectId = prj30.Id
            };
            TaskList tl117 = new TaskList
            {
                Id = new Guid("011dd84d-69f8-47ac-98be-960ed42786ff"),
                Name = "Model Training",
                MaxTasks = 3,
                Order = 3,
                ProjectId = prj30.Id
            };
            TaskList tl118 = new TaskList
            {
                Id = new Guid("3e0dae6f-8ca9-4c9b-b218-210031248c61"),
                Name = "Model Testing",
                MaxTasks = 6,
                Order = 4,
                ProjectId = prj30.Id
            };

            builder.Entity<TaskList>().HasData(tl1, tl2, tl3, tl4, tl5, tl6, tl7, tl8, tl9, tl10, tl11, tl12, tl13, tl14, tl15, tl16, tl17, tl18, tl19, tl20, tl21, tl22, tl23, tl24, tl25, tl26, tl27, tl28, tl29, tl30, tl31, tl32, tl33, tl34, tl35, tl36, tl37, tl38, tl39, tl40, tl41, tl42, tl43, tl44, tl45, tl46, tl47, tl48, tl49, tl50, tl51, tl52, tl53, tl54, tl55, tl56, tl57, tl58, tl59, tl60, tl61, tl62, tl63, tl64, tl65, tl66, tl67, tl68, tl69, tl70, tl71, tl72, tl73, tl74, tl75, tl76, tl77, tl78, tl79, tl80, tl81, tl82, tl83, tl84, tl85, tl86, tl87, tl88, tl89, tl90, tl91, tl92, tl93, tl94, tl95, tl96, tl97, tl98, tl99, tl100, tl101, tl102, tl103, tl104, tl105, tl106, tl107, tl108, tl109, tl110, tl111, tl112, tl113, tl114, tl115, tl116, tl117, tl118);

            //builder.Entity<TaskPriorities>().HasData(
            //    new TaskPriorities
            //    {
            //        Id = 1,
            //        Name = "Low",
            //    },
            //    new TaskPriorities
            //    {
            //        Id = 2,
            //        Name = "Medium",
            //    },
            //    new TaskPriorities
            //    {
            //        Id = 3,
            //        Name = "High",
            //    },
            //    new TaskPriorities
            //    {
            //        Id = 4,
            //        Name = "Critical",
            //    }
            //);

            //builder.Entity<TasksStatus>().HasData(
            //    new TasksStatus
            //    {
            //        Id = 1,
            //        Name = "Open/To do",
            //    },
            //    new TasksStatus
            //    {
            //        Id = 2,
            //        Name = "Doing",
            //    },
            //    new TasksStatus
            //    {
            //        Id = 3,
            //        Name = "Review",
            //    },
            //    new TasksStatus
            //    {
            //        Id = 4,
            //        Name = "Close",
            //    }
            //);
            // Tasks for Project "LIMS"
            Tasks t1 = new Tasks
            {
                Id = new Guid("2dea5f06-9385-46a8-97ec-577eebe2e93b"),
                Title = "Gather Requirements",
                CreatedBy = user1.Id,
                RequiredValidation = true,
                Description = "Gather all requirements for LIMS",
                CreatedDate = new DateTime(2024, 05, 01),
                StartDate = new DateTime(2024, 05, 02),
                DueDate = new DateTime(2024, 05, 10),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("0bb2e364-d05d-4128-b24d-0f69725b85f3"),
                ProjectId = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user3.Id

            };
            Tasks t2 = new Tasks
            {
                Id = new Guid("a551a73d-46d3-4c95-8c72-d17991580b74"),
                Title = "Analyze User Needs",
                CreatedBy = user1.Id,
                RequiredValidation = true,
                Description = "Analyze user needs for the LIMS system",
                CreatedDate = new DateTime(2024, 05, 01),
                StartDate = new DateTime(2024, 05, 02),
                DueDate = new DateTime(2024, 05, 15),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("0bb2e364-d05d-4128-b24d-0f69725b85f3"),
                ProjectId = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user4.Id,
            };
            Tasks t3 = new Tasks
            {
                Id = new Guid("98905a8d-8ca0-4eb5-a6ab-27df729e2d8e"),
                Title = "Design System Architecture",
                CreatedBy = user1.Id,
                RequiredValidation = true,
                Description = "Create a detailed design of the system architecture",
                CreatedDate = new DateTime(2024, 05, 12),
                StartDate = new DateTime(2024, 05, 13),
                DueDate = new DateTime(2024, 05, 25),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("8866bcb2-198a-4fcd-b0c0-8090444b8722"),
                ProjectId = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user3.Id
            };
            Tasks t4 = new Tasks
            {
                Id = new Guid("a1ee2254-c6fd-47be-9e85-05eef2d3c8b7"),
                Title = "Create Database Schema",
                CreatedBy = user1.Id,
                RequiredValidation = true,
                Description = "Develop the database schema for the LIMS system",
                CreatedDate = new DateTime(2024, 05, 12),
                StartDate = new DateTime(2024, 05, 13),
                DueDate = new DateTime(2024, 05, 27),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("8866bcb2-198a-4fcd-b0c0-8090444b8722"),
                ProjectId = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user5.Id,
            };
            Tasks t5 = new Tasks
            {
                Id = new Guid("7f580704-62d1-416e-ac93-d27920ac89b5"),
                Title = "Develop Module A",
                CreatedBy = user3.Id,
                RequiredValidation = true,
                Description = "Implement the core functionality of Module A",
                CreatedDate = new DateTime(2024, 05, 25),
                StartDate = new DateTime(2024, 05, 26),
                DueDate = new DateTime(2024, 06, 15),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("94420810-4a35-4f33-a7df-6078ab4efb1c"),
                ProjectId = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user6.Id
            };
            Tasks t6 = new Tasks
            {
                Id = new Guid("189651cf-51fe-4a9a-aa2d-c70430234f44"),
                Title = "Develop Module B",
                CreatedBy = user3.Id,
                RequiredValidation = true,
                Description = "Implement the core functionality of Module B",
                CreatedDate = new DateTime(2024, 05, 25),
                StartDate = new DateTime(2024, 05, 26),
                DueDate = new DateTime(2024, 06, 20),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("94420810-4a35-4f33-a7df-6078ab4efb1c"),
                ProjectId = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user4.Id
            };
            Tasks t7 = new Tasks
            {
                Id = new Guid("8bf983d2-bf13-40ad-a46c-5cc0eb63519f"),
                Title = "Create Unit Tests",
                CreatedBy = user1.Id,
                RequiredValidation = true,
                Description = "Develop unit tests for Module A",
                CreatedDate = new DateTime(2024, 05, 30),
                StartDate = new DateTime(2024, 06, 01),
                DueDate = new DateTime(2024, 06, 10),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("94420810-4a35-4f33-a7df-6078ab4efb1c"),
                ProjectId = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,
                AssignedTo = user3.Id
            };
            Tasks t8 = new Tasks
            {
                Id = new Guid("f873907a-20a5-4360-a60d-1decda1ccba6"),
                Title = "Perform System Testing",
                CreatedBy = user3.Id,
                RequiredValidation = true,
                Description = "Execute system tests for the LIMS system",
                CreatedDate = new DateTime(2024, 06, 20),
                StartDate = new DateTime(2024, 06, 21),
                DueDate = new DateTime(2024, 07, 01),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("816ebcd1-124d-4b5c-810e-b0e8aeedb501"),
                ProjectId = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user6.Id
            };
            Tasks t9 = new Tasks
            {
                Id = new Guid("28617a26-3ef4-45ac-9f9d-32ec74edc723"),
                Title = "Perform Integration Testing",
                CreatedBy = user3.Id,
                RequiredValidation = true,
                Description = "Execute integration tests for the LIMS system",
                CreatedDate = new DateTime(2024, 06, 20),
                StartDate = new DateTime(2024, 06, 21),
                DueDate = new DateTime(2024, 07, 05),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("816ebcd1-124d-4b5c-810e-b0e8aeedb501"),
                ProjectId = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user5.Id
            };
            Tasks t10 = new Tasks
            {
                Id = new Guid("07adf7cb-121c-4b3d-abb4-2861c9468ae4"),
                Title = "Deploy System",
                CreatedBy = user1.Id,
                RequiredValidation = true,
                Description = "Deploy the LIMS system to production",
                CreatedDate = new DateTime(2024, 07, 01),
                StartDate = new DateTime(2024, 07, 02),
                DueDate = new DateTime(2024, 07, 05),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("e86a5ffe-7b06-4f06-94a4-698cb58161db"),
                ProjectId = new Guid("c70f946f-c591-4794-b053-174765ae386d"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user3.Id
            };

            //Tasks for Project "VR application for patient"
            Tasks t11 = new Tasks
            {
                Id = new Guid("506e2185-63ba-4e89-aea0-0fe048987c54"),
                Title = "Conduct Initial Research",
                CreatedBy = user2.Id,
                RequiredValidation = false,
                Description = "Research on current VR applications in occupational therapy",
                CreatedDate = new DateTime(2024, 05, 01),
                StartDate = new DateTime(2024, 05, 02),
                DueDate = new DateTime(2024, 05, 15),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("2c81e116-5120-4920-bf51-092081bfc67d"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user3.Id
            };
            Tasks t12 = new Tasks
            {
                Id = new Guid("493280b5-0346-4895-a6e2-72d2da4741ef"),
                Title = "Develop Prototype",
                CreatedBy = user2.Id,
                RequiredValidation = true,
                Description = "Create a prototype VR application for patient therapy",
                CreatedDate = new DateTime(2024, 05, 16),
                StartDate = new DateTime(2024, 05, 17),
                DueDate = new DateTime(2024, 06, 05),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("a88a1f4e-d3dd-42f0-a0e7-3a7f6affa301"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user4.Id
            };
            Tasks t13 = new Tasks
            {
                Id = new Guid("a87c0c26-a8ba-4edb-81dc-7346ac7a0468"),
                Title = "Conduct User Testing",
                CreatedBy = user2.Id,
                RequiredValidation = true,
                Description = "Test the prototype with patients and collect feedback",
                CreatedDate = new DateTime(2024, 06, 06),
                StartDate = new DateTime(2024, 06, 07),
                DueDate = new DateTime(2024, 06, 20),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("8de05be7-f7d1-425e-9c5e-b1a965456935"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user8.Id
            };
            Tasks t14 = new Tasks
            {
                Id = new Guid("b746a240-2e8e-41cd-9f80-2dd239374dea"),
                Title = "Finalize Development",
                CreatedBy = user3.Id,
                RequiredValidation = true,
                Description = "Incorporate feedback and finalize the VR application development",
                CreatedDate = new DateTime(2024, 06, 21),
                StartDate = new DateTime(2024, 06, 22),
                DueDate = new DateTime(2024, 07, 10),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("95be764c-437f-42c8-bd26-bf0aff147218"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user8.Id
            };
            Tasks t15 = new Tasks
            {
                Id = new Guid("bb59aa7a-9ede-40f2-a1f7-2b38a7ac0aa1"),
                Title = "Design User Interface",
                CreatedBy = user3.Id,
                RequiredValidation = false,
                Description = "Create user interface designs for the VR application",
                CreatedDate = new DateTime(2024, 05, 01),
                StartDate = new DateTime(2024, 05, 02),
                DueDate = new DateTime(2024, 05, 15),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("2c81e116-5120-4920-bf51-092081bfc67d"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user4.Id
            };
            Tasks t16 = new Tasks
            {
                Id = new Guid("1cebf167-3bb2-4462-a60b-409e4f6ccb8b"),
                Title = "Develop VR Scenarios",
                CreatedBy = user3.Id,
                RequiredValidation = true,
                Description = "Develop different scenarios for VR occupational therapy",
                CreatedDate = new DateTime(2024, 05, 16),
                StartDate = new DateTime(2024, 05, 17),
                DueDate = new DateTime(2024, 06, 05),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("a88a1f4e-d3dd-42f0-a0e7-3a7f6affa301"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user4.Id
            };
            Tasks t17 = new Tasks
            {
                Id = new Guid("574b0b77-1a4c-4f91-8cb3-d3f9fd943dd0"),
                Title = "Conduct User Interviews",
                CreatedBy = user2.Id,
                RequiredValidation = true,
                Description = "Interview potential users to gather requirements and feedback",
                CreatedDate = new DateTime(2024, 06, 06),
                StartDate = new DateTime(2024, 06, 07),
                DueDate = new DateTime(2024, 06, 20),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("8de05be7-f7d1-425e-9c5e-b1a965456935"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user3.Id
            };
            Tasks t18 = new Tasks
            {
                Id = new Guid("269527d0-fadf-43f5-a74a-4c8e96ed3535"),
                Title = "Improve User Experience",
                CreatedBy = user2.Id,
                RequiredValidation = true,
                Description = "Enhance the user experience based on feedback from user testing",
                CreatedDate = new DateTime(2024, 06, 21),
                StartDate = new DateTime(2024, 06, 22),
                DueDate = new DateTime(2024, 07, 10),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("95be764c-437f-42c8-bd26-bf0aff147218"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user3.Id
            };
            Tasks t19 = new Tasks
            {
                Id = new Guid("24d65a98-4aa0-421e-b7f8-702034653159"),
                Title = "Prepare Documentation",
                CreatedBy = user2.Id,
                RequiredValidation = false,
                Description = "Document all aspects of the VR application development",
                CreatedDate = new DateTime(2024, 05, 01),
                StartDate = new DateTime(2024, 05, 02),
                DueDate = new DateTime(2024, 05, 15),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("2c81e116-5120-4920-bf51-092081bfc67d"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,  
                AssignedTo = user8.Id
            };
            Tasks t20 = new Tasks
            {
                Id = new Guid("de14cdcf-436c-4642-9b03-6228b5fa87bb"),
                Title = "Integration with Existing Systems",
                CreatedBy = user2.Id,
                RequiredValidation = true,
                Description = "Ensure the VR application integrates smoothly with existing systems",
                CreatedDate = new DateTime(2024, 05, 16),
                StartDate = new DateTime(2024, 05, 17),
                DueDate = new DateTime(2024, 06, 05),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("a88a1f4e-d3dd-42f0-a0e7-3a7f6affa301"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,
                AssignedTo = user8.Id
            };
            Tasks t21 = new Tasks
            {
                Id = new Guid("1fd2a91e-f6db-449d-a533-99d88b0642e8"),
                Title = "Evaluate Performance",
                CreatedBy = user2.Id,
                RequiredValidation = true,
                Description = "Evaluate the performance of the VR application under different conditions",
                CreatedDate = new DateTime(2024, 06, 06),
                StartDate = new DateTime(2024, 06, 07),
                DueDate = new DateTime(2024, 06, 20),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("8de05be7-f7d1-425e-9c5e-b1a965456935"),
                ProjectId = new Guid("2f722609-dace-4c60-a6f3-19e015546310"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,
                AssignedTo = user3.Id
            };

            Tasks t22 = new Tasks
            {
                Id = new Guid("9eb5bb05-946f-4e93-80aa-0593c06e1d7b"),
                Title = "Conduct Literature Review",
                CreatedBy = user12.Id,
                RequiredValidation = false,
                Description = "Review existing literature on quantum computing",
                CreatedDate = new DateTime(2024, 05, 01),
                StartDate = new DateTime(2024, 05, 02),
                DueDate = new DateTime(2024, 05, 15),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("84f2c617-35e0-4343-a7c8-35226cb4c6a1"),
                ProjectId = new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user7.Id
            };
            Tasks t23 = new Tasks
            {
                Id = new Guid("0928cce1-121b-4b27-b233-58f8d7a97810"),
                Title = "Design Experiment",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Design experiments to test quantum algorithms",
                CreatedDate = new DateTime(2024, 05, 16),
                StartDate = new DateTime(2024, 05, 17),
                DueDate = new DateTime(2024, 06, 05),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("3a339b14-8f9e-413d-97d0-7ce36aafee58"),
                ProjectId = new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user7.Id
            };
            Tasks t24 = new Tasks
            {
                Id = new Guid("26b877a8-7541-4350-8831-10a7d6781988"),
                Title = "Conduct Experiments",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Carry out designed experiments on quantum computing",
                CreatedDate = new DateTime(2024, 06, 06),
                StartDate = new DateTime(2024, 06, 07),
                DueDate = new DateTime(2024, 06, 20),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("3a339b14-8f9e-413d-97d0-7ce36aafee58"),
                ProjectId = new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user7.Id
            };
            Tasks t25 = new Tasks
            {
                Id = new Guid("79da03b6-24be-4a6a-98b5-eadcaf5a8ed3"),
                Title = "Analyze Data",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Analyze the data collected from experiments",
                CreatedDate = new DateTime(2024, 06, 21),
                StartDate = new DateTime(2024, 06, 22),
                DueDate = new DateTime(2024, 07, 10),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("67a4dd09-f119-4c82-921e-597279ef412d"),
                ProjectId = new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user16.Id
            };
            Tasks t26 = new Tasks
            {
                Id = new Guid("e2f7147d-ac48-4b1f-9dee-3bb590063de4"),
                Title = "Draft Research Paper",
                CreatedBy = user12.Id,
                RequiredValidation = false,
                Description = "Write the initial draft of the research paper",
                CreatedDate = new DateTime(2024, 07, 11),
                StartDate = new DateTime(2024, 07, 12),
                DueDate = new DateTime(2024, 07, 30),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"),
                ProjectId = new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user16.Id
            };
            Tasks t27 = new Tasks
            {
                Id = new Guid("de6d1c54-6561-4433-bb1a-1013174a4937"),
                Title = "Review Draft",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Review the initial draft and make necessary corrections",
                CreatedDate = new DateTime(2024, 08, 01),
                StartDate = new DateTime(2024, 08, 02),
                DueDate = new DateTime(2024, 08, 15),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"),
                ProjectId = new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user7.Id
            };
            Tasks t28 = new Tasks
            {
                Id = new Guid("55115cac-f39b-44a1-941e-b33c91b8632a"),
                Title = "Submit Paper for Peer Review",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Submit the paper to a journal for peer review",
                CreatedDate = new DateTime(2024, 08, 16),
                StartDate = new DateTime(2024, 08, 17),
                DueDate = new DateTime(2024, 09, 01),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"),
                ProjectId = new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,
                AssignedTo = user7.Id
            };
            Tasks t29 = new Tasks
            {
                Id = new Guid("6f58ce78-70e0-4d37-bbcf-03681223355c"),
                Title = "Address Peer Review Comments",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Address any comments or suggestions from peer reviewers",
                CreatedDate = new DateTime(2024, 09, 02),
                StartDate = new DateTime(2024, 09, 03),
                DueDate = new DateTime(2024, 09, 20),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"),
                ProjectId = new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 4,
                AssignedTo = user16.Id
            };
            Tasks t30 = new Tasks
            {
                Id = new Guid("25f640e0-7ec0-4862-a6b0-2f7ad7aae367"),
                Title = "Finalize Paper",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Incorporate peer review comments and finalize the paper",
                CreatedDate = new DateTime(2024, 09, 21),
                StartDate = new DateTime(2024, 09, 22),
                DueDate = new DateTime(2024, 10, 05),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"),
                ProjectId = new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 5,
                AssignedTo = user7.Id
            };
            Tasks t31 = new Tasks
            {
                Id = new Guid("878cdd73-e80a-4a89-9348-b125867b3ee0"),
                Title = "Publish Paper",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Publish the final paper in a scientific journal",
                CreatedDate = new DateTime(2024, 10, 06),
                StartDate = new DateTime(2024, 10, 07),
                DueDate = new DateTime(2024, 10, 20),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"),
                ProjectId = new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 6,
                AssignedTo = user16.Id
            };

            // Task lists for Project "AI in Healthcare"

            Tasks t32 = new Tasks
            {
                Id = new Guid("232e6e66-8b24-4305-be80-fbe67d333f19"),
                Title = "Collect Patient Data",
                CreatedBy = user2.Id,
                RequiredValidation = true,
                Description = "Gather patient data for AI training",
                CreatedDate = new DateTime(2023, 12, 07),
                StartDate = new DateTime(2023, 12, 08),
                DueDate = new DateTime(2023, 12, 20),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("5b24898d-dddc-4c99-8c69-5e43a370e45c"),
                ProjectId = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user4.Id
            };
            Tasks t33 = new Tasks
            {
                Id = new Guid("a70e55b4-5935-4498-9411-4f1a22101f11"),
                Title = "Prepare Training Data",
                CreatedBy = user2.Id,
                RequiredValidation = false,
                Description = "Process and prepare the data for AI model training",
                CreatedDate = new DateTime(2023, 12, 21),
                StartDate = new DateTime(2023, 12, 22),
                DueDate = new DateTime(2024, 01, 05),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("5b24898d-dddc-4c99-8c69-5e43a370e45c"),
                ProjectId = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user20.Id
            };
            Tasks t34 = new Tasks
            {
                Id = new Guid("c1fa15bb-68e3-4db7-b161-5e619643ccf9"),
                Title = "Develop AI Model",
                CreatedBy = user4.Id,
                RequiredValidation = true,
                Description = "Develop the AI model for healthcare predictions",
                CreatedDate = new DateTime(2024, 01, 06),
                StartDate = new DateTime(2024, 01, 07),
                DueDate = new DateTime(2024, 01, 31),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("f5840e34-49e8-435f-bbb4-e403c53642b1"),
                ProjectId = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user20.Id
            };
            Tasks t35 = new Tasks
            {
                Id = new Guid("e0d133a7-f4e4-46b5-a38e-228964ae0a2c"),
                Title = "Train AI Model",
                CreatedBy = user2.Id,
                RequiredValidation = true,
                Description = "Train the AI model using the prepared data",
                CreatedDate = new DateTime(2024, 02, 01),
                StartDate = new DateTime(2024, 02, 02),
                DueDate = new DateTime(2024, 02, 28),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("f5840e34-49e8-435f-bbb4-e403c53642b1"),
                ProjectId = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user19.Id
            };
            Tasks t36 = new Tasks
            {
                Id = new Guid("3f57d84d-ab4b-4264-a099-b4b55440df0f"),
                Title = "Evaluate Model Performance",
                CreatedBy = user2.Id,
                RequiredValidation = false,
                Description = "Evaluate the performance of the trained AI model",
                CreatedDate = new DateTime(2024, 03, 01),
                StartDate = new DateTime(2024, 03, 02),
                DueDate = new DateTime(2024, 03, 15),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("4c238c20-5106-4ca5-88a7-9980892a5455"),
                ProjectId = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user18.Id
            };
            Tasks t37 = new Tasks
            {
                Id = new Guid("e5b86e5d-972b-4248-b5aa-1b0e7367698e"),
                Title = "Refine Model",
                CreatedBy = user4.Id,
                RequiredValidation = true,
                Description = "Refine the AI model based on evaluation results",
                CreatedDate = new DateTime(2024, 03, 16),
                StartDate = new DateTime(2024, 03, 17),
                DueDate = new DateTime(2024, 03, 31),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("4c238c20-5106-4ca5-88a7-9980892a5455"),
                ProjectId = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user19.Id
            };
            Tasks t38 = new Tasks
            {
                Id = new Guid("3c676df2-bb57-4408-9c99-ae04242599c7"),
                Title = "Deploy AI Model",
                CreatedBy = user4.Id,
                RequiredValidation = true,
                Description = "Deploy the AI model to the healthcare system",
                CreatedDate = new DateTime(2024, 04, 01),
                StartDate = new DateTime(2024, 04, 02),
                DueDate = new DateTime(2024, 04, 15),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("ac829962-0360-44d2-a766-bb50e3e2001e"),
                ProjectId = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user20.Id
            };
            Tasks t39 = new Tasks
            {
                Id = new Guid("6d042aa6-a33f-416c-b058-5e5f0d75c720"),
                Title = "Monitor AI Model",
                CreatedBy = user4.Id,
                RequiredValidation = false,
                Description = "Monitor the performance of the deployed AI model",
                CreatedDate = new DateTime(2024, 04, 16),
                StartDate = new DateTime(2024, 04, 17),
                DueDate = new DateTime(2024, 04, 30),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("ac829962-0360-44d2-a766-bb50e3e2001e"),
                ProjectId = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user19.Id
            };
            Tasks t40 = new Tasks
            {
                Id = new Guid("ae1d316a-2ced-4cd4-8ca9-2d1977b85e11"),
                Title = "Collect Feedback",
                CreatedBy = user2.Id,
                RequiredValidation = true,
                Description = "Collect feedback from healthcare providers using the AI model",
                CreatedDate = new DateTime(2024, 05, 01),
                StartDate = new DateTime(2024, 05, 02),
                DueDate = new DateTime(2024, 05, 15),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("ac829962-0360-44d2-a766-bb50e3e2001e"),
                ProjectId = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,
                AssignedTo = user4.Id
            };
            Tasks t41 = new Tasks
            {
                Id = new Guid("4dad49ff-a7a0-4c8a-950a-8d713a0c8932"),
                Title = "Prepare Final Report",
                CreatedBy = user2.Id,
                RequiredValidation = true,
                Description = "Prepare a final report on the AI in Healthcare project",
                CreatedDate = new DateTime(2024, 05, 16),
                StartDate = new DateTime(2024, 05, 17),
                DueDate = new DateTime(2024, 06, 01),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("ac829962-0360-44d2-a766-bb50e3e2001e"),
                ProjectId = new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 4,
                AssignedTo = user4.Id
            };

            // Task lists for Project "Environmental Monitoring"

            Tasks t42 = new Tasks
            {
                Id = new Guid("a00f5027-9268-4393-813c-a63db0c2a8a8"),
                Title = "Install Temperature Sensors",
                CreatedBy = user13.Id,
                RequiredValidation = true,
                Description = "Install sensors for monitoring temperature",
                CreatedDate = new DateTime(2024, 01, 17),
                StartDate = new DateTime(2024, 01, 18),
                DueDate = new DateTime(2024, 01, 25),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("c07b395a-cbf6-49a4-aeaa-ef28de9517ff"),
                ProjectId = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user20.Id
            };
            Tasks t43 = new Tasks
            {
                Id = new Guid("ddb21729-1887-4e7a-940b-feea633ee41a"),
                Title = "Calibrate Sensors",
                CreatedBy = user13.Id,
                RequiredValidation = false,
                Description = "Calibrate the installed sensors for accurate readings",
                CreatedDate = new DateTime(2024, 01, 26),
                StartDate = new DateTime(2024, 01, 27),
                DueDate = new DateTime(2024, 02, 03),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("c07b395a-cbf6-49a4-aeaa-ef28de9517ff"),
                ProjectId = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user17.Id
            };
            Tasks t44 = new Tasks
            {
                Id = new Guid("43d107bc-fa1c-4afc-98bd-0007d5aa7020"),
                Title = "Collect Air Quality Data",
                CreatedBy = user13.Id,
                RequiredValidation = true,
                Description = "Gather air quality data using the installed sensors",
                CreatedDate = new DateTime(2024, 02, 04),
                StartDate = new DateTime(2024, 02, 05),
                DueDate = new DateTime(2024, 02, 12),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("24d9bd4f-d960-4081-87a8-6be032290863"),
                ProjectId = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user16.Id
            };
            Tasks t45 = new Tasks
            {
                Id = new Guid("82bfec66-7d0c-4cbb-bf2d-77fc147aaf09"),
                Title = "Monitor Water Quality",
                CreatedBy = user13.Id,
                RequiredValidation = true,
                Description = "Monitor the quality of water using IoT sensors",
                CreatedDate = new DateTime(2024, 02, 13),
                StartDate = new DateTime(2024, 02, 14),
                DueDate = new DateTime(2024, 02, 21),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("24d9bd4f-d960-4081-87a8-6be032290863"),
                ProjectId = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user15.Id
            };
            Tasks t46 = new Tasks
            {
                Id = new Guid("2bd36dd9-187a-4396-a8ac-586b9aa3e7ba"),
                Title = "Analyze Temperature Data",
                CreatedBy = user20.Id,
                RequiredValidation = true,
                Description = "Analyze the collected temperature data for patterns",
                CreatedDate = new DateTime(2024, 02, 22),
                StartDate = new DateTime(2024, 02, 23),
                DueDate = new DateTime(2024, 03, 01),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("455d5a96-2d52-4aa8-a98f-ac27f4f321c3"),
                ProjectId = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user15.Id
            };
            Tasks t47 = new Tasks
            {
                Id = new Guid("bc34f494-9389-4f72-9649-5e1d6204e663"),
                Title = "Evaluate Air Quality Data",
                CreatedBy = user20.Id,
                RequiredValidation = false,
                Description = "Evaluate the air quality data to assess pollution levels",
                CreatedDate = new DateTime(2024, 03, 02),
                StartDate = new DateTime(2024, 03, 03),
                DueDate = new DateTime(2024, 03, 10),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("455d5a96-2d52-4aa8-a98f-ac27f4f321c3"),
                ProjectId = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user17.Id
            };
            Tasks t48 = new Tasks
            {
                Id = new Guid("0fb94e6e-024e-4fd3-bd24-8dc60f0acaaf"),
                Title = "Generate Temperature Report",
                CreatedBy = user20.Id,
                RequiredValidation = true,
                Description = "Create a report based on the analyzed temperature data",
                CreatedDate = new DateTime(2024, 03, 11),
                StartDate = new DateTime(2024, 03, 12),
                DueDate = new DateTime(2024, 03, 18),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("a37790d5-0113-491b-98af-5060ff8aa26c"),
                ProjectId = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user16.Id
            };
            Tasks t49 = new Tasks
            {
                Id = new Guid("873b1348-3fae-4d43-bd10-f8944e356eb0"),
                Title = "Prepare Air Quality Report",
                CreatedBy = user13.Id,
                RequiredValidation = false,
                Description = "Prepare a detailed report on the air quality findings",
                CreatedDate = new DateTime(2024, 03, 19),
                StartDate = new DateTime(2024, 03, 20),
                DueDate = new DateTime(2024, 03, 27),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("a37790d5-0113-491b-98af-5060ff8aa26c"),
                ProjectId = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user20.Id
            };
            Tasks t50 = new Tasks
            {
                Id = new Guid("75fa3124-b700-417b-a58b-0ff98a970cba"),
                Title = "Evaluate Water Quality Data",
                CreatedBy = user13.Id,
                RequiredValidation = true,
                Description = "Analyze water quality data for contamination",
                CreatedDate = new DateTime(2024, 03, 28),
                StartDate = new DateTime(2024, 03, 29),
                DueDate = new DateTime(2024, 04, 04),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("455d5a96-2d52-4aa8-a98f-ac27f4f321c3"),
                ProjectId = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,
                AssignedTo = user17.Id
            };
            Tasks t51 = new Tasks
            {
                Id = new Guid("fb6f1125-7ce8-4977-a06a-047c906d29bc"),
                Title = "Compile Final Report",
                CreatedBy = user13.Id,
                RequiredValidation = true,
                Description = "Compile all findings into a comprehensive final report",
                CreatedDate = new DateTime(2024, 04, 05),
                StartDate = new DateTime(2024, 04, 06),
                DueDate = new DateTime(2024, 04, 15),
                TaskPriority = TASK_PRIORITY.LOW,
                TaskListId = new Guid("a37790d5-0113-491b-98af-5060ff8aa26c"),
                ProjectId = new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,
                AssignedTo = user20.Id
            };

            // Tasks for Project "Mobile Health App"
            Tasks t52 = new Tasks
            {
                Id = new Guid("9a07a1b4-7093-4048-80d8-49cb69eccea7"),
                Title = "Gather Requirements",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Collect requirements from stakeholders",
                CreatedDate = new DateTime(2024, 01, 07),
                StartDate = new DateTime(2024, 01, 08),
                DueDate = new DateTime(2024, 01, 15),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("41640d60-1134-45c3-a7c4-2e7f306ec967"),
                ProjectId = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user15.Id
            };
            Tasks t53 = new Tasks
            {
                Id = new Guid("1f412d44-c3fc-4f4a-bf22-e0ed210d2c2a"),
                Title = "Design UI Mockups",
                CreatedBy = user12.Id,
                RequiredValidation = false,
                Description = "Create UI mockups for the app",
                CreatedDate = new DateTime(2024, 01, 16),
                StartDate = new DateTime(2024, 01, 17),
                DueDate = new DateTime(2024, 01, 22),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("5618a016-156a-449c-92e6-926eabe0cf8a"),
                ProjectId = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user14.Id
            };
            Tasks t54 = new Tasks
            {
                Id = new Guid("8030fade-0f45-4971-8c38-0d4b329e1f95"),
                Title = "Develop Authentication Module",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Implement the user authentication module",
                CreatedDate = new DateTime(2024, 01, 23),
                StartDate = new DateTime(2024, 01, 24),
                DueDate = new DateTime(2024, 02, 01),
                TaskPriority = TASK_PRIORITY.CRITICAL,
                TaskListId = new Guid("431dd63b-469e-4589-b1c6-4b4af20a7728"),
                ProjectId = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user7.Id
            };
            Tasks t55 = new Tasks
            {
                Id = new Guid("16a3be27-df3c-4e7a-9b6c-97c81eceadf0"),
                Title = "Integrate Health APIs",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Integrate APIs for health data",
                CreatedDate = new DateTime(2024, 02, 02),
                StartDate = new DateTime(2024, 02, 03),
                DueDate = new DateTime(2024, 02, 10),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("431dd63b-469e-4589-b1c6-4b4af20a7728"),
                ProjectId = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,
                AssignedTo = user15.Id
            };
            Tasks t56 = new Tasks
            {
                Id = new Guid("faa1404e-f423-4e45-9678-fbf1dbe03114"),
                Title = "Unit Testing",
                CreatedBy = user12.Id,
                RequiredValidation = false,
                Description = "Perform unit testing on developed modules",
                CreatedDate = new DateTime(2024, 02, 11),
                StartDate = new DateTime(2024, 02, 12),
                DueDate = new DateTime(2024, 02, 18),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("60ac6a0a-2788-4326-ad31-fdd899d7b80f"),
                ProjectId = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user7.Id
            };
            Tasks t57 = new Tasks
            {
                Id = new Guid("a61919da-1b18-4430-bac7-044a119cc94a"),
                Title = "Conduct Beta Testing",
                CreatedBy = user15.Id,
                RequiredValidation = true,
                Description = "Conduct beta testing with selected users",
                CreatedDate = new DateTime(2024, 02, 19),
                StartDate = new DateTime(2024, 02, 20),
                DueDate = new DateTime(2024, 02, 28),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("60ac6a0a-2788-4326-ad31-fdd899d7b80f"),
                ProjectId = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user14.Id
            };
            Tasks t58 = new Tasks
            {
                Id = new Guid("f384d62d-bf83-41b6-aff1-7c6c752f4007"),
                Title = "Fix Identified Bugs",
                CreatedBy = user15.Id,
                RequiredValidation = true,
                Description = "Fix bugs identified during testing",
                CreatedDate = new DateTime(2024, 02, 29),
                StartDate = new DateTime(2024, 03, 01),
                DueDate = new DateTime(2024, 03, 07),
                TaskPriority = TASK_PRIORITY.CRITICAL,
                TaskListId = new Guid("60ac6a0a-2788-4326-ad31-fdd899d7b80f"),
                ProjectId = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,
                AssignedTo = user7.Id
            };
            Tasks t59 = new Tasks
            {
                Id = new Guid("5f6c7526-71da-4ff0-95ee-cfbc56d5fc03"),
                Title = "Prepare Deployment Plan",
                CreatedBy = user12.Id,
                RequiredValidation = false,
                Description = "Prepare a detailed deployment plan",
                CreatedDate = new DateTime(2024, 03, 08),
                StartDate = new DateTime(2024, 03, 09),
                DueDate = new DateTime(2024, 03, 15),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("75f606e3-f12a-4257-b486-a15ef2aad23b"),
                ProjectId = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user15.Id
            };
            Tasks t60 = new Tasks
            {
                Id = new Guid("8e62b119-e3df-44ae-a432-119ca8384db5"),
                Title = "Deploy to Production",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Deploy the app to the production environment",
                CreatedDate = new DateTime(2024, 03, 16),
                StartDate = new DateTime(2024, 03, 17),
                DueDate = new DateTime(2024, 03, 20),
                TaskPriority = TASK_PRIORITY.CRITICAL,
                TaskListId = new Guid("75f606e3-f12a-4257-b486-a15ef2aad23b"),
                ProjectId = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user7.Id
            };
            Tasks t61 = new Tasks
            {
                Id = new Guid("b2af7872-5bf8-4d3b-b109-d0755da498b7"),
                Title = "Post-Deployment Support",
                CreatedBy = user12.Id,
                RequiredValidation = true,
                Description = "Provide support and monitor the app post-deployment",
                CreatedDate = new DateTime(2024, 03, 21),
                StartDate = new DateTime(2024, 03, 22),
                DueDate = new DateTime(2024, 03, 29),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("75f606e3-f12a-4257-b486-a15ef2aad23b"),
                ProjectId = new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user14.Id
            };

            // Tasks for Project "AI-based Image Recognition"
            Tasks t62 = new Tasks
            {
                Id = new Guid("4e0910eb-4502-48c3-92ad-1aa03a9cc12e"),
                Title = "Data Collection Plan",
                CreatedBy = user1.Id,
                RequiredValidation = true,
                Description = "Create a plan for collecting data for image recognition",
                CreatedDate = new DateTime(2023, 12, 10),
                StartDate = new DateTime(2023, 12, 11),
                DueDate = new DateTime(2023, 12, 18),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("5f54b6b6-614e-46d2-a64e-10d91db2f516"),
                ProjectId = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user6.Id
            };
            Tasks t63 = new Tasks
            {
                Id = new Guid("c5721f73-535e-4f68-835a-b0267631f127"),
                Title = "Preprocessing Data",
                CreatedBy = user1.Id,
                RequiredValidation = false,
                Description = "Preprocess collected data for training",
                CreatedDate = new DateTime(2023, 12, 19),
                StartDate = new DateTime(2023, 12, 20),
                DueDate = new DateTime(2023, 12, 25),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("5f54b6b6-614e-46d2-a64e-10d91db2f516"),
                ProjectId = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user5.Id
            };
            Tasks t64 = new Tasks
            {
                Id = new Guid("21fb7139-1def-43d9-bc25-87d84ad9c141"),
                Title = "Model Development",
                CreatedBy = user1.Id,
                RequiredValidation = true,
                Description = "Develop the initial image recognition model",
                CreatedDate = new DateTime(2023, 12, 26),
                StartDate = new DateTime(2023, 12, 27),
                DueDate = new DateTime(2024, 01, 05),
                TaskPriority = TASK_PRIORITY.CRITICAL,
                TaskListId = new Guid("b351e4b2-8b16-4c0c-b37b-630bcf661e4b"),
                ProjectId = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user4.Id
            };
            Tasks t65 = new Tasks
            {
                Id = new Guid("41281716-6715-44f7-a7f6-0382c12fb7a2"),
                Title = "Training Model",
                CreatedBy = user1.Id,
                RequiredValidation = true,
                Description = "Train the image recognition model with collected data",
                CreatedDate = new DateTime(2024, 01, 06),
                StartDate = new DateTime(2024, 01, 07),
                DueDate = new DateTime(2024, 01, 15),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("0008056c-1d86-45f8-ae4e-b0512284472d"),
                ProjectId = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user16.Id
            };
            Tasks t66 = new Tasks
            {
                Id = new Guid("81f1530e-bce0-45c9-b4af-b0393009fc56"),
                Title = "Model Testing",
                CreatedBy = user1.Id,
                RequiredValidation = false,
                Description = "Test the trained model for accuracy and performance",
                CreatedDate = new DateTime(2024, 01, 16),
                StartDate = new DateTime(2024, 01, 17),
                DueDate = new DateTime(2024, 01, 22),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"),
                ProjectId = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 1,
                AssignedTo = user6.Id
            };
            Tasks t67 = new Tasks
            {
                Id = new Guid("237219d8-c04a-4ab1-bda7-045fe94b6d9c"),
                Title = "Optimize Model",
                CreatedBy = user6.Id,
                RequiredValidation = true,
                Description = "Optimize the model for faster inference and better accuracy",
                CreatedDate = new DateTime(2024, 01, 23),
                StartDate = new DateTime(2024, 01, 24),
                DueDate = new DateTime(2024, 01, 31),
                TaskPriority = TASK_PRIORITY.CRITICAL,
                TaskListId = new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"),
                ProjectId = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 2,
                AssignedTo = user16.Id
            };
            Tasks t68 = new Tasks
            {
                Id = new Guid("f3e477a0-283a-41a3-9895-7b68d59c0d1f"),
                Title = "Deploy Model",
                CreatedBy = user6.Id,
                RequiredValidation = true,
                Description = "Deploy the trained model into a production environment",
                CreatedDate = new DateTime(2024, 02, 01),
                StartDate = new DateTime(2024, 02, 02),
                DueDate = new DateTime(2024, 02, 10),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"),
                ProjectId = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 3,
                AssignedTo = user5.Id
            };
            Tasks t69 = new Tasks
            {
                Id = new Guid("20717fc1-7cc5-40d7-841a-1cce5a9d0026"),
                Title = "Monitor Performance",
                CreatedBy = user6.Id,
                RequiredValidation = false,
                Description = "Monitor model performance in production",
                CreatedDate = new DateTime(2024, 02, 11),
                StartDate = new DateTime(2024, 02, 12),
                DueDate = new DateTime(2024, 02, 18),
                TaskPriority = TASK_PRIORITY.MEDIUM,
                TaskListId = new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"),
                ProjectId = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 4,
                AssignedTo = user16.Id
            };
            Tasks t70 = new Tasks
            {
                Id = new Guid("694be8c9-2b1e-4747-8ca0-d724befb9fba"),
                Title = "Fine-tune Model",
                CreatedBy = user1.Id,
                RequiredValidation = true,
                Description = "Continuously fine-tune the model based on feedback",
                CreatedDate = new DateTime(2024, 02, 19),
                StartDate = new DateTime(2024, 02, 20),
                DueDate = new DateTime(2024, 02, 28),
                TaskPriority = TASK_PRIORITY.HIGH,
                TaskListId = new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"),
                ProjectId = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 5,
                AssignedTo = user4.Id
            };
            Tasks t71 = new Tasks
            {
                Id = new Guid("6288fba6-d072-4d9f-ac30-e9b4e43893dc"),
                Title = "Documentation",
                CreatedBy = user6.Id,
                RequiredValidation = true,
                Description = "Document the model architecture and usage",
                CreatedDate = new DateTime(2024, 02, 29),
                StartDate = new DateTime(2024, 03, 01),
                DueDate = new DateTime(2024, 03, 07),
                TaskPriority = TASK_PRIORITY.CRITICAL,
                TaskListId = new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"),
                ProjectId = new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"),
                TaskStatus = TASK_STATUS.OPEN_TODO,
                Order = 6,
                AssignedTo = user4.Id
            };

            builder.Entity<Tasks>().HasData(t1, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t2, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t3, t30, t31, t32, t33, t34, t35, t36, t37, t38, t39, t4, t40, t41, t42, t43, t44, t45, t46, t47, t48, t49, t5, t50, t51, t52, t53, t54, t55, t56, t57, t58, t59, t6, t60, t61, t62, t63, t64, t65, t66, t67, t68, t69, t7, t70, t71, t8, t9);
        }
    }
}
