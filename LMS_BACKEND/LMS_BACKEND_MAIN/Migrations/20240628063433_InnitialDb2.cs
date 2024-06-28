using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS_BACKEND_MAIN.Migrations
{
    /// <inheritdoc />
    public partial class InnitialDb2 : Migration
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Size = table.Column<float>(type: "real", nullable: false),
                    FileKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
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
                    PredecessorTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks",
                        column: x => x.PredecessorTaskId,
                        principalTable: "Tasks",
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
                    { "1c5c3b44-7164-4232-a49a-10ab367d5102", 0, "632cb874-5bf5-47e7-b9fe-a5399fb84fb6", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4019), "gakkou123@gmail.com", true, null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(4020), "Gakkou Atarashi", false, false, false, true, false, null, "GAKKOU123@GMAIL.COM", "GAKKOU", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965795220", true, "95fc2fba-1a55-4d40-93bc-af2055ad440d", false, "gakkou", null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(4021), null },
                    { "603600b5-ca65-4fa7-817e-4583ef22b330", 0, "cef5188d-afae-46a3-9047-4e756027a6f6", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(3937), "cuongndhe163098@fpt.edu.vn", true, null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3939), "Nguyen Duc Cuong", true, false, false, true, false, null, "CUONGNDHE163098@FPT.EDU.VN", "CUONGNDHE163098", "AQAAAAIAAYagAAAAENVZ95qV36S0GH4gzip/nSmI9JKDA1CAGuL2+t1ysccrtPgGLrSZ6k9v/tS37ojoSw==", "0975465220", true, "d2ea8636-3803-4f0f-b8c0-3ef3e0e861b7", false, "cuongndhe163098", null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3940), null },
                    { "68fdf17c-7cbe-4a4c-a674-c530ffc77667", 0, "64c8d9d0-a1a5-42a8-ba06-d9fc94acadb6", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(3956), "hoangnmhe163884@fpt.edu.vn", true, null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3958), null, false, false, false, true, false, null, "HOANGNMHE163884@FPT.EDU.VN", "HOANGNMHE163884", "AQAAAAIAAYagAAAAEBSeWGYcWJzo0jTXDBqXgYkMmzdQCRKsLrFMaaqieAdCHchkvB2oa1eRy3gsuvWyVw==", "0975765220", true, "0238d777-9ff7-47f8-8e49-2980221ba100", false, "hoangnmhe163884", null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3959), null },
                    { "6ad0a020-e6a6-4e66-8f4a-d815594ba862", 0, "7fc0c176-0036-4232-afae-f725b84cf7c9", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4000), "kenshiyonezu123@gmail.com", true, null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(4001), "Kenshi Yonezu", true, false, false, true, false, null, "KENSHIYONEZU123@GMAIL.COM", "KENSHIYONEZU", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965765120", true, "0ad1f238-2e76-4b49-8c60-597e8ba7ee96", false, "kenshiyonezu", null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(4002), null },
                    { "6c6abe62-f811-4a8b-96eb-ed326c47d209", 0, "450c7da2-8029-4529-bc8a-6113a6df6c6e", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(3843), "thailshe160614@fpt.edu.vn", true, null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3845), "Le Sy Thai", true, false, false, true, false, null, "THAILSHE160614@FPT.EDU.VN", "THAILSHE160614", "AQAAAAIAAYagAAAAEO5SGANyOkCieJN+MspCJeIbBLjDruXYD5omO5+7u9NVKctIo979jEts1uoDaalzTw==", "0497461220", true, "a8140e18-aece-4da7-8f65-335a25678ccf", false, "thailshe160614", null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3846), null },
                    { "7397c854-194b-4749-9205-f46e4f2fccf8", 0, "c0803dcd-c5ab-400d-be42-cafd6b2d8543", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(3975), "littlejohn123@gmail.com", true, null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3976), "John", true, false, false, true, false, null, "LITTLEJOHN123@GMAIL.COM", "LITTLEJOHN", "AQAAAAIAAYagAAAAEHgJ1v35yMdrboz2wNnq7ycAFHmE2gEKN5HvTBhtJlXU94370YPUlLqftEVfKcYgPA==", "0965765228", true, "bd4ad2e1-2add-4821-8239-3691be10c184", false, "littlejohn", null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3977), null },
                    { "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", 0, "1c597ba1-5962-4b6b-b63a-34b47af71beb", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(3788), "minhtche161354@fpt.edu.vn", true, null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3807), "Tran Cong Minh", false, false, false, true, false, null, "MINHTCHE161354@FPT.EDU.VN", "MINHTCHE161354", "AQAAAAIAAYagAAAAELgUn5wJH9empSyZm7MdUy84spVESi+LvNCV8nDY9PMgoY0fOBYhfZO/MPZHjSZimA==", "0963661093", true, "5ada14ae-fef2-44b2-916b-540c1bb70f02", false, "minhtche161354", null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3809), null },
                    { "a687bb04-4f19-49d5-a60f-2db52044767c", 0, "c9e6f27f-3ae0-40f4-83a2-7cf0936cf22c", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(3862), "hungmvhe163655@fpt.edu.vn", true, null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3863), "Mai Viet Hung", true, false, false, true, false, null, "HUNGMVHE163655@FPT.EDU.VN", "HUNGMVHE163655", "AQAAAAIAAYagAAAAEHaY3BZO2ooRDvclwsiVvksAaPExz0GAXkEHlfwAtwfVBfRcw9gQTR02USItL9NrSg==", "0975461220", true, "35d89004-9d58-484d-a6a6-b31593a83159", false, "hungmvhe163655", null, new DateTime(2024, 6, 28, 6, 34, 32, 636, DateTimeKind.Utc).AddTicks(3864), null }
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
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", "a687bb04-4f19-49d5-a60f-2db52044767c" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "DeviceStatusId", "IsDeleted", "LastUsed", "Name", "OwnedBy" },
                values: new object[,]
                {
                    { new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), "Dell UltraSharp U2723QE 27 inch", 2, false, new DateTime(2024, 6, 26, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4860), "Screen", "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { new Guid("0a395b72-ae0d-4a49-b7f8-1763de733068"), "High resolution monitor", 2, false, new DateTime(2024, 6, 23, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4878), "Monitor", "6c6abe62-f811-4a8b-96eb-ed326c47d209" },
                    { new Guid("11d331b4-136c-4844-a686-ffc38c103268"), "Main office router", 3, false, new DateTime(2024, 6, 18, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4870), "Router", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), "Thai's PC", 1, false, new DateTime(2024, 6, 25, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4865), "PC", "a687bb04-4f19-49d5-a60f-2db52044767c" },
                    { new Guid("51e6edb8-0a1f-4c26-afb7-fcf95ea0965f"), "Network switch", 3, false, new DateTime(2024, 6, 13, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4892), "Switch", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("5947a22f-0191-419c-873b-4324b5b95e84"), "Office printer", 1, false, new DateTime(2024, 6, 21, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4882), "Printer", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"), "Primary server", 1, false, new DateTime(2024, 6, 27, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4853), "Server", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" },
                    { new Guid("a1d65f8a-f7fd-4995-940f-6ab254523f90"), "Designer's tablet", 2, false, new DateTime(2024, 6, 26, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4886), "Tablet", "a687bb04-4f19-49d5-a60f-2db52044767c" },
                    { new Guid("b4dc2d48-482a-48a2-bad6-7a1e0e3139b7"), "Development desktop", 1, false, new DateTime(2024, 6, 27, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4875), "Desktop", "a687bb04-4f19-49d5-a60f-2db52044767c" },
                    { new Guid("eb934470-4e73-41a8-8304-3bcb1ea18502"), "Conference room projector", 1, false, new DateTime(2024, 6, 24, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4889), "Projector", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("049d2c9c-f550-4e21-8911-efc5789106ec"), "This is the content of news item 5.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 5" },
                    { new Guid("0985634f-496f-4480-83f0-14ff0c30b002"), "This is the content of news item 16.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 16" },
                    { new Guid("0da0b088-1b08-404b-9696-eb539d31c9e5"), "This is the content of news item 14.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 14" },
                    { new Guid("14764db6-10f1-48e6-a4e8-3ae063814acf"), "This is the content of news item 12.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 12" },
                    { new Guid("245b3c4d-ba95-4040-818d-23da69f08e9b"), "This is the content of news item 17.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 17" },
                    { new Guid("5d0bfb1c-d68d-450e-8fe9-e7d94be4eaac"), "This is the content of news item 15.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 15" },
                    { new Guid("650204d7-0be6-4f91-89f7-d80572d4f76a"), "This is the content of news item 4.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 4" },
                    { new Guid("663c5d19-d3ed-4d6a-aff6-3997dd0c43c4"), "This is the content of news item 10.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 10" },
                    { new Guid("6798cf4d-8399-4572-955e-595ddf13f292"), "This is the content of news item 6.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 6" },
                    { new Guid("6e08720f-d73a-4ae1-be83-559dbb96a344"), "This is the content of news item 11.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 11" },
                    { new Guid("7c712eff-f7d8-41af-a36c-9d7ce1439e3b"), "This is the content of news item 2.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 2" },
                    { new Guid("97755739-5cc9-49f7-bcf7-a66765be0571"), "This is the content of news item 20.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 20" },
                    { new Guid("a491e3db-344e-4f16-a051-1ed491901340"), "This is the content of news item 7.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 7" },
                    { new Guid("c0268d79-cfd7-44c3-9b13-709869ae00e2"), "This is the content of news item 8.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 8" },
                    { new Guid("cfc8a241-628f-4fab-acaf-60ffd42f97cd"), "This is the content of news item 3.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 3" },
                    { new Guid("e277ec7f-14cf-47a2-a234-1265920647a4"), "This is the content of news item 18.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 18" },
                    { new Guid("efb06517-4673-4b44-bf11-ee12198c26a7"), "This is the content of news item 1.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 1" },
                    { new Guid("f0c49374-4c7d-464a-9f38-e6f59b20344d"), "This is the content of news item 13.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 13" },
                    { new Guid("f3e39c12-df43-4e2a-b84e-92374739e0e9"), "This is the content of news item 9.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 9" },
                    { new Guid("fb4d071c-c460-4a01-8ee4-9247a97214a6"), "This is the content of news item 19.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "News Title 19" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "NotificationTypeId", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("4f517076-e6c7-43ce-93b6-9aeae4857760"), "Don't miss out on our latest promotions!", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 21, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4273), 2, "Promotion Alert", "" },
                    { new Guid("5754541e-7c1e-4839-8021-963e90f6e4e0"), "Your account details have been updated.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 19, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4281), 1, "Account Notice", "" },
                    { new Guid("86514fb2-c7d5-487c-ba29-371a8c8c825d"), "We are excited to announce a new feature in our application.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 25, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4256), 1, "New Feature Release", "" },
                    { new Guid("931129a9-986f-4560-99f1-a06b692c71a1"), "Please take a moment to complete our user survey.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 20, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4277), 2, "Survey Request", "" },
                    { new Guid("a48b1a4c-83de-4469-a9ec-dbf01ea41ad5"), "Don't forget about the event tomorrow!", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 18, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4285), 1, "Event Reminder", "" },
                    { new Guid("b20db794-17a6-4802-aa6f-7e540e34643b"), "Please update your password to enhance security.", "6c6abe62-f811-4a8b-96eb-ed326c47d209", new DateTime(2024, 6, 24, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4260), 1, "Security Alert", "" },
                    { new Guid("d6dedee7-ab6d-4bfd-bdf7-b3665679cc50"), "The system will be down for maintenance tonight.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 23, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4264), 1, "Downtime Notification", "" },
                    { new Guid("dc42dcc5-b3d1-4bab-8263-bee081234d38"), "Scheduled maintenance will occur this weekend.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 26, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4250), 1, "Maintenance Notice", "" },
                    { new Guid("e331de18-289c-403d-8028-26c4b595587a"), "A new system update will be available tomorrow.", "97571dcc-079e-4c3a-ba9b-bbde3d03a03d", new DateTime(2024, 6, 27, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4237), 1, "System Update", "" },
                    { new Guid("e4455de4-ff95-4957-85a1-b03b8b97f9c3"), "Join weekly meeting.", "a687bb04-4f19-49d5-a60f-2db52044767c", new DateTime(2024, 6, 22, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4270), 2, "Weekly Meeting", "" }
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
                    { new Guid("27f1b969-1b68-4cf8-8a51-c8be5356f7f8"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 26, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(4974), "Development", new DateTime(2024, 6, 26, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4972), new DateTime(2024, 6, 26, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(4973) },
                    { new Guid("37d2c7b3-7406-418d-9062-e81dfff02d9a"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), new DateTime(2024, 6, 27, 15, 34, 32, 636, DateTimeKind.Local).AddTicks(4958), "Testing", new DateTime(2024, 6, 27, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4956), new DateTime(2024, 6, 27, 14, 34, 32, 636, DateTimeKind.Local).AddTicks(4957) },
                    { new Guid("44efa2a7-4f64-4fc6-bbbe-869099817d4f"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"), new DateTime(2024, 6, 28, 15, 34, 32, 636, DateTimeKind.Local).AddTicks(4945), "Testing", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4941), new DateTime(2024, 6, 28, 14, 34, 32, 636, DateTimeKind.Local).AddTicks(4943) },
                    { new Guid("4da0b3f8-95aa-40cd-ab32-75876ca13900"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 26, 19, 34, 32, 636, DateTimeKind.Local).AddTicks(4980), "Development", new DateTime(2024, 6, 26, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4977), new DateTime(2024, 6, 26, 18, 34, 32, 636, DateTimeKind.Local).AddTicks(4978) },
                    { new Guid("4fa30f09-e82a-4375-a28f-8190a8667a09"), "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 22, 19, 34, 32, 636, DateTimeKind.Local).AddTicks(5013), "Development", new DateTime(2024, 6, 22, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(5011), new DateTime(2024, 6, 22, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(5012) },
                    { new Guid("5547314b-521a-47e9-ad60-5e376e686636"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("5947a22f-0191-419c-873b-4324b5b95e84"), new DateTime(2024, 6, 28, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(5087), "Development", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(5085), new DateTime(2024, 6, 28, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(5085) },
                    { new Guid("5b1615a6-b870-456a-a483-e99a3f9122dc"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("11d331b4-136c-4844-a686-ffc38c103268"), new DateTime(2024, 6, 26, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(5069), "Development", new DateTime(2024, 6, 26, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(5067), new DateTime(2024, 6, 26, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(5068) },
                    { new Guid("5dc94e7f-845b-480b-8c81-f1d50c359491"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 25, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(4991), "Development", new DateTime(2024, 6, 25, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4989), new DateTime(2024, 6, 25, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(4990) },
                    { new Guid("6500363e-6574-42e7-8577-6dc87a55ce15"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("eb934470-4e73-41a8-8304-3bcb1ea18502"), new DateTime(2024, 6, 26, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(5097), "Development", new DateTime(2024, 6, 26, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(5095), new DateTime(2024, 6, 26, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(5096) },
                    { new Guid("70f625f4-33f5-4c62-9718-d3e2c420e703"), "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 25, 19, 34, 32, 636, DateTimeKind.Local).AddTicks(4997), "Development", new DateTime(2024, 6, 25, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4995), new DateTime(2024, 6, 25, 18, 34, 32, 636, DateTimeKind.Local).AddTicks(4996) },
                    { new Guid("77153502-8631-4b5f-b05d-76d4796c06d4"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 24, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(5002), "Development", new DateTime(2024, 6, 24, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(5000), new DateTime(2024, 6, 24, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(5001) },
                    { new Guid("77790ba9-1f3c-4943-9e39-097000fc6fa2"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 21, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(5019), "Development", new DateTime(2024, 6, 21, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(5016), new DateTime(2024, 6, 21, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(5017) },
                    { new Guid("80d34442-7c14-4060-ae8f-24cda38e63f9"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 27, 15, 34, 32, 636, DateTimeKind.Local).AddTicks(4986), "Development", new DateTime(2024, 6, 27, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4984), new DateTime(2024, 6, 27, 14, 34, 32, 636, DateTimeKind.Local).AddTicks(4985) },
                    { new Guid("8bb44d07-f470-4434-a023-6bdffb4311cc"), "603600b5-ca65-4fa7-817e-4583ef22b330", new Guid("2bda9dfe-1337-4372-bec0-c4c5e690ff6a"), new DateTime(2024, 6, 23, 19, 34, 32, 636, DateTimeKind.Local).AddTicks(5008), "Development", new DateTime(2024, 6, 23, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(5006), new DateTime(2024, 6, 23, 18, 34, 32, 636, DateTimeKind.Local).AddTicks(5007) },
                    { new Guid("9bfeb5df-03a4-4ae5-904e-1779c19a5313"), "1c5c3b44-7164-4232-a49a-10ab367d5102", new Guid("a1d65f8a-f7fd-4995-940f-6ab254523f90"), new DateTime(2024, 6, 27, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(5092), "Development", new DateTime(2024, 6, 27, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(5090), new DateTime(2024, 6, 27, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(5091) },
                    { new Guid("db1fcaa0-e934-4429-a567-2ac802d0b453"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), new DateTime(2024, 6, 27, 19, 34, 32, 636, DateTimeKind.Local).AddTicks(4969), "Testing", new DateTime(2024, 6, 27, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4967), new DateTime(2024, 6, 27, 18, 34, 32, 636, DateTimeKind.Local).AddTicks(4968) },
                    { new Guid("e0fa81b1-9eea-4b4b-93a7-b7a34aae4014"), "7397c854-194b-4749-9205-f46e4f2fccf8", new Guid("0104f1af-a314-4c64-8b8d-92c72caa97df"), new DateTime(2024, 6, 27, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(4963), "Development", new DateTime(2024, 6, 27, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4961), new DateTime(2024, 6, 27, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(4962) },
                    { new Guid("e377b750-0b20-4943-9e5d-6909d4810f13"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("9eae03ad-745d-47c0-baef-ae4657964e6a"), new DateTime(2024, 6, 28, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(4952), "Development", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(4950), new DateTime(2024, 6, 28, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(4951) },
                    { new Guid("eb607a7a-2572-4a16-bbbd-99f3db25d40b"), "68fdf17c-7cbe-4a4c-a674-c530ffc77667", new Guid("0a395b72-ae0d-4a49-b7f8-1763de733068"), new DateTime(2024, 6, 28, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(5079), "Development", new DateTime(2024, 6, 28, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(5077), new DateTime(2024, 6, 28, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(5078) },
                    { new Guid("ff18bb51-3c4e-4fcb-a73e-39f60996be8c"), "6ad0a020-e6a6-4e66-8f4a-d815594ba862", new Guid("b4dc2d48-482a-48a2-bad6-7a1e0e3139b7"), new DateTime(2024, 6, 27, 17, 34, 32, 636, DateTimeKind.Local).AddTicks(5075), "Development", new DateTime(2024, 6, 27, 13, 34, 32, 636, DateTimeKind.Local).AddTicks(5073), new DateTime(2024, 6, 27, 16, 34, 32, 636, DateTimeKind.Local).AddTicks(5073) }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "AccountId", "Description", "DeviceStatusId", "ScheduleId" },
                values: new object[,]
                {
                    { new Guid("06a6fcd7-eb30-4728-9856-ee8d00f84810"), null, "Designer's tablet updated with latest design apps.", 1, new Guid("5b1615a6-b870-456a-a483-e99a3f9122dc") },
                    { new Guid("0e287e15-6c9f-44ab-9fb3-dc183f5e5e92"), null, "Network switch configuration updated.", 1, new Guid("5dc94e7f-845b-480b-8c81-f1d50c359491") },
                    { new Guid("19f6bcc1-2a8d-4c5d-ab3b-d5d3b21da159"), null, "Network switch maintenance and inspection.", 2, new Guid("eb607a7a-2572-4a16-bbbd-99f3db25d40b") },
                    { new Guid("285ce1fd-470c-4474-ad1b-ba273c0e8653"), null, "Printer serviced and toner replaced.", 1, new Guid("27f1b969-1b68-4cf8-8a51-c8be5356f7f8") },
                    { new Guid("426c57ce-68aa-498b-b603-16cf1e7a238d"), null, "Monitor calibrated for color accuracy.", 1, new Guid("db1fcaa0-e934-4429-a567-2ac802d0b453") },
                    { new Guid("5e2385b4-08f6-4e9e-888b-5d94c4b7fb78"), null, "The desktop was used for backend development tasks.", 2, new Guid("6500363e-6574-42e7-8577-6dc87a55ce15") },
                    { new Guid("5faf118e-4687-47c2-9b83-ecb389b8b6d5"), null, "Router settings optimized for network traffic.", 1, new Guid("8bb44d07-f470-4434-a023-6bdffb4311cc") },
                    { new Guid("697817b7-9d65-47dd-a39b-909f89e25bce"), null, "The desktop was used for backend development tasks.", 1, new Guid("5547314b-521a-47e9-ad60-5e376e686636") },
                    { new Guid("75fb870f-e344-40c9-ab85-101631f22505"), null, "Device was used for setting up a new development environment.", 1, new Guid("44efa2a7-4f64-4fc6-bbbe-869099817d4f") },
                    { new Guid("76199946-58bd-473a-95a7-9da8afcb9fc7"), null, "Desktop setup for new project development.", 1, new Guid("4fa30f09-e82a-4375-a28f-8190a8667a09") },
                    { new Guid("78d4e5bd-d685-49b5-8b12-e71df921ec65"), null, "Server performance was monitored during load testing.", 1, new Guid("70f625f4-33f5-4c62-9718-d3e2c420e703") },
                    { new Guid("8455c9b0-c2ca-4de4-bdee-3070dc8af954"), null, "The desktop was used for backend development tasks.", 1, new Guid("e0fa81b1-9eea-4b4b-93a7-b7a34aae4014") },
                    { new Guid("b774e795-3469-4b58-afe0-5f6e9e0a6aec"), null, "The desktop was used for backend development tasks.", 2, new Guid("9bfeb5df-03a4-4ae5-904e-1779c19a5313") },
                    { new Guid("b9d04c5f-2ec0-4da1-92ab-7ef9bdcd82e4"), null, "Developer's laptop used for bug fixing.", 2, new Guid("77153502-8631-4b5f-b05d-76d4796c06d4") },
                    { new Guid("c8fb056c-cff8-4db2-b951-01859431a35e"), null, "Router firmware was updated and tested.", 1, new Guid("37d2c7b3-7406-418d-9062-e81dfff02d9a") },
                    { new Guid("cf4dfffd-74e9-46dd-b9b5-2a9d09001564"), null, "Projector used for team meeting presentations.", 1, new Guid("ff18bb51-3c4e-4fcb-a73e-39f60996be8c") },
                    { new Guid("d3b039bd-813c-4b33-af98-2264dcb440c0"), null, "The laptop was utilized for testing the latest software build.", 2, new Guid("e377b750-0b20-4943-9e5d-6909d4810f13") },
                    { new Guid("dd8ac1ac-0f4f-45af-825e-e74e531b66dc"), null, "Tablet used for sketching new UI designs.", 1, new Guid("4da0b3f8-95aa-40cd-ab32-75876ca13900") },
                    { new Guid("e4880a12-6d1d-4e9b-8832-89c5982b1346"), null, "High-resolution monitor tested with graphic design software.", 2, new Guid("77790ba9-1f3c-4943-9e39-097000fc6fa2") },
                    { new Guid("f1dcaea6-1670-47d7-b8cb-398b89ca09d0"), null, "Projector used in a client presentation.", 1, new Guid("80d34442-7c14-4060-ae8f-24cda38e63f9") }
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
                name: "IX_Reports_AccountId",
                table: "Reports",
                column: "AccountId");

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
                name: "IX_Tasks_PredecessorTaskId",
                table: "Tasks",
                column: "PredecessorTaskId");

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
