using System;
using System.Collections.Generic;
using System.Windows.Input;
using final;

namespace final.ViewModels
{
    public class EditorViewModel : BaseViewModel
    {
        private Recipe _editingRecipe;

        public Recipe EditingRecipe
        {
            get => _editingRecipe;
            set => SetProperty(ref _editingRecipe, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand AddIngredientCommand { get; }

        public EditorViewModel(Recipe recipe = null)
        {
            if (recipe != null)
            {
                EditingRecipe = recipe;
            }
            else
            {
                var factory = new RecipeFactory();
                EditingRecipe = factory.CreateRecipe("", new List<Ingredient>(), new List<string>());
            }
            SaveCommand = new RelayCommand(obj => Save(), can => IsValid());
        }

        private bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(EditingRecipe.Title) &&
                   EditingRecipe.Ingredients.Count > 0;
        }

        private void Save()
        {
            // Логіка збереження рецепта
        }
    }
}
