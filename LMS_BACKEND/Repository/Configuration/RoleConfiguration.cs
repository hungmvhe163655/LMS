using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
             new IdentityRole
             {
                 Id = "c55924f5-4cf4-4a29-9820-b5d0d9bdf3c5",
                 Name = "LabAdmin",
                 NormalizedName = "LABADMIN"
             },
             new IdentityRole
             {
                 Id = "cd10e24b-ecbc-4dd0-8141-32c452e1d1c2",
                 Name = "Student",
                 NormalizedName = "STUDENT"
             },
             new IdentityRole
             {
                 Id = "fef2c515-3fe0-4b7d-9f9f-a2ecca647e8d",
                 Name = "Supervisor",
                 NormalizedName = "SUPERVISOR"
             }
                );
        }
    }
}
