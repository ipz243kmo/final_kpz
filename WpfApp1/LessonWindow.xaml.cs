using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class LessonWindow : Window
    {
        private User currentUser;
        private string currentTopic = "";

        private Dictionary<string, List<Word>> vocabularyTopics = new Dictionary<string, List<Word>>();
        private Dictionary<string, Brush> topicColors = new Dictionary<string, Brush>
        {
            { "Сім’я", Brushes.LightBlue },
            { "Їжа", Brushes.Orange },
            { "Тварини", Brushes.LightGreen },
            { "Кольори", Brushes.Purple },
            { "Одяг", Brushes.LightPink },
            { "Професії", Brushes.Gold },
            { "Погода", Brushes.LightCyan }
        };

        public LessonWindow(User user, string topic)
        {
            InitializeComponent();
            currentUser = user;
            currentTopic = topic ?? "";

            InitializeVocabulary();

            foreach (var t in vocabularyTopics.Keys)
                SubTopicComboBox.Items.Add(t);

            SubTopicComboBox.SelectedItem = topic;
            DisplayWords(topic);

        }

        private void InitializeVocabulary()
        {
            
            vocabularyTopics["Сім’я"] = new List<Word> { new Word("Father", "ˈfɑːðər", "Батько", "Images/father.png"), 
                new Word("Mother", "ˈmʌðər", "Мати", "Images/mother.png"), 
                new Word("Brother", "ˈbrʌðər", "Брат", "Images/brother.png"),
                new Word("Sister", "ˈsɪstər", "Сестра", "Images/sister.png"), 
                new Word("Grandfather", "ˈɡrændˌfɑːðər", "Дідусь", "Images/grandfather.png"), 
                new Word("Grandmother", "ˈɡrændˌmʌðər", "Бабуся", "Images/grandmother.png"), 
                new Word("Uncle", "ˈʌŋkəl", "Дядько", "Images/uncle.png"), 
                new Word("Aunt", "ænt", "Тітка", "Images/aunt.png"), 
                new Word("Cousin", "ˈkʌzən", "Двоюрідний брат/сестра", "Images/cousin.png"),
                new Word("Son", "sʌn", "Син", "Images/son.png"), 
                new Word("Daughter", "ˈdɔːtər", "Донька", "Images/daughter.png"),
                new Word("Nephew", "ˈnɛfjuː", "Племінник", "Images/nephew.png"),
                new Word("Niece", "niːs", "Племінниця", "Images/niece.png"), 
                new Word("Husband", "ˈhʌzbənd", "Чоловік", "Images/husband.png"),
                new Word("Wife", "waɪf", "Дружина", "Images/wife.png"),
                new Word("Baby", "ˈbeɪbi", "Дитина", "Images/baby.png"),
                new Word("Parents", "ˈpɛrənts", "Батьки", "Images/parents.png"), 
                new Word("Family", "ˈfæməli", "Сім’я", "Images/family.png"),
                new Word("Child", "ʧaɪld", "Дитина", "Images/child.png"),
                new Word("Teenager", "ˈtiːnˌeɪdʒər", "Підліток", "Images/teenager.png") }; 
            vocabularyTopics["Їжа"] = new List<Word> 
            { new Word("Apple", "ˈæpəl", "Яблуко", "Images/apple.png"),
                new Word("Bread", "brɛd", "Хліб", "Images/bread.png"), 
                new Word("Milk", "mɪlk", "Молоко", "Images/milk.png"),
                new Word("Cheese", "ʧiːz", "Сир", "Images/cheese.png"),
                new Word("Egg", "ɛg", "Яйце", "Images/egg.png"), 
                new Word("Chicken", "ˈʧɪkən", "Курка", "Images/chicken.png"), 
                new Word("Fish", "fɪʃ", "Риба", "Images/fish.png"), 
                new Word("Rice", "raɪs", "Рис", "Images/rice.png"),
                new Word("Tomato", "təˈmeɪtoʊ", "Помідор", "Images/tomato.png"), 
                new Word("Potato", "pəˈteɪtoʊ", "Картопля", "Images/potato.png"), 
                new Word("Carrot", "ˈkærət", "Морква", "Images/carrot.png"), 
                new Word("Banana", "bəˈnænə", "Банан", "Images/banana.png"),
                new Word("Orange", "ˈɔːrɪndʒ", "Апельсин", "Images/orange.png"), 
                new Word("Grapes", "ɡreɪps", "Виноград", "Images/grapes.png"), 
                new Word("Lemon", "ˈlɛmən", "Лимон", "Images/lemon.png"),
                new Word("Strawberry", "ˈstrɔːˌbɛri", "Полуниця", "Images/strawberry.png"), 
                new Word("Watermelon", "ˈwɔːtərˌmɛlən", "Кавун", "Images/watermelon.png"), 
                new Word("Cucumber", "ˈkjuːkʌmbər", "Огірок", "Images/cucumber.png"),
                new Word("Onion", "ˈʌnjən", "Цибуля", "Images/onion.png"), 
                new Word("Garlic", "ˈɡɑːrlɪk", "Часник", "Images/garlic.png") };
            vocabularyTopics["Тварини"] = new List<Word> 
            { new Word("Dog", "dɔg", "Собака", "Images/dog.png"),
                new Word("Cat", "kæt", "Кіт", "Images/cat.png"),
                new Word("Horse", "hɔrs", "Кінь", "Images/horse.png"), 
                new Word("Cow", "kaʊ", "Корова", "Images/cow.png"),
                new Word("Pig", "pɪg", "Свиня", "Images/pig.png"), 
                new Word("Sheep", "ʃiːp", "Вівця", "Images/sheep.png"), 
                new Word("Rabbit", "ˈræbɪt", "Кролик", "Images/rabbit.png"),
                new Word("Lion", "ˈlaɪən", "Лев", "Images/lion.png"), 
                new Word("Tiger", "ˈtaɪgər", "Тигр", "Images/tiger.png"),
                new Word("Elephant", "ˈɛlɪfənt", "Слон", "Images/elephant.png"), 
                new Word("Monkey", "ˈmʌŋki", "Мавпа", "Images/monkey.png"), 
                new Word("Bear", "bɛr", "Ведмідь", "Images/bear.png"),
                new Word("Fox", "fɑks", "Лис", "Images/fox.png"), 
                new Word("Wolf", "wʊlf", "Вовк", "Images/wolf.png"), 
                new Word("Deer", "dɪr", "Олень", "Images/deer.png"),
                new Word("Duck", "dʌk", "Качка", "Images/duck.png"),
                new Word("Goat", "ɡoʊt", "Коза", "Images/goat.png"), 
                new Word("Chicken", "ˈʧɪkən", "Курка", "Images/chicken.png"),
                new Word("Parrot", "ˈpærət", "Папуга", "Images/parrot.png"),
                new Word("Bee", "biː", "Бджола", "Images/bee.png") }; 
            vocabularyTopics["Кольори"] = new List<Word> 
            { new Word("Red", "rɛd", "Червоний", "Images/red.png"), 
                new Word("Blue", "bluː", "Синій", "Images/blue.png"), 
                new Word("Green", "ɡriːn", "Зелений", "Images/green.png"), 
                new Word("Yellow", "ˈjɛloʊ", "Жовтий", "Images/yellow.png"), 
                new Word("Pink", "pɪŋk", "Рожевий", "Images/pink.png"),
                new Word("Purple", "ˈpɜːrpl", "Фіолетовий", "Images/purple.png"), 
                new Word("Orange", "ˈɔːrɪndʒ", "Помаранчевий", "Images/orange.png"),
                new Word("Brown", "braʊn", "Коричневий", "Images/brown.png"),
                new Word("Black", "blæk", "Чорний", "Images/black.png"), 
                new Word("White", "waɪt", "Білий", "Images/white.png"), 
                new Word("Gray", "ɡreɪ", "Сірий", "Images/gray.png"), 
                new Word("Violet", "ˈvaɪəlɪt", "Фіалковий", "Images/violet.png"),
                new Word("Cyan", "ˈsaɪən", "Блакитний", "Images/cyan.png"), 
                new Word("Magenta", "mæˈdʒɛntə", "Маджента", "Images/magenta.png"), 
                new Word("Beige", "beɪʒ", "Бежевий", "Images/beige.png"), 
                new Word("Maroon", "məˈruːn", "Бордовый", "Images/maroon.png"),
                new Word("Olive", "ˈɑːlɪv", "Оливковий", "Images/olive.png"),
                new Word("Turquoise", "ˈtɜːrkɔɪz", "Бірюзовий", "Images/turquoise.png"), 
                new Word("Indigo", "ˈɪndɪɡoʊ", "Індиго", "Images/indigo.png"),
                new Word("Lime", "laɪm", "Лаймовий", "Images/lime.png"), 
            }; 
            vocabularyTopics["Одяг"] = new List<Word> 
            { 
                new Word("Shirt", "ʃɜːrt", "Сорочка", "Images/shirt.png"), 
                new Word("Pants", "pænts", "Штани", "Images/pants.png"),
                new Word("Dress", "drɛs", "Сукня", "Images/dress.png"),
                new Word("Skirt", "skɜːrt", "Спідниця", "Images/skirt.png"),
                new Word("Shoes", "ʃuːz", "Взуття", "Images/shoes.png"), 
                new Word("Hat", "hæt", "Капелюх", "Images/hat.png"), 
                new Word("Coat", "koʊt", "Пальто", "Images/coat.png"), 
                new Word("Jacket", "ˈdʒækɪt", "Куртка", "Images/jacket.png"),
                new Word("Socks", "sɑks", "Шкарпетки", "Images/socks.png"),
                new Word("Scarf", "skɑːrf", "Шарф", "Images/scarf.png"), 
                new Word("Gloves", "ɡlʌvz", "Рукавички", "Images/gloves.png"), 
                new Word("Sweater", "ˈswɛtər", "Светр", "Images/sweater.png"),
                new Word("Belt", "bɛlt", "Ремінь", "Images/belt.png"), 
                new Word("Tie", "taɪ", "Краватка", "Images/tie.png"),
                new Word("Shorts", "ʃɔːrts", "Шорти", "Images/shorts.png"), 
                new Word("Boots", "buːts", "Чоботи", "Images/boots.png"),
                new Word("Underwear", "ˈʌndərwɛr", "Білизна", "Images/underwear.png"),
                new Word("Cap", "kæp", "Кепка", "Images/cap.png"), 
                new Word("Blouse", "blaʊs", "Блузка", "Images/blouse.png"),
                new Word("Sweatshirt", "ˈswɛtʃɜːrt", "Светр спортивний", "Images/sweatshirt.png"), 
            }; 
            vocabularyTopics["Професії"] = new List<Word> 
            { new Word("Teacher", "ˈtiːtʃər", "Вчитель", "Images/teacher.png"), 
                new Word("Doctor", "ˈdɒktər", "Лікар", "Images/doctor.png"), 
                new Word("Engineer", "ˌɛnʤɪˈnɪər", "Інженер", "Images/engineer.png"),
                new Word("Farmer", "ˈfɑːrmər", "Фермер", "Images/farmer.png"),
                new Word("Nurse", "nɜːrs", "Медсестра", "Images/nurse.png"), 
                new Word("Driver", "ˈdraɪvər", "Водій", "Images/driver.png"),
                new Word("Chef", "ʃɛf", "Шеф-кухар", "Images/chef.png"),
                new Word("Police", "pəˈliːs", "Поліцейський", "Images/police.png"), 
                new Word("Firefighter", "ˈfaɪərˌfaɪtər", "Пожежник", "Images/firefighter.png"),
                new Word("Actor", "ˈæktər", "Актор", "Images/actor.png"), 
                new Word("Singer", "ˈsɪŋər", "Співак", "Images/singer.png"), 
                new Word("Painter", "ˈpeɪntər", "Художник", "Images/painter.png"), 
                new Word("Driver", "ˈdraɪvər", "Водій", "Images/driver.png"), 
                new Word("Writer", "ˈraɪtər", "Письменник", "Images/writer.png"), 
                new Word("Dancer", "ˈdænsər", "Танцівник", "Images/dancer.png"), 
                new Word("Student", "ˈstjuːdənt", "Студент", "Images/student.png"),
                new Word("Manager", "ˈmænɪdʒər", "Менеджер", "Images/manager.png"), 
                new Word("Programmer", "ˈproʊɡræmər", "Програміст", "Images/programmer.png"),
                new Word("Designer", "dɪˈzaɪnər", "Дизайнер", "Images/designer.png"), 
                new Word("Pilot", "ˈpaɪlət", "Пілот", "Images/pilot.png"), 
            };
            vocabularyTopics["Погода"] = new List<Word> 
            { new Word("Sunny", "ˈsʌni", "Сонячно", "Images/sunny.png"), 
                new Word("Rainy", "ˈreɪni", "Дощ", "Images/rainy.png"), 
                new Word("Cloudy", "ˈklaʊdi", "Хмарно", "Images/cloudy.png"),
                new Word("Snowy", "ˈsnoʊi", "Сніг", "Images/snowy.png"), 
                new Word("Windy", "ˈwɪndi", "Вітряно", "Images/windy.png"), 
                new Word("Stormy", "ˈstɔːrmi", "Шторм", "Images/stormy.png"), 
                new Word("Foggy", "ˈfɒgi", "Туман", "Images/foggy.png"),
                new Word("Hot", "hɒt", "Спекотно", "Images/hot.png"), 
                new Word("Cold", "koʊld", "Холодно", "Images/cold.png"), 
                new Word("Warm", "wɔːrm", "Тепло", "Images/warm.png"),
                new Word("Cool", "kuːl", "Прохолодно", "Images/cool.png"), 
                new Word("Thunder", "ˈθʌndər", "Грім", "Images/thunder.png"), 
                new Word("Lightning", "ˈlaɪtnɪŋ", "Блискавка", "Images/lightning.png"),
                new Word("Rainbow", "ˈreɪnˌboʊ", "Веселка", "Images/rainbow.png"),
                new Word("Hail", "heɪl", "Град", "Images/hail.png"),
                new Word("Mist", "mɪst", "Мгла", "Images/mist.png"),
                new Word("Drizzle", "ˈdrɪzəl", "Моросяний дощ", "Images/drizzle.png"), 
                new Word("Blizzard", "ˈblɪzərd", "Метель", "Images/blizzard.png"), 
                new Word("Hurricane", "ˈhʌrɪkən", "Ураган", "Images/hurricane.png"), 
                new Word("Tornado", "tɔːrˈneɪdoʊ", "Торнадо", "Images/tornado.png") };
        }


        private void DisplayWords(string topic, bool unlearnedOnly = false)
        {
            if (topic == null) return;
            WordCardsPanel.Children.Clear();
            if (!vocabularyTopics.ContainsKey(topic)) return;

            foreach (var word in vocabularyTopics[topic])
            {
                if (unlearnedOnly && word.IsLearned) continue;

                Border card = new Border
                {
                    Width = 180,
                    Height = 200,
                    Background = Brushes.White,
                    CornerRadius = new CornerRadius(10),
                    Margin = new Thickness(10),
                    BorderBrush = topicColors.ContainsKey(topic) ? topicColors[topic] : Brushes.Gray,
                    BorderThickness = new Thickness(2),
                    Cursor = Cursors.Hand
                };

                card.MouseEnter += (s, e) => card.Background = new SolidColorBrush(Color.FromRgb(230, 250, 255));
                card.MouseLeave += (s, e) => card.Background = Brushes.White;

                StackPanel sp = new StackPanel { Margin = new Thickness(5) };

                Image img = new Image
                {
                    Source = new BitmapImage(new Uri(word.ImagePath, UriKind.Relative)),
                    Height = 80,
                    Stretch = Stretch.Uniform
                };
                sp.Children.Add(img);

                sp.Children.Add(new TextBlock { Text = word.English, FontWeight = FontWeights.Bold, FontSize = 14, TextAlignment = TextAlignment.Center });
                sp.Children.Add(new TextBlock { Text = word.Transcription, FontStyle = FontStyles.Italic, FontSize = 12, TextAlignment = TextAlignment.Center });
                sp.Children.Add(new TextBlock { Text = word.Ukrainian, FontSize = 13, TextAlignment = TextAlignment.Center });

                CheckBox learned = new CheckBox
                {
                    Content = "Вивчено",
                    IsChecked = word.IsLearned,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                learned.Checked += (s, e) => word.IsLearned = true;
                learned.Unchecked += (s, e) => word.IsLearned = false;
                sp.Children.Add(learned);

                card.Child = sp;
                WordCardsPanel.Children.Add(card);
            }
        }
        private void OpenGrammar_Click(object sender, RoutedEventArgs e)
        {
            GrammarWindow grammarWindow = new GrammarWindow(currentUser);
            grammarWindow.Show();
        }
        private void SubTopicComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubTopicComboBox.SelectedItem != null)
                DisplayWords(SubTopicComboBox.SelectedItem?.ToString());
        }

        private void ShowUnlearned_Click(object sender, RoutedEventArgs e)
        {
            if (SubTopicComboBox.SelectedItem != null)
                DisplayWords(SubTopicComboBox.SelectedItem.ToString(), true);
        }

        private void PlayGame_Click(object sender, RoutedEventArgs e)
        {
            if (SubTopicComboBox.SelectedItem == null) return;
            var learnedWords = vocabularyTopics[SubTopicComboBox.SelectedItem.ToString()].FindAll(w => w.IsLearned);
            if (learnedWords.Count == 0) { MessageBox.Show("No words learned yet!"); return; }
            GameWindow game = new GameWindow(learnedWords);
            game.ShowDialog();
        }

        private void BackToProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void ResetLearned_Click(object sender, RoutedEventArgs e)
        {
            foreach (var list in vocabularyTopics.Values)
                foreach (var word in list)
                    word.IsLearned = false;
            DisplayWords(SubTopicComboBox.SelectedItem?.ToString());
        }

        private void SaveProgress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                var progress = new Dictionary<string, List<string>>();
                foreach (var topic in vocabularyTopics.Keys)
                {
                    progress[topic] = new List<string>();
                    foreach (var word in vocabularyTopics[topic])
                        if (word.IsLearned) progress[topic].Add(word.English);
                }

                string file = $"User_{currentUser.Login}_progress.json";
                string json = JsonSerializer.Serialize(progress, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(file, json);

                MessageBox.Show("Progress saved successfully!", "Save Progress", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving progress: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}