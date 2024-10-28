using Microsoft.EntityFrameworkCore;
using StayFit.Domain.Entities;
using StayFit.Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Persistence.Contexts
{
    public class StayFitDbContext : DbContext
    {
        public StayFitDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TrainerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DietEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DietPlanEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DietDayEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutDayEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutPlanEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WeeklyProgressEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GoalEntityConfiguration());

            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<DietDay> DietDays { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutDay> WorkoutDays { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ProgressImage> ProgressImages { get; set; }
        public DbSet<WeeklyProgress> WeeklyProgresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Goal> Goals { get; set; }
    }
}
