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
    public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasOne(s => s.Trainer)
                    .WithMany()
                    .HasForeignKey(s => s.TrainerId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Member)
                .WithMany()
                .HasForeignKey(s => s.MemberId)
                .OnDelete(DeleteBehavior.Cascade);


            builder
                .HasIndex(x => new { x.TrainerId, x.PaymentStatus });

        }
    }
}
