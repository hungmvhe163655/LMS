using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS_BACKEND_MAIN.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewDataAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "094505b2-4be4-43c6-ac2f-53428f706d19",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "86ec2e85-1e1e-4053-ac07-29fc43996444", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9258), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9260), "e166a18d-0372-48bc-b69f-dbb200c0eced", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "1c5c3b44-7164-4232-a49a-10ab367d5102",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "aeeaf371-1062-4214-b9b3-96da01a61c0b", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9120), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9121), "9cc7a1dd-6400-4360-9220-c0108fb6333c", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9121) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "29df78da-8830-4bb3-8ece-f11cf9f5cc34",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "a549a907-f9ad-406e-85d1-bf589c7d42a3", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9182), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9183), "fa434d2f-73d2-4b64-bd68-f67e81a70351", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "603600b5-ca65-4fa7-817e-4583ef22b330",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "14c60fbd-52c9-4c11-9b7d-3255e4c89c7f", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9041), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9042), "d35975ea-eee9-4849-9632-5535b308f8c0", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "68fdf17c-7cbe-4a4c-a674-c530ffc77667",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "f808776e-f629-4060-bf0e-7a300abab3f0", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9050), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9051), "6d0d308a-8161-4007-87c3-4602d4b32b33", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "6ad0a020-e6a6-4e66-8f4a-d815594ba862",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "7ade07fa-c93b-4d58-85e3-72ac0128e38c", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9070), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9071), "3899ba58-ed68-4289-948c-22d158b914be", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9071) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "6c6abe62-f811-4a8b-96eb-ed326c47d209",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "a54593e3-41e7-42c7-b875-6c2ea3fe8f28", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9018), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9020), "96d5aa5b-5e21-4687-bb66-6c466b96761b", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9020) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "72339042-5a5d-46f1-9b24-c5446332a29c",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "be005b90-bae8-4a8e-a8ae-d8e760476f5e", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9221), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9222), "3f7911b1-315c-4be1-872f-0a20230b4256", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9222) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7397c854-194b-4749-9205-f46e4f2fccf8",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "37d916d2-b0eb-48bb-acfb-3644945692b9", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9060), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9062), "b856207b-b301-484e-95c2-37df71e05306", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9062) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "75beaf54-8c16-4464-9cd5-fa272d942f43",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "45e35ed9-40fc-4b01-829f-d5616bb18e4d", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9240), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9241), "e8da47d3-3e8b-4629-baec-5e76f665df11", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9241) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "85b70a16-20bb-400f-a478-78c6f8c6d067",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "267e4757-20cc-42cd-98a7-36cace28ad40", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9249), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9250), "5e2fd146-901b-428b-b09b-3adbfeb48a8b", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "89d0ed33-21e5-401e-b3b4-963ef6e6be16",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "d65de21e-169f-48e3-9b26-ccc9767a7118", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9231), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9232), "9af1d7e9-ec1f-4191-bd74-87a7a25884e6", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9233) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "0df66555-098e-4746-a7e1-aa14957d8a14", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(8993), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9009), "e9115fe4-431a-434d-ab0f-8ab57cf424f7", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9009) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "a687bb04-4f19-49d5-a60f-2db52044767c",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "a612a18c-a71c-4c1a-9388-59b7d2d60d53", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9029), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9030), "8c046803-e6de-4d5f-8deb-ae1f9330b32a", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9031) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "b745d464-f213-487c-8469-1f0d10d32224",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "28094fb1-f931-44a0-bc91-7d55f7e69125", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9141), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9142), "2eef22aa-959a-48c5-af1a-5327915aa187", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9143) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "c4a15b23-9d00-4ec5-acc9-493354e91973",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "14142e36-090e-4182-9e82-605bfbbd6f7f", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9171), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9172), "7e71b16c-2710-4808-9a00-e5eeef641095", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9172) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "d4325be4-cb11-4f2f-b29e-dc52024d6c65",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "f8e4a58d-d465-4622-906b-b7ef8bcf6008", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9132), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9133), "ebb314f4-ae07-471e-8a63-0c21ba075881", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9134) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "d7d2f268-eea4-4299-9342-800564cc6411",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime", "VerifiedBy" },
                values: new object[] { "8ac92cef-606b-4f86-a07a-ce5bcd20beda", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9150), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9151), "2dc60b78-14ef-4b9c-8961-6b7fa0f76a66", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9152), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "e214c150-f35c-4567-aaf0-c103d4e4d198",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "bbfe41d9-ce3a-43a6-bf5a-ecbeeaed1442", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9212), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9213), "ff01cb96-4449-41fd-8bf8-7733f5d3b813", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9214) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "a991811a-1c22-4ca1-8dd2-8ffa9508f3ac", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9161), new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9162), "a005208d-edb9-4656-a0cc-f116fa6688c7", new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9163) });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "EmailVerifyCode", "EmailVerifyCodeAge", "FullName", "Gender", "IsBanned", "IsDeleted", "IsVerified", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRefreshToken", "UserRefreshTokenExpiryTime", "VerifiedBy" },
                values: new object[,]
                {
                    { "2c3fb112-bab3-4e92-8ea5-99f9e459eebb", 0, "985834f9-f5fb-4335-900d-5be231edd32b", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9277), "duongtb@fe.edu.vn", true, null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9278), "Tran Binh Duong", true, false, false, false, false, null, "DUONGTB@FE.EDU.VN", "DUONGTB", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0961396719", true, "6ddc419b-be15-49a5-9e93-66e322e056e6", false, "duongtb", null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9278), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "7c9d1962-a18c-48c9-8c1d-a8cc1a338500", 0, "3fb2b98e-8432-45c3-bdcb-8f9c83b26390", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9267), "huongnt135@fe.edu.vn", true, null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9268), "Nguyen Thuy Huong", false, false, false, false, false, null, "HUONGNT135@FE.EDU.VN", "HUONGNT7", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0961396789", true, "65259260-e392-42a9-9204-01a881665735", false, "huongnt7", null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9268), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "aa95f3d5-3f75-422a-b667-48afe6789500", 0, "d74edaba-3c12-4c17-93b9-69f391c297ee", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9313), "luannd@fpt.edu.vn", true, null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9314), "Ngo Doan Luan", true, false, false, false, false, null, "LUANND@FPT.EDU.VN", "LUANND", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0961396789", true, "08455f35-64f3-4111-8269-0d26f4827854", false, "luannd", null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9315), "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832" },
                    { "f0c48f74-0461-4b07-abf1-912384cd5cbc", 0, "e5ce043c-a2af-4771-9fe5-abc042a02854", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9332), "quynhbn@fpt.edu.vn", true, null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9333), "Bui Ngoc Quynh", true, false, false, false, false, null, "QUYNHBN@FPT.EDU.VN", "QUYNHBN", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0969396289", true, "627342b9-c70c-40b4-b611-05be05348962", false, "quynhbn", null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9333), "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832" },
                    { "fbf09f94-8b51-4611-8997-a40481400e5d", 0, "adfe72d7-7dfc-4b6a-82ea-34398f69abb7", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9323), "nhanpt@fpt.edu.vn", true, null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9324), "Phan Trong Nhan", true, false, false, false, false, null, "NHANPT@FPT.EDU.VN", "NHANPT", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0969396789", true, "db21fa19-62ec-454b-bc85-7db031a6b655", false, "nhanpt", null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9324), "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832" },
                    { "fde461fc-70cb-4334-be2a-521f1e7984da", 0, "b2469d48-3804-4ab1-a53f-c9b5d6fc5ac2", new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9305), "sangnv@fe.edu.vn", true, null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9306), "Nguyen Van Sang", true, false, false, false, false, null, "SANGNV@FE.EDU.VN", "SANGNV", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0961396489", true, "66918165-3f65-4430-8a24-4a6860c0da73", false, "sangnv", null, new DateTime(2024, 7, 25, 14, 23, 49, 206, DateTimeKind.Utc).AddTicks(9307), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" }
                });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 23, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("0a395b72-ae0d-4a49-b7f8-1763de733068"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 20, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9738));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("11d331b4-136c-4844-a686-ffc38c103268"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 15, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 22, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("51e6edb8-0a1f-4c26-afb7-fcf95ea0965f"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 10, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("5947a22f-0191-419c-873b-4324b5b95e84"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 18, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 24, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("a1d65f8a-f7fd-4995-940f-6ab254523f90"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 23, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9742));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("b4dc2d48-482a-48a2-bad6-7a1e0e3139b7"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 24, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("eb934470-4e73-41a8-8304-3bcb1ea18502"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 21, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 16, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 22, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("931129a9-986f-4560-99f1-a06b692c71a1"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 17, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 15, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 21, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 20, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 23, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e331de18-289c-403d-8028-26c4b595587a"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 24, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 19, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("06a6fcd7-eb30-4728-9856-ee8d00f84810"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9896));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("0e287e15-6c9f-44ab-9fb3-dc183f5e5e92"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("19f6bcc1-2a8d-4c5d-ab3b-d5d3b21da159"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9899));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("285ce1fd-470c-4474-ad1b-ba273c0e8653"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("426c57ce-68aa-498b-b603-16cf1e7a238d"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5e2385b4-08f6-4e9e-888b-5d94c4b7fb78"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5faf118e-4687-47c2-9b83-ecb389b8b6d5"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9892));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("697817b7-9d65-47dd-a39b-909f89e25bce"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9900));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("75fb870f-e344-40c9-ab85-101631f22505"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("76199946-58bd-473a-95a7-9da8afcb9fc7"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("78d4e5bd-d685-49b5-8b12-e71df921ec65"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("8455c9b0-c2ca-4de4-bdee-3070dc8af954"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b774e795-3469-4b58-afe0-5f6e9e0a6aec"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b9d04c5f-2ec0-4da1-92ab-7ef9bdcd82e4"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c8fb056c-cff8-4db2-b951-01859431a35e"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("cf4dfffd-74e9-46dd-b9b5-2a9d09001564"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9898));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("d3b039bd-813c-4b33-af98-2264dcb440c0"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9877));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("dd8ac1ac-0f4f-45af-825e-e74e531b66dc"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("e4880a12-6d1d-4e9b-8832-89c5982b1346"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9895));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("f1dcaea6-1670-47d7-b8cb-398b89ca09d0"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9886));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("27f1b969-1b68-4cf8-8a51-c8be5356f7f8"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9808), new DateTime(2024, 7, 23, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9807), new DateTime(2024, 7, 24, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9807) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("37d2c7b3-7406-418d-9062-e81dfff02d9a"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 23, 23, 49, 206, DateTimeKind.Local).AddTicks(9778), new DateTime(2024, 7, 24, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9776), new DateTime(2024, 7, 24, 22, 23, 49, 206, DateTimeKind.Local).AddTicks(9777) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("44efa2a7-4f64-4fc6-bbbe-869099817d4f"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 25, 23, 23, 49, 206, DateTimeKind.Local).AddTicks(9770), new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9768), new DateTime(2024, 7, 25, 22, 23, 49, 206, DateTimeKind.Local).AddTicks(9769) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("4da0b3f8-95aa-40cd-ab32-75876ca13900"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 3, 23, 49, 206, DateTimeKind.Local).AddTicks(9811), new DateTime(2024, 7, 23, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9810), new DateTime(2024, 7, 24, 2, 23, 49, 206, DateTimeKind.Local).AddTicks(9810) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("4fa30f09-e82a-4375-a28f-8190a8667a09"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 20, 3, 23, 49, 206, DateTimeKind.Local).AddTicks(9830), new DateTime(2024, 7, 19, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9829), new DateTime(2024, 7, 20, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("5547314b-521a-47e9-ad60-5e376e686636"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 26, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9845), new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9844), new DateTime(2024, 7, 26, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9844) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("5b1615a6-b870-456a-a483-e99a3f9122dc"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9836), new DateTime(2024, 7, 23, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9835), new DateTime(2024, 7, 24, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9835) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("5dc94e7f-845b-480b-8c81-f1d50c359491"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 23, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9817), new DateTime(2024, 7, 22, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9816), new DateTime(2024, 7, 23, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9816) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("6500363e-6574-42e7-8577-6dc87a55ce15"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9851), new DateTime(2024, 7, 23, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9850), new DateTime(2024, 7, 24, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("70f625f4-33f5-4c62-9718-d3e2c420e703"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 23, 3, 23, 49, 206, DateTimeKind.Local).AddTicks(9820), new DateTime(2024, 7, 22, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9819), new DateTime(2024, 7, 23, 2, 23, 49, 206, DateTimeKind.Local).AddTicks(9819) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("77153502-8631-4b5f-b05d-76d4796c06d4"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 22, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9823), new DateTime(2024, 7, 21, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9822), new DateTime(2024, 7, 22, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9823) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("77790ba9-1f3c-4943-9e39-097000fc6fa2"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 19, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9833), new DateTime(2024, 7, 18, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9832), new DateTime(2024, 7, 19, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9832) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("80d34442-7c14-4060-ae8f-24cda38e63f9"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 23, 23, 49, 206, DateTimeKind.Local).AddTicks(9814), new DateTime(2024, 7, 24, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9813), new DateTime(2024, 7, 24, 22, 23, 49, 206, DateTimeKind.Local).AddTicks(9813) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("8bb44d07-f470-4434-a023-6bdffb4311cc"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 21, 3, 23, 49, 206, DateTimeKind.Local).AddTicks(9826), new DateTime(2024, 7, 20, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9825), new DateTime(2024, 7, 21, 2, 23, 49, 206, DateTimeKind.Local).AddTicks(9825) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("9bfeb5df-03a4-4ae5-904e-1779c19a5313"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 25, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9848), new DateTime(2024, 7, 24, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9846), new DateTime(2024, 7, 25, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9847) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("db1fcaa0-e934-4429-a567-2ac802d0b453"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 25, 3, 23, 49, 206, DateTimeKind.Local).AddTicks(9784), new DateTime(2024, 7, 24, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9783), new DateTime(2024, 7, 25, 2, 23, 49, 206, DateTimeKind.Local).AddTicks(9783) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("e0fa81b1-9eea-4b4b-93a7-b7a34aae4014"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 25, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9781), new DateTime(2024, 7, 24, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9780), new DateTime(2024, 7, 25, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("e377b750-0b20-4943-9e5d-6909d4810f13"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 26, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9774), new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9773), new DateTime(2024, 7, 26, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9773) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("eb607a7a-2572-4a16-bbbd-99f3db25d40b"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 26, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9842), new DateTime(2024, 7, 25, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9841), new DateTime(2024, 7, 26, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9842) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("ff18bb51-3c4e-4fcb-a73e-39f60996be8c"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 25, 1, 23, 49, 206, DateTimeKind.Local).AddTicks(9839), new DateTime(2024, 7, 24, 21, 23, 49, 206, DateTimeKind.Local).AddTicks(9838), new DateTime(2024, 7, 25, 0, 23, 49, 206, DateTimeKind.Local).AddTicks(9838) });

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "2c3fb112-bab3-4e92-8ea5-99f9e459eebb" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "7c9d1962-a18c-48c9-8c1d-a8cc1a338500" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "aa95f3d5-3f75-422a-b667-48afe6789500" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "f0c48f74-0461-4b07-abf1-912384cd5cbc" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "fbf09f94-8b51-4611-8997-a40481400e5d" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "fde461fc-70cb-4334-be2a-521f1e7984da" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "2c3fb112-bab3-4e92-8ea5-99f9e459eebb" });

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "7c9d1962-a18c-48c9-8c1d-a8cc1a338500" });

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "aa95f3d5-3f75-422a-b667-48afe6789500" });

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "f0c48f74-0461-4b07-abf1-912384cd5cbc" });

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "fbf09f94-8b51-4611-8997-a40481400e5d" });

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "fde461fc-70cb-4334-be2a-521f1e7984da" });

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "2c3fb112-bab3-4e92-8ea5-99f9e459eebb");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7c9d1962-a18c-48c9-8c1d-a8cc1a338500");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "aa95f3d5-3f75-422a-b667-48afe6789500");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "f0c48f74-0461-4b07-abf1-912384cd5cbc");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "fbf09f94-8b51-4611-8997-a40481400e5d");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "fde461fc-70cb-4334-be2a-521f1e7984da");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "094505b2-4be4-43c6-ac2f-53428f706d19",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "b14d677d-be18-4e56-ae3e-e689f9c6c2dd", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5193), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5194), "a2834d50-cf7a-4f3b-80bc-eb999f966825", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5195) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "1c5c3b44-7164-4232-a49a-10ab367d5102",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "2ccfc437-c6be-4092-9e01-82fd524d25f5", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5039), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5040), "180c260f-3e40-4ab4-af68-0ed6e86bc6f9", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "29df78da-8830-4bb3-8ece-f11cf9f5cc34",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "e7f6b432-bd85-4ce9-b889-54e96bb4b78a", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5115), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5116), "0c2b95a3-9193-4378-a699-d38d34cef1c9", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5117) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "603600b5-ca65-4fa7-817e-4583ef22b330",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "67dc968a-666f-4dbb-a539-757e5e6fb031", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5003), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5004), "58797ff0-07e2-40a3-8ede-e955158ea5fc", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "68fdf17c-7cbe-4a4c-a674-c530ffc77667",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "9eb6c74a-6c14-4adf-9647-4008bf5e86a7", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5012), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5012), "95daf409-d63a-4475-8f19-1259e9c4894e", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "6ad0a020-e6a6-4e66-8f4a-d815594ba862",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "1dca5174-5949-4d70-b78e-4a5553e6ed03", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5030), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5031), "41413a6a-4c8c-41dd-b579-e229d36ade38", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "6c6abe62-f811-4a8b-96eb-ed326c47d209",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "5fbb8dd4-213c-423a-8acc-e4d02d16c8a5", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(4952), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(4953), "763f327f-3cd1-4b1e-b1ff-c82ee2d3fdcf", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(4954) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "72339042-5a5d-46f1-9b24-c5446332a29c",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "e4b86326-debd-44f5-b344-00a3df74ffc1", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5134), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5135), "f57cde9a-e059-4f70-8b8f-4694fbc13bab", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5135) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7397c854-194b-4749-9205-f46e4f2fccf8",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "5c7496e3-4167-4370-b42a-34f8956f215f", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5020), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5021), "d2c07bd0-515a-4b84-b1a2-f4341cce1110", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5021) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "75beaf54-8c16-4464-9cd5-fa272d942f43",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "eed290cf-0506-4330-8755-d927229b79fe", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5173), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5174), "83465707-91eb-4f04-9d4d-a52c6db0af80", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5174) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "85b70a16-20bb-400f-a478-78c6f8c6d067",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "244a85b0-71b5-4a53-85c4-0403c8e8b4be", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5183), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5184), "147afb9d-d293-453c-9ed4-7ea13dbcfc64", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5184) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "89d0ed33-21e5-401e-b3b4-963ef6e6be16",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "2ee27343-951c-4055-8519-b8910f19fcca", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5144), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5145), "eb816092-e70f-47d5-9893-de5040082a0b", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5145) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "97571dcc-079e-4c3a-ba9b-bbde3d03a03d",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "06d8078e-c099-435d-b121-ebd5cad36600", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(4925), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(4941), "75df296b-d790-454b-b5a0-076db2be16c9", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "a687bb04-4f19-49d5-a60f-2db52044767c",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "abc8435a-9df0-4c0a-96d7-81b6ec22b79f", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(4991), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(4992), "e5b13737-67da-461e-9fdb-7aa3fe605dea", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(4992) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "b745d464-f213-487c-8469-1f0d10d32224",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "efee00dc-699a-4af1-8978-65f7d489b66b", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5058), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5059), "8261ee67-31c5-41c6-8303-5fbf840c7aaa", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5059) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "c4a15b23-9d00-4ec5-acc9-493354e91973",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "9bc5bf1e-0e10-4dc4-81f4-c3c618aabbd7", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5107), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5108), "35dd5d63-9d3f-467c-8e4b-454dca050fc2", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5108) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "d4325be4-cb11-4f2f-b29e-dc52024d6c65",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "4fe6156c-70e1-4140-bfca-3eaf413704cb", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5049), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5050), "a76be44c-db2b-466b-b675-9a04a458dca9", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "d7d2f268-eea4-4299-9342-800564cc6411",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime", "VerifiedBy" },
                values: new object[] { "2f78ef0c-345e-4560-8fb6-b53f4851262c", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5087), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5088), "5df93567-b125-486a-8887-d274e49debf9", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5088), null });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "e214c150-f35c-4567-aaf0-c103d4e4d198",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "191c70b8-cc3a-4a03-8cc3-4dc0d172bdb4", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5126), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5126), "06971da4-c65b-4e84-85fa-db5e5efa02b5", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5127) });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "EmailVerifyCodeAge", "SecurityStamp", "UserRefreshTokenExpiryTime" },
                values: new object[] { "a227f4aa-e73b-467c-a4aa-8ba7f797f1e2", new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5098), new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5099), "433fb52d-2609-4dc3-bfa0-728a3ea112ce", new DateTime(2024, 7, 25, 11, 8, 32, 870, DateTimeKind.Utc).AddTicks(5099) });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 23, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("0a395b72-ae0d-4a49-b7f8-1763de733068"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 20, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("11d331b4-136c-4844-a686-ffc38c103268"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 15, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5635));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 22, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("51e6edb8-0a1f-4c26-afb7-fcf95ea0965f"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 10, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("5947a22f-0191-419c-873b-4324b5b95e84"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 18, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 24, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("a1d65f8a-f7fd-4995-940f-6ab254523f90"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 23, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("b4dc2d48-482a-48a2-bad6-7a1e0e3139b7"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 24, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("eb934470-4e73-41a8-8304-3bcb1ea18502"),
                column: "LastUsed",
                value: new DateTime(2024, 7, 21, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 16, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5351));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 22, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("931129a9-986f-4560-99f1-a06b692c71a1"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 17, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 15, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5353));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 21, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 20, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 23, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e331de18-289c-403d-8028-26c4b595587a"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 24, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 19, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("06a6fcd7-eb30-4728-9856-ee8d00f84810"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5809));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("0e287e15-6c9f-44ab-9fb3-dc183f5e5e92"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("19f6bcc1-2a8d-4c5d-ab3b-d5d3b21da159"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("285ce1fd-470c-4474-ad1b-ba273c0e8653"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("426c57ce-68aa-498b-b603-16cf1e7a238d"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5e2385b4-08f6-4e9e-888b-5d94c4b7fb78"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5faf118e-4687-47c2-9b83-ecb389b8b6d5"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5804));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("697817b7-9d65-47dd-a39b-909f89e25bce"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("75fb870f-e344-40c9-ab85-101631f22505"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("76199946-58bd-473a-95a7-9da8afcb9fc7"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("78d4e5bd-d685-49b5-8b12-e71df921ec65"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("8455c9b0-c2ca-4de4-bdee-3070dc8af954"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5792));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b774e795-3469-4b58-afe0-5f6e9e0a6aec"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b9d04c5f-2ec0-4da1-92ab-7ef9bdcd82e4"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5803));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c8fb056c-cff8-4db2-b951-01859431a35e"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("cf4dfffd-74e9-46dd-b9b5-2a9d09001564"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("d3b039bd-813c-4b33-af98-2264dcb440c0"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("dd8ac1ac-0f4f-45af-825e-e74e531b66dc"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("e4880a12-6d1d-4e9b-8832-89c5982b1346"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("f1dcaea6-1670-47d7-b8cb-398b89ca09d0"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("27f1b969-1b68-4cf8-8a51-c8be5356f7f8"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 23, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5695), new DateTime(2024, 7, 23, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5694), new DateTime(2024, 7, 23, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5694) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("37d2c7b3-7406-418d-9062-e81dfff02d9a"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 20, 8, 32, 870, DateTimeKind.Local).AddTicks(5686), new DateTime(2024, 7, 24, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5685), new DateTime(2024, 7, 24, 19, 8, 32, 870, DateTimeKind.Local).AddTicks(5686) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("44efa2a7-4f64-4fc6-bbbe-869099817d4f"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 25, 20, 8, 32, 870, DateTimeKind.Local).AddTicks(5679), new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5674), new DateTime(2024, 7, 25, 19, 8, 32, 870, DateTimeKind.Local).AddTicks(5678) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("4da0b3f8-95aa-40cd-ab32-75876ca13900"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 8, 32, 870, DateTimeKind.Local).AddTicks(5698), new DateTime(2024, 7, 23, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5697), new DateTime(2024, 7, 23, 23, 8, 32, 870, DateTimeKind.Local).AddTicks(5697) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("4fa30f09-e82a-4375-a28f-8190a8667a09"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 20, 0, 8, 32, 870, DateTimeKind.Local).AddTicks(5715), new DateTime(2024, 7, 19, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5713), new DateTime(2024, 7, 19, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5714) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("5547314b-521a-47e9-ad60-5e376e686636"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 25, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5728), new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5727), new DateTime(2024, 7, 25, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5728) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("5b1615a6-b870-456a-a483-e99a3f9122dc"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 23, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5720), new DateTime(2024, 7, 23, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5719), new DateTime(2024, 7, 23, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5719) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("5dc94e7f-845b-480b-8c81-f1d50c359491"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 22, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5703), new DateTime(2024, 7, 22, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5702), new DateTime(2024, 7, 22, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5703) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("6500363e-6574-42e7-8577-6dc87a55ce15"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 23, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5734), new DateTime(2024, 7, 23, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5733), new DateTime(2024, 7, 23, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5733) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("70f625f4-33f5-4c62-9718-d3e2c420e703"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 23, 0, 8, 32, 870, DateTimeKind.Local).AddTicks(5706), new DateTime(2024, 7, 22, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5705), new DateTime(2024, 7, 22, 23, 8, 32, 870, DateTimeKind.Local).AddTicks(5705) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("77153502-8631-4b5f-b05d-76d4796c06d4"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5709), new DateTime(2024, 7, 21, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5708), new DateTime(2024, 7, 21, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5708) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("77790ba9-1f3c-4943-9e39-097000fc6fa2"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 18, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5717), new DateTime(2024, 7, 18, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5716), new DateTime(2024, 7, 18, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5717) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("80d34442-7c14-4060-ae8f-24cda38e63f9"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 20, 8, 32, 870, DateTimeKind.Local).AddTicks(5700), new DateTime(2024, 7, 24, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5699), new DateTime(2024, 7, 24, 19, 8, 32, 870, DateTimeKind.Local).AddTicks(5700) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("8bb44d07-f470-4434-a023-6bdffb4311cc"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 21, 0, 8, 32, 870, DateTimeKind.Local).AddTicks(5712), new DateTime(2024, 7, 20, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5711), new DateTime(2024, 7, 20, 23, 8, 32, 870, DateTimeKind.Local).AddTicks(5711) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("9bfeb5df-03a4-4ae5-904e-1779c19a5313"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5731), new DateTime(2024, 7, 24, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5730), new DateTime(2024, 7, 24, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5730) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("db1fcaa0-e934-4429-a567-2ac802d0b453"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 25, 0, 8, 32, 870, DateTimeKind.Local).AddTicks(5692), new DateTime(2024, 7, 24, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5691), new DateTime(2024, 7, 24, 23, 8, 32, 870, DateTimeKind.Local).AddTicks(5691) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("e0fa81b1-9eea-4b4b-93a7-b7a34aae4014"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5689), new DateTime(2024, 7, 24, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5688), new DateTime(2024, 7, 24, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5689) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("e377b750-0b20-4943-9e5d-6909d4810f13"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 25, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5683), new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5681), new DateTime(2024, 7, 25, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5682) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("eb607a7a-2572-4a16-bbbd-99f3db25d40b"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 25, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5725), new DateTime(2024, 7, 25, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5724), new DateTime(2024, 7, 25, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5725) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("ff18bb51-3c4e-4fcb-a73e-39f60996be8c"),
                columns: new[] { "EndDate", "ScheduledDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 24, 22, 8, 32, 870, DateTimeKind.Local).AddTicks(5723), new DateTime(2024, 7, 24, 18, 8, 32, 870, DateTimeKind.Local).AddTicks(5722), new DateTime(2024, 7, 24, 21, 8, 32, 870, DateTimeKind.Local).AddTicks(5722) });
        }
    }
}
