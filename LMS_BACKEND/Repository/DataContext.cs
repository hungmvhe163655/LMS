using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;


namespace Repository
{
    public class DataContext : IdentityDbContext<Account>
    {
        public DataContext(DbContextOptions options)
        : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceStatus> DeviceStatuses { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<FolderClosure> FoldersClosure { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsFile> newsFiles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationAccount> notificationAccounts { get; set; }
        public DbSet<NotificationType> notificationTypes { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        //public DbSet<Setting> Settings { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<NewsFile> NewsFiles { get; set; }
        public DbSet<TaskPriorities> TaskPriorities { get; set; }
        public DbSet<TasksStatus> TaskStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable("Account");
                entity.Property(e => e.Id).HasColumnName("Id");
            });
            */

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("AccountRoles");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("AccountLogins");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("AccountClaims");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("SystemRole");
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("AccountToken");
            });
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fullname");
                entity.Property(e => e.EmailVerifyCode)
                    .HasMaxLength(6)
                    .HasColumnName("EmailVerifyCode");
                entity.Property(e => e.EmailVerifyCodeAge).HasColumnName("EmailVerifyCodeAge");
                entity.Property(e => e.Gender).HasColumnName("gender");
                entity.Property(e => e.isBanned).HasColumnName("isBanned");
                entity.Property(e => e.isDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.VerifiedBy).HasColumnName("verifiedBy");

                entity.HasOne(d => d.VerifiedByUser).WithMany(p => p.VerifiedAccounts)
                    .HasForeignKey(d => d.VerifiedBy)
                    .HasConstraintName("FK_Accounts_Accounts");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("content");
                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
                entity.Property(e => e.ParentId).HasColumnName("parentId");
                entity.Property(e => e.TaskId).HasColumnName("taskId");

                entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Accounts");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Comments_Comments");

                entity.HasOne(d => d.Task).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Tasks");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.DeviceStatusId).HasColumnName("deviceStatusId");
                entity.Property(e => e.LastUsed).HasColumnName("lastUsed");
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.OwnedBy).HasColumnName("ownedBy");

                entity.HasOne(d => d.DeviceStatus).WithMany(p => p.Devices)
                    .HasForeignKey(d => d.DeviceStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devices_DeviceStatuses");

                entity.HasOne(d => d.OwnedByUser).WithMany(p => p.Devices)
                    .HasForeignKey(d => d.OwnedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devices_Accounts");
            });

            modelBuilder.Entity<DeviceStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.FileKey)
                    .HasMaxLength(500)
                    .HasColumnName("fileKey");
                entity.Property(e => e.FolderId).HasColumnName("folderId");
                entity.Property(e => e.MimeType)
                    .HasMaxLength(20)
                    .HasColumnName("mimeType");
                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name");
                entity.Property(e => e.Size).HasColumnName("size");
                entity.Property(e => e.UploadDate).HasColumnName("uploadDate");

                entity.HasOne(d => d.Folder).WithMany(p => p.Files)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Files_Folders");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Folders)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Folders_Accounts");
            });

            modelBuilder.Entity<FolderClosure>(entity =>
            {
                entity.HasKey(e => new { e.AncestorID, e.DescendantID });

                entity.Property(e => e.AncestorID).HasColumnName("ancestor");
                entity.Property(e => e.DescendantID).HasColumnName("descendant");
                entity.Property(e => e.Depth).HasColumnName("depth");

                entity.HasOne(d => d.AncestorNavigation).WithMany(p => p.FolderClosureAncestor)
                    .HasForeignKey(d => d.AncestorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FolderClosures_Folders");

                entity.HasOne(d => d.DescendantNavigation).WithMany(p => p.FolderClosureDescendant)
                    .HasForeignKey(d => d.DescendantID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FolderClosures_Folders1");
            });

            modelBuilder.Entity<Label>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.HexColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("hexColor");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.UserId });

                entity.Property(e => e.ProjectId).HasColumnName("projectId");
                entity.Property(e => e.UserId).HasColumnName("userId");
                entity.Property(e => e.IsLeader).HasColumnName("isLeader");

                entity.HasOne(d => d.Project).WithMany(p => p.Members)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_Projects");

                entity.HasOne(d => d.User).WithMany(p => p.Members)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_Accounts");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Content).HasColumnName("content");
                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.News)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_News_Accounts");
            });

            modelBuilder.Entity<NewsFile>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_NewsFiles_1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.FileKey)
                    .HasMaxLength(500)
                    .HasColumnName("fileKey");
                entity.Property(e => e.NewsID).HasColumnName("newsId");

                entity.HasOne(d => d.News).WithMany(p => p.NewsFiles)
                    .HasForeignKey(d => d.NewsID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewsFiles_News1");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Content)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("content");
                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
                entity.Property(e => e.NotificationTypeId).HasColumnName("notificationTypeId");
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");
                entity.Property(e => e.Url)
                    .HasMaxLength(2048)
                    .HasColumnName("url");

                entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Notifications_Accounts");

                entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.NotificationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_NotificationTypes");
            });

            modelBuilder.Entity<NotificationType>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<NotificationAccount>(entity =>
            {
                entity.HasKey(e => new { e.NotificationId, e.AccountId });

                entity.Property(e => e.NotificationId).HasColumnName("notificationId");
                entity.Property(e => e.AccountId).HasColumnName("accountId");
                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.HasOne(d => d.Account).WithMany(p => p.NotificationsAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationsAccounts_Accounts");

                entity.HasOne(d => d.Notification).WithMany(p => p.NotificationsAccounts)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationsAccounts_Notifications");
            });
            /*
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });
            */
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("description");
                entity.Property(e => e.IsRecruiting)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("isRecruiting");
                entity.Property(e => e.MaxMember).HasColumnName("maxMember");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.ProjectStatusId).HasColumnName("projectStatusId");
                entity.Property(e => e.ProjectTypeId).HasColumnName("projectTypeId");

                entity.HasOne(d => d.ProjectStatus).WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_ProjectStatuses");

                entity.HasOne(d => d.ProjectType).WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_ProjectTypes");
                /*
                entity.HasMany(d => d.Permissions).WithMany(p => p.Projects)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectsPermission",
                        r => r.HasOne<Permission>().WithMany()
                            .HasForeignKey("PermissionId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_ProjectsPermissions_Permissions"),
                        l => l.HasOne<Project>().WithMany()
                            .HasForeignKey("ProjectId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_ProjectsPermissions_Projects"),
                        j =>
                        {
                            j.HasKey("ProjectId", "PermissionId");
                            j.ToTable("ProjectsPermissions");
                            j.IndexerProperty<Guid>("ProjectId").HasColumnName("projectId");
                            j.IndexerProperty<int>("PermissionId").HasColumnName("permissionId");
                        });
                
                entity.HasMany(d => d.Settings).WithMany(p => p.Projects)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectsSetting",
                        r => r.HasOne<Setting>().WithMany()
                            .HasForeignKey("SettingId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_ProjectsSettings_Settings"),
                        l => l.HasOne<Project>().WithMany()
                            .HasForeignKey("ProjectId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_ProjectsSettings_Projects"),
                        j =>
                        {
                            j.HasKey("ProjectId", "SettingId");
                            j.ToTable("ProjectsSettings");
                            j.IndexerProperty<Guid>("ProjectId").HasColumnName("projectId");
                            j.IndexerProperty<int>("SettingId").HasColumnName("settingId");
                        });
                */
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.HasOne(d => d.Schedules)
                    .WithOne(p => p.Report)
                    .HasForeignKey<Report>(d => d.ScheduleId) 
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reports_Schedules");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.Id); 

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DeviceId).HasColumnName("deviceId");
                entity.Property(e => e.AccountId).HasColumnName("accountId");
                entity.Property(e => e.EndDate).HasColumnName("endDate");
                entity.Property(e => e.Purpose)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("purpose");
                entity.Property(e => e.StartDate).HasColumnName("startDate");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedules_Accounts");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedules_Devices");
            });
            /*
            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });
            */

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("accountId");
                entity.Property(e => e.Major)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("major");
                entity.Property(e => e.RollNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("rollNumber");
                entity.Property(e => e.Specialized)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("specialized");

                entity.HasOne(d => d.Account).WithOne(p => p.StudentDetail)
                    .HasForeignKey<StudentDetail>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentDetails_Accounts");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.AssignedTo).HasColumnName("assignedTo");
                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
                entity.Property(e => e.DueDate).HasColumnName("dueDate");
                entity.Property(e => e.PredecessorTaskId).HasColumnName("predecessorTaskId");
                entity.Property(e => e.RequiredValidation).HasColumnName("requiresValidation");
                entity.Property(e => e.StartDate).HasColumnName("startDate");
                entity.Property(e => e.TaskListId).HasColumnName("taskListId");
                entity.Property(e => e.TaskPriorityId).HasColumnName("taskPriorityId");
                entity.Property(e => e.TaskStatusId).HasColumnName("taskStatusId");
                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .HasColumnName("title");

                entity.HasOne(d => d.AssignedToUser).WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("FK_Tasks_Accounts");

                entity.HasOne(d => d.PredecessorTask).WithMany(p => p.InversePredecessorTask)
                    .HasForeignKey(d => d.PredecessorTaskId)
                    .HasConstraintName("FK_Tasks_Tasks");

                entity.HasOne(d => d.TaskList).WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_TaskLists");

                entity.HasOne(d => d.TaskPriority).WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskPriorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_TaskPrioties");

                entity.HasOne(d => d.TaskStatus).WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_TaskStatus");
//////////////////////////////////////////////
                entity.HasMany(d => d.Accounts).WithMany(p => p.TasksCurrent)
                    .UsingEntity<Dictionary<string, object>>(
                        "TasksAccount",

                        r => r.HasOne<Account>().WithMany()
                            .HasForeignKey("AccountId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TasksAccounts_Accounts"),
                        l => l.HasOne<Tasks>().WithMany()
                            .HasForeignKey("TaskId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TasksAccounts_Tasks"),
 
                        j =>
                        {
                            j.HasKey("TaskId", "AccountId");
                            j.ToTable("TasksAccounts");
                            j.IndexerProperty<Guid>("TaskId").HasColumnName("taskId");
                            j.IndexerProperty<string>("AccountId").HasColumnName("accountId");
                        });
////////////////////////////////////////////////
                entity.HasMany(d => d.Files).WithMany(p => p.Tasks)
                    .UsingEntity<Dictionary<string, object>>(
                        "TasksFile",
                        r => r.HasOne<Files>().WithMany()
                            .HasForeignKey("FileId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TasksFiles_Files"),
                        l => l.HasOne<Tasks>().WithMany()
                            .HasForeignKey("TaskId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TasksFiles_Tasks"),
                        j =>
                        {
                            j.HasKey("TaskId", "FileId");
                            j.ToTable("TasksFiles");
                            j.IndexerProperty<Guid>("TaskId").HasColumnName("taskId");
                            j.IndexerProperty<Guid>("FileId").HasColumnName("fileId");
                        });

                entity.HasMany(d => d.Labels).WithMany(p => p.Tasks)
                    .UsingEntity<Dictionary<string, object>>(
                        "TasksLabel",
                        r => r.HasOne<Label>().WithMany()
                            .HasForeignKey("LabelId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TasksLabels_Labels"),
                        l => l.HasOne<Tasks>().WithMany()
                            .HasForeignKey("TaskId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TasksLabels_Tasks"),
                        j =>
                        {
                            j.HasKey("TaskId", "LabelId");
                            j.ToTable("TasksLabels");
                            j.IndexerProperty<Guid>("TaskId").HasColumnName("taskId");
                            j.IndexerProperty<Guid>("LabelId").HasColumnName("labelId");
                        });
            });
            modelBuilder.Entity<TaskHistory>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.TaskGuid).HasColumnName("taskGuid");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.RequiredValidation).HasColumnName("requiresValidation");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.EditDate).HasColumnName("editDate");
                entity.Property(e => e.StartDate).HasColumnName("startDate");
                entity.Property(e => e.DueDate).HasColumnName("dueDate");
                entity.Property(e => e.TaskPriorityId).HasColumnName("taskPriorityId");
                entity.Property(e => e.TaskStatusId).HasColumnName("taskStatusId");

                entity.HasOne(d => d.TaskPriority).WithMany()
                    .HasForeignKey(d => d.TaskPriorityId)
                    .HasConstraintName("FK_TaskHistories_TaskPrioties");

                entity.HasOne(d => d.TaskStatus).WithMany()
                    .HasForeignKey(d => d.TaskStatusId)
                    .HasConstraintName("FK_TaskHistories_TaskStatus");
