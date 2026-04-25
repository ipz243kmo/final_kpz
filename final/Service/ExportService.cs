
using System;
using System.IO;
using System.Text;
using RecipeFinder.Models;

namespace RecipeFinder.Services
{
    public class ExportService
    {
        private readonly string _exportDirectory = "Exports";

        public ExportService()
        {
            if (!Directory.Exists(_exportDirectory))
                Directory.CreateDirectory(_exportDirectory);
        }

        public string ExportToText(Recipe recipe)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"РЕЦЕПТ: {recipe.Title.ToUpper()}");
            sb.AppendLine(new string('=', 20));
            sb.AppendLine($"Категорія: {recipe.Category}");
            sb.AppendLine($"Час приготування: {recipe.CookingTimeInMinutes} хв.");
            sb.AppendLine();

            sb.AppendLine("ІНГРЕДІЄНТИ:");
            foreach (var ing in recipe.Ingredients)
            {
                sb.AppendLine($"- {ing.Name}: {ing.Amount} {ing.Unit}");
            }

            sb.AppendLine();
            sb.AppendLine("ІНСТРУКЦІЯ:");
            for (int i = 0; i < recipe.Instructions.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {recipe.Instructions[i]}");
            }

            string fileName = $"Recipe_{Guid.NewGuid().ToString().Substring(0, 8)}.txt";
            string fullPath = Path.Combine(_exportDirectory, fileName);

            File.WriteAllText(fullPath, sb.ToString(), Encoding.UTF8);
            return fullPath;
        }
    }
}