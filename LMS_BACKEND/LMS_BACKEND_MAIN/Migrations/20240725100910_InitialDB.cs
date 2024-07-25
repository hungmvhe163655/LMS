using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS_BACKEND_MAIN.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerifiedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false),
                    EmailVerifyCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    EmailVerifyCodeAge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserRefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts",
                        column: x => x.VerifiedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    HexColor = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountClaims_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AccountLogins_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AccountToken_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Accounts",
                        column: x => x.OwnedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Accounts",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Major = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Specialized = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RollNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_StudentDetails_Accounts",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxMember = table.Column<int>(type: "int", nullable: false),
                    IsRecruiting = table.Column<bool>(type: "bit", fixedLength: true, maxLength: 10, nullable: true),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectTypes",
                        column: x => x.ProjectTypeId,
                        principalTable: "ProjectTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AccountRoles_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRoles_SystemRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SystemRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_SystemRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SystemRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extentions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Purpose = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Accounts",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedules_Devices",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NewsFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFiles_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsFiles_News1",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRoot = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Accounts",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Folders_Projects",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsLeader = table.Column<bool>(type: "bit", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Members_Accounts",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Projects",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Content = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Accounts",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Project",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxTasks = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskLists_Projects",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Schedules",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Size = table.Column<float>(type: "real", nullable: false),
                    FileKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Folders",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoldersClosure",
                columns: table => new
                {
                    Ancestor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descendant = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoldersClosure", x => new { x.Ancestor, x.Descendant });
                    table.ForeignKey(
                        name: "FK_FolderClosures_Folders",
                        column: x => x.Ancestor,
                        principalTable: "Folders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FolderClosures_Folders1",
                        column: x => x.Descendant,
                        principalTable: "Folders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationAccounts",
                columns: table => new
                {
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationAccounts", x => new { x.NotificationId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_NotificationsAccounts_Accounts",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationsAccounts_Notifications",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiresValidation = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    TaskPriority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Accounts",
                        column: x => x.AssignedTo,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_TaskLists",
                        column: x => x.TaskListId,
                        principalTable: "TaskLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Accounts",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Comments",
                        column: x => x.ParentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Tasks",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskClosure",
                columns: table => new
                {
                    Ancestor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descendant = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskClosure", x => new { x.Ancestor, x.Descendant });
                    table.ForeignKey(
                        name: "FK_TaskClosures_Task",
                        column: x => x.Ancestor,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskClosures_Task1",
                        column: x => x.Descendant,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiresValidation = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TasksId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskHistories_Tasks",
                        column: x => x.TaskGuid,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskHistories_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TasksHistory_Accounts",
                        column: x => x.AssignedTo,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TasksAccounts",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksAccounts", x => new { x.TaskId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_TasksAccounts_Accounts",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TasksAccounts_Tasks",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TasksFiles",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksFiles", x => new { x.TaskId, x.FileId });
                    table.ForeignKey(
                        name: "FK_TasksFiles_Files",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TasksFiles_Tasks",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TasksLabels",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksLabels", x => new { x.TaskId, x.LabelId });
                    table.ForeignKey(
                        name: "FK_TasksLabels_Labels",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TasksLabels_Tasks",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskHistoriesLabels",
                columns: table => new
                {
                    TaskHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHistoriesLabels", x => new { x.TaskHistoryId, x.LabelId });
                    table.ForeignKey(
                        name: "FK_TaskHistoriesLabels_Labels",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskHistoriesLabels_TaskHistories",
                        column: x => x.TaskHistoryId,
                        principalTable: "TaskHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "EmailVerifyCode", "EmailVerifyCodeAge", "FullName", "Gender", "IsBanned", "IsDeleted", "IsVerified", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRefreshToken", "UserRefreshTokenExpiryTime", "VerifiedBy" },
                values: new object[,]
                {
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", 0, "7c492fb8-d875-492e-a46a-9e4b2cd17ac8", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7832), "minhtche161354@fpt.edu.vn", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7845), "Tran Cong Minh", false, false, false, true, false, null, "MINHTCHE161354@FPT.EDU.VN", "MINHTCHE161354", "AQAAAAIAAYagAAAAELgUn5wJH9empSyZm7MdUy84spVESi+LvNCV8nDY9PMgoY0fOBYhfZO/MPZHjSZimA==", "0963661093", true, "9a483741-96fd-46e1-b175-9bea04e3873e", false, "minhtche161354", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7846), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "d7d2f268-eea4-4299-9342-800564cc6411", 0, "6adc7498-c89f-4d6f-8dca-8626cfc34478", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7975), "doantrungnam123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7976), "Doan Trung Nam", true, false, false, false, false, null, "DOANTRUNGNAM123@GMAIL.COM", "NAMDTHE159865", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965795220", true, "ad3931ff-4ab0-4101-941f-7283ca2edb04", false, "namdthe159865", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7976), null }
                });

            migrationBuilder.InsertData(
                table: "ProjectTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Web Application" },
                    { 2, "Research Paper" },
                    { 3, "Iot" },
                    { 4, "Mobile App" },
                    { 5, "AI" },
                    { 6, "VR" }
                });

            migrationBuilder.InsertData(
                table: "SystemRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c55924f5-4cf4-4a29-9820-b5d0d9bdf3c5", null, "LabAdmin", "LABADMIN" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", null, "Student", "STUDENT" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "EmailVerifyCode", "EmailVerifyCodeAge", "FullName", "Gender", "IsBanned", "IsDeleted", "IsVerified", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRefreshToken", "UserRefreshTokenExpiryTime", "VerifiedBy" },
                values: new object[,]
                {
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", 0, "52a19d3f-0384-425b-95fe-3474ca86e425", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7880), "cuongndhe163098@fpt.edu.vn", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7882), "Nguyen Duc Cuong", true, false, false, true, false, null, "CUONGNDHE163098@FPT.EDU.VN", "CUONGNDHE163098", "AQAAAAIAAYagAAAAENVZ95qV36S0GH4gzip/nSmI9JKDA1CAGuL2+t1ysccrtPgGLrSZ6k9v/tS37ojoSw==", "0975465220", true, "5018782e-4f3b-4a5c-acc5-7e40106de72e", false, "cuongndhe163098", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7882), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", 0, "92a74215-75df-45a5-b471-5eb508b0515b", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7890), "hoangnmhe163884@fpt.edu.vn", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7891), "Nguyen Minh Hoang", false, false, false, true, false, null, "HOANGNMHE163884@FPT.EDU.VN", "HOANGNMHE163884", "AQAAAAIAAYagAAAAEBSeWGYcWJzo0jTXDBqXgYkMmzdQCRKsLrFMaaqieAdCHchkvB2oa1eRy3gsuvWyVw==", "0975765220", true, "7cec26d0-92e3-4fa2-b5a3-286f3b494732", false, "hoangnmhe163884", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7891), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", 0, "a19db35d-28c1-4c8f-baae-75e88b53d6dd", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7857), "thailshe160614@fpt.edu.vn", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7858), "Le Sy Thai", true, false, false, true, false, null, "THAILSHE160614@FPT.EDU.VN", "THAILSHE160614", "AQAAAAIAAYagAAAAEO5SGANyOkCieJN+MspCJeIbBLjDruXYD5omO5+7u9NVKctIo979jEts1uoDaalzTw==", "0497461220", true, "3eaaa927-a8e3-4151-81ad-c49415212059", false, "thailshe160614", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7858), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", 0, "be65023c-030c-4d67-9e7a-d008a69d7912", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7902), "littlejohn123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7903), "John", true, false, false, true, false, null, "LITTLEJOHN123@GMAIL.COM", "LITTLEJOHN", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965765228", true, "803323a8-373b-4d27-af19-803ff53b88e0", false, "littlejohn", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7903), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", 0, "2354a98f-233b-4a56-8fbc-29cd134bf28b", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7870), "hungmvhe163655@fpt.edu.vn", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7872), "Mai Viet Hung", true, false, false, true, false, null, "HUNGMVHE163655@FPT.EDU.VN", "HUNGMVHE163655", "AQAAAAIAAYagAAAAEHaY3BZO2ooRDvclwsiVvksAaPExz0GAXkEHlfwAtwfVBfRcw9gQTR02USItL9NrSg==", "0975461220", true, "96f454b4-8c5d-4b49-8e5e-4b1b20933a45", false, "hungmvhe163655", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7872), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "c4a15b23-9d00-4ec5-acc9-493354e91973", 0, "029eb01f-ae02-4408-a96e-0ebe83f6a796", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7994), "tientd123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7995), "Ta Dinh Tien", true, false, false, true, false, null, "TIENTD123@GMAIL.COM", "TIENTD", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965796963", true, "bca7725d-ce8a-4381-8cb9-407e4e5d8156", false, "tientd", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7995), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", 0, "b1c41521-ba63-4d8a-bd36-621180d18366", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7984), "chilp123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7985), "Le Phuong Chi", false, false, false, true, false, null, "CHILP123@GMAIL.COM", "CHILP", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965796856", true, "40e9ec5f-7d2e-4285-bb6b-8412080516f4", false, "chilp", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7986), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" }
                });

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c55924f5-4cf4-4a29-9820-b5d0d9bdf3c5", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "d7d2f268-eea4-4299-9342-800564cc6411" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "DeviceStatus", "IsDeleted", "LastUsed", "Name", "OwnedBy" },
                values: new object[,]
                {
                    { new Guid("11d331b4-136c-4844-a686-ffc38c103268"), "Main office router", "Disable", false, new DateTime(2024, 7, 15, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8526), "Router", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("51e6edb8-0a1f-4c26-afb7-fcf95ea0965f"), "Network switch", "Disable", false, new DateTime(2024, 7, 10, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8538), "Switch", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("5947a22f-0191-419c-873b-4324b5b95e84"), "Office printer", "Available", false, new DateTime(2024, 7, 18, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8532), "Printer", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"), "Primary server", "Available", false, new DateTime(2024, 7, 24, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8519), "Server", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("eb934470-4e73-41a8-8304-3bcb1ea18502"), "Conference room projector", "Available", false, new DateTime(2024, 7, 21, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8536), "Projector", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0985634f-496f-4480-83f0-14ff0c30b002"), "Từ ngày 14/8/2023, phòng Đào tạo bổ sung chức năng cho sinh viên tự đăng ký lớp/ hủy các môn đã đăng ký trong danh sách chờ trên fap.fpt.edu.vn. Các bước thực hiện như sau:\r\n\r\nSinh viên đăng nhập vào trang Fap.fpt.edu.vn\r\nVào Academic Information/ Registration/Application(Thủ tục/đơn từ)/ Wishlist Course (Danh các môn học chờ xếp lớp)", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 25, 11, 34, 0, 0, DateTimeKind.Unspecified), "Hướng dẫn sinh viên các bước tự đăng ký/ hủy các môn đã đăng ký trong danh sách chờ" },
                    { new Guid("0da0b088-1b08-404b-9696-eb539d31c9e5"), "Phòng Dịch vụ sinh viên thông báo hướng dẫn đăng ký mua BHYT hiệu lực trong năm 2024 đợt bổ sung dành cho sinh viên, cụ thể như sau:\r\n\r\n1/ Đối tượng áp dụng: tất cả sinh viên chưa mua BHYT năm 2024\r\n\r\n(Nếu không biết mình đã có thẻ BHYT năm 2024 hay chưa, sinh viên có thể tra cứu tại đây: tracuuhieulucthe)\r\n\r\n2/ Hiệu lực thẻ: 7 tháng (Từ tháng 20/06/2024 – 31/12/2024) – Mức phí: 397,000 VNĐ", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 29, 14, 58, 0, 0, DateTimeKind.Unspecified), "Thông báo về việc đăng ký mua BHYT đợt bổ sung" },
                    { new Guid("14764db6-10f1-48e6-a4e8-3ae063814acf"), "Phòng Tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Seminar “Điệu nhảy của các con số trong thiết kế phần mềm của đồ án tốt nghiệp​”. Thông tin chi tiết như sau:\r\n\r\n·       Thời gian:  20:30 – 22:00 - Thứ 3 ngày 28/05/2024.\r\n\r\n·       Địa điểm (Online qua link): https://zoom.us/j/9836098489 - ID cuộc họp: 983 609 8489, Passcode: 1\r\n\r\n·       Diễn giả: Giảng viên Nguyễn Tất Trung\r\n\r\nLưu ý: Đây là một trong năm buổi chia sẻ mà nhà trường và bộ môn sẽ trang bị thêm kiến thức, kĩ năng giúp các em có thể hoàn thành tốt đồ án tốt nghiệp. Phòng TC&QLDT không recording lại buổi seminar để gửi sinh viên, đề nghị sinh viên các nhóm có mặt đầy đủ và đúng giờ.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 27, 16, 11, 0, 0, DateTimeKind.Unspecified), "V/v: Tham dự Seminar “Điệu nhảy của các con số trong thiết kế phần mềm của đồ án tốt nghiệp​”" },
                    { new Guid("245b3c4d-ba95-4040-818d-23da69f08e9b"), "Phòng tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Seminar “Cách thức đặt vấn đề khi xác định bài toán của đồ án”. Thông tin chi tiết như sau:\r\n\r\n·       Thời gian:  20:30 – 22:00 - Thứ 3 ngày 14/05/2024.\r\n\r\n·       Địa điểm (Online qua link): https://zoom.us/j/9836098489 - ID cuộc họp: 983 609 8489, Passcode: 1\r\n\r\n·       Diễn giả: Tiến sĩ Ngô Tùng Sơn - Chủ nhiệm bộ môn An toàn thông tin.\r\n\r\nLưu ý: Đây là một trong năm buổi chia sẻ mà nhà trường và bộ môn sẽ trang bị thêm kiến thức, kĩ năng giúp các em có thể hoàn thành tốt đồ án tốt nghiệp. Đề nghị sinh viên có mặt đầy đủ và đúng giờ.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 14, 14, 5, 0, 0, DateTimeKind.Unspecified), "V/v: Tham dự Seminar “Cách thức đặt vấn đề khi xác định bài toán của đồ án”" },
                    { new Guid("5d0bfb1c-d68d-450e-8fe9-e7d94be4eaac"), "Phòng Tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Seminar “Hướng dẫn lập kế hoạch và đặc tả yêu cầu dự án Đồ án tốt nghiệp ( ~ Report 2&3 )​”. Thông tin chi tiết như sau:\r\n\r\n·       Thời gian:  20:30 – 22:00 - Thứ 3 ngày 21/05/2024.\r\n\r\n·       Địa điểm (Online qua link): https://zoom.us/j/9836098489 - ID cuộc họp: 983 609 8489, Passcode: 1\r\n\r\n·       Diễn giả: Giảng viên Nguyễn Trung Kiên\r\n\r\nLưu ý: Đây là một trong năm buổi chia sẻ mà nhà trường và bộ môn sẽ trang bị thêm kiến thức, kĩ năng giúp các em có thể hoàn thành tốt đồ án tốt nghiệp. Đề nghị sinh viên có mặt đầy đủ và đúng giờ.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 20, 22, 23, 0, 0, DateTimeKind.Unspecified), "V/v: Tham dự Seminar “Hướng dẫn lập kế hoạch và đặc tả yêu cầu dự án Đồ án tốt nghiệp”" },
                    { new Guid("6798cf4d-8399-4572-955e-595ddf13f292"), "\r\nThông báo về việc thay đổi tem kiểm soát ô tô ra/vào cổng Trường tại Hòa Lạc\r\nPost by hangntt6 on 18/06/24 09:45\r\nTrường Đại học FPT cơ sở Hà Nội thông báo về việc thay đổi tem kiểm soát ô tô ra/vào cổng trường, cụ thể:\r\n\r\nI. Đối tượng: Chỉ áp dụng ô tô đăng ký ra vào trường với 2 trường hợp:\r\n\r\nXe chính chủ của sinh viên, CBGV\r\nXe của người thân trong gia đình sinh viên, CBGV\r\nII. Hình thức triển khai:\r\n\r\nĐối với các trường hợp đã đăng ký từ ngày 15/06/2024 trở về trước:\r\nBổ sung thông tin theo link: https://forms.gle/HSjMfrJwSJH8t4Wi8\r\nMang theo biển cũ đổi lấy tem mới tại phòng Dịch vụ sinh viên từ ngày 18.06 đến 21.06/2024\r\nĐối với các trường hợp đăng ký mới:\r\nĐăng ký thông tin qua link: https://forms.gle/HSjMfrJwSJH8t4Wi8\r\nDự kiến nhận tem sau 07 ngày làm việc kể từ thời điểm đăng ký\r\n*Thời gian áp dụng kiểm soát xe ra/vào bằng Tem từ ngày 01/7/2024.\r\n\r\nSau thời gian bổ sung thêm, tất cả các xe chưa dán tem sẽ bắt buộc phải đăng ký tại cổng bảo vệ trước khi vào Trường.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 18, 9, 45, 0, 0, DateTimeKind.Unspecified), "Thông báo về việc thay đổi tem kiểm soát ô tô ra/vào cổng Trường tại Hòa Lạc" },
                    { new Guid("6e08720f-d73a-4ae1-be83-559dbb96a344"), "Chương trình Thạc sĩ Quản trị kinh doanh Cao cấp (SeMBA) và Chương trình Thạc sĩ Kỹ thuật phần mềm gửi chính sách đặc biệt dành riêng cho Cựu sinh viên Đại học FPT như sau:\r\n\r\nĐối tượng hưởng ưu đãi: Sinh viên tốt nghiệp Đại học FPT các chuyên ngành.\r\nMức ưu đãi đặc biệt: \r\nƯu đãi giảm 20% học phí khi đăng ký các khóa học\r\nMiễn chứng chỉ ngoại ngữ đầu vào\r\nVới kinh nghiệm hơn 20 năm đào tạo quản trị kinh doanh và công nghệ, top 3 Trường đào tạo kinh doanh tốt nhất Việt Nam, top 25 chương trình MBA tốt nhất Đông Á, Viện Quản trị & Công nghệ FSB (Đại học FPT) đã nghiên cứu và triển khai 2 chương trình đào tạo ưu việt, cập nhật xu hướng mới nhất nhằm đáp ứng những nhu cầu của Doanh nghiệp như sau:\r\n\r\nThạc sĩ Quản trị kinh doanh (SeMBA): được thiết kế theo mô hình STEM MBA đang là xu hướng trên toàn cầu, chương trình hướng đến mục tiêu đào tạo những nhà quản lý có tư duy nhạy bén và khả năng ứng dụng công nghệ, phân tích dữ liệu vào quản trị để đưa ra các quyết định kinh doanh mang tính đột phá.\r\nThạc sĩ Kỹ thuật phần mềm (MSE): chương trình trang bị cho học viên kiến thức chuyên sâu về AI và phân tích dữ liệu lớn, cùng các kỹ năng cần thiết để nhanh chóng nắm bắt, làm chủ những xu hướng công nghệ mới. Từ đó, học viên có thể vận dụng kiến thức về công nghệ vào xây dựng các hệ thống phần mềm thông minh, phù hợp với thời đại kinh doanh số.\r\nThời gian đào tạo: 18 tháng\r\nLịch học: Tối 2-4-6 | Từ 18h00 – 21h00\r\nĐịa điểm học: Nhà C, tòa nhà Việt Úc, KĐT Mỹ Đình 1, Nam Từ Liêm, Hà Nội.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 6, 14, 10, 0, 0, DateTimeKind.Unspecified), "Chương trình Thạc sĩ Quản trị kinh doanh Cao cấp (SeMBA) và Chương trình Thạc sĩ Kỹ thuật phần mềm dành tặng ưu đãi cho Cựu sinh viên FPT" },
                    { new Guid("e277ec7f-14cf-47a2-a234-1265920647a4"), "Gửi các bạn,\r\n\r\nPhòng HCTH xin gửi thông báo tới bạn thủ tục đăng ký/hủy phòng cho kỳ Summer 2024 như sau:\r\n\r\nĐăng ký ở tiếp:\r\nØ Thời gian giữ chỗ: Từ ngày 11/4 – 21/4/2024. Gia hạn 22/4/2024.\r\n\r\n Ø Thời gian đăng ký phòng mới: Từ ngày 23/4 đến ngày 27/4/2024.\r\n\r\n(Trường hợp không đăng ký giữ chỗ được hiểu là bạn không còn nhu cầu sử dụng và bạn khác có thể đăng ký)  \r\n\r\n         Ø Đối tượng ưu tiên đăng ký KTX\r\n\r\n- Sinh viên học tập tại cơ sở Hòa Lạc trước kỳ OJT (xét tại thời điểm đăng ký phòng)\r\n\r\n- Các đối tượng sinh viên sinh viên khác có nhu cầu đăng ký phòng, Nhà trường sẽ hỗ trợ giải quyết đặt phòng qua hòm thư ktx@fpt.edu.vn.\r\n\r\n   Phương thức nộp phí và đăng ký phòng KTX qua Hệ thống OCD http://ocd.fpt.edu.vn/\r\n\r\nBước 1: Đặt phòng\r\n\r\n- Sinh viên truy cập http://ocd.fpt.edu.vn/  thực hiện đặt phòng tại chức năng  Booking Bed.\r\n\r\n- Lựa chọn đặt phòng Giữ chỗ cũ hoặc đăng ký mới theo nhu cầu.\r\n\r\nSinh viên chuyển phòng/đăng ký mới cần thao tác chọn chính xác thông tin tại các mục: Loại phòng/Dom/Tầng.\r\n\r\nBước 2: Thanh toán\r\n\r\nSau khi hoàn tất chọn phòng, sinh viên tiến hành thanh toán bằng một trong 2 hình thức sau:\r\n\r\n- Booking with FAP (nếu trên ví FAP còn đủ tiền)\r\n\r\n- Booking with DNG (Sinh viên vào App ngân hàng quét QR code để thanh toán).\r\n\r\nà Đặt phòng thành công.\r\n\r\nLưu ý: KTX sẽ gửi thư xác nhận và thông báo số phòng sau 48 giờ kể từ khi nhận booking.\r\n\r\nThời gian giữ chỗ cho SV thanh toán DNG là 10 phút. Nếu thanh toán chậm sau 10 phút thì OCD hủy giữ chỗ và tiền SV đã nộp sẽ trả về FAP. Sinh viên truy cập Hệ thống OCD đăng ký lại với hình thức sử dụng tiền dư trong ví FAP (Booking with FAP).", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 4, 25, 20, 21, 0, 0, DateTimeKind.Unspecified), "THÔNG BÁO V/V ĐĂNG KÝ/HỦY PHÒNG KTX KỲ SU24" },
                    { new Guid("efb06517-4673-4b44-bf11-ee12198c26a7"), "Phòng khảo thí thông báo đã có điểm thi lần 2 các môn ENT104, TRS401, TRS501, TRS601, VOV114, VOV124, VOV134 Part 1 HK Summer2024. Các em đăng nhập FAP để xem điểm chi tiết.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 29, 21, 39, 0, 0, DateTimeKind.Unspecified), "Thông báo điểm thi lần 2 các môn ENT104, TRS401, TRS501, TRS601 HK Summer2024." },
                    { new Guid("f0c49374-4c7d-464a-9f38-e6f59b20344d"), "Nhằm khắc phục sự cố và bảo trì trạm biến áp số 1 Trường Đại học FPT.\r\n\r\nPhòng hành chính tổng hợp - Trường Đại học FPT cơ sở Hà Nội thông báo lịch tạm ngưng cấp điện như sau:\r\n\r\nThời gian dự kiến từ: Từ 08 giờ 00 phút đến 10 giờ 00 phút ngày 25/5/2024. \r\n\r\nKhu vực ảnh hưởng: Dom A, B, C, D, Nhà Dịch 1, Tòa Beta.\r\n\r\n Sinh viên lưu ý về thời gian tạm ngừng cắt điện để chủ động trong công việc của mình. \r\n\r\nRất mong các bạn thông cảm vì sự bất tiện này. ", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 24, 23, 15, 0, 0, DateTimeKind.Unspecified), "TB. V/v cắt điện ngày 25/05/2024" },
                    { new Guid("f3e39c12-df43-4e2a-b84e-92374739e0e9"), "Phòng Tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Super Sunday Workshop “Chia sẻ về Testing”.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 8, 21, 29, 0, 0, DateTimeKind.Unspecified), "V/v: Tham dự Super Sunday Workshop “Chia sẻ về Testing”" },
                    { new Guid("fb4d071c-c460-4a01-8ee4-9247a97214a6"), "Chào các em,\r\n\r\nĐiều kiện để được miễn điểm danh kỳ SU24 như sau:\r\n\r\nSV đã hoàn thành kỳ OJT và đang học ở 1 trong số các kỳ sau: 7,8,9,10 (kỳ 10: hoàn thành các môn học còn thiếu)\r\nYêu cầu chung cho tất cả các loại HĐ làm việc hợp lệ.\r\n=>Thời gian làm việc: fulltime 8h/ngày (không nhận HĐ bán thời gian, part time) – Hợp đồng làm việc full kỳ SU2024 (từ tháng 5=>tháng 8/2024)\r\n=>Làm việc có lương và chịu sự quản lý, giám sát của nhà tuyển dụng.\r\n=>HĐ có đủ con dấu & chữ ký tươi/chữ ký số nhà tuyển dụng.\r\nThời gian mở đơn miễn điểm danh : 2 tuần trước khi vào kỳ SU24  (16/4 – 30/04/2024)  - đơn đã được gia hạn đến 20/5/2024\r\n\r\nSau thời gian trên phòng TC&QLĐT sẽ không nhận hỗ trợ bất kỳ trường hợp nào.\r\n\r\nThời gian mở đơn Block 5 : Tuần 12 của kỳ SU2024\r\n\r\nKhi làm đơn xin miễn điểm danh SV lưu ý cần làm theo chỉ dẫn sau:\r\n\r\n- SV đăng nhập FAP, vào phần HOME -> GỬI ĐƠN\r\n\r\n =>Application type: chọn Đơn miễn điểm danh\r\n\r\n=> Reason: Ghi rõ lý do làm đơn (ví dụ: Đã hoàn thành kỳ OJT – đang học kỳ … được ký HĐ làm việc fulltime với công ty…)\r\n\r\nFile Attach bao gồm:      \r\n\r\nGửi full file HĐ làm việc & giấy xác nhận nhân viên\r\nKhi gửi file nếu dung lượng file HĐLĐ nặng >2MB các em cần giảm dung lượng , nén file <2MB  hoặc các em có thể gửi HĐ qua link google drive…\r\n   LƯU Ý: \r\n\r\nPhòng TC&QLĐT chỉ nhận hỗ trợ những SV có HĐ làm việc (thời gian làm việc full kỳ SU2024). Trong trường hợp HĐ có thời gian làm việc chỉ còn 1 đến 2 tháng; HĐ thử việc ngắn hạn trong đơn cần ghi rõ thời gian sẽ bổ sung HĐ làm việc mới, HĐ làm việc chính thức để phòng Đào tạo xem xét. Những HĐ không đủ thời gian làm việc full kỳ SU24, không cam kết thời gian nộp HĐ mới sẽ bị từ chối không hỗ trợ.\r\nCác HĐ làm việc cũ nhưng còn thời gian làm việc full kỳ SU2024: SV gửi nộp file HĐ và Giấy xác nhận nhân viên (giấy xác nhận nhân viên phải được cấp quản lý ký và đóng dấu xác nhận trước khi nộp đơn miễn điểm danh kỳ SU24 khoảng 1 tuần làm việc)\r\nThư mời làm việc không phải là HĐLĐ do vậy không đủ ĐK để làm đơn miễn điểm danh, SV có thể làm đơn và phòng ĐT sẽ note vào danh sách chờ, phải bổ sung HĐ chính thức trước ngày 20/5/2024.\r\nCác loại Hợp đồng khoán gọn, Hợp đồng dịch vụ, Hợp đồng hợp tác, Hợp đồng với các công ty nhà đất, chứng khoán...: cần nộp file HĐ và giấy xác nhận nhân viên, trong giấy xác nhận nhân viên cần ghi rõ SV đang làm việc fulltime (8h/ngày) - có hưởng lương tại doanh nghiệp\r\nĐƠN MIỄN ĐIỂM DANH sẽ bị hủy NẾU PHÒNG TC&QLĐT phát hiện SV đã được duyệt miễn điểm danh trong kỳ SU24 nhưng nghỉ làm giữa chừng, không hoàn thành thời gian làm việc ghi trên HĐ làm việc đã nộp (sẽ chuyển trạng thái từ miễn điểm danh => chỉ được phép nghỉ 20% theo quy định của SV)\r\nThời gian duyệt đơn miễn điểm danh từ 5 ngày làm việc tùy thuộc vào số lượng đơn phòng TC&QLĐT nhận được. (không tính thứ 7 và CN)\r\nCHÚ Ý:\r\n\r\n- Các em chỉ gửi đơn Miễn điểm danh 1 lần và vui lòng chờ kết quả trả lời ở phần Xem đơn – KHÔNG GỬI TRÙNG ĐƠN  để tránh làm loãng thông tin. (Bạn nào gửi từ 2 lần đơn trở lên thời gian chờ duyệt đơn sẽ tăng theo số lần gửi đơn )\r\n\r\n- Đơn miễn điểm danh kỳ SU2024 được duyệt, SV sẽ được miễn điểm danh full cả 2 block ( block1-4 và block5) do vậy những SV đã được duyệt đơn miễn điểm danh đầu kỳ SU24 nếu học block 5 không cần làm đơn xin miễn điểm danh block5-SU2024.\r\n\r\n- Đơn miễn điểm danh này chỉ có giá trị trong kỳ SU2024\r\n\r\n- Phòng TC&QLĐT chỉ nhận ĐƠN MIỄN ĐIỂM DANH ONLINE – KHÔNG NHẬN ĐƠN MIỄN ĐIỂM DANH GỬI QUA MAIL\r\n\r\n- SV miễn điểm danh được phép vắng mặt >20% (không giới hạn %) và phòng TC&QLĐT quản lý SV miễn điểm danh độc lập do vậy SV không gửi mail thắc mắc khi chưa thấy chữ Attendance Exemption\r\n\r\n- Trường hợp hiếm gặp: Nếu các em làm đơn miễn điểm danh đã được duyệt nhưng vẫn có tên trong DSSV không đủ điều kiện dự thi, các em cần gửi mail tới phòng TC&QLĐT (acad.hl@fpt.edu.vn ) để được hỗ trợ.\r\n\r\n. Do các em bận đi làm, ít đến lớp nên điểm chuyên cần sẽ giảm tùy theo cách đánh giá của giảng viên.\r\n\r\n- Không được miễn điểm danh các môn GDQP và khóa luận tốt nghiệp.\r\n\r\nCác em đọc kỹ thông báo này và làm theo hướng dẫn để được hỗ trợ chính xác nhất.\r\n\r\nTrân trọng thông báo\r\n\r\nPhòng TC&QL Đào tạo", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 9, 23, 37, 0, 0, DateTimeKind.Unspecified), "HƯỚNG DẪN LÀM VÀ GỬI ĐƠN MIỄN ĐIỂM DANH KỲ SU2024" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "NotificationType", "ProjectId", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), "Your account details have been updated.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 7, 16, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8281), "System", null, "Account Notice", "" },
                    { new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), "We are excited to announce a new feature in our application.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 7, 22, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8268), "System", null, "New Feature Release", "" },
                    { new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), "Don't forget about the event tomorrow!", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 7, 15, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8284), "System", null, "Event Reminder", "" },
                    { new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), "Scheduled maintenance will occur this weekend.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 7, 23, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8265), "System", null, "Maintenance Notice", "" },
                    { new Guid("e331de18-289c-403d-8028-26c4b595587a"), "A new system update will be available tomorrow.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 7, 24, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8256), "System", null, "System Update", "" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedDate", "Description", "IsRecruiting", "MaxMember", "Name", "ProjectStatus", "ProjectTypeId" },
                values: new object[,]
                {
                    { new Guid("0d59a77e-14b0-441f-9c66-240b1f4ce144"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("0e175a98-f6f3-4fbf-aa2f-c7f0f8446d60"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using AI to improve healthcare outcomes.", false, 5, "AI in Healthcare", "Completed", 5 },
                    { new Guid("16e98a28-511a-49b1-9c04-d60626a889ee"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("1b3c2e9a-c77c-417e-a093-8d701d2b4821"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "A comprehensive research paper on the applications of quantum computing in cryptography.", false, 3, "Research Paper on Quantum Computing", "On-going", 2 },
                    { new Guid("20a39a90-b376-477d-a2c2-1973cd347092"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("2bc0fef9-3000-48ec-82e9-de4dc0494056"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("2f404ee3-9fe2-407f-a07e-0b100e268c0e"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("2f722609-dace-4c60-a6f3-19e015546310"), new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developing application for occupational therapy", false, 4, "VR application for patient", "On-going", 6 },
                    { new Guid("390dba55-cdc1-4b12-88b8-0e3c257253c5"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("4b400907-f70f-453e-b8ae-92c522a69805"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("4e3b54cf-8b56-4590-adca-73112fa8b9e7"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "Initializing", 1 },
                    { new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A mobile application for monitoring and managing personal health data.", false, 4, "Mobile Health App", "Completed", 4 },
                    { new Guid("88d39e7e-3952-43ef-8e15-57116d276d59"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("8c76d5f2-2f87-4cf0-820f-f81284cbb10b"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("94985ddd-ca1f-402f-a389-f1e1df169f75"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("a210682e-f41e-4e01-af7c-43cd942ac9df"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("a474440d-4a24-4e27-9863-99fb0d0ec189"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("aaa1e013-1aa8-44ef-adaa-298a8d81b2d0"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("b5c6dbc1-8e92-4667-8627-8772ffbd09d0"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("b915e80e-2894-4443-92ea-1fcfbf3fd851"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("bbbdb7db-bf17-4d42-bb22-beebe83f6f34"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("c6187862-b687-4c00-9f5a-4d5c6b52d87d"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("c70f946f-c591-4794-b053-174765ae386d"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implementing LIMS system for laboratory management.", false, 5, "LIMS", "On-going", 1 },
                    { new Guid("da45413f-3263-4076-b186-03c9a5f9220f"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monitoring environmental parameters using IoT.", false, 5, "Environmental Monitoring", "On-going", 3 },
                    { new Guid("f2cc754b-fd44-45db-b3d8-32db885ba9bd"), new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creating a VR platform for training professionals in various fields.", true, 5, "Virtual Reality Training Platform", "Initializing", 6 },
                    { new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 },
                    { new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developing an AI system for recognizing and classifying images with high accuracy.", false, 5, "AI-based Image Recognition", "Cancel", 5 },
                    { new Guid("fc88de4a-d833-40a5-a9e5-e5b1b1f0718f"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using data analytics to improve public health policies.", true, 4, "Data Analytics for Public Health", "On-going", 1 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "EmailVerifyCode", "EmailVerifyCodeAge", "FullName", "Gender", "IsBanned", "IsDeleted", "IsVerified", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRefreshToken", "UserRefreshTokenExpiryTime", "VerifiedBy" },
                values: new object[,]
                {
                    { "094505b2-4be4-43c6-ac2f-53428f706d19", 0, "edde4282-1dcd-4cf9-b26b-667810753174", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8092), "phuongdb123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8093), "Dao Bich Phuong", false, false, false, true, false, null, "PHUONGDB123@GMAIL.COM", "PHUONGDB", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965796789", true, "e24f6555-3ba9-485a-9ff3-6a2305e7e673", false, "phuongdb", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8093), "c4a15b23-9d00-4ec5-acc9-493354e91973" },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", 0, "956d4d46-faa8-4038-b59f-ee7681549e5d", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7922), "gakkou123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7923), "Gakkou Atarashi", false, false, false, true, false, null, "GAKKOU123@GMAIL.COM", "GAKKOU", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965795220", true, "dcb8e8b5-1110-4d67-a2d7-232021ccc353", false, "gakkou", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7923), "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { "29df78da-8830-4bb3-8ece-f11cf9f5cc34", 0, "28320395-492e-4f40-a515-b27e1393e62f", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8004), "lamndt123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8005), "Nguyen Duc Tung Lam", true, false, false, true, false, null, "LAMNDT123@GMAIL.COM", "LAMNDT", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965796741", true, "b15f74ae-0a55-438d-a5bd-e20924986d27", false, "lamndt", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8006), "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832" },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", 0, "e3873b99-fc66-4feb-a88d-9ea7acfe9e29", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7912), "kenshiyonezu123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7913), "Kenshi Yonezu", true, false, false, true, false, null, "KENSHIYONEZU123@GMAIL.COM", "KENSHIYONEZU", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965765120", true, "04311a15-1882-4e5b-8d29-824d6f93b2f8", false, "kenshiyonezu", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7914), "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { "72339042-5a5d-46f1-9b24-c5446332a29c", 0, "d1f2af40-8029-433c-b4bd-6ec0c8da41c3", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8044), "hungpv123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8045), "Pham Van Hung", true, false, false, true, false, null, "HUNGPV123@GMAIL.COM", "HUNGPV", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965796741", true, "93305de1-ab5e-45fa-a2ea-d3b518f22fa8", false, "hungpv", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8045), "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832" },
                    { "75beaf54-8c16-4464-9cd5-fa272d942f43", 0, "1a96c5ba-1e9d-4f0b-806f-da3d48f6a845", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8065), "thanhkn123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8066), "Kim Nhat Thanh", true, false, false, true, false, null, "THANHKN123@GMAIL.COM", "THANHKN", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965796456", true, "59f0411a-55a6-456e-b072-54d3239a756a", false, "thanhkn", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8067), "c4a15b23-9d00-4ec5-acc9-493354e91973" },
                    { "85b70a16-20bb-400f-a478-78c6f8c6d067", 0, "b8f4f5ec-5561-464d-92ef-4edbecaf871b", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8078), "linhltm123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8079), "Le Thi Mai Linh", false, false, false, true, false, null, "LINHLTM123@GMAIL.COM", "LINHLMT", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965796789", true, "3b949bf0-dfc2-47d5-84ff-5114957e2d73", false, "linltm", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8080), "c4a15b23-9d00-4ec5-acc9-493354e91973" },
                    { "89d0ed33-21e5-401e-b3b4-963ef6e6be16", 0, "6ed97882-4964-44bb-b6ca-901c5a2026b7", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8056), "longpt123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8057), "Phi Thang Long", true, false, false, true, false, null, "LONGPT123@GMAIL.COM", "LONGPT", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965796123", true, "77e6a680-09e2-4190-80dc-9ce586ede7d0", false, "longpt", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8057), "c4a15b23-9d00-4ec5-acc9-493354e91973" },
                    { "b745d464-f213-487c-8469-1f0d10d32224", 0, "8f7994c4-b995-4d76-8731-0a7e0f0d685a", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7964), "caohoanganh123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7965), "Cao Hoang Anh", true, false, true, true, false, null, "CAOHOANGANH123@GMAIL.COM", "ANHCHHE161236", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965795220", true, "89459d35-cd51-43b7-a27b-bed9ac612468", false, "anhchhe161236", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7965), "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { "d4325be4-cb11-4f2f-b29e-dc52024d6c65", 0, "b3d8d388-54d7-4212-a8ef-efeda3fb60d8", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(7955), "nguyentrunghieu123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7956), "Nguyen Trung Hieu", true, true, false, true, false, null, "NGUYENTRUNGHIEU123@GMAIL.COM", "HIEUNTHE168975", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965795220", true, "fc2ace38-cee7-42fa-8f90-f4da8e8c9468", false, "hieunthe168975", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(7956), "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { "e214c150-f35c-4567-aaf0-c103d4e4d198", 0, "d2ca1b69-a3e9-43b1-94c4-807eb89ff767", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8013), "duongdd123@gmail.com", true, null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8014), "Do Duc Duong", true, false, false, true, false, null, "DUONGDD123@GMAIL.COM", "DUONGDD", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965796852", true, "9efa5dd2-e80e-4390-8429-601329e52ede", false, "duongdd", null, new DateTime(2024, 7, 25, 10, 9, 10, 568, DateTimeKind.Utc).AddTicks(8015), "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832" }
                });

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "603600b5-ca65-4fa7-817e-4583ef22b330" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "68fdf17c-7cbe-4a4c-a674-c530ffc77667" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "7397c854-194b-4749-9205-f46e4f2fccf8" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "a687bb04-4f19-49d5-a60f-2db52044767c" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "c4a15b23-9d00-4ec5-acc9-493354e91973" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "DeviceStatus", "IsDeleted", "LastUsed", "Name", "OwnedBy" },
                values: new object[,]
                {
                    { new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), "Dell UltraSharp U2723QE 27 inch", "In Use", false, new DateTime(2024, 7, 23, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8522), "Screen", "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { new Guid("0a395b72-ae0d-4a49-b7f8-1763de733068"), "High resolution monitor", "In Use", false, new DateTime(2024, 7, 20, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8530), "Monitor", "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), "Thai's PC", "Available", false, new DateTime(2024, 7, 22, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8524), "PC", "a687bb04-4f19-49d5-a60f-2db52044767c" },
                    { new Guid("a1d65f8a-f7fd-4995-940f-6ab254523f90"), "Designer's tablet", "In Use", false, new DateTime(2024, 7, 23, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8534), "Tablet", "a687bb04-4f19-49d5-a60f-2db52044767c" },
                    { new Guid("b4dc2d48-482a-48a2-bad6-7a1e0e3139b7"), "Development desktop", "Available", false, new DateTime(2024, 7, 24, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8528), "Desktop", "a687bb04-4f19-49d5-a60f-2db52044767c" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "ProjectId", "UserId", "DeletedAt", "IsDeleted", "IsLeader", "IsValid", "JoinDate" },
                values: new object[,]
                {
                    { new Guid("0d59a77e-14b0-441f-9c66-240b1f4ce144"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d59a77e-14b0-441f-9c66-240b1f4ce144"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d59a77e-14b0-441f-9c66-240b1f4ce144"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d59a77e-14b0-441f-9c66-240b1f4ce144"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e175a98-f6f3-4fbf-aa2f-c7f0f8446d60"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e175a98-f6f3-4fbf-aa2f-c7f0f8446d60"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e175a98-f6f3-4fbf-aa2f-c7f0f8446d60"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e175a98-f6f3-4fbf-aa2f-c7f0f8446d60"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("16e98a28-511a-49b1-9c04-d60626a889ee"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("16e98a28-511a-49b1-9c04-d60626a889ee"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("16e98a28-511a-49b1-9c04-d60626a889ee"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("16e98a28-511a-49b1-9c04-d60626a889ee"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b3c2e9a-c77c-417e-a093-8d701d2b4821"), "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", null, false, true, true, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20a39a90-b376-477d-a2c2-1973cd347092"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20a39a90-b376-477d-a2c2-1973cd347092"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20a39a90-b376-477d-a2c2-1973cd347092"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20a39a90-b376-477d-a2c2-1973cd347092"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2bc0fef9-3000-48ec-82e9-de4dc0494056"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2bc0fef9-3000-48ec-82e9-de4dc0494056"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2bc0fef9-3000-48ec-82e9-de4dc0494056"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2bc0fef9-3000-48ec-82e9-de4dc0494056"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f404ee3-9fe2-407f-a07e-0b100e268c0e"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f404ee3-9fe2-407f-a07e-0b100e268c0e"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f404ee3-9fe2-407f-a07e-0b100e268c0e"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f404ee3-9fe2-407f-a07e-0b100e268c0e"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f722609-dace-4c60-a6f3-19e015546310"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f722609-dace-4c60-a6f3-19e015546310"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f722609-dace-4c60-a6f3-19e015546310"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, false, true, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("390dba55-cdc1-4b12-88b8-0e3c257253c5"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("390dba55-cdc1-4b12-88b8-0e3c257253c5"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("390dba55-cdc1-4b12-88b8-0e3c257253c5"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("390dba55-cdc1-4b12-88b8-0e3c257253c5"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b400907-f70f-453e-b8ae-92c522a69805"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b400907-f70f-453e-b8ae-92c522a69805"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b400907-f70f-453e-b8ae-92c522a69805"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b400907-f70f-453e-b8ae-92c522a69805"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e3b54cf-8b56-4590-adca-73112fa8b9e7"), "c4a15b23-9d00-4ec5-acc9-493354e91973", null, false, true, true, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", null, false, true, true, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("88d39e7e-3952-43ef-8e15-57116d276d59"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("88d39e7e-3952-43ef-8e15-57116d276d59"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("88d39e7e-3952-43ef-8e15-57116d276d59"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("88d39e7e-3952-43ef-8e15-57116d276d59"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c76d5f2-2f87-4cf0-820f-f81284cbb10b"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c76d5f2-2f87-4cf0-820f-f81284cbb10b"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c76d5f2-2f87-4cf0-820f-f81284cbb10b"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c76d5f2-2f87-4cf0-820f-f81284cbb10b"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94985ddd-ca1f-402f-a389-f1e1df169f75"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94985ddd-ca1f-402f-a389-f1e1df169f75"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94985ddd-ca1f-402f-a389-f1e1df169f75"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94985ddd-ca1f-402f-a389-f1e1df169f75"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a210682e-f41e-4e01-af7c-43cd942ac9df"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a210682e-f41e-4e01-af7c-43cd942ac9df"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a210682e-f41e-4e01-af7c-43cd942ac9df"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a210682e-f41e-4e01-af7c-43cd942ac9df"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a474440d-4a24-4e27-9863-99fb0d0ec189"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a474440d-4a24-4e27-9863-99fb0d0ec189"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a474440d-4a24-4e27-9863-99fb0d0ec189"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a474440d-4a24-4e27-9863-99fb0d0ec189"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aaa1e013-1aa8-44ef-adaa-298a8d81b2d0"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aaa1e013-1aa8-44ef-adaa-298a8d81b2d0"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aaa1e013-1aa8-44ef-adaa-298a8d81b2d0"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aaa1e013-1aa8-44ef-adaa-298a8d81b2d0"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5c6dbc1-8e92-4667-8627-8772ffbd09d0"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5c6dbc1-8e92-4667-8627-8772ffbd09d0"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5c6dbc1-8e92-4667-8627-8772ffbd09d0"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5c6dbc1-8e92-4667-8627-8772ffbd09d0"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b915e80e-2894-4443-92ea-1fcfbf3fd851"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b915e80e-2894-4443-92ea-1fcfbf3fd851"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b915e80e-2894-4443-92ea-1fcfbf3fd851"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b915e80e-2894-4443-92ea-1fcfbf3fd851"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbbdb7db-bf17-4d42-bb22-beebe83f6f34"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbbdb7db-bf17-4d42-bb22-beebe83f6f34"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbbdb7db-bf17-4d42-bb22-beebe83f6f34"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbbdb7db-bf17-4d42-bb22-beebe83f6f34"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6187862-b687-4c00-9f5a-4d5c6b52d87d"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6187862-b687-4c00-9f5a-4d5c6b52d87d"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6187862-b687-4c00-9f5a-4d5c6b52d87d"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6187862-b687-4c00-9f5a-4d5c6b52d87d"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c70f946f-c591-4794-b053-174765ae386d"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, false, true, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c70f946f-c591-4794-b053-174765ae386d"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, false, true, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c70f946f-c591-4794-b053-174765ae386d"), "7397c854-194b-4749-9205-f46e4f2fccf8", null, false, false, true, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c70f946f-c591-4794-b053-174765ae386d"), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", null, false, true, true, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c70f946f-c591-4794-b053-174765ae386d"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da45413f-3263-4076-b186-03c9a5f9220f"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da45413f-3263-4076-b186-03c9a5f9220f"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da45413f-3263-4076-b186-03c9a5f9220f"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da45413f-3263-4076-b186-03c9a5f9220f"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), "c4a15b23-9d00-4ec5-acc9-493354e91973", null, false, true, true, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, false, true, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, false, true, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), "7397c854-194b-4749-9205-f46e4f2fccf8", null, false, true, true, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", null, false, true, true, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc88de4a-d833-40a5-a9e5-e5b1b1f0718f"), "603600b5-ca65-4fa7-817e-4583ef22b330", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc88de4a-d833-40a5-a9e5-e5b1b1f0718f"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc88de4a-d833-40a5-a9e5-e5b1b1f0718f"), "6c6abe62-f811-4a8b-96eb-ed326c47d209", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc88de4a-d833-40a5-a9e5-e5b1b1f0718f"), "a687bb04-4f19-49d5-a60f-2db52044767c", null, false, true, true, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("049d2c9c-f550-4e21-8911-efc5789106ec"), "Thân gửi các bạn sinh viên,\r\n\r\nPhòng Phát triển bền vững trường Đại học FPT (FSDG) sẽ tiến hành khảo sát với sinh viên trên cổng thông tin đào tạo FAP.\r\n\r\nKhảo sát về các hành động thúc đẩy 17 mục tiêu phát triển bền vững toàn cầu của sinh viên đã thực hiện trong thời gian một năm qua.\r\n\r\nKhảo sát sẽ bắt đầu từ ngày 25/06/2024, sinh viên vui lòng truy cập vào địa chỉ FAP (https://fap.fpt.edu.vn/) và tham gia khảo sát đầy đủ. Sau khi hoàn thành khảo sát, sinh viên sẽ tiếp tục vào FAP bình thường.\r\n\r\nThân mến!.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 24, 15, 16, 0, 0, DateTimeKind.Unspecified), "[Phòng Phát triển bền vững] Chuẩn bị khảo sát SV toàn trường về PTBV" },
                    { new Guid("650204d7-0be6-4f91-89f7-d80572d4f76a"), "Phòng Khảo thí thông báo đã có điểm thi kết thúc học phần lần 2 môn SSL101c học kỳ Spring 2024. Môn COV111, COV121, AET102, MLN111, HCM202, IOT102, MLN131 học kỳ Summer 2024, các em đăng nhập FAP để xem chi tiết..", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 26, 22, 7, 0, 0, DateTimeKind.Unspecified), "Thông báo điểm thi kết thúc học phần lần 2 môn SSL101c học kỳ Spring 2024." },
                    { new Guid("663c5d19-d3ed-4d6a-aff6-3997dd0c43c4"), "Theo kế hoạch của phòng Quản lý Đào tạo, học kỳ SUMMER 2024 H2 sẽ bắt đầu vào ngày 08/07/2024:\r\n\r\nBan Kế toán gửi tới các bạn sinh viên thông tin về học phí kỳ SUMMER 2024 H2, chi tiết như sau:\r\n\r\nHạn nộp tiền (ngày nhà trường nhận được tiền): 26/06/2024\r\n \r\n\r\nSố tiền cần nộp: SV đăng nhập vào fap.fpt.edu.vn, số tiền học phí phải nộp kỳ tới sẽ hiển thị trên màn chính. Ban Kế toán cập nhật hóa đơn học phí lên hệ thống từ ngày 12/06/2024. \r\nĐối tượng loại trừ: - Sinh viên có học bổng 100%\r\n\r\n                                            - Sinh viên đã hoàn thành thủ tục tạm ngưng học phần Tiếng Anh hoặc bảo lưu kỳ.\r\n\r\n \r\n\r\nHướng dẫn thanh toán học phí:\r\nSinh viên đăng nhập vào fap.fpt.edu.vn → Choose paid items → Học phí và phụ trội KTX đã được mặc định tick chọn → nhấn Add to Card → nhấn Submit Order → Sinh viên thực hiện thanh toán theo nguyên tắc sau\r\n\r\nNếu ví FAP đủ số dư → Hệ thống tự động trừ tiền.\r\nNếu ví FAP có số dư bằng 0 → Tạo khoản thanh toán → Sinh viên quét QRCode để thanh toán\r\nNếu ví FAP có số dư lớn hơn 0 nhưng không đủ số tiền thanh toán học phí, phụ trội KTX → Sinh viên quét QRCode thanh toán số tiền còn thiếu.\r\nLưu ý: Sau khi SV nộp đủ học phí, hệ thống sẽ tự động quét trừ học phí kỳ này ngay lập tức.\r\n\r\nSinh viên không thấy xuất hiện học phí phải nộp trên FAP nếu rơi vào các trường hợp sau: Sinh viên bảo lưu kỳ, tạm ngưng học phần, sinh viên đã nộp đủ học phí kỳ SU24H2, chờ lớp.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 12, 9, 26, 0, 0, DateTimeKind.Unspecified), "THÔNG BÁO NỘP HỌC PHÍ KỲ SUMMER 2024 H2" },
                    { new Guid("7c712eff-f7d8-41af-a36c-9d7ce1439e3b"), "Phòng Dịch vụ sinh viên xin thông báo sẽ ngừng làm việc trong thời gian nghỉ hè kéo dài từ 01/07 đến hết ngày 05/07/2024.\r\n\r\nThời gian quay trở lại làm việc bình thường: 08/07/2024\r\n\r\nMọi yêu cầu hỗ trợ, giải đáp thắc mắc vui lòng gửi tới email: dichvusinhvien@fe.edu.vn\r\n\r\nTrân trọng thông báo,", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thông báo về việc phòng Dịch vụ sinh viên ngừng làm việc trong thời gian nghỉ hè" },
                    { new Guid("97755739-5cc9-49f7-bcf7-a66765be0571"), "Phòng Khảo thi thông báo đã có điểm thi kết thúc học phần lần 1 các môn AIG201c, ASR301c, BDI302c, CHN132c, CMC201c, ECC301c, ENM211c, ENM221c, FIM302c, FRS401c, HOM301c, IAO201c, IAR401c, ITE303c, LAB221c, MKT205c, SEO201c, SSC302c, AIG202c, CRY303c, DWP301c, EBC301c, EDT202c, ENG302c, HRM201c, IFT201c, ITA203c, ITB301c, ITE302c, LAW201c, NWC203c, OBE102c, PMG201c, PMG202c, PRC391c, PRC392c, PRE201c, PRN292c, SSL101c, WDU203c, WDU202c, PRO192c học kỳ Spring 2024, các em đăng nhập FAP để xem chi tiết điểm.\r\n\r\n", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 4, 18, 23, 37, 0, 0, DateTimeKind.Unspecified), "Thông báo điểm thi kết thúc học phần lần 1 các môn học online trên Coursera học kỳ Spring 2024" },
                    { new Guid("a491e3db-344e-4f16-a051-1ed491901340"), "Phòng Tổ chức và Quản lý Đào tạo thông báo kế hoạch học tập Half 2 - Học kỳ Summer 2024 đối với sinh viên giai đoạn Tiếng Anh chuẩn bị tại cơ sở Hà Nội như sau:\r\n\r\n \r\n\r\nTHỜI GIAN HỌC:\r\n \r\n\r\nSinh viên học chương trình Little UK và Transition bắt đầu học Half 2 từ ngày 08/7/2024.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 12, 16, 1, 0, 0, DateTimeKind.Unspecified), "KẾ HOẠCH HỌC TẬP HALF 2 KỲ SUMMER 2024 DÀNH CHO SINH VIÊN GIAI ĐOẠN TIẾNG ANH CHUẨN BỊ TẠI ĐH FPT HÀ NỘI" },
                    { new Guid("c0268d79-cfd7-44c3-9b13-709869ae00e2"), "Phòng Công tác sinh viên thông báo:\r\n\r\nBảng điểm phong trào tháng 1-2-3-4 và điểm Tổng kết học kỳ Spring 2024 (final): Tại đây\r\n\r\nMọi thắc mắc vui lòng gửi về hòm mail sro.hn@fpt.edu.vn trước 14h ngày 13/06/2024\r\n\r\nTrân trọng thông báo,", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 12, 12, 40, 0, 0, DateTimeKind.Unspecified), "[CTSV] - Thông báo Điểm Rèn Luyện Học Kỳ Spring 2024" },
                    { new Guid("cfc8a241-628f-4fab-acaf-60ffd42f97cd"), "This is the content of news item 3.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 27, 16, 25, 0, 0, DateTimeKind.Unspecified), "News Title 3" }
                });

            migrationBuilder.InsertData(
                table: "NotificationAccounts",
                columns: new[] { "AccountId", "NotificationId", "IsRead" },
                values: new object[,]
                {
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), false },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), true },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), false },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), false },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), false },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), false },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), false },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), false },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), true },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), true },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("e331de18-289c-403d-8028-26c4b595587a"), false },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("e331de18-289c-403d-8028-26c4b595587a"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("e331de18-289c-403d-8028-26c4b595587a"), false },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("e331de18-289c-403d-8028-26c4b595587a"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("e331de18-289c-403d-8028-26c4b595587a"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("e331de18-289c-403d-8028-26c4b595587a"), false }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "NotificationType", "ProjectId", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), "Don't miss out on our latest promotions!", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 7, 18, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8276), "Project", null, "Promotion Alert", "" },
                    { new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), "Please take a moment to complete our user survey.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 7, 17, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8278), "Project", null, "Survey Request", "" },
                    { new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), "Please update your password to enhance security.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 7, 21, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8270), "System", null, "Security Alert", "" },
                    { new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), "The system will be down for maintenance tonight.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 7, 20, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8272), "System", null, "Downtime Notification", "" },
                    { new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), "Join weekly meeting.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 7, 19, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8274), "Project", null, "Weekly Meeting", "" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "AccountId", "DeviceId", "EndDate", "Purpose", "ScheduledDate", "StartDate" },
                values: new object[,]
                {
                    { new Guid("44efa2a7-4f64-4fc6-bbbe-869099817d4f"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"), new DateTime(2024, 7, 25, 19, 9, 10, 568, DateTimeKind.Local).AddTicks(8587), "Testing", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8585), new DateTime(2024, 7, 25, 18, 9, 10, 568, DateTimeKind.Local).AddTicks(8586) },
                    { new Guid("5547314b-521a-47e9-ad60-5e376e686636"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("5947a22f-0191-419c-873b-4324b5b95e84"), new DateTime(2024, 7, 25, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8637), "Development", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8636), new DateTime(2024, 7, 25, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8636) },
                    { new Guid("5b1615a6-b870-456a-a483-e99a3f9122dc"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("11d331b4-136c-4844-a686-ffc38c103268"), new DateTime(2024, 7, 23, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8629), "Development", new DateTime(2024, 7, 23, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8628), new DateTime(2024, 7, 23, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8628) },
                    { new Guid("6500363e-6574-42e7-8577-6dc87a55ce15"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("eb934470-4e73-41a8-8304-3bcb1ea18502"), new DateTime(2024, 7, 23, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8642), "Development", new DateTime(2024, 7, 23, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8641), new DateTime(2024, 7, 23, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8642) },
                    { new Guid("e377b750-0b20-4943-9e5d-6909d4810f13"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"), new DateTime(2024, 7, 25, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8591), "Development", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8590), new DateTime(2024, 7, 25, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8590) }
                });

            migrationBuilder.InsertData(
                table: "StudentDetails",
                columns: new[] { "AccountId", "Major", "RollNumber", "Specialized" },
                values: new object[,]
                {
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", "Software Engineering", "HE163098", "ASP.NET" },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", "Data Engineer", "HE163884", "Data Analyst" },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", "Artifact Intelligent", "HE163956", "C" }
                });

            migrationBuilder.InsertData(
                table: "TaskLists",
                columns: new[] { "Id", "MaxTasks", "Name", "Order", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("0008056c-1d86-45f8-ae4e-b0512284472d"), 3, "Model Training", 3, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f") },
                    { new Guid("00085297-3c05-4062-a240-bb1b4c6b4a38"), 5, "Data Collection", 1, new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6") },
                    { new Guid("011dd84d-69f8-47ac-98be-960ed42786ff"), 3, "Model Training", 3, new Guid("4b400907-f70f-453e-b8ae-92c522a69805") },
                    { new Guid("0169efa4-85d1-4e90-a8a2-c14a742c80eb"), 3, "Model Training", 3, new Guid("0d59a77e-14b0-441f-9c66-240b1f4ce144") },
                    { new Guid("044978f5-431a-4fd2-aa4e-35fde9b9083b"), 6, "Model Testing", 4, new Guid("b915e80e-2894-4443-92ea-1fcfbf3fd851") },
                    { new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"), 6, "Model Testing", 4, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f") },
                    { new Guid("0626e30e-f0a1-40af-a3a0-51edbbd88d03"), 5, "Data Collection", 1, new Guid("b915e80e-2894-4443-92ea-1fcfbf3fd851") },
                    { new Guid("065898cb-e8f8-4305-b8e8-0c69ad7273e4"), 6, "Model Testing", 4, new Guid("0d59a77e-14b0-441f-9c66-240b1f4ce144") },
                    { new Guid("072f6ce9-76d8-4d49-95d4-893802b4c49e"), 5, "Data Collection", 1, new Guid("da45413f-3263-4076-b186-03c9a5f9220f") },
                    { new Guid("073e7608-8fc4-4b30-9f92-994c6e3552e9"), 3, "Model Training", 3, new Guid("16e98a28-511a-49b1-9c04-d60626a889ee") },
                    { new Guid("08267faa-a7f9-48b3-bdd1-5ff95d9d500a"), 3, "Model Training", 3, new Guid("88d39e7e-3952-43ef-8e15-57116d276d59") },
                    { new Guid("0bb2e364-d05d-4128-b24d-0f69725b85f3"), 5, "Requirement Analysis", 1, new Guid("c70f946f-c591-4794-b053-174765ae386d") },
                    { new Guid("0c370783-e453-471d-8518-4c42b681ff0d"), 5, "Data Collection", 1, new Guid("0d59a77e-14b0-441f-9c66-240b1f4ce144") },
                    { new Guid("0c988920-3d90-4131-b93e-9a50a5b83c8b"), 6, "Model Testing", 4, new Guid("2bc0fef9-3000-48ec-82e9-de4dc0494056") },
                    { new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"), 5, "Paper Writing", 4, new Guid("1b3c2e9a-c77c-417e-a093-8d701d2b4821") },
                    { new Guid("126f3145-dfa9-4c94-aa27-669a70a73dab"), 6, "Model Testing", 4, new Guid("da45413f-3263-4076-b186-03c9a5f9220f") },
                    { new Guid("1e8ed824-cfcb-4ec2-8f8b-e3c46067cdff"), 6, "Model Testing", 4, new Guid("a210682e-f41e-4e01-af7c-43cd942ac9df") },
                    { new Guid("24d9bd4f-d960-4081-87a8-6be032290863"), 6, "Data Collection", 2, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe") },
                    { new Guid("2b140863-8557-4ad9-b2c1-ee9ee7381a2c"), 3, "Model Training", 3, new Guid("0e175a98-f6f3-4fbf-aa2f-c7f0f8446d60") },
                    { new Guid("2c81e116-5120-4920-bf51-092081bfc67d"), 3, "Initial Research", 1, new Guid("2f722609-dace-4c60-a6f3-19e015546310") },
                    { new Guid("2cfc3aab-2f03-4f6f-b532-1cb65cf505bd"), 3, "Model Training", 3, new Guid("8c76d5f2-2f87-4cf0-820f-f81284cbb10b") },
                    { new Guid("2f7ff47f-c1e2-4e10-b472-298e5dd1e312"), 3, "Model Training", 3, new Guid("c6187862-b687-4c00-9f5a-4d5c6b52d87d") },
                    { new Guid("31b43d03-c250-4b85-b86f-7f106af51f4e"), 5, "Data Collection", 1, new Guid("390dba55-cdc1-4b12-88b8-0e3c257253c5") },
                    { new Guid("31da73d3-4de1-49c4-be8b-80a8c0b9d30b"), 3, "Model Training", 3, new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6") },
                    { new Guid("327ed869-4449-41ae-84d1-8eeb11d890ac"), 3, "Model Development", 2, new Guid("0d59a77e-14b0-441f-9c66-240b1f4ce144") },
                    { new Guid("3a339b14-8f9e-413d-97d0-7ce36aafee58"), 6, "Experimentation", 2, new Guid("1b3c2e9a-c77c-417e-a093-8d701d2b4821") },
                    { new Guid("3d30d2e9-2fc9-467b-a2a2-030280f534ce"), 5, "Data Collection", 1, new Guid("bbbdb7db-bf17-4d42-bb22-beebe83f6f34") },
                    { new Guid("3e0dae6f-8ca9-4c9b-b218-210031248c61"), 6, "Model Testing", 4, new Guid("4b400907-f70f-453e-b8ae-92c522a69805") },
                    { new Guid("3f3af254-7792-467e-83d4-19c0d2835750"), 3, "Model Development", 2, new Guid("2bc0fef9-3000-48ec-82e9-de4dc0494056") },
                    { new Guid("41640d60-1134-45c3-a7c4-2e7f306ec967"), 5, "Requirement Gathering", 1, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1") },
                    { new Guid("41a17fc7-3de1-4033-8732-c24849eae75c"), 3, "Model Training", 3, new Guid("20a39a90-b376-477d-a2c2-1973cd347092") },
                    { new Guid("420ee8e5-71b3-49e4-b809-296e3058349e"), 3, "Model Development", 2, new Guid("0e175a98-f6f3-4fbf-aa2f-c7f0f8446d60") },
                    { new Guid("431dd63b-469e-4589-b1c6-4b4af20a7728"), 6, "Development", 3, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1") },
                    { new Guid("438858f4-203a-4de5-ab75-20292a481a50"), 3, "Model Training", 3, new Guid("b5c6dbc1-8e92-4667-8627-8772ffbd09d0") },
                    { new Guid("4473ec89-7805-41b9-8364-d2b35a501636"), 3, "Model Training", 3, new Guid("aaa1e013-1aa8-44ef-adaa-298a8d81b2d0") },
                    { new Guid("455d5a96-2d52-4aa8-a98f-ac27f4f321c3"), 5, "Data Analysis", 3, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe") },
                    { new Guid("4852130d-ab5f-4979-aa8e-37cce9335e13"), 3, "Model Training", 3, new Guid("b915e80e-2894-4443-92ea-1fcfbf3fd851") },
                    { new Guid("4c238c20-5106-4ca5-88a7-9980892a5455"), 5, "Model Evaluation", 3, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42") },
                    { new Guid("4e4d83da-580a-438d-954f-c4a57dcbbf60"), 6, "Model Testing", 4, new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6") },
                    { new Guid("4fb411c2-c2fe-4dc0-904b-2c711ee8a085"), 5, "Data Collection", 1, new Guid("aaa1e013-1aa8-44ef-adaa-298a8d81b2d0") },
                    { new Guid("53f24f9c-fe0c-4ded-91ef-2d52d18463b6"), 5, "Data Collection", 1, new Guid("88d39e7e-3952-43ef-8e15-57116d276d59") },
                    { new Guid("556dbbe7-9f99-4c1f-b7a5-44392ad1ae81"), 3, "Model Development", 2, new Guid("aaa1e013-1aa8-44ef-adaa-298a8d81b2d0") },
                    { new Guid("5618a016-156a-449c-92e6-926eabe0cf8a"), 4, "UI/UX Design", 2, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1") },
                    { new Guid("5702d933-e34f-41c9-b9a1-fb64999f3e27"), 6, "Model Testing", 4, new Guid("390dba55-cdc1-4b12-88b8-0e3c257253c5") },
                    { new Guid("5b24898d-dddc-4c99-8c69-5e43a370e45c"), 6, "Data Collection", 1, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42") },
                    { new Guid("5f54b6b6-614e-46d2-a64e-10d91db2f516"), 5, "Data Collection", 1, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f") },
                    { new Guid("5f6f2583-ace4-48b6-98e5-69c400c5f983"), 5, "Data Collection", 1, new Guid("fc88de4a-d833-40a5-a9e5-e5b1b1f0718f") },
                    { new Guid("60ac6a0a-2788-4326-ad31-fdd899d7b80f"), 4, "Testing", 4, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1") },
                    { new Guid("60c72e99-ff91-4312-8405-83243c0fd4a8"), 3, "Model Training", 3, new Guid("390dba55-cdc1-4b12-88b8-0e3c257253c5") },
                    { new Guid("63f4b512-c46c-4cf4-ad61-5e665735f82b"), 3, "Model Training", 3, new Guid("da45413f-3263-4076-b186-03c9a5f9220f") },
                    { new Guid("67a4dd09-f119-4c82-921e-597279ef412d"), 5, "Data Analysis", 3, new Guid("1b3c2e9a-c77c-417e-a093-8d701d2b4821") },
                    { new Guid("67cda2c4-355f-4690-ae22-d595fe4c7ae5"), 3, "Model Development", 2, new Guid("fc88de4a-d833-40a5-a9e5-e5b1b1f0718f") },
                    { new Guid("6a772965-aae4-4b04-8e89-fe14dee28b88"), 5, "Data Collection", 1, new Guid("16e98a28-511a-49b1-9c04-d60626a889ee") },
                    { new Guid("6b9652a0-3923-4885-bdee-a31f15e9e855"), 5, "Data Collection", 1, new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6") },
                    { new Guid("706fc57b-286f-419e-99a5-3734634bf9e8"), 5, "Data Collection", 1, new Guid("a210682e-f41e-4e01-af7c-43cd942ac9df") },
                    { new Guid("708358a5-efbb-451d-926c-af4d4f65bb72"), 6, "Model Testing", 4, new Guid("8c76d5f2-2f87-4cf0-820f-f81284cbb10b") },
                    { new Guid("71ecf7a0-92a9-40f8-9bbf-45a871bea3c3"), 3, "Model Development", 2, new Guid("a210682e-f41e-4e01-af7c-43cd942ac9df") },
                    { new Guid("75072b8e-0a97-470a-86d8-1f105994df83"), 6, "Model Testing", 4, new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6") },
                    { new Guid("75f606e3-f12a-4257-b486-a15ef2aad23b"), 3, "Deployment", 5, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1") },
                    { new Guid("78282fba-7ef4-4f16-89e3-93a097271cc7"), 6, "Model Testing", 4, new Guid("16e98a28-511a-49b1-9c04-d60626a889ee") },
                    { new Guid("7965e5b0-b9a9-41c7-9d23-55507f84478b"), 6, "Model Testing", 4, new Guid("aaa1e013-1aa8-44ef-adaa-298a8d81b2d0") },
                    { new Guid("816ebcd1-124d-4b5c-810e-b0e8aeedb501"), 6, "Testing", 4, new Guid("c70f946f-c591-4794-b053-174765ae386d") },
                    { new Guid("8203bcf4-60d3-4593-9934-32df5f18da43"), 3, "Model Training", 3, new Guid("bbbdb7db-bf17-4d42-bb22-beebe83f6f34") },
                    { new Guid("84f2c617-35e0-4343-a7c8-35226cb4c6a1"), 4, "Literature Review", 1, new Guid("1b3c2e9a-c77c-417e-a093-8d701d2b4821") },
                    { new Guid("855ee363-b3cc-4628-ac7d-7016fee75dcd"), 5, "Data Collection", 1, new Guid("a474440d-4a24-4e27-9863-99fb0d0ec189") },
                    { new Guid("8866bcb2-198a-4fcd-b0c0-8090444b8722"), 4, "System Design", 2, new Guid("c70f946f-c591-4794-b053-174765ae386d") },
                    { new Guid("88ccda68-cf6d-4468-a5dc-49474fd2537c"), 6, "Model Testing", 4, new Guid("bbbdb7db-bf17-4d42-bb22-beebe83f6f34") },
                    { new Guid("8de05be7-f7d1-425e-9c5e-b1a965456935"), 4, "User Testing", 3, new Guid("2f722609-dace-4c60-a6f3-19e015546310") },
                    { new Guid("8dec80db-c938-4030-94c7-2e7fe6821cac"), 3, "Model Development", 2, new Guid("2f404ee3-9fe2-407f-a07e-0b100e268c0e") },
                    { new Guid("913951cc-4679-46e7-bea9-64092bd733d0"), 6, "Model Testing", 4, new Guid("2f404ee3-9fe2-407f-a07e-0b100e268c0e") },
                    { new Guid("94420810-4a35-4f33-a7df-6078ab4efb1c"), 10, "Implementation", 3, new Guid("c70f946f-c591-4794-b053-174765ae386d") },
                    { new Guid("95be764c-437f-42c8-bd26-bf0aff147218"), 5, "Final Development", 4, new Guid("2f722609-dace-4c60-a6f3-19e015546310") },
                    { new Guid("9c8b594c-a4b1-428d-a017-27b78704307a"), 3, "Model Training", 3, new Guid("2f404ee3-9fe2-407f-a07e-0b100e268c0e") },
                    { new Guid("9f4bf898-f8f5-4d7f-8bf5-c3769059060e"), 6, "Model Testing", 4, new Guid("fc88de4a-d833-40a5-a9e5-e5b1b1f0718f") },
                    { new Guid("9fe99984-6667-4011-9be6-ec588a437e26"), 5, "Data Collection", 1, new Guid("20a39a90-b376-477d-a2c2-1973cd347092") },
                    { new Guid("a1a1142b-22df-49c6-b46f-649dd1345989"), 3, "Model Development", 2, new Guid("16e98a28-511a-49b1-9c04-d60626a889ee") },
                    { new Guid("a35f0d22-bf97-436f-9aee-a33edf8e26d3"), 3, "Model Development", 2, new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6") },
                    { new Guid("a373d48c-7a4b-4cc8-a879-19b4b5ff3c41"), 5, "Data Collection", 1, new Guid("b5c6dbc1-8e92-4667-8627-8772ffbd09d0") },
                    { new Guid("a37790d5-0113-491b-98af-5060ff8aa26c"), 4, "Reporting", 4, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe") },
                    { new Guid("a88a1f4e-d3dd-42f0-a0e7-3a7f6affa301"), 5, "Prototype Development", 2, new Guid("2f722609-dace-4c60-a6f3-19e015546310") },
                    { new Guid("a88e6bc8-51e6-43b1-955b-66d132791b85"), 3, "Model Training", 3, new Guid("94985ddd-ca1f-402f-a389-f1e1df169f75") },
                    { new Guid("ac829962-0360-44d2-a766-bb50e3e2001e"), 4, "Deployment", 4, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42") },
                    { new Guid("ace555ec-8088-4219-be76-dc6eb76dc4fd"), 6, "Model Testing", 4, new Guid("88d39e7e-3952-43ef-8e15-57116d276d59") },
                    { new Guid("b12d7375-dc9f-46a3-a315-eb02cbf0f371"), 3, "Model Development", 2, new Guid("390dba55-cdc1-4b12-88b8-0e3c257253c5") },
                    { new Guid("b1cf6c5a-81a5-495d-9071-335b629f29d0"), 5, "Data Collection", 1, new Guid("94985ddd-ca1f-402f-a389-f1e1df169f75") },
                    { new Guid("b1d1ceed-5120-4c84-aed7-ecaf2da41f88"), 6, "Model Testing", 4, new Guid("0e175a98-f6f3-4fbf-aa2f-c7f0f8446d60") },
                    { new Guid("b213e848-0190-42af-82ce-143847dfe69a"), 5, "Data Collection", 1, new Guid("c6187862-b687-4c00-9f5a-4d5c6b52d87d") },
                    { new Guid("b351e4b2-8b16-4c0c-b37b-630bcf661e4b"), 3, "Model Development", 2, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f") },
                    { new Guid("b3f0e11a-2e7e-438b-8905-4b02a5028f95"), 3, "Model Training", 3, new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6") },
                    { new Guid("b5884262-3510-44b5-95ca-82420dc4ba15"), 5, "Data Collection", 1, new Guid("2f404ee3-9fe2-407f-a07e-0b100e268c0e") },
                    { new Guid("b5a32109-454a-48f3-b298-712238b91483"), 5, "Data Collection", 1, new Guid("0e175a98-f6f3-4fbf-aa2f-c7f0f8446d60") },
                    { new Guid("b5cae679-8459-4214-a9d6-02e9c2f427bb"), 3, "Model Training", 3, new Guid("fc88de4a-d833-40a5-a9e5-e5b1b1f0718f") },
                    { new Guid("b6dd29bd-ff67-4574-8409-f72bf454b5b1"), 3, "Model Training", 3, new Guid("2bc0fef9-3000-48ec-82e9-de4dc0494056") },
                    { new Guid("b98058fd-7ee5-4430-8a25-c2d86aa80e44"), 6, "Model Testing", 4, new Guid("b5c6dbc1-8e92-4667-8627-8772ffbd09d0") },
                    { new Guid("bc28df54-9252-46fa-9ec1-7e0c4d92ea16"), 5, "Data Collection", 1, new Guid("8c76d5f2-2f87-4cf0-820f-f81284cbb10b") },
                    { new Guid("c059bb8a-b7ba-445d-9f93-3034c64a16b6"), 3, "Model Development", 2, new Guid("da45413f-3263-4076-b186-03c9a5f9220f") },
                    { new Guid("c07b395a-cbf6-49a4-aeaa-ef28de9517ff"), 5, "Sensor Installation", 1, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe") },
                    { new Guid("c17941d1-a1b7-4a31-9b9e-729449214f30"), 3, "Model Development", 2, new Guid("20a39a90-b376-477d-a2c2-1973cd347092") },
                    { new Guid("ccc01136-2fc2-4a76-aa88-c943994ea3ed"), 3, "Model Training", 3, new Guid("a210682e-f41e-4e01-af7c-43cd942ac9df") },
                    { new Guid("cd75e5bb-185f-41c8-9038-fa77b0e15346"), 3, "Model Development", 2, new Guid("8c76d5f2-2f87-4cf0-820f-f81284cbb10b") },
                    { new Guid("cdd20bb7-6562-416f-9138-fef2d097cc62"), 6, "Model Testing", 4, new Guid("c6187862-b687-4c00-9f5a-4d5c6b52d87d") },
                    { new Guid("ce7bd183-f8e9-4472-b967-6a8548c40323"), 3, "Model Development", 2, new Guid("bbbdb7db-bf17-4d42-bb22-beebe83f6f34") },
                    { new Guid("d2220ea0-8e34-4ccf-a8e4-a2b77364a1f8"), 3, "Model Development", 2, new Guid("94985ddd-ca1f-402f-a389-f1e1df169f75") },
                    { new Guid("d3381095-da10-40fd-82ac-75f981774a29"), 3, "Model Training", 3, new Guid("a474440d-4a24-4e27-9863-99fb0d0ec189") },
                    { new Guid("d33a98d8-b806-430c-9c6a-e142d2992379"), 3, "Model Development", 2, new Guid("b915e80e-2894-4443-92ea-1fcfbf3fd851") },
                    { new Guid("d3b8b9a5-a488-43c4-8d3a-2ceb948e770f"), 5, "Data Collection", 1, new Guid("2bc0fef9-3000-48ec-82e9-de4dc0494056") },
                    { new Guid("d5cd0716-7854-46c2-9909-e20668836094"), 6, "Model Testing", 4, new Guid("a474440d-4a24-4e27-9863-99fb0d0ec189") },
                    { new Guid("d91d4391-852d-4e06-b122-0374b8b5d854"), 3, "Model Development", 2, new Guid("f5741ce6-d21c-4d8b-9005-ca669b1ed9e6") },
                    { new Guid("d954bf2a-bb9e-4e90-8e43-a4cce635ded3"), 3, "Model Development", 2, new Guid("4b400907-f70f-453e-b8ae-92c522a69805") },
                    { new Guid("daf064c6-75ff-4590-a3b8-a996468e19d8"), 6, "Model Testing", 4, new Guid("94985ddd-ca1f-402f-a389-f1e1df169f75") },
                    { new Guid("db3c0bd2-aed1-4e4e-bd25-e24080a1e0c8"), 3, "Model Development", 2, new Guid("c6187862-b687-4c00-9f5a-4d5c6b52d87d") },
                    { new Guid("e819d6c6-cec6-493a-8e8d-2129a259c634"), 5, "Data Collection", 1, new Guid("4b400907-f70f-453e-b8ae-92c522a69805") },
                    { new Guid("e86a5ffe-7b06-4f06-94a4-698cb58161db"), 2, "Deployment", 5, new Guid("c70f946f-c591-4794-b053-174765ae386d") },
                    { new Guid("f1ccd0d5-7e64-4740-a44d-b89430d6a1fb"), 3, "Model Development", 2, new Guid("a474440d-4a24-4e27-9863-99fb0d0ec189") },
                    { new Guid("f5840e34-49e8-435f-bbb4-e403c53642b1"), 7, "Model Training", 2, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42") },
                    { new Guid("fa15a081-aeae-425c-b9c3-06c2646aa4c6"), 6, "Model Testing", 4, new Guid("20a39a90-b376-477d-a2c2-1973cd347092") },
                    { new Guid("faa974a0-4bb3-495e-a9a5-195e8516bd44"), 3, "Model Development", 2, new Guid("88d39e7e-3952-43ef-8e15-57116d276d59") },
                    { new Guid("fe2ff4d0-732e-433b-b05d-7a985edc6fe5"), 3, "Model Development", 2, new Guid("b5c6dbc1-8e92-4667-8627-8772ffbd09d0") }
                });

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "094505b2-4be4-43c6-ac2f-53428f706d19" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "1c5c3b44-7164-4232-a49a-10ab367d5102" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "29df78da-8830-4bb3-8ece-f11cf9f5cc34" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "6ad0a020-e6a6-4e66-8f4a-d815594ba862" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "72339042-5a5d-46f1-9b24-c5446332a29c" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "75beaf54-8c16-4464-9cd5-fa272d942f43" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "85b70a16-20bb-400f-a478-78c6f8c6d067" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "89d0ed33-21e5-401e-b3b4-963ef6e6be16" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "b745d464-f213-487c-8469-1f0d10d32224" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "d4325be4-cb11-4f2f-b29e-dc52024d6c65" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "e214c150-f35c-4567-aaf0-c103d4e4d198" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "ProjectId", "UserId", "DeletedAt", "IsDeleted", "IsLeader", "IsValid", "JoinDate" },
                values: new object[,]
                {
                    { new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), "094505b2-4be4-43c6-ac2f-53428f706d19", null, false, false, true, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), "75beaf54-8c16-4464-9cd5-fa272d942f43", null, false, false, true, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), "85b70a16-20bb-400f-a478-78c6f8c6d067", null, false, false, true, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b3c2e9a-c77c-417e-a093-8d701d2b4821"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", null, false, true, true, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b3c2e9a-c77c-417e-a093-8d701d2b4821"), "72339042-5a5d-46f1-9b24-c5446332a29c", null, false, false, true, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f722609-dace-4c60-a6f3-19e015546310"), "1c5c3b44-7164-4232-a49a-10ab367d5102", null, false, false, true, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e3b54cf-8b56-4590-adca-73112fa8b9e7"), "85b70a16-20bb-400f-a478-78c6f8c6d067", null, false, false, true, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), "29df78da-8830-4bb3-8ece-f11cf9f5cc34", null, false, false, true, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", null, false, false, true, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), "e214c150-f35c-4567-aaf0-c103d4e4d198", null, false, true, true, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), "094505b2-4be4-43c6-ac2f-53428f706d19", null, false, true, true, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), "72339042-5a5d-46f1-9b24-c5446332a29c", null, false, false, true, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), "89d0ed33-21e5-401e-b3b4-963ef6e6be16", null, false, false, true, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), "e214c150-f35c-4567-aaf0-c103d4e4d198", null, false, false, true, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), "72339042-5a5d-46f1-9b24-c5446332a29c", null, false, false, true, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "NotificationAccounts",
                columns: new[] { "AccountId", "NotificationId", "IsRead" },
                values: new object[,]
                {
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), true },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), false },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), true },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), true },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), false },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), true },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), false },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), true },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), true },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), true },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), true },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), false },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), false },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), false },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), false },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), true },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), false },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), false },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), false },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("e331de18-289c-403d-8028-26c4b595587a"), true },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("e331de18-289c-403d-8028-26c4b595587a"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), false },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), false },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), false },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), false },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), true },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), false },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), true }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CreatedDate", "Description", "DeviceStatus", "FileKey", "ScheduleId" },
                values: new object[,]
                {
                    { new Guid("06a6fcd7-eb30-4728-9856-ee8d00f84810"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8694), "Designer's tablet updated with latest design apps.", "Available", null, new Guid("5b1615a6-b870-456a-a483-e99a3f9122dc") },
                    { new Guid("5e2385b4-08f6-4e9e-888b-5d94c4b7fb78"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8701), "The desktop was used for backend development tasks.", "In Use", null, new Guid("6500363e-6574-42e7-8577-6dc87a55ce15") },
                    { new Guid("697817b7-9d65-47dd-a39b-909f89e25bce"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8698), "The desktop was used for backend development tasks.", "Available", null, new Guid("5547314b-521a-47e9-ad60-5e376e686636") },
                    { new Guid("75fb870f-e344-40c9-ab85-101631f22505"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8671), "Device was used for setting up a new development environment.", "Available", null, new Guid("44efa2a7-4f64-4fc6-bbbe-869099817d4f") },
                    { new Guid("d3b039bd-813c-4b33-af98-2264dcb440c0"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8675), "The laptop was utilized for testing the latest software build.", "In Use", null, new Guid("e377b750-0b20-4943-9e5d-6909d4810f13") }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "AccountId", "DeviceId", "EndDate", "Purpose", "ScheduledDate", "StartDate" },
                values: new object[,]
                {
                    { new Guid("27f1b969-1b68-4cf8-8a51-c8be5356f7f8"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 23, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8603), "Development", new DateTime(2024, 7, 23, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8602), new DateTime(2024, 7, 23, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8602) },
                    { new Guid("37d2c7b3-7406-418d-9062-e81dfff02d9a"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), new DateTime(2024, 7, 24, 19, 9, 10, 568, DateTimeKind.Local).AddTicks(8594), "Testing", new DateTime(2024, 7, 24, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8593), new DateTime(2024, 7, 24, 18, 9, 10, 568, DateTimeKind.Local).AddTicks(8593) },
                    { new Guid("4da0b3f8-95aa-40cd-ab32-75876ca13900"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 23, 23, 9, 10, 568, DateTimeKind.Local).AddTicks(8606), "Development", new DateTime(2024, 7, 23, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8604), new DateTime(2024, 7, 23, 22, 9, 10, 568, DateTimeKind.Local).AddTicks(8605) },
                    { new Guid("4fa30f09-e82a-4375-a28f-8190a8667a09"), "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 19, 23, 9, 10, 568, DateTimeKind.Local).AddTicks(8623), "Development", new DateTime(2024, 7, 19, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8622), new DateTime(2024, 7, 19, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8622) },
                    { new Guid("5dc94e7f-845b-480b-8c81-f1d50c359491"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 22, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8611), "Development", new DateTime(2024, 7, 22, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8610), new DateTime(2024, 7, 22, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8611) },
                    { new Guid("70f625f4-33f5-4c62-9718-d3e2c420e703"), "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 22, 23, 9, 10, 568, DateTimeKind.Local).AddTicks(8614), "Development", new DateTime(2024, 7, 22, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8613), new DateTime(2024, 7, 22, 22, 9, 10, 568, DateTimeKind.Local).AddTicks(8613) },
                    { new Guid("77153502-8631-4b5f-b05d-76d4796c06d4"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 21, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8617), "Development", new DateTime(2024, 7, 21, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8616), new DateTime(2024, 7, 21, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8616) },
                    { new Guid("77790ba9-1f3c-4943-9e39-097000fc6fa2"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 18, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8626), "Development", new DateTime(2024, 7, 18, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8625), new DateTime(2024, 7, 18, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8625) },
                    { new Guid("80d34442-7c14-4060-ae8f-24cda38e63f9"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 24, 19, 9, 10, 568, DateTimeKind.Local).AddTicks(8608), "Development", new DateTime(2024, 7, 24, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8607), new DateTime(2024, 7, 24, 18, 9, 10, 568, DateTimeKind.Local).AddTicks(8608) },
                    { new Guid("8bb44d07-f470-4434-a023-6bdffb4311cc"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 20, 23, 9, 10, 568, DateTimeKind.Local).AddTicks(8620), "Development", new DateTime(2024, 7, 20, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8619), new DateTime(2024, 7, 20, 22, 9, 10, 568, DateTimeKind.Local).AddTicks(8619) },
                    { new Guid("9bfeb5df-03a4-4ae5-904e-1779c19a5313"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("a1d65f8a-f7fd-4995-940f-6ab254523f90"), new DateTime(2024, 7, 24, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8640), "Development", new DateTime(2024, 7, 24, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8639), new DateTime(2024, 7, 24, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8639) },
                    { new Guid("db1fcaa0-e934-4429-a567-2ac802d0b453"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), new DateTime(2024, 7, 24, 23, 9, 10, 568, DateTimeKind.Local).AddTicks(8600), "Testing", new DateTime(2024, 7, 24, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8599), new DateTime(2024, 7, 24, 22, 9, 10, 568, DateTimeKind.Local).AddTicks(8599) },
                    { new Guid("e0fa81b1-9eea-4b4b-93a7-b7a34aae4014"), "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), new DateTime(2024, 7, 24, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8597), "Development", new DateTime(2024, 7, 24, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8596), new DateTime(2024, 7, 24, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8596) },
                    { new Guid("eb607a7a-2572-4a16-bbbd-99f3db25d40b"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("0a395b72-ae0d-4a49-b7f8-1763de733068"), new DateTime(2024, 7, 25, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8634), "Development", new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8633), new DateTime(2024, 7, 25, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8634) },
                    { new Guid("ff18bb51-3c4e-4fcb-a73e-39f60996be8c"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("b4dc2d48-482a-48a2-bad6-7a1e0e3139b7"), new DateTime(2024, 7, 24, 21, 9, 10, 568, DateTimeKind.Local).AddTicks(8632), "Development", new DateTime(2024, 7, 24, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8631), new DateTime(2024, 7, 24, 20, 9, 10, 568, DateTimeKind.Local).AddTicks(8631) }
                });

            migrationBuilder.InsertData(
                table: "StudentDetails",
                columns: new[] { "AccountId", "Major", "RollNumber", "Specialized" },
                values: new object[,]
                {
                    { "094505b2-4be4-43c6-ac2f-53428f706d19", "Iot", "HE153098", "Java" },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", "Software Engineering", "HE156894", "PHP" },
                    { "29df78da-8830-4bb3-8ece-f11cf9f5cc34", "SE", "HE150032", "C#" },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "Iot", "HE145689", "Python" },
                    { "72339042-5a5d-46f1-9b24-c5446332a29c", "Iot", "HE150210", "Java" },
                    { "75beaf54-8c16-4464-9cd5-fa272d942f43", "SE", "HE150263", "Java" },
                    { "85b70a16-20bb-400f-a478-78c6f8c6d067", "AI", "HE150555", "Python" },
                    { "89d0ed33-21e5-401e-b3b4-963ef6e6be16", "IA", "HE150253", "Java" },
                    { "b745d464-f213-487c-8469-1f0d10d32224", "Software Engineering", "HE156844", "PHP" },
                    { "d4325be4-cb11-4f2f-b29e-dc52024d6c65", "Software Engineering", "HE156824", "PHP" },
                    { "e214c150-f35c-4567-aaf0-c103d4e4d198", "AI", "HE150190", "Python" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssignedTo", "CreatedBy", "CreatedDate", "Description", "DueDate", "Order", "ProjectId", "RequiresValidation", "StartDate", "TaskListId", "TaskPriority", "TaskStatus", "Title" },
                values: new object[,]
                {
                    { new Guid("07adf7cb-121c-4b3d-abb4-2861c9468ae4"), "a687bb04-4f19-49d5-a60f-2db52044767c", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deploy the LIMS system to production", new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("c70f946f-c591-4794-b053-174765ae386d"), true, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e86a5ffe-7b06-4f06-94a4-698cb58161db"), "Low", "Open/To do", "Deploy System" },
                    { new Guid("0928cce1-121b-4b27-b233-58f8d7a97810"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Design experiments to test quantum algorithms", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"), true, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3a339b14-8f9e-413d-97d0-7ce36aafee58"), "High", "Open/To do", "Design Experiment" },
                    { new Guid("0fb94e6e-024e-4fd3-bd24-8dc60f0acaaf"), "72339042-5a5d-46f1-9b24-c5446332a29c", "094505b2-4be4-43c6-ac2f-53428f706d19", new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create a report based on the analyzed temperature data", new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), true, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a37790d5-0113-491b-98af-5060ff8aa26c"), "Medium", "Open/To do", "Generate Temperature Report" },
                    { new Guid("16a3be27-df3c-4e7a-9b6c-97c81eceadf0"), "e214c150-f35c-4567-aaf0-c103d4e4d198", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Integrate APIs for health data", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), true, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("431dd63b-469e-4589-b1c6-4b4af20a7728"), "High", "Open/To do", "Integrate Health APIs" },
                    { new Guid("189651cf-51fe-4a9a-aa2d-c70430234f44"), "603600b5-ca65-4fa7-817e-4583ef22b330", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implement the core functionality of Module B", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c70f946f-c591-4794-b053-174765ae386d"), true, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("94420810-4a35-4f33-a7df-6078ab4efb1c"), "Low", "Open/To do", "Develop Module B" },
                    { new Guid("1cebf167-3bb2-4462-a60b-409e4f6ccb8b"), "603600b5-ca65-4fa7-817e-4583ef22b330", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop different scenarios for VR occupational therapy", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), true, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a88a1f4e-d3dd-42f0-a0e7-3a7f6affa301"), "Medium", "Open/To do", "Develop VR Scenarios" },
                    { new Guid("1f412d44-c3fc-4f4a-bf22-e0ed210d2c2a"), "29df78da-8830-4bb3-8ece-f11cf9f5cc34", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create UI mockups for the app", new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), false, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5618a016-156a-449c-92e6-926eabe0cf8a"), "Medium", "Open/To do", "Design UI Mockups" },
                    { new Guid("1fd2a91e-f6db-449d-a533-99d88b0642e8"), "a687bb04-4f19-49d5-a60f-2db52044767c", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the performance of the VR application under different conditions", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), true, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8de05be7-f7d1-425e-9c5e-b1a965456935"), "Medium", "Open/To do", "Evaluate Performance" },
                    { new Guid("20717fc1-7cc5-40d7-841a-1cce5a9d0026"), "72339042-5a5d-46f1-9b24-c5446332a29c", "7397c854-194b-4749-9205-f46e4f2fccf8", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monitor model performance in production", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"), "Medium", "Open/To do", "Monitor Performance" },
                    { new Guid("21fb7139-1def-43d9-bc25-87d84ad9c141"), "603600b5-ca65-4fa7-817e-4583ef22b330", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop the initial image recognition model", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), true, new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b351e4b2-8b16-4c0c-b37b-630bcf661e4b"), "Critical", "Open/To do", "Model Development" },
                    { new Guid("232e6e66-8b24-4305-be80-fbe67d333f19"), "603600b5-ca65-4fa7-817e-4583ef22b330", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gather patient data for AI training", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), true, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5b24898d-dddc-4c99-8c69-5e43a370e45c"), "High", "Open/To do", "Collect Patient Data" },
                    { new Guid("237219d8-c04a-4ab1-bda7-045fe94b6d9c"), "72339042-5a5d-46f1-9b24-c5446332a29c", "7397c854-194b-4749-9205-f46e4f2fccf8", new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Optimize the model for faster inference and better accuracy", new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), true, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"), "Critical", "Open/To do", "Optimize Model" },
                    { new Guid("24d65a98-4aa0-421e-b7f8-702034653159"), "1c5c3b44-7164-4232-a49a-10ab367d5102", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Document all aspects of the VR application development", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), false, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c81e116-5120-4920-bf51-092081bfc67d"), "High", "Open/To do", "Prepare Documentation" },
                    { new Guid("25f640e0-7ec0-4862-a6b0-2f7ad7aae367"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incorporate peer review comments and finalize the paper", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"), true, new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"), "Low", "Open/To do", "Finalize Paper" },
                    { new Guid("269527d0-fadf-43f5-a74a-4c8e96ed3535"), "a687bb04-4f19-49d5-a60f-2db52044767c", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enhance the user experience based on feedback from user testing", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), true, new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95be764c-437f-42c8-bd26-bf0aff147218"), "Low", "Open/To do", "Improve User Experience" },
                    { new Guid("26b877a8-7541-4350-8831-10a7d6781988"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carry out designed experiments on quantum computing", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"), true, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3a339b14-8f9e-413d-97d0-7ce36aafee58"), "Medium", "Open/To do", "Conduct Experiments" },
                    { new Guid("28617a26-3ef4-45ac-9f9d-32ec74edc723"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Execute integration tests for the LIMS system", new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c70f946f-c591-4794-b053-174765ae386d"), true, new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("816ebcd1-124d-4b5c-810e-b0e8aeedb501"), "Medium", "Open/To do", "Perform Integration Testing" },
                    { new Guid("2bd36dd9-187a-4396-a8ac-586b9aa3e7ba"), "e214c150-f35c-4567-aaf0-c103d4e4d198", "094505b2-4be4-43c6-ac2f-53428f706d19", new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyze the collected temperature data for patterns", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), true, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("455d5a96-2d52-4aa8-a98f-ac27f4f321c3"), "Low", "Open/To do", "Analyze Temperature Data" },
                    { new Guid("2dea5f06-9385-46a8-97ec-577eebe2e93b"), "a687bb04-4f19-49d5-a60f-2db52044767c", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gather all requirements for LIMS", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("c70f946f-c591-4794-b053-174765ae386d"), true, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0bb2e364-d05d-4128-b24d-0f69725b85f3"), "High", "Open/To do", "Gather Requirements" },
                    { new Guid("3c676df2-bb57-4408-9c99-ae04242599c7"), "094505b2-4be4-43c6-ac2f-53428f706d19", "603600b5-ca65-4fa7-817e-4583ef22b330", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deploy the AI model to the healthcare system", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), true, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ac829962-0360-44d2-a766-bb50e3e2001e"), "High", "Open/To do", "Deploy AI Model" },
                    { new Guid("3f57d84d-ab4b-4264-a099-b4b55440df0f"), "75beaf54-8c16-4464-9cd5-fa272d942f43", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the performance of the trained AI model", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), false, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4c238c20-5106-4ca5-88a7-9980892a5455"), "Medium", "Open/To do", "Evaluate Model Performance" },
                    { new Guid("41281716-6715-44f7-a7f6-0382c12fb7a2"), "72339042-5a5d-46f1-9b24-c5446332a29c", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Train the image recognition model with collected data", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0008056c-1d86-45f8-ae4e-b0512284472d"), "High", "Open/To do", "Training Model" },
                    { new Guid("43d107bc-fa1c-4afc-98bd-0007d5aa7020"), "72339042-5a5d-46f1-9b24-c5446332a29c", "c4a15b23-9d00-4ec5-acc9-493354e91973", new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gather air quality data using the installed sensors", new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), true, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24d9bd4f-d960-4081-87a8-6be032290863"), "Low", "Open/To do", "Collect Air Quality Data" },
                    { new Guid("493280b5-0346-4895-a6e2-72d2da4741ef"), "603600b5-ca65-4fa7-817e-4583ef22b330", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create a prototype VR application for patient therapy", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), true, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a88a1f4e-d3dd-42f0-a0e7-3a7f6affa301"), "Medium", "Open/To do", "Develop Prototype" },
                    { new Guid("4dad49ff-a7a0-4c8a-950a-8d713a0c8932"), "603600b5-ca65-4fa7-817e-4583ef22b330", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare a final report on the AI in Healthcare project", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), true, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ac829962-0360-44d2-a766-bb50e3e2001e"), "Medium", "Open/To do", "Prepare Final Report" },
                    { new Guid("4e0910eb-4502-48c3-92ad-1aa03a9cc12e"), "7397c854-194b-4749-9205-f46e4f2fccf8", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create a plan for collecting data for image recognition", new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), true, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f54b6b6-614e-46d2-a64e-10d91db2f516"), "High", "Open/To do", "Data Collection Plan" },
                    { new Guid("506e2185-63ba-4e89-aea0-0fe048987c54"), "a687bb04-4f19-49d5-a60f-2db52044767c", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Research on current VR applications in occupational therapy", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), false, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c81e116-5120-4920-bf51-092081bfc67d"), "High", "Open/To do", "Conduct Initial Research" },
                    { new Guid("55115cac-f39b-44a1-941e-b33c91b8632a"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Submit the paper to a journal for peer review", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"), true, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"), "Low", "Open/To do", "Submit Paper for Peer Review" },
                    { new Guid("574b0b77-1a4c-4f91-8cb3-d3f9fd943dd0"), "a687bb04-4f19-49d5-a60f-2db52044767c", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interview potential users to gather requirements and feedback", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), true, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8de05be7-f7d1-425e-9c5e-b1a965456935"), "Medium", "Open/To do", "Conduct User Interviews" },
                    { new Guid("5f6c7526-71da-4ff0-95ee-cfbc56d5fc03"), "e214c150-f35c-4567-aaf0-c103d4e4d198", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare a detailed deployment plan", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), false, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("75f606e3-f12a-4257-b486-a15ef2aad23b"), "Medium", "Open/To do", "Prepare Deployment Plan" },
                    { new Guid("6288fba6-d072-4d9f-ac30-e9b4e43893dc"), "603600b5-ca65-4fa7-817e-4583ef22b330", "7397c854-194b-4749-9205-f46e4f2fccf8", new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Document the model architecture and usage", new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), true, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"), "Critical", "Open/To do", "Documentation" },
                    { new Guid("694be8c9-2b1e-4747-8ca0-d724befb9fba"), "603600b5-ca65-4fa7-817e-4583ef22b330", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Continuously fine-tune the model based on feedback", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), true, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"), "High", "Open/To do", "Fine-tune Model" },
                    { new Guid("6d042aa6-a33f-416c-b058-5e5f0d75c720"), "85b70a16-20bb-400f-a478-78c6f8c6d067", "603600b5-ca65-4fa7-817e-4583ef22b330", new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monitor the performance of the deployed AI model", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), false, new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ac829962-0360-44d2-a766-bb50e3e2001e"), "Medium", "Open/To do", "Monitor AI Model" },
                    { new Guid("6f58ce78-70e0-4d37-bbcf-03681223355c"), "72339042-5a5d-46f1-9b24-c5446332a29c", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Address any comments or suggestions from peer reviewers", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"), true, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"), "Medium", "Open/To do", "Address Peer Review Comments" },
                    { new Guid("75fa3124-b700-417b-a58b-0ff98a970cba"), "89d0ed33-21e5-401e-b3b4-963ef6e6be16", "c4a15b23-9d00-4ec5-acc9-493354e91973", new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyze water quality data for contamination", new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), true, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("455d5a96-2d52-4aa8-a98f-ac27f4f321c3"), "Medium", "Open/To do", "Evaluate Water Quality Data" },
                    { new Guid("79da03b6-24be-4a6a-98b5-eadcaf5a8ed3"), "72339042-5a5d-46f1-9b24-c5446332a29c", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyze the data collected from experiments", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"), true, new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("67a4dd09-f119-4c82-921e-597279ef412d"), "Low", "Open/To do", "Analyze Data" },
                    { new Guid("7f580704-62d1-416e-ac93-d27920ac89b5"), "7397c854-194b-4749-9205-f46e4f2fccf8", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implement the core functionality of Module A", new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("c70f946f-c591-4794-b053-174765ae386d"), true, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("94420810-4a35-4f33-a7df-6078ab4efb1c"), "Low", "Open/To do", "Develop Module A" },
                    { new Guid("8030fade-0f45-4971-8c38-0d4b329e1f95"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implement the user authentication module", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), true, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("431dd63b-469e-4589-b1c6-4b4af20a7728"), "Critical", "Open/To do", "Develop Authentication Module" },
                    { new Guid("81f1530e-bce0-45c9-b4af-b0393009fc56"), "7397c854-194b-4749-9205-f46e4f2fccf8", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test the trained model for accuracy and performance", new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), false, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"), "Medium", "Open/To do", "Model Testing" },
                    { new Guid("82bfec66-7d0c-4cbb-bf2d-77fc147aaf09"), "e214c150-f35c-4567-aaf0-c103d4e4d198", "c4a15b23-9d00-4ec5-acc9-493354e91973", new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monitor the quality of water using IoT sensors", new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), true, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24d9bd4f-d960-4081-87a8-6be032290863"), "Medium", "Open/To do", "Monitor Water Quality" },
                    { new Guid("873b1348-3fae-4d43-bd10-f8944e356eb0"), "094505b2-4be4-43c6-ac2f-53428f706d19", "c4a15b23-9d00-4ec5-acc9-493354e91973", new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare a detailed report on the air quality findings", new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), false, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a37790d5-0113-491b-98af-5060ff8aa26c"), "High", "Open/To do", "Prepare Air Quality Report" },
                    { new Guid("878cdd73-e80a-4a89-9348-b125867b3ee0"), "72339042-5a5d-46f1-9b24-c5446332a29c", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Publish the final paper in a scientific journal", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"), true, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"), "High", "Open/To do", "Publish Paper" },
                    { new Guid("8bf983d2-bf13-40ad-a46c-5cc0eb63519f"), "a687bb04-4f19-49d5-a60f-2db52044767c", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop unit tests for Module A", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("c70f946f-c591-4794-b053-174765ae386d"), true, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("94420810-4a35-4f33-a7df-6078ab4efb1c"), "Medium", "Open/To do", "Create Unit Tests" },
                    { new Guid("8e62b119-e3df-44ae-a432-119ca8384db5"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deploy the app to the production environment", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), true, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("75f606e3-f12a-4257-b486-a15ef2aad23b"), "Critical", "Open/To do", "Deploy to Production" },
                    { new Guid("98905a8d-8ca0-4eb5-a6ab-27df729e2d8e"), "a687bb04-4f19-49d5-a60f-2db52044767c", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create a detailed design of the system architecture", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("c70f946f-c591-4794-b053-174765ae386d"), true, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8866bcb2-198a-4fcd-b0c0-8090444b8722"), "High", "Open/To do", "Design System Architecture" },
                    { new Guid("9a07a1b4-7093-4048-80d8-49cb69eccea7"), "e214c150-f35c-4567-aaf0-c103d4e4d198", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collect requirements from stakeholders", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), true, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("41640d60-1134-45c3-a7c4-2e7f306ec967"), "High", "Open/To do", "Gather Requirements" },
                    { new Guid("9eb5bb05-946f-4e93-80aa-0593c06e1d7b"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review existing literature on quantum computing", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"), false, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("84f2c617-35e0-4343-a7c8-35226cb4c6a1"), "Medium", "Open/To do", "Conduct Literature Review" },
                    { new Guid("a00f5027-9268-4393-813c-a63db0c2a8a8"), "094505b2-4be4-43c6-ac2f-53428f706d19", "c4a15b23-9d00-4ec5-acc9-493354e91973", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install sensors for monitoring temperature", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), true, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c07b395a-cbf6-49a4-aeaa-ef28de9517ff"), "Medium", "Open/To do", "Install Temperature Sensors" },
                    { new Guid("a1ee2254-c6fd-47be-9e85-05eef2d3c8b7"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop the database schema for the LIMS system", new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c70f946f-c591-4794-b053-174765ae386d"), true, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8866bcb2-198a-4fcd-b0c0-8090444b8722"), "Medium", "Open/To do", "Create Database Schema" },
                    { new Guid("a551a73d-46d3-4c95-8c72-d17991580b74"), "603600b5-ca65-4fa7-817e-4583ef22b330", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyze user needs for the LIMS system", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c70f946f-c591-4794-b053-174765ae386d"), true, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0bb2e364-d05d-4128-b24d-0f69725b85f3"), "Medium", "Open/To do", "Analyze User Needs" },
                    { new Guid("a61919da-1b18-4430-bac7-044a119cc94a"), "29df78da-8830-4bb3-8ece-f11cf9f5cc34", "e214c150-f35c-4567-aaf0-c103d4e4d198", new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conduct beta testing with selected users", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), true, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("60ac6a0a-2788-4326-ad31-fdd899d7b80f"), "High", "Open/To do", "Conduct Beta Testing" },
                    { new Guid("a70e55b4-5935-4498-9411-4f1a22101f11"), "094505b2-4be4-43c6-ac2f-53428f706d19", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Process and prepare the data for AI model training", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), false, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5b24898d-dddc-4c99-8c69-5e43a370e45c"), "Medium", "Open/To do", "Prepare Training Data" },
                    { new Guid("a87c0c26-a8ba-4edb-81dc-7346ac7a0468"), "1c5c3b44-7164-4232-a49a-10ab367d5102", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test the prototype with patients and collect feedback", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), true, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8de05be7-f7d1-425e-9c5e-b1a965456935"), "Medium", "Open/To do", "Conduct User Testing" },
                    { new Guid("ae1d316a-2ced-4cd4-8ca9-2d1977b85e11"), "603600b5-ca65-4fa7-817e-4583ef22b330", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collect feedback from healthcare providers using the AI model", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), true, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ac829962-0360-44d2-a766-bb50e3e2001e"), "Low", "Open/To do", "Collect Feedback" },
                    { new Guid("b2af7872-5bf8-4d3b-b109-d0755da498b7"), "29df78da-8830-4bb3-8ece-f11cf9f5cc34", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provide support and monitor the app post-deployment", new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), true, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("75f606e3-f12a-4257-b486-a15ef2aad23b"), "High", "Open/To do", "Post-Deployment Support" },
                    { new Guid("b746a240-2e8e-41cd-9f80-2dd239374dea"), "1c5c3b44-7164-4232-a49a-10ab367d5102", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incorporate feedback and finalize the VR application development", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), true, new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95be764c-437f-42c8-bd26-bf0aff147218"), "Low", "Open/To do", "Finalize Development" },
                    { new Guid("bb59aa7a-9ede-40f2-a1f7-2b38a7ac0aa1"), "603600b5-ca65-4fa7-817e-4583ef22b330", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create user interface designs for the VR application", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), false, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c81e116-5120-4920-bf51-092081bfc67d"), "Medium", "Open/To do", "Design User Interface" },
                    { new Guid("bc34f494-9389-4f72-9649-5e1d6204e663"), "89d0ed33-21e5-401e-b3b4-963ef6e6be16", "094505b2-4be4-43c6-ac2f-53428f706d19", new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the air quality data to assess pollution levels", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), false, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("455d5a96-2d52-4aa8-a98f-ac27f4f321c3"), "High", "Open/To do", "Evaluate Air Quality Data" },
                    { new Guid("c1fa15bb-68e3-4db7-b161-5e619643ccf9"), "094505b2-4be4-43c6-ac2f-53428f706d19", "603600b5-ca65-4fa7-817e-4583ef22b330", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop the AI model for healthcare predictions", new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f5840e34-49e8-435f-bbb4-e403c53642b1"), "Low", "Open/To do", "Develop AI Model" },
                    { new Guid("c5721f73-535e-4f68-835a-b0267631f127"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Preprocess collected data for training", new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), false, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f54b6b6-614e-46d2-a64e-10d91db2f516"), "Medium", "Open/To do", "Preprocessing Data" },
                    { new Guid("ddb21729-1887-4e7a-940b-feea633ee41a"), "89d0ed33-21e5-401e-b3b4-963ef6e6be16", "c4a15b23-9d00-4ec5-acc9-493354e91973", new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calibrate the installed sensors for accurate readings", new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), false, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c07b395a-cbf6-49a4-aeaa-ef28de9517ff"), "High", "Open/To do", "Calibrate Sensors" },
                    { new Guid("de14cdcf-436c-4642-9b03-6228b5fa87bb"), "1c5c3b44-7164-4232-a49a-10ab367d5102", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensure the VR application integrates smoothly with existing systems", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("2f722609-dace-4c60-a6f3-19e015546310"), true, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a88a1f4e-d3dd-42f0-a0e7-3a7f6affa301"), "Medium", "Open/To do", "Integration with Existing Systems" },
                    { new Guid("de6d1c54-6561-4433-bb1a-1013174a4937"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review the initial draft and make necessary corrections", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"), true, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"), "Medium", "Open/To do", "Review Draft" },
                    { new Guid("e0d133a7-f4e4-46b5-a38e-228964ae0a2c"), "85b70a16-20bb-400f-a478-78c6f8c6d067", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Train the AI model using the prepared data", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), true, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f5840e34-49e8-435f-bbb4-e403c53642b1"), "High", "Open/To do", "Train AI Model" },
                    { new Guid("e2f7147d-ac48-4b1f-9dee-3bb590063de4"), "72339042-5a5d-46f1-9b24-c5446332a29c", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Write the initial draft of the research paper", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("99d3dfb7-8a58-4bc6-bf43-39257ec2a472"), false, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103337e3-a98d-4427-8a4c-ac8563886b47"), "High", "Open/To do", "Draft Research Paper" },
                    { new Guid("e5b86e5d-972b-4248-b5aa-1b0e7367698e"), "85b70a16-20bb-400f-a478-78c6f8c6d067", "603600b5-ca65-4fa7-817e-4583ef22b330", new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refine the AI model based on evaluation results", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("10fee09a-22f0-4e5e-96b3-62417249ee42"), true, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4c238c20-5106-4ca5-88a7-9980892a5455"), "Low", "Open/To do", "Refine Model" },
                    { new Guid("f384d62d-bf83-41b6-aff1-7c6c752f4007"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "e214c150-f35c-4567-aaf0-c103d4e4d198", new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fix bugs identified during testing", new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), true, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("60ac6a0a-2788-4326-ad31-fdd899d7b80f"), "Critical", "Open/To do", "Fix Identified Bugs" },
                    { new Guid("f3e477a0-283a-41a3-9895-7b68d59c0d1f"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", "7397c854-194b-4749-9205-f46e4f2fccf8", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deploy the trained model into a production environment", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("f671377a-4c92-444a-ac7c-065c9fd0962f"), true, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05c5e7b3-63ac-482e-82fc-00bfb32afeca"), "High", "Open/To do", "Deploy Model" },
                    { new Guid("f873907a-20a5-4360-a60d-1decda1ccba6"), "7397c854-194b-4749-9205-f46e4f2fccf8", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Execute system tests for the LIMS system", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("c70f946f-c591-4794-b053-174765ae386d"), true, new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("816ebcd1-124d-4b5c-810e-b0e8aeedb501"), "Medium", "Open/To do", "Perform System Testing" },
                    { new Guid("faa1404e-f423-4e45-9678-fbf1dbe03114"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "f64cc4f0-ada8-4b0b-86c7-d28b29bc4832", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform unit testing on developed modules", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("52dd6c08-8b05-43b3-96a6-fc1c654011a1"), false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("60ac6a0a-2788-4326-ad31-fdd899d7b80f"), "Medium", "Open/To do", "Unit Testing" },
                    { new Guid("fb6f1125-7ce8-4977-a06a-047c906d29bc"), "094505b2-4be4-43c6-ac2f-53428f706d19", "c4a15b23-9d00-4ec5-acc9-493354e91973", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compile all findings into a comprehensive final report", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("e02093b0-3a46-4b6f-87e0-5c7a5be650fe"), true, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a37790d5-0113-491b-98af-5060ff8aa26c"), "Low", "Open/To do", "Compile Final Report" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CreatedDate", "Description", "DeviceStatus", "FileKey", "ScheduleId" },
                values: new object[,]
                {
                    { new Guid("0e287e15-6c9f-44ab-9fb3-dc183f5e5e92"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8686), "Network switch configuration updated.", "Available", null, new Guid("5dc94e7f-845b-480b-8c81-f1d50c359491") },
                    { new Guid("19f6bcc1-2a8d-4c5d-ab3b-d5d3b21da159"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8697), "Network switch maintenance and inspection.", "In Use", null, new Guid("eb607a7a-2572-4a16-bbbd-99f3db25d40b") },
                    { new Guid("285ce1fd-470c-4474-ad1b-ba273c0e8653"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8681), "Printer serviced and toner replaced.", "Available", null, new Guid("27f1b969-1b68-4cf8-8a51-c8be5356f7f8") },
                    { new Guid("426c57ce-68aa-498b-b603-16cf1e7a238d"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8679), "Monitor calibrated for color accuracy.", "Available", null, new Guid("db1fcaa0-e934-4429-a567-2ac802d0b453") },
                    { new Guid("5faf118e-4687-47c2-9b83-ecb389b8b6d5"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8690), "Router settings optimized for network traffic.", "Available", null, new Guid("8bb44d07-f470-4434-a023-6bdffb4311cc") },
                    { new Guid("76199946-58bd-473a-95a7-9da8afcb9fc7"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8691), "Desktop setup for new project development.", "Available", null, new Guid("4fa30f09-e82a-4375-a28f-8190a8667a09") },
                    { new Guid("78d4e5bd-d685-49b5-8b12-e71df921ec65"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8687), "Server performance was monitored during load testing.", "Available", null, new Guid("70f625f4-33f5-4c62-9718-d3e2c420e703") },
                    { new Guid("8455c9b0-c2ca-4de4-bdee-3070dc8af954"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8678), "The desktop was used for backend development tasks.", "Available", null, new Guid("e0fa81b1-9eea-4b4b-93a7-b7a34aae4014") },
                    { new Guid("b774e795-3469-4b58-afe0-5f6e9e0a6aec"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8699), "The desktop was used for backend development tasks.", "In Use", null, new Guid("9bfeb5df-03a4-4ae5-904e-1779c19a5313") },
                    { new Guid("b9d04c5f-2ec0-4da1-92ab-7ef9bdcd82e4"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8688), "Developer's laptop used for bug fixing.", "In Use", null, new Guid("77153502-8631-4b5f-b05d-76d4796c06d4") },
                    { new Guid("c8fb056c-cff8-4db2-b951-01859431a35e"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8677), "Router firmware was updated and tested.", "Available", null, new Guid("37d2c7b3-7406-418d-9062-e81dfff02d9a") },
                    { new Guid("cf4dfffd-74e9-46dd-b9b5-2a9d09001564"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8695), "Projector used for team meeting presentations.", "Available", null, new Guid("ff18bb51-3c4e-4fcb-a73e-39f60996be8c") },
                    { new Guid("dd8ac1ac-0f4f-45af-825e-e74e531b66dc"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8682), "Tablet used for sketching new UI designs.", "Available", null, new Guid("4da0b3f8-95aa-40cd-ab32-75876ca13900") },
                    { new Guid("e4880a12-6d1d-4e9b-8832-89c5982b1346"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8693), "High-resolution monitor tested with graphic design software.", "In Use", null, new Guid("77790ba9-1f3c-4943-9e39-097000fc6fa2") },
                    { new Guid("f1dcaea6-1670-47d7-b8cb-398b89ca09d0"), new DateTime(2024, 7, 25, 17, 9, 10, 568, DateTimeKind.Local).AddTicks(8684), "Projector used in a client presentation.", "Available", null, new Guid("80d34442-7c14-4060-ae8f-24cda38e63f9") }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Account",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Account_VerifiedBy",
                table: "Account",
                column: "VerifiedBy");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Account",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AccountClaims_UserId",
                table: "AccountClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLogins_UserId",
                table: "AccountLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_RoleId",
                table: "AccountRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedBy",
                table: "Comments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskId",
                table: "Comments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_OwnedBy",
                table: "Devices",
                column: "OwnedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FolderId",
                table: "Files",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_CreatedBy",
                table: "Folders",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ProjectId",
                table: "Folders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FoldersClosure_Descendant",
                table: "FoldersClosure",
                column: "Descendant");

            migrationBuilder.CreateIndex(
                name: "IX_Image_DeviceId",
                table: "Image",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                table: "Members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_CreatedBy",
                table: "News",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFiles_NewsId",
                table: "NewsFiles",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationAccounts_AccountId",
                table: "NotificationAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedBy",
                table: "Notifications",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ProjectId",
                table: "Notifications",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ScheduleId",
                table: "Reports",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_AccountId",
                table: "Schedules",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DeviceId",
                table: "Schedules",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "SystemRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaskClosure_Descendant",
                table: "TaskClosure",
                column: "Descendant");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_AssignedTo",
                table: "TaskHistories",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_TaskGuid",
                table: "TaskHistories",
                column: "TaskGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_TasksId",
                table: "TaskHistories",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistoriesLabels_LabelId",
                table: "TaskHistoriesLabels",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLists_ProjectId",
                table: "TaskLists",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedTo",
                table: "Tasks",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskListId",
                table: "Tasks",
                column: "TaskListId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksAccounts_AccountId",
                table: "TasksAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksFiles_FileId",
                table: "TasksFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksLabels_LabelId",
                table: "TasksLabels",
                column: "LabelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountClaims");

            migrationBuilder.DropTable(
                name: "AccountLogins");

            migrationBuilder.DropTable(
                name: "AccountRoles");

            migrationBuilder.DropTable(
                name: "AccountToken");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FoldersClosure");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "NewsFiles");

            migrationBuilder.DropTable(
                name: "NotificationAccounts");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "StudentDetails");

            migrationBuilder.DropTable(
                name: "TaskClosure");

            migrationBuilder.DropTable(
                name: "TaskHistoriesLabels");

            migrationBuilder.DropTable(
                name: "TasksAccounts");

            migrationBuilder.DropTable(
                name: "TasksFiles");

            migrationBuilder.DropTable(
                name: "TasksLabels");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "SystemRole");

            migrationBuilder.DropTable(
                name: "TaskHistories");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "TaskLists");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectTypes");
        }
    }
}
