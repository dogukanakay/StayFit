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
    public class WeeklyProgressEntityConfiguration : IEntityTypeConfiguration<WeeklyProgress>
    {
        public void Configure(EntityTypeBuilder<WeeklyProgress> builder)
        {
            builder.HasOne(wp => wp.Subscription).WithMany().HasForeignKey(wp => wp.SubscriptionId);
        }
    }
}
