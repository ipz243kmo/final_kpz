using System.Windows;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private User currentUser;

        public MainWindow()
        {
            InitializeComponent();

          
            currentUser = UserStorage.Load() ?? new User();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заповніть всі поля!", "Помилка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

           
            if (currentUser.Login == login && currentUser.Password == password)
            {
                MessageBox.Show("Вхід успішний!", "Успіх",
                    MessageBoxButton.OK, MessageBoxImage.Information);

             
                UserWindow userWindow = new UserWindow(currentUser);
                userWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль!", "Помилка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}