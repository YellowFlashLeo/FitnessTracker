using FitnessTracker.Shared.Domain.NewFolder;

namespace FitnessTracker.Shared
{
    public class EmailDto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public TrainingDTO Body { get; set; } = new ();
        public NutritionDTO Food { get; set; } = new();
    }
}
