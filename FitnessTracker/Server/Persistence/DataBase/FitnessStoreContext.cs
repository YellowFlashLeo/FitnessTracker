﻿using FitnessTracker.Shared.Domain.Fitness;
using FitnessTracker.Shared.Domain.Fitness.Dto;
using FitnessTracker.Shared.Domain.Nutrition;
using FitnessTracker.Shared.Domain.Nutrition.Dto;
using FitnessTracker.Shared.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Server.Persistence.DataBase
{
    public class FitnessStoreContext :IdentityDbContext<FitnessAppUser>
    {
        public FitnessStoreContext(DbContextOptions<FitnessStoreContext> options) : base(options)
        {
            
        }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
 
        public DbSet<TrainingDTO> TrainingDto { get; set; }
        public DbSet<NutritionDTO>NutritionDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FitnessAppUser>().ToTable("FitnessAppUsers", "dbo");
        }
    }
}
