using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS_BACKEND_MAIN.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
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
                name: "DeviceStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceStatuses", x => x.Id);
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
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
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
                name: "TaskPriorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.Id);
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
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Accounts",
                        column: x => x.CreatedBy,
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
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
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
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceStatusId = table.Column<int>(type: "int", nullable: false),
                    OwnedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Devices_DeviceStatuses",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatuses",
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
                    Url = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Notifications_NotificationTypes",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
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
                    ProjectStatusId = table.Column<int>(type: "int", nullable: false),
                    MaxMember = table.Column<int>(type: "int", nullable: false),
                    IsRecruiting = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectStatuses",
                        column: x => x.ProjectStatusId,
                        principalTable: "ProjectStatuses",
                        principalColumn: "Id");
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
                name: "NewsFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
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
                name: "Members",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsLeader = table.Column<bool>(type: "bit", nullable: false)
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
                name: "TaskLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxTasks = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    DeviceStatusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiresValidation = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskPriorityId = table.Column<int>(type: "int", nullable: false),
                    TaskListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskStatusId = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Tasks_TaskPrioties",
                        column: x => x.TaskPriorityId,
                        principalTable: "TaskPriorities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_TaskStatus",
                        column: x => x.TaskStatusId,
                        principalTable: "TaskStatus",
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
                    TaskPriorityId = table.Column<int>(type: "int", nullable: false),
                    TaskStatusId = table.Column<int>(type: "int", nullable: false),
                    AssignedToUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TasksId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskHistories_Account_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskHistories_TaskPrioties",
                        column: x => x.TaskPriorityId,
                        principalTable: "TaskPriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskHistories_TaskStatus",
                        column: x => x.TaskStatusId,
                        principalTable: "TaskStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", 0, "aec29a5d-ea27-4c3c-a33b-1ee476f26dfa", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(4982), "gakkou123@gmail.com", true, null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4982), "Gakkou Atarashi", false, false, false, true, false, null, "GAKKOU123@GMAIL.COM", "GAKKOU", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965795220", true, "edfc9dd9-54f4-4681-b18c-55051a9751db", false, "gakkou", null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4983), null },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", 0, "43af0b47-6b84-4309-a7d7-9aec61abf76c", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(4934), "cuongndhe163098@fpt.edu.vn", true, null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4935), "Nguyen Duc Cuong", true, false, false, true, false, null, "CUONGNDHE163098@FPT.EDU.VN", "CUONGNDHE163098", "AQAAAAIAAYagAAAAENVZ95qV36S0GH4gzip/nSmI9JKDA1CAGuL2+t1ysccrtPgGLrSZ6k9v/tS37ojoSw==", "0975465220", true, "b6a02f5c-8e62-4d67-b5cf-a86c34e7f608", false, "cuongndhe163098", null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4936), null },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", 0, "99471613-7989-4be3-959a-38b097e3e9b3", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(4945), "hoangnmhe163884@fpt.edu.vn", true, null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4946), null, false, false, false, true, false, null, "HOANGNMHE163884@FPT.EDU.VN", "HOANGNMHE163884", "AQAAAAIAAYagAAAAEBSeWGYcWJzo0jTXDBqXgYkMmzdQCRKsLrFMaaqieAdCHchkvB2oa1eRy3gsuvWyVw==", "0975765220", true, "1e24e97c-7357-40cd-b397-c2f62b572e41", false, "hoangnmhe163884", null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4946), null },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", 0, "1de0eb0a-9aed-412e-847c-220c9950d47c", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(4970), "kenshiyonezu123@gmail.com", true, null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4971), "Kenshi Yonezu", true, false, false, true, false, null, "KENSHIYONEZU123@GMAIL.COM", "KENSHIYONEZU", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965765120", true, "70e3ba29-e3ad-42e0-b186-c32f15d5d614", false, "kenshiyonezu", null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4972), null },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", 0, "d528fdf6-8728-4b64-9fdb-c55f188e2edc", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(4905), "thailshe160614@fpt.edu.vn", true, null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4906), "Le Sy Thai", true, false, false, true, false, null, "THAILSHE160614@FPT.EDU.VN", "THAILSHE160614", "AQAAAAIAAYagAAAAEO5SGANyOkCieJN+MspCJeIbBLjDruXYD5omO5+7u9NVKctIo979jEts1uoDaalzTw==", "0497461220", true, "276abb99-4f80-4a50-bc06-fc268829339b", false, "thailshe160614", null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4907), null },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", 0, "ea3b402a-29b4-4187-ae39-bddccffee4b9", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(4956), "littlejohn123@gmail.com", true, null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4957), "John", true, false, false, true, false, null, "LITTLEJOHN123@GMAIL.COM", "LITTLEJOHN", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965765228", true, "c4ce07f0-6893-4749-b3f6-f6b4dd380017", false, "littlejohn", null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4958), null },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", 0, "a0b6831e-4283-4e98-b062-91642f25548d", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(4874), "minhtche161354@fpt.edu.vn", true, null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4885), "Tran Cong Minh", false, false, false, true, false, null, "MINHTCHE161354@FPT.EDU.VN", "MINHTCHE161354", "AQAAAAIAAYagAAAAELgUn5wJH9empSyZm7MdUy84spVESi+LvNCV8nDY9PMgoY0fOBYhfZO/MPZHjSZimA==", "0963661093", true, "8157f0e9-a72f-4a7c-a2ba-7f27dec729b9", false, "minhtche161354", null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4886), null },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", 0, "d6dd2830-2939-4821-b234-40f161140646", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(4916), "hungmvhe163655@fpt.edu.vn", true, null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4917), "Mai Viet Hung", true, false, false, true, false, null, "HUNGMVHE163655@FPT.EDU.VN", "HUNGMVHE163655", "AQAAAAIAAYagAAAAEHaY3BZO2ooRDvclwsiVvksAaPExz0GAXkEHlfwAtwfVBfRcw9gQTR02USItL9NrSg==", "0975461220", true, "35757015-2798-4000-9772-406f6fea3a07", false, "hungmvhe163655", null, new DateTime(2024, 7, 4, 10, 31, 45, 610, DateTimeKind.Utc).AddTicks(4918), null }
                });

            migrationBuilder.InsertData(
                table: "DeviceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Available" },
                    { 2, "In Use" },
                    { 3, "Disable" }
                });

            migrationBuilder.InsertData(
                table: "NotificationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "System" },
                    { 2, "Project" }
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
                table: "AccountRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "1c5c3b44-7164-4232-a49a-10ab367d5102" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "603600b5-ca65-4fa7-817e-4583ef22b330" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "68fdf17c-7cbe-4a4c-a674-c530ffc77667" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "6ad0a020-e6a6-4e66-8f4a-d815594ba862" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", "7397c854-194b-4749-9205-f46e4f2fccf8" },
                    { "c55924f5-4cf4-4a29-9820-b5d0d9bdf3c5", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "a687bb04-4f19-49d5-a60f-2db52044767c" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "DeviceStatusId", "IsDeleted", "LastUsed", "Name", "OwnedBy" },
                values: new object[,]
                {
                    { new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), "Dell UltraSharp U2723QE 27 inch", 2, false, new DateTime(2024, 7, 2, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5468), "Screen", "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { new Guid("0a395b72-ae0d-4a49-b7f8-1763de733068"), "High resolution monitor", 2, false, new DateTime(2024, 6, 29, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5478), "Monitor", "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { new Guid("11d331b4-136c-4844-a686-ffc38c103268"), "Main office router", 3, false, new DateTime(2024, 6, 24, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5473), "Router", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), "Thai's PC", 1, false, new DateTime(2024, 7, 1, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5471), "PC", "a687bb04-4f19-49d5-a60f-2db52044767c" },
                    { new Guid("51e6edb8-0a1f-4c26-afb7-fcf95ea0965f"), "Network switch", 3, false, new DateTime(2024, 6, 19, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5493), "Switch", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("5947a22f-0191-419c-873b-4324b5b95e84"), "Office printer", 1, false, new DateTime(2024, 6, 27, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5480), "Printer", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"), "Primary server", 1, false, new DateTime(2024, 7, 3, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5464), "Server", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("a1d65f8a-f7fd-4995-940f-6ab254523f90"), "Designer's tablet", 2, false, new DateTime(2024, 7, 2, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5488), "Tablet", "a687bb04-4f19-49d5-a60f-2db52044767c" },
                    { new Guid("b4dc2d48-482a-48a2-bad6-7a1e0e3139b7"), "Development desktop", 1, false, new DateTime(2024, 7, 3, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5475), "Desktop", "a687bb04-4f19-49d5-a60f-2db52044767c" },
                    { new Guid("eb934470-4e73-41a8-8304-3bcb1ea18502"), "Conference room projector", 1, false, new DateTime(2024, 6, 30, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5491), "Projector", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("049d2c9c-f550-4e21-8911-efc5789106ec"), "Thân gửi các bạn sinh viên,\r\n\r\nPhòng Phát triển bền vững trường Đại học FPT (FSDG) sẽ tiến hành khảo sát với sinh viên trên cổng thông tin đào tạo FAP.\r\n\r\nKhảo sát về các hành động thúc đẩy 17 mục tiêu phát triển bền vững toàn cầu của sinh viên đã thực hiện trong thời gian một năm qua.\r\n\r\nKhảo sát sẽ bắt đầu từ ngày 25/06/2024, sinh viên vui lòng truy cập vào địa chỉ FAP (https://fap.fpt.edu.vn/) và tham gia khảo sát đầy đủ. Sau khi hoàn thành khảo sát, sinh viên sẽ tiếp tục vào FAP bình thường.\r\n\r\nThân mến!.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 24, 15, 16, 0, 0, DateTimeKind.Unspecified), "[Phòng Phát triển bền vững] Chuẩn bị khảo sát SV toàn trường về PTBV" },
                    { new Guid("0985634f-496f-4480-83f0-14ff0c30b002"), "Từ ngày 14/8/2023, phòng Đào tạo bổ sung chức năng cho sinh viên tự đăng ký lớp/ hủy các môn đã đăng ký trong danh sách chờ trên fap.fpt.edu.vn. Các bước thực hiện như sau:\r\n\r\nSinh viên đăng nhập vào trang Fap.fpt.edu.vn\r\nVào Academic Information/ Registration/Application(Thủ tục/đơn từ)/ Wishlist Course (Danh các môn học chờ xếp lớp)", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 25, 11, 34, 0, 0, DateTimeKind.Unspecified), "Hướng dẫn sinh viên các bước tự đăng ký/ hủy các môn đã đăng ký trong danh sách chờ" },
                    { new Guid("0da0b088-1b08-404b-9696-eb539d31c9e5"), "Phòng Dịch vụ sinh viên thông báo hướng dẫn đăng ký mua BHYT hiệu lực trong năm 2024 đợt bổ sung dành cho sinh viên, cụ thể như sau:\r\n\r\n1/ Đối tượng áp dụng: tất cả sinh viên chưa mua BHYT năm 2024\r\n\r\n(Nếu không biết mình đã có thẻ BHYT năm 2024 hay chưa, sinh viên có thể tra cứu tại đây: tracuuhieulucthe)\r\n\r\n2/ Hiệu lực thẻ: 7 tháng (Từ tháng 20/06/2024 – 31/12/2024) – Mức phí: 397,000 VNĐ", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 29, 14, 58, 0, 0, DateTimeKind.Unspecified), "Thông báo về việc đăng ký mua BHYT đợt bổ sung" },
                    { new Guid("14764db6-10f1-48e6-a4e8-3ae063814acf"), "Phòng Tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Seminar “Điệu nhảy của các con số trong thiết kế phần mềm của đồ án tốt nghiệp​”. Thông tin chi tiết như sau:\r\n\r\n·       Thời gian:  20:30 – 22:00 - Thứ 3 ngày 28/05/2024.\r\n\r\n·       Địa điểm (Online qua link): https://zoom.us/j/9836098489 - ID cuộc họp: 983 609 8489, Passcode: 1\r\n\r\n·       Diễn giả: Giảng viên Nguyễn Tất Trung\r\n\r\nLưu ý: Đây là một trong năm buổi chia sẻ mà nhà trường và bộ môn sẽ trang bị thêm kiến thức, kĩ năng giúp các em có thể hoàn thành tốt đồ án tốt nghiệp. Phòng TC&QLDT không recording lại buổi seminar để gửi sinh viên, đề nghị sinh viên các nhóm có mặt đầy đủ và đúng giờ.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 27, 16, 11, 0, 0, DateTimeKind.Unspecified), "V/v: Tham dự Seminar “Điệu nhảy của các con số trong thiết kế phần mềm của đồ án tốt nghiệp​”" },
                    { new Guid("245b3c4d-ba95-4040-818d-23da69f08e9b"), "Phòng tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Seminar “Cách thức đặt vấn đề khi xác định bài toán của đồ án”. Thông tin chi tiết như sau:\r\n\r\n·       Thời gian:  20:30 – 22:00 - Thứ 3 ngày 14/05/2024.\r\n\r\n·       Địa điểm (Online qua link): https://zoom.us/j/9836098489 - ID cuộc họp: 983 609 8489, Passcode: 1\r\n\r\n·       Diễn giả: Tiến sĩ Ngô Tùng Sơn - Chủ nhiệm bộ môn An toàn thông tin.\r\n\r\nLưu ý: Đây là một trong năm buổi chia sẻ mà nhà trường và bộ môn sẽ trang bị thêm kiến thức, kĩ năng giúp các em có thể hoàn thành tốt đồ án tốt nghiệp. Đề nghị sinh viên có mặt đầy đủ và đúng giờ.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 14, 14, 5, 0, 0, DateTimeKind.Unspecified), "V/v: Tham dự Seminar “Cách thức đặt vấn đề khi xác định bài toán của đồ án”" },
                    { new Guid("5d0bfb1c-d68d-450e-8fe9-e7d94be4eaac"), "Phòng Tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Seminar “Hướng dẫn lập kế hoạch và đặc tả yêu cầu dự án Đồ án tốt nghiệp ( ~ Report 2&3 )​”. Thông tin chi tiết như sau:\r\n\r\n·       Thời gian:  20:30 – 22:00 - Thứ 3 ngày 21/05/2024.\r\n\r\n·       Địa điểm (Online qua link): https://zoom.us/j/9836098489 - ID cuộc họp: 983 609 8489, Passcode: 1\r\n\r\n·       Diễn giả: Giảng viên Nguyễn Trung Kiên\r\n\r\nLưu ý: Đây là một trong năm buổi chia sẻ mà nhà trường và bộ môn sẽ trang bị thêm kiến thức, kĩ năng giúp các em có thể hoàn thành tốt đồ án tốt nghiệp. Đề nghị sinh viên có mặt đầy đủ và đúng giờ.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 20, 22, 23, 0, 0, DateTimeKind.Unspecified), "V/v: Tham dự Seminar “Hướng dẫn lập kế hoạch và đặc tả yêu cầu dự án Đồ án tốt nghiệp”" },
                    { new Guid("650204d7-0be6-4f91-89f7-d80572d4f76a"), "Phòng Khảo thí thông báo đã có điểm thi kết thúc học phần lần 2 môn SSL101c học kỳ Spring 2024. Môn COV111, COV121, AET102, MLN111, HCM202, IOT102, MLN131 học kỳ Summer 2024, các em đăng nhập FAP để xem chi tiết..", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 26, 22, 7, 0, 0, DateTimeKind.Unspecified), "Thông báo điểm thi kết thúc học phần lần 2 môn SSL101c học kỳ Spring 2024." },
                    { new Guid("663c5d19-d3ed-4d6a-aff6-3997dd0c43c4"), "Theo kế hoạch của phòng Quản lý Đào tạo, học kỳ SUMMER 2024 H2 sẽ bắt đầu vào ngày 08/07/2024:\r\n\r\nBan Kế toán gửi tới các bạn sinh viên thông tin về học phí kỳ SUMMER 2024 H2, chi tiết như sau:\r\n\r\nHạn nộp tiền (ngày nhà trường nhận được tiền): 26/06/2024\r\n \r\n\r\nSố tiền cần nộp: SV đăng nhập vào fap.fpt.edu.vn, số tiền học phí phải nộp kỳ tới sẽ hiển thị trên màn chính. Ban Kế toán cập nhật hóa đơn học phí lên hệ thống từ ngày 12/06/2024. \r\nĐối tượng loại trừ: - Sinh viên có học bổng 100%\r\n\r\n                                            - Sinh viên đã hoàn thành thủ tục tạm ngưng học phần Tiếng Anh hoặc bảo lưu kỳ.\r\n\r\n \r\n\r\nHướng dẫn thanh toán học phí:\r\nSinh viên đăng nhập vào fap.fpt.edu.vn → Choose paid items → Học phí và phụ trội KTX đã được mặc định tick chọn → nhấn Add to Card → nhấn Submit Order → Sinh viên thực hiện thanh toán theo nguyên tắc sau\r\n\r\nNếu ví FAP đủ số dư → Hệ thống tự động trừ tiền.\r\nNếu ví FAP có số dư bằng 0 → Tạo khoản thanh toán → Sinh viên quét QRCode để thanh toán\r\nNếu ví FAP có số dư lớn hơn 0 nhưng không đủ số tiền thanh toán học phí, phụ trội KTX → Sinh viên quét QRCode thanh toán số tiền còn thiếu.\r\nLưu ý: Sau khi SV nộp đủ học phí, hệ thống sẽ tự động quét trừ học phí kỳ này ngay lập tức.\r\n\r\nSinh viên không thấy xuất hiện học phí phải nộp trên FAP nếu rơi vào các trường hợp sau: Sinh viên bảo lưu kỳ, tạm ngưng học phần, sinh viên đã nộp đủ học phí kỳ SU24H2, chờ lớp.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 12, 9, 26, 0, 0, DateTimeKind.Unspecified), "THÔNG BÁO NỘP HỌC PHÍ KỲ SUMMER 2024 H2" },
                    { new Guid("6798cf4d-8399-4572-955e-595ddf13f292"), "\r\nThông báo về việc thay đổi tem kiểm soát ô tô ra/vào cổng Trường tại Hòa Lạc\r\nPost by hangntt6 on 18/06/24 09:45\r\nTrường Đại học FPT cơ sở Hà Nội thông báo về việc thay đổi tem kiểm soát ô tô ra/vào cổng trường, cụ thể:\r\n\r\nI. Đối tượng: Chỉ áp dụng ô tô đăng ký ra vào trường với 2 trường hợp:\r\n\r\nXe chính chủ của sinh viên, CBGV\r\nXe của người thân trong gia đình sinh viên, CBGV\r\nII. Hình thức triển khai:\r\n\r\nĐối với các trường hợp đã đăng ký từ ngày 15/06/2024 trở về trước:\r\nBổ sung thông tin theo link: https://forms.gle/HSjMfrJwSJH8t4Wi8\r\nMang theo biển cũ đổi lấy tem mới tại phòng Dịch vụ sinh viên từ ngày 18.06 đến 21.06/2024\r\nĐối với các trường hợp đăng ký mới:\r\nĐăng ký thông tin qua link: https://forms.gle/HSjMfrJwSJH8t4Wi8\r\nDự kiến nhận tem sau 07 ngày làm việc kể từ thời điểm đăng ký\r\n*Thời gian áp dụng kiểm soát xe ra/vào bằng Tem từ ngày 01/7/2024.\r\n\r\nSau thời gian bổ sung thêm, tất cả các xe chưa dán tem sẽ bắt buộc phải đăng ký tại cổng bảo vệ trước khi vào Trường.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 18, 9, 45, 0, 0, DateTimeKind.Unspecified), "Thông báo về việc thay đổi tem kiểm soát ô tô ra/vào cổng Trường tại Hòa Lạc" },
                    { new Guid("6e08720f-d73a-4ae1-be83-559dbb96a344"), "Chương trình Thạc sĩ Quản trị kinh doanh Cao cấp (SeMBA) và Chương trình Thạc sĩ Kỹ thuật phần mềm gửi chính sách đặc biệt dành riêng cho Cựu sinh viên Đại học FPT như sau:\r\n\r\nĐối tượng hưởng ưu đãi: Sinh viên tốt nghiệp Đại học FPT các chuyên ngành.\r\nMức ưu đãi đặc biệt: \r\nƯu đãi giảm 20% học phí khi đăng ký các khóa học\r\nMiễn chứng chỉ ngoại ngữ đầu vào\r\nVới kinh nghiệm hơn 20 năm đào tạo quản trị kinh doanh và công nghệ, top 3 Trường đào tạo kinh doanh tốt nhất Việt Nam, top 25 chương trình MBA tốt nhất Đông Á, Viện Quản trị & Công nghệ FSB (Đại học FPT) đã nghiên cứu và triển khai 2 chương trình đào tạo ưu việt, cập nhật xu hướng mới nhất nhằm đáp ứng những nhu cầu của Doanh nghiệp như sau:\r\n\r\nThạc sĩ Quản trị kinh doanh (SeMBA): được thiết kế theo mô hình STEM MBA đang là xu hướng trên toàn cầu, chương trình hướng đến mục tiêu đào tạo những nhà quản lý có tư duy nhạy bén và khả năng ứng dụng công nghệ, phân tích dữ liệu vào quản trị để đưa ra các quyết định kinh doanh mang tính đột phá.\r\nThạc sĩ Kỹ thuật phần mềm (MSE): chương trình trang bị cho học viên kiến thức chuyên sâu về AI và phân tích dữ liệu lớn, cùng các kỹ năng cần thiết để nhanh chóng nắm bắt, làm chủ những xu hướng công nghệ mới. Từ đó, học viên có thể vận dụng kiến thức về công nghệ vào xây dựng các hệ thống phần mềm thông minh, phù hợp với thời đại kinh doanh số.\r\nThời gian đào tạo: 18 tháng\r\nLịch học: Tối 2-4-6 | Từ 18h00 – 21h00\r\nĐịa điểm học: Nhà C, tòa nhà Việt Úc, KĐT Mỹ Đình 1, Nam Từ Liêm, Hà Nội.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 6, 14, 10, 0, 0, DateTimeKind.Unspecified), "Chương trình Thạc sĩ Quản trị kinh doanh Cao cấp (SeMBA) và Chương trình Thạc sĩ Kỹ thuật phần mềm dành tặng ưu đãi cho Cựu sinh viên FPT" },
                    { new Guid("7c712eff-f7d8-41af-a36c-9d7ce1439e3b"), "Phòng Dịch vụ sinh viên xin thông báo sẽ ngừng làm việc trong thời gian nghỉ hè kéo dài từ 01/07 đến hết ngày 05/07/2024.\r\n\r\nThời gian quay trở lại làm việc bình thường: 08/07/2024\r\n\r\nMọi yêu cầu hỗ trợ, giải đáp thắc mắc vui lòng gửi tới email: dichvusinhvien@fe.edu.vn\r\n\r\nTrân trọng thông báo,", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thông báo về việc phòng Dịch vụ sinh viên ngừng làm việc trong thời gian nghỉ hè" },
                    { new Guid("97755739-5cc9-49f7-bcf7-a66765be0571"), "Phòng Khảo thi thông báo đã có điểm thi kết thúc học phần lần 1 các môn AIG201c, ASR301c, BDI302c, CHN132c, CMC201c, ECC301c, ENM211c, ENM221c, FIM302c, FRS401c, HOM301c, IAO201c, IAR401c, ITE303c, LAB221c, MKT205c, SEO201c, SSC302c, AIG202c, CRY303c, DWP301c, EBC301c, EDT202c, ENG302c, HRM201c, IFT201c, ITA203c, ITB301c, ITE302c, LAW201c, NWC203c, OBE102c, PMG201c, PMG202c, PRC391c, PRC392c, PRE201c, PRN292c, SSL101c, WDU203c, WDU202c, PRO192c học kỳ Spring 2024, các em đăng nhập FAP để xem chi tiết điểm.\r\n\r\n", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 4, 18, 23, 37, 0, 0, DateTimeKind.Unspecified), "Thông báo điểm thi kết thúc học phần lần 1 các môn học online trên Coursera học kỳ Spring 2024" },
                    { new Guid("a491e3db-344e-4f16-a051-1ed491901340"), "Phòng Tổ chức và Quản lý Đào tạo thông báo kế hoạch học tập Half 2 - Học kỳ Summer 2024 đối với sinh viên giai đoạn Tiếng Anh chuẩn bị tại cơ sở Hà Nội như sau:\r\n\r\n \r\n\r\nTHỜI GIAN HỌC:\r\n \r\n\r\nSinh viên học chương trình Little UK và Transition bắt đầu học Half 2 từ ngày 08/7/2024.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 12, 16, 1, 0, 0, DateTimeKind.Unspecified), "KẾ HOẠCH HỌC TẬP HALF 2 KỲ SUMMER 2024 DÀNH CHO SINH VIÊN GIAI ĐOẠN TIẾNG ANH CHUẨN BỊ TẠI ĐH FPT HÀ NỘI" },
                    { new Guid("c0268d79-cfd7-44c3-9b13-709869ae00e2"), "Phòng Công tác sinh viên thông báo:\r\n\r\nBảng điểm phong trào tháng 1-2-3-4 và điểm Tổng kết học kỳ Spring 2024 (final): Tại đây\r\n\r\nMọi thắc mắc vui lòng gửi về hòm mail sro.hn@fpt.edu.vn trước 14h ngày 13/06/2024\r\n\r\nTrân trọng thông báo,", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 12, 12, 40, 0, 0, DateTimeKind.Unspecified), "[CTSV] - Thông báo Điểm Rèn Luyện Học Kỳ Spring 2024" },
                    { new Guid("cfc8a241-628f-4fab-acaf-60ffd42f97cd"), "This is the content of news item 3.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 27, 16, 25, 0, 0, DateTimeKind.Unspecified), "News Title 3" },
                    { new Guid("e277ec7f-14cf-47a2-a234-1265920647a4"), "Gửi các bạn,\r\n\r\nPhòng HCTH xin gửi thông báo tới bạn thủ tục đăng ký/hủy phòng cho kỳ Summer 2024 như sau:\r\n\r\nĐăng ký ở tiếp:\r\nØ Thời gian giữ chỗ: Từ ngày 11/4 – 21/4/2024. Gia hạn 22/4/2024.\r\n\r\n Ø Thời gian đăng ký phòng mới: Từ ngày 23/4 đến ngày 27/4/2024.\r\n\r\n(Trường hợp không đăng ký giữ chỗ được hiểu là bạn không còn nhu cầu sử dụng và bạn khác có thể đăng ký)  \r\n\r\n         Ø Đối tượng ưu tiên đăng ký KTX\r\n\r\n- Sinh viên học tập tại cơ sở Hòa Lạc trước kỳ OJT (xét tại thời điểm đăng ký phòng)\r\n\r\n- Các đối tượng sinh viên sinh viên khác có nhu cầu đăng ký phòng, Nhà trường sẽ hỗ trợ giải quyết đặt phòng qua hòm thư ktx@fpt.edu.vn.\r\n\r\n   Phương thức nộp phí và đăng ký phòng KTX qua Hệ thống OCD http://ocd.fpt.edu.vn/\r\n\r\nBước 1: Đặt phòng\r\n\r\n- Sinh viên truy cập http://ocd.fpt.edu.vn/  thực hiện đặt phòng tại chức năng  Booking Bed.\r\n\r\n- Lựa chọn đặt phòng Giữ chỗ cũ hoặc đăng ký mới theo nhu cầu.\r\n\r\nSinh viên chuyển phòng/đăng ký mới cần thao tác chọn chính xác thông tin tại các mục: Loại phòng/Dom/Tầng.\r\n\r\nBước 2: Thanh toán\r\n\r\nSau khi hoàn tất chọn phòng, sinh viên tiến hành thanh toán bằng một trong 2 hình thức sau:\r\n\r\n- Booking with FAP (nếu trên ví FAP còn đủ tiền)\r\n\r\n- Booking with DNG (Sinh viên vào App ngân hàng quét QR code để thanh toán).\r\n\r\nà Đặt phòng thành công.\r\n\r\nLưu ý: KTX sẽ gửi thư xác nhận và thông báo số phòng sau 48 giờ kể từ khi nhận booking.\r\n\r\nThời gian giữ chỗ cho SV thanh toán DNG là 10 phút. Nếu thanh toán chậm sau 10 phút thì OCD hủy giữ chỗ và tiền SV đã nộp sẽ trả về FAP. Sinh viên truy cập Hệ thống OCD đăng ký lại với hình thức sử dụng tiền dư trong ví FAP (Booking with FAP).", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 4, 25, 20, 21, 0, 0, DateTimeKind.Unspecified), "THÔNG BÁO V/V ĐĂNG KÝ/HỦY PHÒNG KTX KỲ SU24" },
                    { new Guid("efb06517-4673-4b44-bf11-ee12198c26a7"), "Phòng khảo thí thông báo đã có điểm thi lần 2 các môn ENT104, TRS401, TRS501, TRS601, VOV114, VOV124, VOV134 Part 1 HK Summer2024. Các em đăng nhập FAP để xem điểm chi tiết.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 29, 21, 39, 0, 0, DateTimeKind.Unspecified), "Thông báo điểm thi lần 2 các môn ENT104, TRS401, TRS501, TRS601 HK Summer2024." },
                    { new Guid("f0c49374-4c7d-464a-9f38-e6f59b20344d"), "Nhằm khắc phục sự cố và bảo trì trạm biến áp số 1 Trường Đại học FPT.\r\n\r\nPhòng hành chính tổng hợp - Trường Đại học FPT cơ sở Hà Nội thông báo lịch tạm ngưng cấp điện như sau:\r\n\r\nThời gian dự kiến từ: Từ 08 giờ 00 phút đến 10 giờ 00 phút ngày 25/5/2024. \r\n\r\nKhu vực ảnh hưởng: Dom A, B, C, D, Nhà Dịch 1, Tòa Beta.\r\n\r\n Sinh viên lưu ý về thời gian tạm ngừng cắt điện để chủ động trong công việc của mình. \r\n\r\nRất mong các bạn thông cảm vì sự bất tiện này. ", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 24, 23, 15, 0, 0, DateTimeKind.Unspecified), "TB. V/v cắt điện ngày 25/05/2024" },
                    { new Guid("f3e39c12-df43-4e2a-b84e-92374739e0e9"), "Phòng Tổ chức và Quản lý đào tạo mời các em sinh viên ngành Công nghệ thông tin, ngành Kỹ thuật phần mềm đang làm đồ án tốt nghiệp học kỳ Summer 2024 tham dự Super Sunday Workshop “Chia sẻ về Testing”.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 8, 21, 29, 0, 0, DateTimeKind.Unspecified), "V/v: Tham dự Super Sunday Workshop “Chia sẻ về Testing”" },
                    { new Guid("fb4d071c-c460-4a01-8ee4-9247a97214a6"), "Chào các em,\r\n\r\nĐiều kiện để được miễn điểm danh kỳ SU24 như sau:\r\n\r\nSV đã hoàn thành kỳ OJT và đang học ở 1 trong số các kỳ sau: 7,8,9,10 (kỳ 10: hoàn thành các môn học còn thiếu)\r\nYêu cầu chung cho tất cả các loại HĐ làm việc hợp lệ.\r\n=>Thời gian làm việc: fulltime 8h/ngày (không nhận HĐ bán thời gian, part time) – Hợp đồng làm việc full kỳ SU2024 (từ tháng 5=>tháng 8/2024)\r\n=>Làm việc có lương và chịu sự quản lý, giám sát của nhà tuyển dụng.\r\n=>HĐ có đủ con dấu & chữ ký tươi/chữ ký số nhà tuyển dụng.\r\nThời gian mở đơn miễn điểm danh : 2 tuần trước khi vào kỳ SU24  (16/4 – 30/04/2024)  - đơn đã được gia hạn đến 20/5/2024\r\n\r\nSau thời gian trên phòng TC&QLĐT sẽ không nhận hỗ trợ bất kỳ trường hợp nào.\r\n\r\nThời gian mở đơn Block 5 : Tuần 12 của kỳ SU2024\r\n\r\nKhi làm đơn xin miễn điểm danh SV lưu ý cần làm theo chỉ dẫn sau:\r\n\r\n- SV đăng nhập FAP, vào phần HOME -> GỬI ĐƠN\r\n\r\n =>Application type: chọn Đơn miễn điểm danh\r\n\r\n=> Reason: Ghi rõ lý do làm đơn (ví dụ: Đã hoàn thành kỳ OJT – đang học kỳ … được ký HĐ làm việc fulltime với công ty…)\r\n\r\nFile Attach bao gồm:      \r\n\r\nGửi full file HĐ làm việc & giấy xác nhận nhân viên\r\nKhi gửi file nếu dung lượng file HĐLĐ nặng >2MB các em cần giảm dung lượng , nén file <2MB  hoặc các em có thể gửi HĐ qua link google drive…\r\n   LƯU Ý: \r\n\r\nPhòng TC&QLĐT chỉ nhận hỗ trợ những SV có HĐ làm việc (thời gian làm việc full kỳ SU2024). Trong trường hợp HĐ có thời gian làm việc chỉ còn 1 đến 2 tháng; HĐ thử việc ngắn hạn trong đơn cần ghi rõ thời gian sẽ bổ sung HĐ làm việc mới, HĐ làm việc chính thức để phòng Đào tạo xem xét. Những HĐ không đủ thời gian làm việc full kỳ SU24, không cam kết thời gian nộp HĐ mới sẽ bị từ chối không hỗ trợ.\r\nCác HĐ làm việc cũ nhưng còn thời gian làm việc full kỳ SU2024: SV gửi nộp file HĐ và Giấy xác nhận nhân viên (giấy xác nhận nhân viên phải được cấp quản lý ký và đóng dấu xác nhận trước khi nộp đơn miễn điểm danh kỳ SU24 khoảng 1 tuần làm việc)\r\nThư mời làm việc không phải là HĐLĐ do vậy không đủ ĐK để làm đơn miễn điểm danh, SV có thể làm đơn và phòng ĐT sẽ note vào danh sách chờ, phải bổ sung HĐ chính thức trước ngày 20/5/2024.\r\nCác loại Hợp đồng khoán gọn, Hợp đồng dịch vụ, Hợp đồng hợp tác, Hợp đồng với các công ty nhà đất, chứng khoán...: cần nộp file HĐ và giấy xác nhận nhân viên, trong giấy xác nhận nhân viên cần ghi rõ SV đang làm việc fulltime (8h/ngày) - có hưởng lương tại doanh nghiệp\r\nĐƠN MIỄN ĐIỂM DANH sẽ bị hủy NẾU PHÒNG TC&QLĐT phát hiện SV đã được duyệt miễn điểm danh trong kỳ SU24 nhưng nghỉ làm giữa chừng, không hoàn thành thời gian làm việc ghi trên HĐ làm việc đã nộp (sẽ chuyển trạng thái từ miễn điểm danh => chỉ được phép nghỉ 20% theo quy định của SV)\r\nThời gian duyệt đơn miễn điểm danh từ 5 ngày làm việc tùy thuộc vào số lượng đơn phòng TC&QLĐT nhận được. (không tính thứ 7 và CN)\r\nCHÚ Ý:\r\n\r\n- Các em chỉ gửi đơn Miễn điểm danh 1 lần và vui lòng chờ kết quả trả lời ở phần Xem đơn – KHÔNG GỬI TRÙNG ĐƠN  để tránh làm loãng thông tin. (Bạn nào gửi từ 2 lần đơn trở lên thời gian chờ duyệt đơn sẽ tăng theo số lần gửi đơn )\r\n\r\n- Đơn miễn điểm danh kỳ SU2024 được duyệt, SV sẽ được miễn điểm danh full cả 2 block ( block1-4 và block5) do vậy những SV đã được duyệt đơn miễn điểm danh đầu kỳ SU24 nếu học block 5 không cần làm đơn xin miễn điểm danh block5-SU2024.\r\n\r\n- Đơn miễn điểm danh này chỉ có giá trị trong kỳ SU2024\r\n\r\n- Phòng TC&QLĐT chỉ nhận ĐƠN MIỄN ĐIỂM DANH ONLINE – KHÔNG NHẬN ĐƠN MIỄN ĐIỂM DANH GỬI QUA MAIL\r\n\r\n- SV miễn điểm danh được phép vắng mặt >20% (không giới hạn %) và phòng TC&QLĐT quản lý SV miễn điểm danh độc lập do vậy SV không gửi mail thắc mắc khi chưa thấy chữ Attendance Exemption\r\n\r\n- Trường hợp hiếm gặp: Nếu các em làm đơn miễn điểm danh đã được duyệt nhưng vẫn có tên trong DSSV không đủ điều kiện dự thi, các em cần gửi mail tới phòng TC&QLĐT (acad.hl@fpt.edu.vn ) để được hỗ trợ.\r\n\r\n. Do các em bận đi làm, ít đến lớp nên điểm chuyên cần sẽ giảm tùy theo cách đánh giá của giảng viên.\r\n\r\n- Không được miễn điểm danh các môn GDQP và khóa luận tốt nghiệp.\r\n\r\nCác em đọc kỹ thông báo này và làm theo hướng dẫn để được hỗ trợ chính xác nhất.\r\n\r\nTrân trọng thông báo\r\n\r\nPhòng TC&QL Đào tạo", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 9, 23, 37, 0, 0, DateTimeKind.Unspecified), "HƯỚNG DẪN LÀM VÀ GỬI ĐƠN MIỄN ĐIỂM DANH KỲ SU2024" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "NotificationTypeId", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), "Don't miss out on our latest promotions!", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 27, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5202), 2, "Promotion Alert", "" },
                    { new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), "Your account details have been updated.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 25, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5209), 1, "Account Notice", "" },
                    { new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), "We are excited to announce a new feature in our application.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 7, 1, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5193), 1, "New Feature Release", "" },
                    { new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), "Please take a moment to complete our user survey.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 26, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5206), 2, "Survey Request", "" },
                    { new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), "Don't forget about the event tomorrow!", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 24, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5212), 1, "Event Reminder", "" },
                    { new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), "Please update your password to enhance security.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 30, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5195), 1, "Security Alert", "" },
                    { new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), "The system will be down for maintenance tonight.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 29, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5198), 1, "Downtime Notification", "" },
                    { new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), "Scheduled maintenance will occur this weekend.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 7, 2, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5190), 1, "Maintenance Notice", "" },
                    { new Guid("e331de18-289c-403d-8028-26c4b595587a"), "A new system update will be available tomorrow.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 7, 3, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5180), 1, "System Update", "" },
                    { new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), "Join weekly meeting.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 28, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5200), 2, "Weekly Meeting", "" }
                });

            migrationBuilder.InsertData(
                table: "StudentDetails",
                columns: new[] { "AccountId", "Major", "RollNumber", "Specialized" },
                values: new object[,]
                {
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", "Software Engineering", "HE156894", "PHP" },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", "Software Engineering", "HE163098", "ASP.NET" },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", "Data Engineer", "HE163884", "Data Analyst" },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", "Iot", "HE145689", "Python" },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", "Artifact Intelligent", "HE163956", "C" }
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
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), false },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), true },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), true },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), false },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), false },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), false },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), false },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), false },
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
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), false },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), false },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), false },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), true },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), true },
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("e331de18-289c-403d-8028-26c4b595587a"), true },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("e331de18-289c-403d-8028-26c4b595587a"), false },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("e331de18-289c-403d-8028-26c4b595587a"), true },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("e331de18-289c-403d-8028-26c4b595587a"), true },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", new Guid("e331de18-289c-403d-8028-26c4b595587a"), false },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("e331de18-289c-403d-8028-26c4b595587a"), true },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new Guid("e331de18-289c-403d-8028-26c4b595587a"), true },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", new Guid("e331de18-289c-403d-8028-26c4b595587a"), false },
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
                table: "Schedules",
                columns: new[] { "Id", "AccountId", "DeviceId", "EndDate", "Purpose", "ScheduledDate", "StartDate" },
                values: new object[,]
                {
                    { new Guid("27f1b969-1b68-4cf8-8a51-c8be5356f7f8"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 2, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5538), "Development", new DateTime(2024, 7, 2, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5536), new DateTime(2024, 7, 2, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5537) },
                    { new Guid("37d2c7b3-7406-418d-9062-e81dfff02d9a"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), new DateTime(2024, 7, 3, 19, 31, 45, 610, DateTimeKind.Local).AddTicks(5527), "Testing", new DateTime(2024, 7, 3, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5525), new DateTime(2024, 7, 3, 18, 31, 45, 610, DateTimeKind.Local).AddTicks(5526) },
                    { new Guid("44efa2a7-4f64-4fc6-bbbe-869099817d4f"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"), new DateTime(2024, 7, 4, 19, 31, 45, 610, DateTimeKind.Local).AddTicks(5519), "Testing", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5517), new DateTime(2024, 7, 4, 18, 31, 45, 610, DateTimeKind.Local).AddTicks(5518) },
                    { new Guid("4da0b3f8-95aa-40cd-ab32-75876ca13900"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 2, 23, 31, 45, 610, DateTimeKind.Local).AddTicks(5541), "Development", new DateTime(2024, 7, 2, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5540), new DateTime(2024, 7, 2, 22, 31, 45, 610, DateTimeKind.Local).AddTicks(5541) },
                    { new Guid("4fa30f09-e82a-4375-a28f-8190a8667a09"), "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 28, 23, 31, 45, 610, DateTimeKind.Local).AddTicks(5563), "Development", new DateTime(2024, 6, 28, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5562), new DateTime(2024, 6, 28, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5562) },
                    { new Guid("5547314b-521a-47e9-ad60-5e376e686636"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("5947a22f-0191-419c-873b-4324b5b95e84"), new DateTime(2024, 7, 4, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5582), "Development", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5581), new DateTime(2024, 7, 4, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5581) },
                    { new Guid("5b1615a6-b870-456a-a483-e99a3f9122dc"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("11d331b4-136c-4844-a686-ffc38c103268"), new DateTime(2024, 7, 2, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5570), "Development", new DateTime(2024, 7, 2, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5569), new DateTime(2024, 7, 2, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5569) },
                    { new Guid("5dc94e7f-845b-480b-8c81-f1d50c359491"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 1, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5549), "Development", new DateTime(2024, 7, 1, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5548), new DateTime(2024, 7, 1, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5548) },
                    { new Guid("6500363e-6574-42e7-8577-6dc87a55ce15"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("eb934470-4e73-41a8-8304-3bcb1ea18502"), new DateTime(2024, 7, 2, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5589), "Development", new DateTime(2024, 7, 2, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5588), new DateTime(2024, 7, 2, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5589) },
                    { new Guid("70f625f4-33f5-4c62-9718-d3e2c420e703"), "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 1, 23, 31, 45, 610, DateTimeKind.Local).AddTicks(5553), "Development", new DateTime(2024, 7, 1, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5551), new DateTime(2024, 7, 1, 22, 31, 45, 610, DateTimeKind.Local).AddTicks(5552) },
                    { new Guid("77153502-8631-4b5f-b05d-76d4796c06d4"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 30, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5556), "Development", new DateTime(2024, 6, 30, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5555), new DateTime(2024, 6, 30, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5556) },
                    { new Guid("77790ba9-1f3c-4943-9e39-097000fc6fa2"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 27, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5566), "Development", new DateTime(2024, 6, 27, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5565), new DateTime(2024, 6, 27, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5566) },
                    { new Guid("80d34442-7c14-4060-ae8f-24cda38e63f9"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 7, 3, 19, 31, 45, 610, DateTimeKind.Local).AddTicks(5545), "Development", new DateTime(2024, 7, 3, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5543), new DateTime(2024, 7, 3, 18, 31, 45, 610, DateTimeKind.Local).AddTicks(5544) },
                    { new Guid("8bb44d07-f470-4434-a023-6bdffb4311cc"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 29, 23, 31, 45, 610, DateTimeKind.Local).AddTicks(5560), "Development", new DateTime(2024, 6, 29, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5558), new DateTime(2024, 6, 29, 22, 31, 45, 610, DateTimeKind.Local).AddTicks(5559) },
                    { new Guid("9bfeb5df-03a4-4ae5-904e-1779c19a5313"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("a1d65f8a-f7fd-4995-940f-6ab254523f90"), new DateTime(2024, 7, 3, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5586), "Development", new DateTime(2024, 7, 3, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5585), new DateTime(2024, 7, 3, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5585) },
                    { new Guid("db1fcaa0-e934-4429-a567-2ac802d0b453"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), new DateTime(2024, 7, 3, 23, 31, 45, 610, DateTimeKind.Local).AddTicks(5534), "Testing", new DateTime(2024, 7, 3, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5532), new DateTime(2024, 7, 3, 22, 31, 45, 610, DateTimeKind.Local).AddTicks(5533) },
                    { new Guid("e0fa81b1-9eea-4b4b-93a7-b7a34aae4014"), "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), new DateTime(2024, 7, 3, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5530), "Development", new DateTime(2024, 7, 3, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5529), new DateTime(2024, 7, 3, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5530) },
                    { new Guid("e377b750-0b20-4943-9e5d-6909d4810f13"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"), new DateTime(2024, 7, 4, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5523), "Development", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5522), new DateTime(2024, 7, 4, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5522) },
                    { new Guid("eb607a7a-2572-4a16-bbbd-99f3db25d40b"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("0a395b72-ae0d-4a49-b7f8-1763de733068"), new DateTime(2024, 7, 4, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5579), "Development", new DateTime(2024, 7, 4, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5578), new DateTime(2024, 7, 4, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5578) },
                    { new Guid("ff18bb51-3c4e-4fcb-a73e-39f60996be8c"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("b4dc2d48-482a-48a2-bad6-7a1e0e3139b7"), new DateTime(2024, 7, 3, 21, 31, 45, 610, DateTimeKind.Local).AddTicks(5575), "Development", new DateTime(2024, 7, 3, 17, 31, 45, 610, DateTimeKind.Local).AddTicks(5573), new DateTime(2024, 7, 3, 20, 31, 45, 610, DateTimeKind.Local).AddTicks(5574) }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Description", "DeviceStatusId", "ScheduleId" },
                values: new object[,]
                {
                    { new Guid("06a6fcd7-eb30-4728-9856-ee8d00f84810"), "Designer's tablet updated with latest design apps.", 1, new Guid("5b1615a6-b870-456a-a483-e99a3f9122dc") },
                    { new Guid("0e287e15-6c9f-44ab-9fb3-dc183f5e5e92"), "Network switch configuration updated.", 1, new Guid("5dc94e7f-845b-480b-8c81-f1d50c359491") },
                    { new Guid("19f6bcc1-2a8d-4c5d-ab3b-d5d3b21da159"), "Network switch maintenance and inspection.", 2, new Guid("eb607a7a-2572-4a16-bbbd-99f3db25d40b") },
                    { new Guid("285ce1fd-470c-4474-ad1b-ba273c0e8653"), "Printer serviced and toner replaced.", 1, new Guid("27f1b969-1b68-4cf8-8a51-c8be5356f7f8") },
                    { new Guid("426c57ce-68aa-498b-b603-16cf1e7a238d"), "Monitor calibrated for color accuracy.", 1, new Guid("db1fcaa0-e934-4429-a567-2ac802d0b453") },
                    { new Guid("5e2385b4-08f6-4e9e-888b-5d94c4b7fb78"), "The desktop was used for backend development tasks.", 2, new Guid("6500363e-6574-42e7-8577-6dc87a55ce15") },
                    { new Guid("5faf118e-4687-47c2-9b83-ecb389b8b6d5"), "Router settings optimized for network traffic.", 1, new Guid("8bb44d07-f470-4434-a023-6bdffb4311cc") },
                    { new Guid("697817b7-9d65-47dd-a39b-909f89e25bce"), "The desktop was used for backend development tasks.", 1, new Guid("5547314b-521a-47e9-ad60-5e376e686636") },
                    { new Guid("75fb870f-e344-40c9-ab85-101631f22505"), "Device was used for setting up a new development environment.", 1, new Guid("44efa2a7-4f64-4fc6-bbbe-869099817d4f") },
                    { new Guid("76199946-58bd-473a-95a7-9da8afcb9fc7"), "Desktop setup for new project development.", 1, new Guid("4fa30f09-e82a-4375-a28f-8190a8667a09") },
                    { new Guid("78d4e5bd-d685-49b5-8b12-e71df921ec65"), "Server performance was monitored during load testing.", 1, new Guid("70f625f4-33f5-4c62-9718-d3e2c420e703") },
                    { new Guid("8455c9b0-c2ca-4de4-bdee-3070dc8af954"), "The desktop was used for backend development tasks.", 1, new Guid("e0fa81b1-9eea-4b4b-93a7-b7a34aae4014") },
                    { new Guid("b774e795-3469-4b58-afe0-5f6e9e0a6aec"), "The desktop was used for backend development tasks.", 2, new Guid("9bfeb5df-03a4-4ae5-904e-1779c19a5313") },
                    { new Guid("b9d04c5f-2ec0-4da1-92ab-7ef9bdcd82e4"), "Developer's laptop used for bug fixing.", 2, new Guid("77153502-8631-4b5f-b05d-76d4796c06d4") },
                    { new Guid("c8fb056c-cff8-4db2-b951-01859431a35e"), "Router firmware was updated and tested.", 1, new Guid("37d2c7b3-7406-418d-9062-e81dfff02d9a") },
                    { new Guid("cf4dfffd-74e9-46dd-b9b5-2a9d09001564"), "Projector used for team meeting presentations.", 1, new Guid("ff18bb51-3c4e-4fcb-a73e-39f60996be8c") },
                    { new Guid("d3b039bd-813c-4b33-af98-2264dcb440c0"), "The laptop was utilized for testing the latest software build.", 2, new Guid("e377b750-0b20-4943-9e5d-6909d4810f13") },
                    { new Guid("dd8ac1ac-0f4f-45af-825e-e74e531b66dc"), "Tablet used for sketching new UI designs.", 1, new Guid("4da0b3f8-95aa-40cd-ab32-75876ca13900") },
                    { new Guid("e4880a12-6d1d-4e9b-8832-89c5982b1346"), "High-resolution monitor tested with graphic design software.", 2, new Guid("77790ba9-1f3c-4943-9e39-097000fc6fa2") },
                    { new Guid("f1dcaea6-1670-47d7-b8cb-398b89ca09d0"), "Projector used in a client presentation.", 1, new Guid("80d34442-7c14-4060-ae8f-24cda38e63f9") }
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
                name: "IX_Devices_DeviceStatusId",
                table: "Devices",
                column: "DeviceStatusId");

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
                name: "IX_FoldersClosure_Descendant",
                table: "FoldersClosure",
                column: "Descendant");

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
                name: "IX_Notifications_NotificationTypeId",
                table: "Notifications",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId");

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
                name: "IX_TaskHistories_AssignedToUserId",
                table: "TaskHistories",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_TaskGuid",
                table: "TaskHistories",
                column: "TaskGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_TaskPriorityId",
                table: "TaskHistories",
                column: "TaskPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_TasksId",
                table: "TaskHistories",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_TaskStatusId",
                table: "TaskHistories",
                column: "TaskStatusId");

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
                name: "IX_Tasks_TaskPriorityId",
                table: "Tasks",
                column: "TaskPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskStatusId",
                table: "Tasks",
                column: "TaskStatusId");

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
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "DeviceStatuses");

            migrationBuilder.DropTable(
                name: "TaskLists");

            migrationBuilder.DropTable(
                name: "TaskPriorities");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");

            migrationBuilder.DropTable(
                name: "ProjectTypes");
        }
    }
}
