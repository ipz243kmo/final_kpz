using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class ExerciseFormWindow : Window
    {
        private Dictionary<string, string> texts = new Dictionary<string, string>
{
    { "Text 1", "I wake up every morning at seven o’clock. I brush my teeth and wash my face. Then I have breakfast with my family. I usually eat bread, eggs, and tea. After breakfast, I go to school by bus. My school starts at eight o’clock. I study math, English, and science. At noon, I have lunch in the school cafeteria. In the afternoon, I have physical education and art classes. School ends at three o’clock. I return home and do my homework. Then I play with my friends or read a book. In the evening, I have dinner with my family. After dinner, I watch TV or listen to music. I go to bed at ten o’clock and sleep well." },

    { "Text 2", "Last Sunday, I went to the park with my friends. The weather was sunny and warm. We walked along the lake and fed the ducks. I brought a picnic basket with sandwiches and juice. We sat on a blanket under a big tree. We played football and ran on the grass. Children were riding bicycles and playing with a ball. We saw some people painting pictures and reading books. I took many photos with my camera. We drank cold lemonade to stay cool. In the afternoon, we went to the playground. I climbed the slides and swings many times. We laughed and talked about school and hobbies. The sun began to set, and it became cooler. We went home tired but happy." },

    { "Text 3", "My favorite hobby is painting. I like to use watercolors and pencils. I usually paint in the evening after school. I have a small table with all my supplies. I often draw landscapes, animals, and flowers. Sometimes I paint portraits of my family members. I watch tutorials online to learn new techniques. Painting makes me feel relaxed and happy. I enjoy mixing colors and creating new shades. My friends like my paintings and sometimes ask for them. I keep my best works in a special folder. On weekends, I attend art classes in the city. The teacher shows us how to improve our skills. I hope one day to have my own art exhibition. Painting is a way to express my feelings and ideas." },

    { "Text 4", "Last summer, I visited the zoo with my family. The zoo is very large and has many animals. First, we saw the lions and tigers in their cages. They were sleeping under the trees. Then we visited the monkeys and watched them play. Some monkeys were eating bananas and jumping around. We also saw elephants, giraffes, and zebras. The elephants were spraying water on themselves. My little brother liked the penguins the most. We took photos of the colorful birds in the aviary. After walking for a while, we had ice cream near the lake. We fed some fish and ducks in the pond. The zoo guide told us interesting facts about the animals. In the afternoon, we went to the gift shop and bought souvenirs. We went home happy and talked about the animals we saw." }
};
        private Dictionary<string, string> translations = new Dictionary<string, string>
        {
        
    { "Text 1", "Я прокидаюся щоранку о сьомій годині. Я чищу зуби та вмиваюся. Потім снідаю з родиною. Зазвичай я їм хліб, яйця та п’ю чай. Після сніданку я їду до школи автобусом. Моя школа починається о восьмій годині. Я вивчаю математику, англійську та природничі науки. Опівдні я обідаю у шкільній їдальні. Вдень у мене уроки фізкультури та мистецтва. Школа закінчується о третій годині. Я повертаюся додому і роблю домашнє завдання. Потім граюся з друзями або читаю книгу. Ввечері я вечеряю з родиною. Після вечері дивлюся телевізор або слухаю музику. Я лягаю спати о десятій годині і добре сплю." },

    { "Text 2", "Минулої неділі я пішов у парк з друзями. Погода була сонячна та тепла. Ми гуляли вздовж озера та годували качок. Я приніс пікніковий кошик із сендвічами та соком. Ми сиділи на ковдрі під великим деревом. Ми грали у футбол і бігали по траві. Діти каталися на велосипедах і гралися м’ячем. Ми бачили людей, які малювали картини та читали книги. Я зробив багато фото на свій фотоапарат. Ми пили холодний лимонад, щоб охолонути. Вдень ми пішли на дитячий майданчик. Я багато разів лазив на гірки та гойдалки. Ми сміялися та говорили про школу та хобі. Сонце почало заходити, і стало прохолодніше. Ми повернулися додому втомлені, але щасливі." },

    { "Text 3", "Моє улюблене хобі – малювання. Мені подобається використовувати акварель та олівці. Зазвичай я малюю ввечері після школи. У мене є маленький столик з усіма матеріалами. Я часто малюю пейзажі, тварин та квіти. Іноді я малюю портрети членів родини. Я дивлюся навчальні відео онлайн, щоб навчитися новим технікам. Малювання робить мене розслабленим та щасливим. Мені подобається змішувати кольори та створювати нові відтінки. Мої друзі люблять мої картини і іноді просять їх. Я зберігаю найкращі роботи в окремій папці. У вихідні я відвідую уроки мистецтва у місті. Учитель показує, як покращити навички. Сподіваюся, колись у мене буде власна виставка. Малювання – це спосіб висловити свої почуття та ідеї." },

    { "Text 4", "Минулого літа я відвідав зоопарк з родиною. Зоопарк дуже великий і має багато тварин. Спершу ми побачили левів і тигрів у їхніх клітках. Вони спали під деревами. Потім ми відвідали мавп і спостерігали, як вони граються. Деякі мавпи їли банани та стрибали навколо. Ми також бачили слонів, жирафів і зебр. Слони обприскували себе водою. Моєму молодшому братові найбільше сподобалися пінгвіни. Ми фотографували яскравих птахів у вольєрі. Після прогулянки ми з’їли морозиво біля озера. Ми годували риб та качок у ставку. Гід розповів цікаві факти про тварин. Вдень ми пішли в сувенірний магазин і купили подарунки. Ми повернулися додому щасливі та обговорювали побачене." }
};
        private string currentTextKey = "";
        private string currentTranslation = "";

        public ExerciseFormWindow()
        {
            InitializeComponent();
            LoadTextButtons();

          
            EnglishTextBlock.Text = "";
            TranslationBox.Text = "";
            ExplanationBorder.Visibility = Visibility.Collapsed;
        }

        private void LoadTextButtons()
        {
            TextSelectionPanel.Children.Clear();
            foreach (var key in texts.Keys)
            {
                Button btn = new Button
                {
                    Content = key,
                    Width = 120,
                    Height = 50,
                    Margin = new Thickness(5),
                    Background = Brushes.LightBlue,
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
            currentTextKey = key;
            EnglishTextBlock.Text = texts[key];
            TranslationBox.Text = "";
            ExplanationBorder.Visibility = Visibility.Collapsed;
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentTextKey)) return;

          
            if (translations.ContainsKey(currentTextKey))
            {
                ExplanationTextBlock.Text = translations[currentTextKey];
                ExplanationBorder.Visibility = Visibility.Visible;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            currentTranslation = TranslationBox.Text;
            MessageBox.Show("Your translation is saved!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}