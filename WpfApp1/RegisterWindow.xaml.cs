using System.Windows;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string confirmPassword = ConfirmPasswordBox.Password.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заповніть всі поля!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Паролі не співпадають!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            User existingUser = UserStorage.Load();

            if (existingUser != null && existingUser.Login == login)
            {
                MessageBox.Show("Користувач з таким логіном вже існує!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User newUser = new User
            {
                Login = login,
                Password = password,
                Level = 1,
                LessonsCompleted = 0,
                StudyMinutes = 0,
                PhotoPath = ""
            };

            UserStorage.Save(newUser);

            MessageBox.Show("Реєстрація успішна!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

            UserWindow userWindow = new UserWindow(newUser);
            userWindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}