using System;
using System.Collections.Generic;

namespace final
{
    public class RecipeFactory
    {
        public Recipe CreateRecipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва рецепта не може бути порожньою.");

            if (ingredients == null || ingredients.Count == 0)
                throw new ArgumentException("Рецепт повинен мати хоча б один інгредієнт.");

            if (steps == null || steps.Count == 0)
                throw new ArgumentException("Рецепт повинен мати хоча б один крок приготування.");

            return new Recipe
            {
                Name = name,
                Ingredients = ingredients,
                Steps = steps,
                CreatedAt = DateTime.Now
            };
        }
    }
}
