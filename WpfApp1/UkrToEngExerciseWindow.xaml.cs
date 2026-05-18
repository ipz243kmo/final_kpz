using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class UkrToEngExerciseWindow : Window
    {
        private Dictionary<string, string> UkrTexts = new Dictionary<string, string>
        {
    { "Text 1", "Щоранку я виходжу на прогулянку в парк. Там я бачу птахів, які співають, та дерева, що шелестять на вітрі. Часто беру з собою блокнот і малюю квіти та дерева. Люди бігають або прогулюються з собаками. Діти граються на дитячому майданчику. Я люблю слухати спів птахів і насолоджуватися свіжим повітрям. Іноді я зустрічаю старих друзів і ми розмовляємо. Прогулянка допомагає мені почуватися бадьоро та щасливо. Після цього я повертаюся додому, роблю легку розминку і снідаю. Це моя улюблена частина дня." },

    { "Text 2", "Моя сім’я любить готувати разом, особливо у вечірні години. Ми часто робимо піцу, салати та десерти. Кожен має своє завдання: хтось ріже овочі, хтось замішує тісто, хтось готує соуси. Після приготування ми сідаємо разом і вечеряємо, розмовляючи про події дня. Я люблю пробувати нові рецепти та експериментувати з інгредієнтами. Мама розповідає цікаві кулінарні поради, а тато жартує і створює веселу атмосферу. Іноді ми запрошуємо сусідів або друзів і вечеря перетворюється на маленьке свято. Це допомагає нам зближуватися та проводити час разом. Після вечері ми миємо посуд і плануємо наступний день." },

    { "Text 3", "У неділю я зазвичай читаю книги. Мені подобаються пригодницькі історії, детективи та книги про науку. Я сідаю у зручному кріслі з чашкою чаю або кави. Читання допомагає мені відпочити після насиченого тижня і розвивати уяву. Іноді я позначаю цікаві місця в книзі олівцем або роблю нотатки. Інколи я обговорюю прочитане з друзями або пишу невеликі відгуки. Я люблю книги, які захоплюють з першої сторінки. У мене є невелика домашня бібліотека, і я постійно купую нові видання. Читання дозволяє мені відчути інші культури та дізнатися нові речі. Це моє улюблене хобі у вихідні." },

    { "Text 4", "Моє хобі – фотографія. Я люблю фотографувати природу, тварин та людей. На вихідних я йду в парк або до лісу з камерою. Я знімаю різні сюжети: пейзажі, портрети, деталі природи. Після цього обробляю фото на комп’ютері, створюю альбоми та презентації. Іноді я публікую свої роботи в соціальних мережах або показую друзям. Мені подобається експериментувати з освітленням, ракурсами та кольорами. Це допомагає мені розвивати творчі навички та уважність до деталей. Фотографія приносить мені задоволення та дозволяє зберігати пам’ять про важливі моменти життя. Я мрію колись влаштувати власну виставку та поділитися своїми роботами з іншими." }
};

        private Dictionary<string, string> ExampleTranslations = new Dictionary<string, string>
        {
            { "Text 1", "Every morning I go for a walk in the park. There I see birds singing and trees rustling in the wind. I often take a notebook with me and draw flowers and trees. People are jogging or walking with their dogs. Children are playing on the playground. I love listening to the birds and enjoying the fresh air. Sometimes I meet old friends and we talk. The walk helps me feel energetic and happy. After that, I return home, do some light stretching, and have breakfast. This is my favorite part of the day." },

    { "Text 2", "My family loves cooking together, especially in the evenings. We often make pizza, salads, and desserts. Everyone has their own task: someone cuts the vegetables, someone kneads the dough, someone prepares sauces. After cooking, we sit together and have dinner, talking about the events of the day. I enjoy trying new recipes and experimenting with ingredients. Mom gives interesting cooking tips, and Dad jokes, creating a fun atmosphere. Sometimes we invite neighbors or friends, and dinner becomes a small celebration. This helps us get closer and spend time together. After dinner, we wash the dishes and plan for the next day." },

    { "Text 3", "On Sundays, I usually read books. I like adventure stories, detective novels, and books about science. I sit in a comfortable armchair with a cup of tea or coffee. Reading helps me relax after a busy week and develops my imagination. Sometimes I mark interesting parts in the book with a pencil or make notes. Occasionally, I discuss what I have read with friends or write short reviews. I love books that capture me from the first page. I have a small home library, and I always buy new editions. Reading allows me to experience other cultures and learn new things. It is my favorite hobby on weekends." },

    { "Text 4", "My hobby is photography. I love photographing nature, animals, and people. On weekends, I go to the park or forest with my camera. I take pictures of different subjects: landscapes, portraits, details of nature. After that, I edit the photos on the computer and create albums and presentations. Sometimes I post my work on social media or show it to friends. I enjoy experimenting with lighting, angles, and colors. This helps me develop creative skills and attention to detail. Photography gives me joy and allows me to preserve memories of important moments in life. I dream of organizing my own exhibition one day and sharing my work with others." }
};

        private string currentKey = "";
        private string currentTranslation = "";

        public UkrToEngExerciseWindow()
        {
            InitializeComponent();
            LoadTextButtons();

            UkrainianTextBlock.Text = "";
            TranslationBox.Text = "";
            ExplanationBorder.Visibility = Visibility.Collapsed;

            TranslationBox.TextChanged += (s, e) =>
            {
                TranslationPlaceholder.Visibility = string.IsNullOrEmpty(TranslationBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            };
        }

        private void LoadTextButtons()
        {
            TextSelectionPanel.Children.Clear();
            foreach (var key in UkrTexts.Keys)
            {
                Button btn = new Button
                {
                    Content = key,
                    Width = 120,
                    Height = 50,
                    Margin = new Thickness(5),
                    Background = Brushes.LightGreen,
                    Foreground = Brushes.Black,
                    FontWeight = FontWeights.Bold,
                    Cursor = System.Windows.Input.Cursors.Hand
                };
                btn.Click += (s, e) => SelectText(key);
                TextSelectionPanel.Children.Add(btn);
            }
        }

        private void SelectText(string key)
        {
            currentKey = key;
            UkrainianTextBlock.Text = UkrTexts[key];
            TranslationBox.Text = "";
            ExplanationBorder.Visibility = Visibility.Collapsed;
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentKey)) return;

            ExplanationTextBlock.Text = ExampleTranslations[currentKey];
            ExplanationBorder.Visibility = Visibility.Visible;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            currentTranslation = TranslationBox.Text;
            MessageBox.Show("Your translation has been saved!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}