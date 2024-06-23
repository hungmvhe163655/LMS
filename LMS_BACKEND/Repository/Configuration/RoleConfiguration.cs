﻿using Microsoft.AspNetCore.Identity;
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
                 Name = "LabAdmin",
                 NormalizedName = "LABADMIN"
             },
             new IdentityRole
             {
                 Name = "Student",
                 NormalizedName = "STUDENT"
             },
             new IdentityRole
             {
                 Name = "Supervisor",
                 NormalizedName = "SUPERVISOR"
             }
                );
        }
    }
}
