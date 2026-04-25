using System.Windows;
using RecipeFinder.ViewModels;
using RecipeFinder.Services;

namespace RecipeFinder.View
{
    
    [cite_start]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            [cite_start]
            var repository = new JsonRecipeRepository();

           
            DataContext = new MainViewModel(repository);
        }
    }
}