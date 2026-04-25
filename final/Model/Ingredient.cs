using System;

namespace RecipeFinder.Models
{
  
    public class Ingredient
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) ? "Невідомий інгредієнт" : value;
        }

        public double Amount { get; set; }

        public string Unit { get; set; } 

        
        public double CaloriesPerUnit { get; set; }

        public Ingredient() { }

        public Ingredient(string name, double amount, string unit, double calories)
        {
            Name = name;
            Amount = amount;
            Unit = unit;
            CaloriesPerUnit = calories;
        }

       
        public double GetTotalCalories() => (Amount * CaloriesPerUnit) / 100;

        public override string ToString() => $"{Name}: {Amount} {Unit}";
    }
}