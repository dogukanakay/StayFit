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
    public class DietEntityConfiguration : IEntityTypeConfiguration<Diet>
    {
        public void Configure(EntityTypeBuilder<Diet> builder)
        {

            builder.HasOne(d => d.DietDay)
                .WithMany(dp => dp.Diets)
                .HasForeignKey(d => d.DietDayId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
