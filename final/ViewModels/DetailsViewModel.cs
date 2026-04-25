public class DetailsViewModel : BaseViewModel
{
    private Recipe _selectedRecipe;
    private int _servings = 1;

    public Recipe SelectedRecipe
    {
        get => _selectedRecipe;
        set => SetProperty(ref _selectedRecipe, value);
    }

    public int Servings
    {
        get => _servings;
        set
        {
            if (SetProperty(ref _servings, value))
                OnPropertyChanged(nameof(TotalCalories)); 
        }
    }

    public double TotalCalories => SelectedRecipe.TotalCalories * Servings;

    public DetailsViewModel(Recipe recipe)
    {
        SelectedRecipe = recipe;
    }

    public ICommand ExportCommand => new RelayCommand(obj => ExportToFile());

    private void ExportToFile()
    {
        [cite_start]
    }
}