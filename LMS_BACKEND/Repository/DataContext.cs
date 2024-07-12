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
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationAccount> NotificationAccounts { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskClosure> TaskClosure { get; set; }
        public DbSet<NewsFile> NewsFiles { get; set; }
        public DbSet<TaskPriorities> TaskPriorities { get; set; }
        public DbSet<TasksStatus> TaskStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode()
                    .HasColumnName("FullName");
                entity.Property(e => e.EmailVerifyCode)
                    .HasMaxLength(6)
                    .HasColumnName("EmailVerifyCode");
                entity.Property(e => e.EmailVerifyCodeAge).HasColumnName("EmailVerifyCodeAge");
                entity.Property(e => e.Gender).HasColumnName("Gender");
                entity.Property(e => e.IsBanned).HasColumnName("IsBanned");
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted");
                entity.Property(e => e.IsVerified).HasColumnName("IsVerified");
                entity.Property(e => e.VerifiedBy).HasColumnName("VerifiedBy");

                entity.HasOne(d => d.VerifiedByUser).WithMany(p => p.VerifiedAccounts)
                    .HasForeignKey(d => d.VerifiedBy)
                    .HasConstraintName("FK_Accounts_Accounts");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Content");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy");
                entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
                entity.Property(e => e.ParentId).HasColumnName("ParentId");
                entity.Property(e => e.TaskId).HasColumnName("TaskId");

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
                    .HasColumnName("Id");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.DeviceStatusId).HasColumnName("DeviceStatusId");
                entity.Property(e => e.LastUsed).HasColumnName("LastUsed");
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Name");
                entity.Property(e => e.OwnedBy).HasColumnName("OwnedBy");

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
                    .HasColumnName("Id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.FileKey)
                    .HasMaxLength(500)
                    .HasColumnName("FileKey");
                entity.Property(e => e.FolderId).HasColumnName("FolderId");
                entity.Property(e => e.MimeType)
                    .HasMaxLength(20)
                    .HasColumnName("MimeType");
                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("Name");
                entity.Property(e => e.Size).HasColumnName("Size");
                entity.Property(e => e.UploadDate).HasColumnName("UploadDate");

                entity.HasOne(d => d.Folder).WithMany(p => p.Files)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Files_Folders");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy");
                entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
                entity.Property(e => e.LastModifiedDate).HasColumnName("LastModifiedDate");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("Name");

                entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Folders)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Folders_Accounts");
            });

            modelBuilder.Entity<FolderClosure>(entity =>
            {
                entity.HasKey(e => new { e.AncestorID, e.DescendantID });

                entity.Property(e => e.AncestorID).HasColumnName("Ancestor");
                entity.Property(e => e.DescendantID).HasColumnName("Descendant");
                entity.Property(e => e.Depth).HasColumnName("Depth");

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
                    .HasColumnName("Id");
                entity.Property(e => e.HexColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("HexColor");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.UserId });

                entity.Property(e => e.ProjectId).HasColumnName("ProjectId");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.IsLeader).HasColumnName("IsLeader");
                entity.Property(e => e.JoinDate).HasColumnName("JoinDate");

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
                    .HasColumnName("Id");
                entity.Property(e => e.Content).HasColumnName("Content")
                .IsUnicode();
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy");
                entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode()
                    .HasColumnName("Title");

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
                    .HasColumnName("Id");
                entity.Property(e => e.FileKey)
                    .HasMaxLength(500)
                    .HasColumnName("FileKey");
                entity.Property(e => e.NewsID).HasColumnName("NewsId");

                entity.HasOne(d => d.News).WithMany(p => p.NewsFiles)
                    .HasForeignKey(d => d.NewsID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewsFiles_News1");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.Content)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Content");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy");
                entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
                entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeId");
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Title");
                entity.Property(e => e.Url)
                    .HasMaxLength(2048)
                    .HasColumnName("Url");

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
                    .HasColumnName("Id");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<NotificationAccount>(entity =>
            {
                entity.HasKey(e => new { e.NotificationId, e.AccountId });

                entity.Property(e => e.NotificationId).HasColumnName("NotificationId");
                entity.Property(e => e.AccountId).HasColumnName("AccountId");
                entity.Property(e => e.IsRead).HasColumnName("IsRead");

                entity.HasOne(d => d.Account).WithMany(p => p.NotificationsAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationsAccounts_Accounts");

                entity.HasOne(d => d.Notification).WithMany(p => p.NotificationsAccounts)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationsAccounts_Notifications");
            });
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("Description");
                entity.Property(e => e.IsRecruiting)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("IsRecruiting");
                entity.Property(e => e.MaxMember).HasColumnName("MaxMember");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("Name");
                entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusId");
                entity.Property(e => e.ProjectTypeId).HasColumnName("ProjectTypeId");

                entity.HasOne(d => d.ProjectStatus).WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_ProjectStatuses");

                entity.HasOne(d => d.ProjectType).WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_ProjectTypes");
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                entity.HasOne(d => d.Schedules)
                    .WithOne(p => p.Report)
                    .HasForeignKey<Report>(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reports_Schedules");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.DeviceId).HasColumnName("DeviceId");
                entity.Property(e => e.AccountId).HasColumnName("AccountId");
                entity.Property(e => e.EndDate).HasColumnName("EndDate");
                entity.Property(e => e.Purpose)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Purpose");
                entity.Property(e => e.StartDate).HasColumnName("StartDate");

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

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountId");
                entity.Property(e => e.Major)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Major");
                entity.Property(e => e.RollNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RollNumber");
                entity.Property(e => e.Specialized)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Specialized");

                entity.HasOne(d => d.Account).WithOne(p => p.StudentDetail)
                    .HasForeignKey<StudentDetail>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentDetails_Accounts");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.AssignedTo).HasColumnName("AssignedTo");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy");
                entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
                entity.Property(e => e.DueDate).HasColumnName("DueDate");
                entity.Property(e => e.RowVersion).IsRowVersion();
                entity.Property(e => e.RequiredValidation).HasColumnName("RequiresValidation");
                entity.Property(e => e.StartDate).HasColumnName("StartDate");
                entity.Property(e => e.TaskListId).HasColumnName("TaskListId");
                entity.Property(e => e.TaskPriorityId).HasColumnName("TaskPriorityId");
                entity.Property(e => e.TaskStatusId).HasColumnName("TaskStatusId");
                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .HasColumnName("Title");

                entity.HasOne(d => d.AssignedToUser).WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("FK_Tasks_Accounts");

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
                            j.IndexerProperty<Guid>("TaskId").HasColumnName("TaskId");
                            j.IndexerProperty<string>("AccountId").HasColumnName("AccountId");
                        });
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
                            j.IndexerProperty<Guid>("TaskId").HasColumnName("TaskId");
                            j.IndexerProperty<Guid>("FileId").HasColumnName("FileId");
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
                            j.IndexerProperty<Guid>("TaskId").HasColumnName("TaskId");
                            j.IndexerProperty<Guid>("LabelId").HasColumnName("LabelId");
                        });
            });
            modelBuilder.Entity<TaskClosure>(entity =>
            {
                entity.HasKey(e => new { e.AncestorID, e.DescendantID });

                entity.Property(e => e.AncestorID).HasColumnName("Ancestor");
                entity.Property(e => e.DescendantID).HasColumnName("Descendant");
                entity.Property(e => e.Depth).HasColumnName("Depth");

                entity.HasOne(d => d.AncestorTaskNavigation).WithMany(p => p.TaskClosuresAncestor)
                    .HasForeignKey(d => d.AncestorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskClosures_Task");

                entity.HasOne(d => d.DescendantTaskNavigation).WithMany(p => p.TaskClosuresDescendant)
                    .HasForeignKey(d => d.DescendantID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskClosures_Task1");
            });
            modelBuilder.Entity<TaskHistory>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                entity.Property(e => e.TaskGuid).HasColumnName("TaskGuid");
                entity.Property(e => e.Title).HasColumnName("Title");
                entity.Property(e => e.RequiredValidation).HasColumnName("RequiresValidation");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.EditDate).HasColumnName("EditDate");
                entity.Property(e => e.StartDate).HasColumnName("StartDate");
                entity.Property(e => e.DueDate).HasColumnName("DueDate");
                entity.Property(e => e.TaskPriorityId).HasColumnName("TaskPriorityId");
                entity.Property(e => e.TaskStatusId).HasColumnName("TaskStatusId");

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
                            j.IndexerProperty<Guid>("TaskHistoryId").HasColumnName("TaskHistoryId");
                            j.IndexerProperty<Guid>("LabelId").HasColumnName("LabelId");
                        });

                entity.HasOne(d => d.TaskVersion).WithMany()
                    .HasForeignKey(d => d.TaskGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskHistories_Tasks");
                
                entity.HasOne(d => d.AssignedToUser).WithMany(p => p.TaskHistories)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("FK_TasksHistory_Accounts");
            });

            modelBuilder.Entity<TaskList>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.MaxTasks).HasColumnName("MaxTasks");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("Name");
                entity.Property(e => e.ProjectId).HasColumnName("ProjectId");

                entity.HasOne(d => d.Project).WithMany(p => p.TaskLists)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskLists_Projects");
            });

            modelBuilder.Entity<TaskPriorities>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<TasksStatus>(entity =>
            {
                entity.ToTable("TaskStatus");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("Name");
            });
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.SeedData();
        }
    }
}
