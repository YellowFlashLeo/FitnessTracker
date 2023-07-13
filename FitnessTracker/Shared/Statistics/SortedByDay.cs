using System.Collections.Generic;
using FitnessTracker.Shared.Domain.Fitness.Dto;

namespace FitnessTracker.Shared.Statistics
{
    public class SortedByDay
    {
        public int DayOfTheYear { get; set; }
        public List<string> MuscleGroups { get; set; }
        public List<ExerciseDTO> Exercises { get; set; }
    }
}
