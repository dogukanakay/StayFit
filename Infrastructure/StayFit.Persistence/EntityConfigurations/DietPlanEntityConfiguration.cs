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
    public class DietPlanEntityConfiguration : IEntityTypeConfiguration<DietPlan>
    {
        public void Configure(EntityTypeBuilder<DietPlan> builder)
        {
            builder.HasOne(dp => dp.Subscription)
                .WithMany()
                .HasForeignKey(dp => dp.SubscriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
