using System.Threading.Tasks;
using FitnessTracker.Shared.Domain.Fitness;
using FitnessTracker.Shared.Domain.Nutrition;
using FitnessTracker.Shared.Identity;

namespace FitnessTracker.Server.Persistence.DataBase
{
    public static class SeedData
    {
        public static async Task Initialize(FitnessStoreContext db)
        {
            var genders = new Gender[]
            {
                new Gender
                {
                    Name = "Male"
                },
                new Gender
                {
                    Name = "Female"
                },
                new Gender
                {
                    Name = "Other"
                }
            };
            var bodyParts = new BodyPart[]
            {
                new BodyPart()
                {
                    Id = 1,
                    ImageUrl = "img/chest/Chest.jpg",
                    Name = "Chest"
                },
                new BodyPart()
                {
                    Id = 2,
                    ImageUrl = "img/back/Back.jpg",
                    Name = "Back"
                },
                new BodyPart()
                {
                    Id = 3,
                    ImageUrl = "img/legs/Legs.jpg",
                    Name = "Legs"
                },
                new BodyPart()
                {
                    Id = 4,
                    ImageUrl = "img/delts/Delts.jpg",
                    Name = "Shoulders"
                },
                new BodyPart()
                {
                    Id=5,
                    ImageUrl = "img/biceps/Biceps.jpg",
                    Name="Biceps"
                },
                new BodyPart()
                {
                    Id=6,
                    ImageUrl = "img/triceps/Triceps.jpg",
                    Name = "Triceps"
                },
                new BodyPart()
                {
                    Id=7,
                    ImageUrl = "img/calves/Calves.jpg",
                    Name="Calves"
                },
                new BodyPart()
                {
                    Id=8,
                    ImageUrl = "img/abs/Abs.jpg",
                    Name="Abs"
                }
            };

            var exercises = new Exercise[]
            {
                new Exercise
                {
                    Name = "Dips",
                    BodyPartId = 6,
                    ImageUrl = "img/triceps/Dips.jpg"
                },
                new Exercise
                {
                    Name = "LyingTricepsDumbellExtensions",
                    BodyPartId = 6,
                    ImageUrl = "img/triceps/LyingTricepsDumbellExtensions.jpg"
                },
                new Exercise
                {
                    Name = "LyingTricepsFrenchPress",
                    BodyPartId = 6,
                    ImageUrl = "img/triceps/LyingTricepsFrenchPress.jpg"
                },
                new Exercise
                {
                    Name = "StandingOverheadOneArmCableTricepsExtension",
                    BodyPartId = 6,
                    ImageUrl = "img/triceps/StandingOverheadOneArmCableTricepsExtension.jpg"
                },
                new Exercise
                {
                    Name = "StandingTricepsOverheadCableExtension",
                    BodyPartId = 6,
                    ImageUrl = "img/triceps/StandingTricepsOverheadCableExtension.jpg"
                },
                new Exercise
                {
                    Name="BarbelLunges",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/BarbelLunges.jpg"
                },
                new Exercise
                {
                    Name="Deadlift",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/Deadlift.jpg"
                },
                new Exercise
                {
                    Name="DumbellDeadlift",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/DumbellDeadlift.jpg"
                },
                new Exercise
                {
                    Name="DumbleSqauts",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/DumbleSqauts.jpg"
                },
                new Exercise
                {
                    Name="GobletSquats",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/GobletSquats.jpg"
                },
                new Exercise
                {
                    Name="HackSquat",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/HackSquat.jpg"
                },
                new Exercise
                {
                    Name="HammstringsExtrension",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/HammstringsExtrension.jpg"
                },
                new Exercise
                {
                    Name="InnerOuterThighMachine",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/InnerOuterThighMachine.jpg"
                },
                new Exercise
                {
                    Name="LegExtension",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/LegExtension.jpg"
                },
                new Exercise
                {
                    Name="LegPress",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/LegPress.jpg"
                },
                new Exercise
                {
                    Name="LungesWithBarbell",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/LungesWithBarbell.jpg"
                },
                new Exercise
                {
                    Name="SingleLegDumbelSplitSquat",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/SingleLegDumbelSplitSquat.jpg"
                },
                new Exercise
                {
                    Name="Squats",
                    BodyPartId = 3,
                    ImageUrl = "img/legs/Squats.jpg"
                },
                new Exercise
                {
                    Name="ArnoldPress",
                    BodyPartId = 4,
                    ImageUrl = "img/delts/ArnoldPress.jpg"
                },
                new Exercise
                {
                    Name="FrontDeltRaises",
                    BodyPartId = 4,
                    ImageUrl = "img/delts/FrontDeltRaises.jpg"
                },
                new Exercise
                {
                    Name="RearDeltsRaises",
                    BodyPartId = 4,
                    ImageUrl = "img/delts/RearDeltsRaises.jpg"
                },
                new Exercise
                {
                    Name="ShouldBarbelSmithPress",
                    BodyPartId = 4,
                    ImageUrl = "img/delts/ShouldBarbelSmithPress.jpg"
                },
                new Exercise
                {
                    Name="ShouldDumbellPress",
                    BodyPartId = 4,
                    ImageUrl = "img/delts/ShouldDumbellPress.jpg"
                },
                new Exercise
                {
                    Name="ShoulderHammerPress",
                    BodyPartId = 4,
                    ImageUrl = "img/delts/ShoulderHammerPress.jpg"
                },
                new Exercise
                {
                    Name="StandingLateralRaises",
                    BodyPartId = 4,
                    ImageUrl = "img/delts/StandingLateralRaises.jpg"
                },
                new Exercise
                {
                    Name = "BenchPress",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/BenchPress.jpg"
                },
                new Exercise
                {
                    Name = "BenchPressOneHand",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/BenchPressOneHand.jpg"
                },
                new Exercise
                {
                    Name = "CableCrossOver",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/CableCrossOver.jpg"
                },
                new Exercise
                {
                    Name = "ChestHammerFlyes",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/ChestHammerFlyes.jpg"
                },
                new Exercise
                {
                    Name = "ChestPullOver",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/ChestPullOver.jpg"
                },
                new Exercise
                {
                    Name = "Dips",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/Dips.jpg"
                },
                new Exercise
                {
                    Name = "FlatBarbellPress",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/FlatBarbellPress.jpg"
                },
                new Exercise
                {
                    Name = "InclineBench",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/InclineBench.jpg"
                },
                new Exercise
                {
                    Name = "InclineDumbelPress",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/InclineDumbelPress.jpg"
                },
                new Exercise
                {
                    Name = "InclineFly",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/InclineFly.jpg"
                },
                new Exercise
                {
                    Name = "LowCableFly",
                    BodyPartId = 1 ,
                    ImageUrl = "img/chest/LowCableFly.jpg"
                },
                new Exercise
                {
                    Name = "CalfRaises",
                    BodyPartId = 7 ,
                    ImageUrl = "img/calves/CalfRaises.jpg"
                },
                new Exercise
                {
                    Name = "CalfSmithRaises",
                    BodyPartId = 7,
                    ImageUrl = "img/calves/CalfSmithRaises.jpg"
                },
                new Exercise
                {
                    Name="BicepsHammer",
                    BodyPartId = 5,
                    ImageUrl = "img/biceps/BicepsHammer.jpg"
                },
                new Exercise
                {
                    Name="BicepsPullUps",
                    BodyPartId = 5,
                    ImageUrl = "img/biceps/BicepsPullUps.jpg"
                },
                new Exercise
                {
                    Name="BicepsScotPull",
                    BodyPartId = 5,
                    ImageUrl = "img/biceps/BicepsScotPull.jpg"
                },
                new Exercise
                {
                    Name="IsolatedSeatedBicepsCurls",
                    BodyPartId = 5,
                    ImageUrl = "img/biceps/IsolatedSeatedBicepsCurls.jpg"
                },
                new Exercise
                {
                    Name="SeatedBicepsDumbellsCurls",
                    BodyPartId = 5,
                    ImageUrl = "img/biceps/SeatedBicepsDumbellsCurls.jpg"
                },
                new Exercise
                {
                    Name="StandingBicepsBenchCurls",
                    BodyPartId = 5,
                    ImageUrl = "img/biceps/StandingBicepsBenchCurls.jpg"
                },
                new Exercise
                {
                    Name="StandingBicepsCableCurls",
                    BodyPartId = 5,
                    ImageUrl = "img/biceps/StandingBicepsCableCurls.jpg"
                },
                new Exercise
                {
                    Name="StandingBicepsDumbellCurls",
                    BodyPartId = 5,
                    ImageUrl = "img/biceps/StandingBicepsDumbellCurls.jpg"
                },
                new Exercise
                {
                    Name="AbsHarley",
                    BodyPartId = 8 ,
                    ImageUrl = "img/abs/AbsHarley.jpg"
                },
                new Exercise
                {
                    Name="Crunches",
                    BodyPartId = 8 ,
                    ImageUrl = "img/abs/Crunches.jpg"
                },
                new Exercise
                {
                    Name="LowerAbsLieRaises",
                    BodyPartId = 8 ,
                    ImageUrl = "img/abs/LowerAbsLieRaises.jpg"
                },
                new Exercise
                {
                    Name="TBarRows",
                    BodyPartId = 2,
                    ImageUrl = "img/back/TBarRows.jpg"
                },
                new Exercise
                {
                    Name="BackPullOver",
                    BodyPartId = 2,
                    ImageUrl = "img/back/BackPullOver.jpg"
                },
                new Exercise
                {
                    Name="BarbellShrugs",
                    BodyPartId = 2,
                    ImageUrl = "img/back/BarbellShrugs.jpg"
                },
                new Exercise
                {
                    Name="HorizontalCableRow",
                    BodyPartId = 2,
                    ImageUrl = "img/back/HorizontalCableRow.jpg"
                },
                new Exercise
                {
                    Name="HyperExtensions",
                    BodyPartId = 2,
                    ImageUrl = "img/back/HyperExtensions.jpg"
                },
                new Exercise
                {
                    Name="InclineBenchRow",
                    BodyPartId = 2,
                    ImageUrl = "img/back/InclineBenchRow.jpg"
                },
                new Exercise
                {
                    Name="LatPullDown",
                    BodyPartId = 2,
                    ImageUrl = "img/back/LatPullDown.jpg"
                },
                new Exercise
                {
                    Name="LatPullDownSingleHand",
                    BodyPartId = 2,
                    ImageUrl = "img/back/LatPullDownSingleHand.jpg"
                },
                new Exercise
                {
                    Name="SeatedRowMachine",
                    BodyPartId = 2,
                    ImageUrl = "img/back/SeatedRowMachine.jpg"
                },
                new Exercise
                {
                    Name="SingleArmRow",
                    BodyPartId = 2,
                    ImageUrl = "img/back/SingleArmRow.jpg"
                }
            };
            var foodTypes = new FoodType[]
            {
                new FoodType()
                {
                    Id = 1,
                    ImageUrl = "img/dairy/Dairy.jpg",
                    Name = "Dairy"
                },
                new FoodType()
                {
                    Id = 2,
                    ImageUrl = "img/eggs/BoiledEggs.jpg",
                    Name = "Eggs"
                },
                new FoodType()
                {
                    Id = 3,
                    ImageUrl = "img/fish/Fish.jpg",
                    Name = "Fish"
                },
                new FoodType()
                {
                    Id = 4,
                    ImageUrl = "img/fruits/Fruits.jpg",
                    Name = "Fruits"
                },
                new FoodType()
                {
                    Id = 5,
                    ImageUrl = "img/garnish/Garnish.jpg",
                    Name = "Garnish"
                },
                new FoodType()
                {
                    Id = 6,
                    ImageUrl = "img/junkFood/JunkFood.jpg",
                    Name = "JunkFood"
                },
                new FoodType()
                {
                    Id = 7,
                    ImageUrl = "img/meat/Meat.jpg",
                    Name = "Meat"
                },
                new FoodType()
                {
                    Id = 8,
                    ImageUrl = "img/nuts/Nuts.jpg",
                    Name = "Nuts"
                },
                new FoodType()
                {
                    Id = 9,
                    ImageUrl = "img/vegg/Veggies.jpg",
                    Name = "Veggies"
                }
            };
            var foods = new Food[]
            {
                new Food()
                {
                    Title = "BlueCheese",
                    ImageUrl = "img/dairy/BlueCheese.jpg",
                    FoodTypeId = 1,
                    CaloriesPer100 = 353,
                    CarbsPer100 = 2.3f,
                    ProteinPer100 = 21.4f,
                    FatsPer100 = 28.7f,
                },
                new Food()
                {
                    Title = "Chedder",
                    ImageUrl = "img/dairy/Chedder.jpg",
                    FoodTypeId = 1,
                    CaloriesPer100 = 403,
                    CarbsPer100 = 1.2f,
                    ProteinPer100 = 24.9f,
                    FatsPer100 = 33.14f,
                },
                new Food()
                {
                    Title = "CottageCheese",
                    ImageUrl = "img/dairy/CottageCheese.png",
                    FoodTypeId = 1,
                    CaloriesPer100 = 103,
                    CarbsPer100 = 2.68f,
                    ProteinPer100 = 12.49f,
                    FatsPer100 = 4.51f,
                },
                new Food()
                {
                    Title = "CremeCheese",
                    ImageUrl = "img/dairy/CreemeCheese.jpg",
                    FoodTypeId = 1,
                    CaloriesPer100 = 349,
                    CarbsPer100 = 2.66f,
                    ProteinPer100 = 7.55f,
                    FatsPer100 = 34.87f,
                },
                new Food()
                {
                    Title = "Hallumi",
                    ImageUrl = "img/dairy/Hallumi.jpg",
                    FoodTypeId = 1,
                    CaloriesPer100 = 316,
                    CarbsPer100 = 1.6f,
                    ProteinPer100 = 20.8f,
                    FatsPer100 = 24.7f,
                },
                new Food()
                {
                    Title = "Milk",
                    ImageUrl = "img/dairy/Milk.jpg",
                    FoodTypeId = 1,
                    CaloriesPer100 = 55,
                    CarbsPer100 = 4.8f,
                    ProteinPer100 = 3.2f,
                    FatsPer100 = 2.5f,
                },
                new Food()
                {
                    Title = "Mozarella",
                    ImageUrl = "img/dairy/Mozarella.jpg",
                    FoodTypeId = 1,
                    CaloriesPer100 = 302,
                    CarbsPer100 = 3.83f,
                    ProteinPer100 = 26,
                    FatsPer100 = 20,
                },
                new Food()
                {
                    Title = "Parmesan",
                    ImageUrl = "img/dairy/Parmesan.jpg",
                    FoodTypeId = 1,
                    CaloriesPer100 = 401,
                    CarbsPer100 = 0,
                    ProteinPer100 = 35.2f,
                    FatsPer100 = 29.4f,
                },
                new Food()
                {
                    Title = "SweetCurd",
                    ImageUrl = "img/dairy/SweetCurd.jpg",
                    FoodTypeId = 1,
                    CaloriesPer100 = 298,
                    CarbsPer100 = 22,
                    ProteinPer100 = 14,
                    FatsPer100 = 19,
                },
                new Food()
                {
                    Title = "Yogurt",
                    ImageUrl = "img/dairy/Yogurt.jpg",
                    FoodTypeId = 1,
                    CaloriesPer100 = 78,
                    CarbsPer100 = 7,
                    ProteinPer100 = 6,
                    FatsPer100 = 3,
                },
                new Food()
                {
                    Title = "BoiledEggs",
                    ImageUrl = "img/eggs/BoiledEggs.jpg",
                    FoodTypeId = 2,
                    CaloriesPer100 = 154,
                    CarbsPer100 = 1,
                    ProteinPer100 = 12.5f,
                    FatsPer100 = 10.6f,
                },
                new Food()
                {
                    Title = "FriedEggs",
                    ImageUrl = "img/eggs/FriedEggs.jpg",
                    FoodTypeId = 2,
                    CaloriesPer100 = 201,
                    CarbsPer100 = 1,
                    ProteinPer100 = 13.6f,
                    FatsPer100 = 15.3f,
                },
                new Food()
                {
                    Title = "Omlet",
                    ImageUrl = "img/eggs/Omlet.jpg",
                    FoodTypeId = 2,
                    CaloriesPer100 = 153,
                    CarbsPer100 = 1,
                    ProteinPer100 = 14,
                    FatsPer100 = 12,
                },
                new Food()
                {
                    Title = "ScrambledEggs",
                    ImageUrl = "img/eggs/ScrambledEggs.jpg",
                    FoodTypeId = 2,
                    CaloriesPer100 = 166,
                    CarbsPer100 = 3,
                    ProteinPer100 = 16,
                    FatsPer100 = 12,
                },
                new Food()
                {
                    Title = "Cod",
                    ImageUrl = "img/fish/Cod.jpg",
                    FoodTypeId = 3,
                    CaloriesPer100 = 105,
                    CarbsPer100 = 0,
                    ProteinPer100 = 23,
                    FatsPer100 = 1,
                },
                new Food()
                {
                    Title = "FriedFish",
                    ImageUrl = "img/fish/FriedFish.jpg",
                    FoodTypeId = 3,
                    CaloriesPer100 = 220,
                    CarbsPer100 = 10,
                    ProteinPer100 = 21,
                    FatsPer100 = 10,
                },
                new Food()
                {
                    Title = "Prawn",
                    ImageUrl = "img/fish/Prawn.jpg",
                    FoodTypeId = 3,
                    CaloriesPer100 = 105,
                    CarbsPer100 = 1,
                    ProteinPer100 = 20,
                    FatsPer100 = 1.7f,
                },
                new Food()
                {
                    Title = "Salmon",
                    ImageUrl = "img/fish/Salmon.jpg",
                    FoodTypeId = 3,
                    CaloriesPer100 = 211,
                    CarbsPer100 = 0,
                    ProteinPer100 = 34,
                    FatsPer100 = 7.3f,
                },
                new Food()
                {
                    Title = "Tiger_Prawn",
                    ImageUrl = "img/fish/Tiger_Prawn.jpg",
                    FoodTypeId = 3,
                    CaloriesPer100 = 105,
                    CarbsPer100 = 1,
                    ProteinPer100 = 20,
                    FatsPer100 = 1.7f,
                },
                new Food()
                {
                    Title = "Tuna",
                    ImageUrl = "img/fish/Tuna.jpg",
                    FoodTypeId = 3,
                    CaloriesPer100 = 130,
                    CarbsPer100 = 7,
                    ProteinPer100 = 10.4f,
                    FatsPer100 = 6.7f,
                },
                new Food()
                {
                    Title = "Apple",
                    ImageUrl = "img/fruits/Apple.jpg",
                    FoodTypeId = 4,
                    CaloriesPer100 = 52,
                    CarbsPer100 = 14,
                    ProteinPer100 = 0.3f,
                    FatsPer100 = 0.2f,
                },
                new Food()
                {
                    Title = "Avocado",
                    ImageUrl = "img/fruits/Avocado.jpg",
                    FoodTypeId = 4,
                    CaloriesPer100 = 160,
                    CarbsPer100 = 8.5f,
                    ProteinPer100 = 2,
                    FatsPer100 = 15,
                },
                new Food()
                {
                    Title = "Bananna",
                    ImageUrl = "img/fruits/Banana.jpg",
                    FoodTypeId = 4,
                    CaloriesPer100 = 89,
                    CarbsPer100 = 23,
                    ProteinPer100 = 1.1f,
                    FatsPer100 = 0.3f,
                },
                new Food()
                {
                    Title = "Coconut",
                    ImageUrl = "img/fruits/Coconut.jpg",
                    FoodTypeId = 4,
                    CaloriesPer100 = 148,
                    CarbsPer100 = 15.23f,
                    ProteinPer100 = 3.3f,
                    FatsPer100 = 33.5f,
                },
                new Food()
                {
                    Title = "Mango",
                    ImageUrl = "img/fruits/Mango.jpg",
                    FoodTypeId = 4,
                    CaloriesPer100 = 60,
                    CarbsPer100 = 15,
                    ProteinPer100 = 1,
                    FatsPer100 = 0.4f,
                },
                new Food()
                {
                    Title = "Orange",
                    ImageUrl = "img/fruits/Orange.jpg",
                    FoodTypeId = 4,
                    CaloriesPer100 = 43,
                    CarbsPer100 = 13,
                    ProteinPer100 = 1,
                    FatsPer100 = 0,
                },
                new Food()
                {
                    Title = "Pear",
                    ImageUrl = "img/fruits/Pear.jpg",
                    FoodTypeId = 4,
                    CaloriesPer100 = 57,
                    CarbsPer100 = 15,
                    ProteinPer100 = 0,
                    FatsPer100 = 0,
                },
                new Food()
                {
                    Title = "Plums",
                    ImageUrl = "img/fruits/Plums.jpg",
                    FoodTypeId = 4,
                    CaloriesPer100 = 46,
                    CarbsPer100 = 11,
                    ProteinPer100 = 0.7f,
                    FatsPer100 = 0.3f,
                },
                new Food()
                {
                    Title = "Strawberries",
                    ImageUrl = "img/fruits/Strawberries.jpg",
                    FoodTypeId = 4,
                    CaloriesPer100 = 32,
                    CarbsPer100 = 8,
                    ProteinPer100 = 0.8f,
                    FatsPer100 = 0.3f,
                },
                new Food()
                {
                    Title = "Watermelon",
                    ImageUrl = "img/fruits/Watermelon.jpg",
                    FoodTypeId = 4,
                    CaloriesPer100 = 30,
                    CarbsPer100 = 7.6f,
                    ProteinPer100 = 0.6f,
                    FatsPer100 = 0,
                },
                new Food()
                {
                    Title = "BrownRice",
                    ImageUrl = "img/garnish/BrownRice.jpg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 112,
                    CarbsPer100 = 24,
                    ProteinPer100 = 2.3f,
                    FatsPer100 = 0.8f,
                },
                new Food()
                {
                    Title = "Buckwheat",
                    ImageUrl = "img/garnish/Buckwheat.jpg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 343,
                    CarbsPer100 = 71.5f,
                    ProteinPer100 = 13.3f,
                    FatsPer100 = 3.4f,
                },
                new Food()
                {
                    Title = "Cuscus",
                    ImageUrl = "img/garnish/Cuscus.jpg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 112,
                    CarbsPer100 = 23.2f,
                    ProteinPer100 = 3.8f,
                    FatsPer100 = 0.2f,
                },
                new Food()
                {
                    Title = "FrenchFries",
                    ImageUrl = "img/garnish/FrenchFries.jpg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 274,
                    CarbsPer100 = 36,
                    ProteinPer100 = 3.5f,
                    FatsPer100 = 14.6f,
                },
                new Food()
                {
                    Title = "JasmineRice",
                    ImageUrl = "img/garnish/JasmineRice.jpg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 170,
                    CarbsPer100 = 32,
                    ProteinPer100 = 3.8f,
                    FatsPer100 = 2.5f,
                },
                new Food()
                {
                    Title = "MashedPotato",
                    ImageUrl = "img/garnish/mashedPotato.jpg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 100,
                    CarbsPer100 = 15.7f,
                    ProteinPer100 = 1.8f,
                    FatsPer100 = 3.5f,
                },
                new Food()
                {
                    Title = "Pasta",
                    ImageUrl = "img/garnish/Pasta.jpg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 131,
                    CarbsPer100 = 25,
                    ProteinPer100 = 5.1f,
                    FatsPer100 = 1,
                },
                new Food()
                {
                    Title = "PotatoWages",
                    ImageUrl = "img/garnish/PotatoWegdes.jpg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 93,
                    CarbsPer100 = 21,
                    ProteinPer100 = 2,
                    FatsPer100 = 2,
                },
                new Food()
                {
                    Title = "Qinoa",
                    ImageUrl = "img/garnish/Qinoa.jpeg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 374,
                    CarbsPer100 = 69,
                    ProteinPer100 = 13,
                    FatsPer100 = 5.8f,
                },
                new Food()
                {
                    Title = "SweetPotato",
                    ImageUrl = "img/garnish/SweetPotato.jpg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 90,
                    CarbsPer100 = 21,
                    ProteinPer100 = 2,
                    FatsPer100 = 0.1f,
                },
                new Food()
                {
                    Title = "WhiteRice",
                    ImageUrl = "img/garnish/WhiteRice.jpeg",
                    FoodTypeId = 5,
                    CaloriesPer100 = 130,
                    CarbsPer100 = 28,
                    ProteinPer100 = 2.7f,
                    FatsPer100 = 0.3f,
                },
                new Food()
                {
                    Title = "Burger",
                    ImageUrl = "img/junkFood/JunkFood.jpg",
                    FoodTypeId = 6,
                    CaloriesPer100 = 540,
                    CarbsPer100 = 45,
                    ProteinPer100 = 25,
                    FatsPer100 = 29
                },
                new Food()
                {
                    Title = "ChickenNuggets",
                    ImageUrl = "img/junkFood/ChickenNuggets.jpg",
                    FoodTypeId = 6,
                    CaloriesPer100 = 470,
                    CarbsPer100 = 30,
                    ProteinPer100 = 22,
                    FatsPer100 = 30
                },
                new Food()
                {
                    Title = "HotDog",
                    ImageUrl = "img/junkFood/HotDog.jpg",
                    FoodTypeId = 6,
                    CaloriesPer100 = 290,
                    CarbsPer100 = 4.2f,
                    ProteinPer100 = 10,
                    FatsPer100 = 26
                },
                new Food()
                {
                    Title = "Pizza",
                    ImageUrl = "img/junkFood/Pizza.jpg",
                    FoodTypeId = 6,
                    CaloriesPer100 = 266,
                    CarbsPer100 = 33,
                    ProteinPer100 = 11,
                    FatsPer100 = 10
                },
                new Food()
                {
                    Title = "Shawarma",
                    ImageUrl = "img/junkFood/Shawarma.jpg",
                    FoodTypeId = 6,
                    CaloriesPer100 = 392,
                    CarbsPer100 = 45.7f,
                    ProteinPer100 = 32.3f,
                    FatsPer100 = 10.6f
                },
                new Food()
                {
                    Title = "Beef",
                    ImageUrl = "img/meat/Beef.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 250,
                    CarbsPer100 = 0,
                    ProteinPer100 = 26,
                    FatsPer100 = 15
                },
                new Food()
                {
                    Title = "Chicken",
                    ImageUrl = "img/meat/Chicken.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 165,
                    CarbsPer100 = 0,
                    ProteinPer100 = 31,
                    FatsPer100 = 3.6f
                },
                new Food()
                {
                    Title = "Duck",
                    ImageUrl = "img/meat/Duck.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 201,
                    CarbsPer100 = 0,
                    ProteinPer100 = 23.5f,
                    FatsPer100 = 11.2f
                },
                new Food()
                {
                    Title = "GroundBeef",
                    ImageUrl = "img/meat/GroundBeef.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 322,
                    CarbsPer100 = 0,
                    ProteinPer100 = 14,
                    FatsPer100 = 30
                },
                new Food()
                {
                    Title = "LambChops",
                    ImageUrl = "img/meat/LambChops.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 294,
                    CarbsPer100 = 0,
                    ProteinPer100 = 25,
                    FatsPer100 = 21
                },
                new Food()
                {
                    Title = "MeatBalls",
                    ImageUrl = "img/meat/MeatBalls.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 197,
                    CarbsPer100 = 8,
                    ProteinPer100 = 21,
                    FatsPer100 = 9
                },
                new Food()
                {
                    Title = "MincedPork",
                    ImageUrl = "img/meat/MincedPork.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 297,
                    CarbsPer100 = 0,
                    ProteinPer100 = 25.7f,
                    FatsPer100 = 20.7f
                },
                new Food()
                {
                    Title = "MincedTurkey",
                    ImageUrl = "img/meat/MincedTurkey.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 203,
                    CarbsPer100 = 0,
                    ProteinPer100 = 27,
                    FatsPer100 = 10
                },
                new Food()
                {
                    Title = "Pork",
                    ImageUrl = "img/meat/Pork.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 283,
                    CarbsPer100 = 0,
                    ProteinPer100 = 26.4f,
                    FatsPer100 = 19
                },
                new Food()
                {
                    Title = "T-boneSteak",
                    ImageUrl = "img/meat/T-boneSteak.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 247,
                    CarbsPer100 = 0,
                    ProteinPer100 = 24,
                    FatsPer100 = 16
                },
                new Food()
                {
                    Title = "WholeChicken",
                    ImageUrl = "img/meat/WholeChicken.jpg",
                    FoodTypeId = 7,
                    CaloriesPer100 = 216,
                    CarbsPer100 = 0,
                    ProteinPer100 = 17,
                    FatsPer100 = 15.9f
                },
                new Food()
                {
                    Title = "Almonds",
                    ImageUrl = "img/nuts/Almonds.jpg",
                    FoodTypeId = 8,
                    CaloriesPer100 = 579,
                    CarbsPer100 = 21.5f,
                    ProteinPer100 = 21.5f,
                    FatsPer100 = 49.9f
                },
                new Food()
                {
                    Title = "BrazilianNut",
                    ImageUrl = "img/nuts/BrazilianNut.jpg",
                    FoodTypeId = 8,
                    CaloriesPer100 = 656,
                    CarbsPer100 = 12,
                    ProteinPer100 = 14,
                    FatsPer100 = 66
                },
                new Food()
                {
                    Title = "Cashew",
                    ImageUrl = "img/nuts/Cashew.jpg",
                    FoodTypeId = 8,
                    CaloriesPer100 = 553,
                    CarbsPer100 = 30.19f,
                    ProteinPer100 = 18.22f,
                    FatsPer100 = 43.85f
                },
                new Food()
                {
                    Title = "Peanuts",
                    ImageUrl = "img/nuts/Peanuts.jpg",
                    FoodTypeId = 8,
                    CaloriesPer100 = 567,
                    CarbsPer100 = 16.13f,
                    ProteinPer100 = 25.8f,
                    FatsPer100 = 49.2f
                },
                new Food()
                {
                    Title = "Pistacheo",
                    ImageUrl = "img/nuts/Pistacheo.jpg",
                    FoodTypeId = 8,
                    CaloriesPer100 = 560,
                    CarbsPer100 = 27.17f,
                    ProteinPer100 = 20.16f,
                    FatsPer100 = 45.32f
                },
                new Food()
                {
                    Title = "Walnuts",
                    ImageUrl = "img/nuts/Walnuts.jpg",
                    FoodTypeId = 8,
                    CaloriesPer100 = 654,
                    CarbsPer100 = 13.7f,
                    ProteinPer100 = 15.2f,
                    FatsPer100 = 65.2f
                },
                new Food()
                {
                    Title = "Brocoli",
                    ImageUrl = "img/vegg/Brocoli.jpeg",
                    FoodTypeId = 9,
                    CaloriesPer100 = 34,
                    CarbsPer100 = 6.6f,
                    ProteinPer100 = 2.8f,
                    FatsPer100 = 0.37f
                },
                new Food()
                {
                    Title = "Carrot",
                    ImageUrl = "img/vegg/Carrot.jpg",
                    FoodTypeId = 9,
                    CaloriesPer100 = 41,
                    CarbsPer100 = 10,
                    ProteinPer100 = 1,
                    FatsPer100 = 0.2f
                },
                new Food()
                {
                    Title = "Cucumber",
                    ImageUrl = "img/vegg/Cucumber.jpg",
                    FoodTypeId = 9,
                    CaloriesPer100 = 15,
                    CarbsPer100 = 3.63f,
                    ProteinPer100 = 0.65f,
                    FatsPer100 = 0.11f
                },
                new Food()
                {
                    Title = "Olive",
                    ImageUrl = "img/vegg/Olive.jpg",
                    FoodTypeId = 9,
                    CaloriesPer100 = 115,
                    CarbsPer100 = 6,
                    ProteinPer100 = 0.8f,
                    FatsPer100 = 11
                },
                new Food()
                {
                    Title = "Paprika",
                    ImageUrl = "img/vegg/Paprika.jpg",
                    FoodTypeId = 9,
                    CaloriesPer100 = 31,
                    CarbsPer100 = 6,
                    ProteinPer100 = 1,
                    FatsPer100 = 0.3f
                },
                new Food()
                {
                    Title = "Tomato",
                    ImageUrl = "img/vegg/Tomato.jpg",
                    FoodTypeId = 9,
                    CaloriesPer100 = 18,
                    CarbsPer100 = 3.9f,
                    ProteinPer100 = 0.9f,
                    FatsPer100 = 0.2f
                }
            };


            await db.FoodTypes.AddRangeAsync(foodTypes);
            await db.Foods.AddRangeAsync(foods);
            await db.BodyParts.AddRangeAsync(bodyParts);
            await db.Exercises.AddRangeAsync(exercises);
            await db.Genders.AddRangeAsync(genders);
            await db.SaveChangesAsync();
        }
    }
}
