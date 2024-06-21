using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS_BACKEND_MAIN.Migrations
{
    /// <inheritdoc />
    public partial class lemo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fullname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    verifiedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    isBanned = table.Column<bool>(type: "bit", nullable: false),
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
                        column: x => x.verifiedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeviceStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceStatuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    hexColor = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notificationTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificationTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.id);
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
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPriorities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.id);
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
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Folders_Accounts",
                        column: x => x.createdBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.id);
                    table.ForeignKey(
                        name: "FK_News_Accounts",
                        column: x => x.createdBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    accountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    major = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    specialized = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    rollNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.accountId);
                    table.ForeignKey(
                        name: "FK_StudentDetails_Accounts",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deviceStatusId = table.Column<int>(type: "int", nullable: false),
                    ownedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.id);
                    table.ForeignKey(
                        name: "FK_Devices_Accounts",
                        column: x => x.ownedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Devices_DeviceStatuses",
                        column: x => x.deviceStatusId,
                        principalTable: "DeviceStatuses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    content = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    notificationTypeId = table.Column<int>(type: "int", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notifications_Accounts",
                        column: x => x.createdBy,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTypes",
                        column: x => x.notificationTypeId,
                        principalTable: "notificationTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projectStatusId = table.Column<int>(type: "int", nullable: false),
                    maxMember = table.Column<int>(type: "int", nullable: false),
                    isRecruiting = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    projectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectStatuses",
                        column: x => x.projectStatusId,
                        principalTable: "ProjectStatuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Projects_ProjectTypes",
                        column: x => x.projectTypeId,
                        principalTable: "ProjectTypes",
                        principalColumn: "id");
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
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    size = table.Column<float>(type: "real", nullable: false),
                    fileKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    folderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    uploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mimeType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.id);
                    table.ForeignKey(
                        name: "FK_Files_Folders",
                        column: x => x.folderId,
                        principalTable: "Folders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "FoldersClosure",
                columns: table => new
                {
                    ancestor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descendant = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    depth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoldersClosure", x => new { x.ancestor, x.descendant });
                    table.ForeignKey(
                        name: "FK_FolderClosures_Folders",
                        column: x => x.ancestor,
                        principalTable: "Folders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FolderClosures_Folders1",
                        column: x => x.descendant,
                        principalTable: "Folders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NewsFile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    fileKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    newsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFiles_1", x => x.id);
                    table.ForeignKey(
                        name: "FK_NewsFiles_News1",
                        column: x => x.newsId,
                        principalTable: "News",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    purpose = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_Schedules_Accounts",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedules_Devices",
                        column: x => x.deviceId,
                        principalTable: "Devices",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "notificationAccounts",
                columns: table => new
                {
                    notificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificationAccounts", x => new { x.notificationId, x.accountId });
                    table.ForeignKey(
                        name: "FK_NotificationsAccounts_Accounts",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationsAccounts_Notifications",
                        column: x => x.notificationId,
                        principalTable: "Notifications",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    projectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isLeader = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => new { x.projectId, x.userId });
                    table.ForeignKey(
                        name: "FK_Members_Accounts",
                        column: x => x.userId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Projects",
                        column: x => x.projectId,
                        principalTable: "Projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PermissionProject",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionProject", x => new { x.PermissionsId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_PermissionProject_Permission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskLists",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    maxTasks = table.Column<int>(type: "int", nullable: false),
                    projectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLists", x => x.id);
                    table.ForeignKey(
                        name: "FK_TaskLists_Projects",
                        column: x => x.projectId,
                        principalTable: "Projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceStatusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reports_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_Schedules",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    predecessorTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    requiresValidation = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    taskPriorityId = table.Column<int>(type: "int", nullable: false),
                    taskListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    taskStatusId = table.Column<int>(type: "int", nullable: false),
                    assignedTo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tasks_Accounts",
                        column: x => x.assignedTo,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_TaskLists",
                        column: x => x.taskListId,
                        principalTable: "TaskLists",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Tasks_TaskPrioties",
                        column: x => x.taskPriorityId,
                        principalTable: "TaskPriorities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Tasks_TaskStatus",
                        column: x => x.taskStatusId,
                        principalTable: "TaskStatus",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks",
                        column: x => x.predecessorTaskId,
                        principalTable: "Tasks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    content = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    parentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    taskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Accounts",
                        column: x => x.createdBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Comments",
                        column: x => x.parentId,
                        principalTable: "Comments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Comments_Tasks",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TaskHistories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    taskGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requiresValidation = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    editDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    taskPriorityId = table.Column<int>(type: "int", nullable: false),
                    taskStatusId = table.Column<int>(type: "int", nullable: false),
                    AssignedToUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TasksId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHistories", x => x.id);
                    table.ForeignKey(
                        name: "FK_TaskHistories_Account_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskHistories_TaskPrioties",
                        column: x => x.taskPriorityId,
                        principalTable: "TaskPriorities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskHistories_TaskStatus",
                        column: x => x.taskStatusId,
                        principalTable: "TaskStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskHistories_Tasks",
                        column: x => x.taskGuid,
                        principalTable: "Tasks",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TaskHistories_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TasksAccounts",
                columns: table => new
                {
                    taskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksAccounts", x => new { x.taskId, x.accountId });
                    table.ForeignKey(
                        name: "FK_TasksAccounts_Accounts",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TasksAccounts_Tasks",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TasksFiles",
                columns: table => new
                {
                    taskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksFiles", x => new { x.taskId, x.fileId });
                    table.ForeignKey(
                        name: "FK_TasksFiles_Files",
                        column: x => x.fileId,
                        principalTable: "Files",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TasksFiles_Tasks",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TasksLabels",
                columns: table => new
                {
                    taskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    labelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksLabels", x => new { x.taskId, x.labelId });
                    table.ForeignKey(
                        name: "FK_TasksLabels_Labels",
                        column: x => x.labelId,
                        principalTable: "Labels",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TasksLabels_Tasks",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TaskHistoriesLabels",
                columns: table => new
                {
                    taskHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    labelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHistoriesLabels", x => new { x.taskHistoryId, x.labelId });
                    table.ForeignKey(
                        name: "FK_TaskHistoriesLabels_Labels",
                        column: x => x.labelId,
                        principalTable: "Labels",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TaskHistoriesLabels_TaskHistories",
                        column: x => x.taskHistoryId,
                        principalTable: "TaskHistories",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "SystemRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c55924f5-4cf4-4a29-9820-b5d0d9bdf3c5", null, "LabLead", "LABADMIN" },
                    { "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2", null, "Teacher", "SUPERVISOR" },
                    { "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d", null, "Student", "STUDENT" }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Account",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Account_verifiedBy",
                table: "Account",
                column: "verifiedBy");

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
                name: "IX_Comments_createdBy",
                table: "Comments",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_parentId",
                table: "Comments",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_taskId",
                table: "Comments",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_deviceStatusId",
                table: "Devices",
                column: "deviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ownedBy",
                table: "Devices",
                column: "ownedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Files_folderId",
                table: "Files",
                column: "folderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_createdBy",
                table: "Folders",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_FoldersClosure_descendant",
                table: "FoldersClosure",
                column: "descendant");

            migrationBuilder.CreateIndex(
                name: "IX_Members_userId",
                table: "Members",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_News_createdBy",
                table: "News",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFile_newsId",
                table: "NewsFile",
                column: "newsId");

            migrationBuilder.CreateIndex(
                name: "IX_notificationAccounts_accountId",
                table: "notificationAccounts",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_createdBy",
                table: "Notifications",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_notificationTypeId",
                table: "Notifications",
                column: "notificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionProject_ProjectsId",
                table: "PermissionProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_projectStatusId",
                table: "Projects",
                column: "projectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_projectTypeId",
                table: "Projects",
                column: "projectTypeId");

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
                name: "IX_Schedules_accountId",
                table: "Schedules",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_deviceId",
                table: "Schedules",
                column: "deviceId");

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
                name: "IX_TaskHistories_taskGuid",
                table: "TaskHistories",
                column: "taskGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_taskPriorityId",
                table: "TaskHistories",
                column: "taskPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_TasksId",
                table: "TaskHistories",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_taskStatusId",
                table: "TaskHistories",
                column: "taskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistoriesLabels_labelId",
                table: "TaskHistoriesLabels",
                column: "labelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLists_projectId",
                table: "TaskLists",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_assignedTo",
                table: "Tasks",
                column: "assignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_predecessorTaskId",
                table: "Tasks",
                column: "predecessorTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_taskListId",
                table: "Tasks",
                column: "taskListId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_taskPriorityId",
                table: "Tasks",
                column: "taskPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_taskStatusId",
                table: "Tasks",
                column: "taskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksAccounts_accountId",
                table: "TasksAccounts",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksFiles_fileId",
                table: "TasksFiles",
                column: "fileId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksLabels_labelId",
                table: "TasksLabels",
                column: "labelId");
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
                name: "NewsFile");

            migrationBuilder.DropTable(
                name: "notificationAccounts");

            migrationBuilder.DropTable(
                name: "PermissionProject");

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
                name: "Permission");

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
                name: "notificationTypes");

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
