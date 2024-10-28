using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Persistence.EntityConfigurations
{
    public class WorkoutDayEntityConfiguration : IEntityTypeConfiguration<WorkoutDay>
    {
        public void Configure(EntityTypeBuilder<WorkoutDay> builder)
        {
            builder.HasOne(w => w.WorkoutPlan)
               .WithMany(wp => wp.WorkoutDays)
               .HasForeignKey(w =>w.WorkoutPlanId )
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
