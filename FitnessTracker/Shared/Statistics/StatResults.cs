﻿using System.Collections.Generic;

namespace FitnessTracker.Shared.Statistics
{
    public class StatResults
    {
        public Dictionary<string, float> BestWorkingWeightPerExercise { get; set; } = new();
        public double AverageAmountOfRepsPerTraining { get; set; } = 0.0f;
        public double AverageAmountOfSetsPerTraining { get; set; } = 0.0f;
        public double AverageAmountOfCaloriesPerDay { get; set; } = 0.0;
        public double AverageAmountOfProteinsPerDay { get; set; } = 0.0;
        public double AverageAmountOfFatsPerDay { get; set; } = 0.0;
        public double AverageAmountOfCarbsPerDay { get; set; } = 0.0;
    }
}
