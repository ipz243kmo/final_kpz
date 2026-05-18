using System;
using System.IO;
using System.Text.Json;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public static class UserStorage
    {
        // Файл збереження у папці Документи користувача
        private static readonly string filePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "user.json"
        );

        // Зберегти користувача
        public static void Save(User user)
        {
            try
            {
                string json = JsonSerializer.Serialize(user, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                // Якщо щось пішло не так, виведемо помилку
                Console.WriteLine($"Помилка збереження користувача: {ex.Message}");
            }
        }

        // Завантажити користувача
        public static User Load()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    // Якщо файлу ще немає, повертаємо новий об’єкт
                    return new User();
                }

                string json = File.ReadAllText(filePath);
                // Десеріалізація, якщо щось пішло не так, повертаємо новий User
                return JsonSerializer.Deserialize<User>(json) ?? new User();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завантаження користувача: {ex.Message}");
                return new User();
            }
        }

        // Додатково: метод для перевірки, чи існує база
        public static bool Exists() => File.Exists(filePath);
    }
}