//////////////////////////////////////////////
///
            /*
                entity.HasMany(d => d.Accounts).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "TaskHistoriesAccounts",

                        r => r.HasOne<Account>().WithMany()
                            .HasForeignKey("AccountId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TaskHistoriesAccounts_Accounts"),
                        l => l.HasOne<TaskHistory>().WithMany()
                            .HasForeignKey("TaskHistoryId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TaskHistoriesAccounts_TaskHistories"),

                        j =>
                        {
                            j.HasKey("TaskHistoryId", "AccountId");
                            j.ToTable("TaskHistoriesAccounts");
                            j.IndexerProperty<Guid>("TaskHistoryId").HasColumnName("taskHistoryId");
                            j.IndexerProperty<string>("AccountId").HasColumnName("accountId");
                        });
                */
/////////////////////////////////////////////////////////////
                entity.HasMany(d => d.Labels).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "TaskHistoriesLabels",
                        r => r.HasOne<Label>().WithMany()
                            .HasForeignKey("LabelId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TaskHistoriesLabels_Labels"),
                        l => l.HasOne<TaskHistory>().WithMany()
                            .HasForeignKey("TaskHistoryId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TaskHistoriesLabels_TaskHistories"),
                        j =>
                        {
                            j.HasKey("TaskHistoryId", "LabelId");
                            j.ToTable("TaskHistoriesLabels");
                            j.IndexerProperty<Guid>("TaskHistoryId").HasColumnName("taskHistoryId");
                            j.IndexerProperty<Guid>("LabelId").HasColumnName("labelId");
                        });

                entity.HasOne(d => d.TaskVersion).WithMany()
                    .HasForeignKey(d => d.TaskGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskHistories_Tasks");
            });

            modelBuilder.Entity<TaskList>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.MaxTasks).HasColumnName("maxTasks");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.HasOne(d => d.Project).WithMany(p => p.TaskLists)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskLists_Projects");
            });

            modelBuilder.Entity<TaskPriorities>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TasksStatus>(entity =>
            {
                entity.ToTable("TaskStatus");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

    }
}
