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
    public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasOne(e=>e.WorkoutDay)
                .WithMany(ep=>ep.Exercises)
                .HasForeignKey(e=>e.WorkoutDayId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
