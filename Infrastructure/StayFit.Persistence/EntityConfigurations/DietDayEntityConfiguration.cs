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
    public class DietDayEntityConfiguration : IEntityTypeConfiguration<DietDay>
    {
        public void Configure(EntityTypeBuilder<DietDay> builder)
        {
            builder.HasOne(d => d.DietPlan)
               .WithMany(dp => dp.DietDays)
               .HasForeignKey(d => d.DietPlanId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
