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
    public class WorkoutPlanEntityConfiguration : IEntityTypeConfiguration<WorkoutPlan>
    {
        public void Configure(EntityTypeBuilder<WorkoutPlan> builder)
        {
            builder.HasOne(wp => wp.Subscription)
               .WithMany()
               .HasForeignKey(wp => wp.SubscriptionId)
               .OnDelete(DeleteBehavior.Cascade);

           
        }
    }
}
