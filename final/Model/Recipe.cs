using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RecipeFinder.Models
{

	public class Recipe
	{
		[cite_start]
		public Guid Id { get; set; }

		private string _title;
		public string Title
		{
			get => _title;
			set => _title = string.IsNullOrWhiteSpace(value) ? "Без назви" : value;
		}

		public string Description { get; set; }

		public RecipeCategory Category { get; set; }

		public DifficultyLevel Difficulty { get; set; }

		
		public int CookingTimeInMinutes { get; set; }

		public ObservableCollection<Ingredient> Ingredients { get; set; }

		
		public List<string> Instructions { get; set; }

		public DateTime CreatedAt { get; set; }

		public Recipe()
		{
			Id = Guid.NewGuid();
			Ingredients = new ObservableCollection<Ingredient>();
			Instructions = new List<string>();
			CreatedAt = DateTime.Now;
		}

		
		public double TotalCalories
		{
			get
			{
				return Ingredients?.Sum(i => i.CaloriesPerUnit * i.Amount) ?? 0;
			}
		}

		
		[cite_start]
		public string FormattedTime => $"{CookingTimeInMinutes} хв.";
	}

	public enum RecipeCategory
	{
		Breakfast,
		Lunch,
		Dinner,
		Dessert,
		Snack
	}

	public enum DifficultyLevel
	{
		Easy,
		Medium,
		Hard
	}
}