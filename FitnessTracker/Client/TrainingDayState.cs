using FitnessTracker.Shared.Domain.Fitness;
using FitnessTracker.Shared.Domain.Nutrition;

namespace FitnessTracker.Client
{
    public class TrainingDayState
    {
        public bool ShowingConfigureDialog { get; private set; }
        public bool ShowingMealDialog { get; private set; }
        public TrainingExercise ConfiguringTrainingSession { get; private set; }
        public Meal ConfiguringMeal { get; private set; }
        public TrainingDay TrainingDay { get; private set; } = new();

        public void ShowConfigureTrainingSessionDialog(Exercise exercise)
        {
            ConfiguringTrainingSession = new TrainingExercise()
            {
                Exercise = exercise,
                ExerciseId = exercise.Id
            };
            ShowingConfigureDialog = true;
        }

        public void ShowConfigureMealDialog(Food food)
        {
            ConfiguringMeal = new Meal()
            {
                Food = food,
                FoodId = food.Id
            };
            ShowingMealDialog = true;
        }


        public void CancelConfigureTrainingSession()
        {
            ConfiguringTrainingSession = null;
            ShowingConfigureDialog = false;
        }

        public void CancelConfigureMeal()
        {
            ConfiguringMeal = null;
            ShowingMealDialog = false;
        }
        public void ConfirmConfigureTrainingSessionDialog()
        {
            TrainingDay.Trainings.Add(ConfiguringTrainingSession);
            ConfiguringTrainingSession = null;

            ShowingConfigureDialog = false;
        }

        public void ConfirmConfigureMealDialog()
        {
            TrainingDay.Meals.Add(ConfiguringMeal);
            ConfiguringMeal = null;

            ShowingMealDialog = false;
        }
        public void RemoveConfiguringTrainingSession(TrainingExercise trainingSession)
        {
            TrainingDay.Trainings.Remove(trainingSession);
        }

        public void RemoveConfiguringMeal(Meal meal)
        {
            TrainingDay.Meals.Remove(meal);
        }
        public void ResetOrder()
        {
            TrainingDay = new();
        }

        public void ReplaceOrder(TrainingDay day)
        {
            TrainingDay = day;
        }
    }
}
