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
		EditingRecipe = recipe ?? new Recipe();
		SaveCommand = new RelayCommand(obj => Save(), can => IsValid());
	}

	private bool IsValid()
	{
		
		return !string.IsNullOrWhiteSpace(EditingRecipe.Title) &&
			   EditingRecipe.Ingredients.Count > 0;
	}

	private void Save() {  }
}