using System;
using System.Linq;
using RecipeFinder.Models;
using System.Collections.Generic;

namespace RecipeFinder.Services
{
    // Рефакторинг: Винесення хардкод-повідомлень в окремий клас констант
    public static class ValidationMessages
    {
        public const string RecipeNull = "Об'єкт рецепта не може бути порожнім.";
        public const string TitleRequired = "Назва рецепта є обов'язковою.";
        public const string TitleTooShort = "Назва занадто коротка (мінімум 3 символи).";
        public const string IngredientsEmpty = "Список інгредієнтів не може бути порожнім.";
        public const string InstructionsEmpty = "Рецепт повинен мати хоча б один крок приготування.";
        
        public static string GetInvalidAmountMessage(string ingredientName)
        {
            return $"Кількість для '{ingredientName}' має бути більшою за 0.";
        }
    }

    public interface IValidationRule
    {
        bool Validate(Recipe recipe, List<string> errors);
    }

    public class TitleValidationRule : IValidationRule
    {
        public bool Validate(Recipe recipe, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(recipe.Title))
            {
                errors.Add(ValidationMessages.TitleRequired);
                return false;
            }
            if (recipe.Title.Length < 3)
            {
                errors.Add(ValidationMessages.TitleTooShort);
                return false;
            }
            return true;
        }
    }

    public class IngredientsValidationRule : IValidationRule
    {
        public bool Validate(Recipe recipe, List<string> errors)
        {
            if (recipe.Ingredients == null || !recipe.Ingredients.Any())
            {
                errors.Add(ValidationMessages.IngredientsEmpty);
                return false;
            }

            foreach (var ing in recipe.Ingredients)
            {
                if (ing.Amount <= 0)
                    errors.Add(ValidationMessages.GetInvalidAmountMessage(ing.Name));
            }
            return true;
        }
    }

    public class InstructionsValidationRule : IValidationRule
    {
        public bool Validate(Recipe recipe, List<string> errors)
        {
            if (recipe.Instructions == null || !recipe.Instructions.Any())
            {
                errors.Add(ValidationMessages.InstructionsEmpty);
                return false;
            }
            return true;
        }
    }

    public class ValidationService
    {
        private readonly List<IValidationRule> _rules;
        public List<string> Errors { get; private set; } = new List<string>();

        public ValidationService()
        {
            _rules = new List<IValidationRule>
            {
                new TitleValidationRule(),
                new IngredientsValidationRule(),
                new InstructionsValidationRule()
            };
        }

        public bool ValidateRecipe(Recipe recipe)
        {
            Errors.Clear();

            if (recipe == null)
            {
                Errors.Add(ValidationMessages.RecipeNull);
                return false;
            }

            foreach (var rule in _rules)
            {
                rule.Validate(recipe, Errors);
            }

            return !Errors.Any();
        }
    }
}
