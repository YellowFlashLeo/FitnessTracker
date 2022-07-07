using FitnessTracker.Shared.Domain.Fitness;

namespace FitnessTracker.Shared
{
    public class EmailDto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public TrainingDay Body { get; set; } = new ();
    }
}
