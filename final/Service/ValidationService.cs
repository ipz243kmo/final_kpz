
using System;
using System.Linq;
using RecipeFinder.Models;
using System.Collections.Generic;

namespace RecipeFinder.Services
{
    public class ValidationService
    {
        public List<string> Errors { get; private set; } = new List<string>();

        public bool ValidateRecipe(Recipe recipe)
        {
            Errors.Clear();

            if (recipe == null)
            {
                Errors.Add("Об'єкт рецепта не може бути порожнім.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(recipe.Title))
                Errors.Add("Назва рецепта є обов'язковою.");
            else if (recipe.Title.Length < 3)
                Errors.Add("Назва занадто коротка (мінімум 3 символи).");

            
            ValidateIngredients(recipe.Ingredients);

            
            if (recipe.Instructions == null || !recipe.Instructions.Any())
                Errors.Add("Рецепт повинен мати хоча б один крок приготування.");

            return !Errors.Any();
        }

        private void ValidateIngredients(IEnumerable<Ingredient> ingredients)
        {
            if (ingredients == null || !ingredients.Any())
            {
                Errors.Add("Список інгредієнтів не може бути порожнім.");
                return;
            }

            foreach (var ing in ingredients)
            {
                if (ing.Amount <= 0)
                    Errors.Add($"Кількість для '{ing.Name}' має бути більшою за 0.");
            }
        }
    }
}