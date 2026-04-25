using System;

namespace RecipeFinder.Models
{

    public class Step
    {
        public int Number { get; set; }

        private string _description;
        public string Description
        {
            get => _description;
            set => _description = value ?? throw new ArgumentNullException(nameof(value), "Опис кроку не може бути порожнім");
        }

        public int EstimatedMinutes { get; set; }

       
        public string ImagePath { get; set; }

        public Step() { }

        public Step(int number, string description, int minutes = 0)
        {
            Number = number;
            Description = description;
            EstimatedMinutes = minutes;
        }

        
        public string GetStepSummary()
        {
            string timeInfo = EstimatedMinutes > 0 ? $" (~{EstimatedMinutes} хв.)" : "";
            return $"{Number}. {Description}{timeInfo}";
        }
    }
}