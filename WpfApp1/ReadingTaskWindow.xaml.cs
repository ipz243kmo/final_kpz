using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class ReadingTaskWindow : Window
    {
        private Dictionary<string, string> texts = new Dictionary<string, string>
{
    { "My Daily Routine",
      "I wake up at 7 a.m. every morning. I brush my teeth and wash my face. I take a shower if I have time. Then I get dressed for school. I make my bed before leaving the room. I have breakfast with my family. I usually eat eggs, toast, and tea. Sometimes I eat cereal or fruit. After breakfast, I pack my school bag. I check if I have all my books. I put on my shoes and coat. I leave the house at 7:45 a.m. I walk to the bus stop. The bus arrives at 7:55 a.m. I sit next to my friend on the bus. We talk about school and hobbies. School starts at 8:15 a.m. In the first lesson, we study English. Then we have math class. After that, we have science. At 10:30 a.m., we have a short break. I eat a snack and drink water. After break, we have history class. Then we have art and music lessons. Lunch is at 12:30 p.m. I eat in the school cafeteria with friends. In the afternoon, we have physical education. I like to play basketball and football. School finishes at 3 p.m. I go home and do my homework. After homework, I play video games or read. Dinner is at 7 p.m. I watch TV or listen to music. I go to bed at 10 p.m."
    },

    { "A Trip to the Zoo",
      "Last Saturday, I visited the zoo with my family. The weather was sunny and warm. We arrived at the zoo at 10 a.m. The first animals we saw were lions. They were sleeping under the trees. Next, we visited the tigers. They looked very strong and big. Then we went to see the monkeys. Some monkeys were playing with each other. Others were eating bananas. We also saw the elephants. They were spraying water with their trunks. The giraffes were eating leaves from tall trees. My little brother liked the penguins the most. We took many photos near the aviary. The colorful birds were singing beautifully. We walked to the reptile house. We saw snakes and lizards. After that, we had ice cream near the lake. We fed some ducks and fish. The zoo guide told us interesting facts. We bought souvenirs in the gift shop. We went to the playground for a while. My sister climbed the slide many times. We laughed and played together. The sun began to set. We left the zoo tired but happy. We returned home at 6 p.m. We talked about our favorite animals. It was a very fun and exciting day."
    },

    { "My Favorite Hobby",
      "My favorite hobby is painting. I like to use watercolors and pencils. I usually paint in the evening after school. I have a small table with all my supplies. I often draw landscapes, animals, and flowers. Sometimes I paint portraits of my family members. I watch online tutorials to learn new techniques. Painting makes me feel relaxed. I enjoy mixing colors. I like creating new shades. My friends admire my paintings. Sometimes they ask me to paint for them. I keep my best works in a special folder. On weekends, I attend art classes in the city. The teacher shows us how to improve our skills. I hope one day to have my own art exhibition. Painting is a way to express my feelings and ideas. I experiment with new tools and brushes. I paint from nature and photographs. I often listen to music while painting. I like to try different styles. I learn a lot from mistakes. Painting helps me focus. I feel proud of my progress. I share my works online. People leave positive comments. I enjoy giving gifts of my paintings. I feel happy when someone appreciates my art. I will continue painting for many years."
    },

    { "A Visit to the Park",
      "Last Sunday, I went to the park with my friends. The weather was sunny and warm. We walked along the lake and fed the ducks. I brought a picnic basket with sandwiches and juice. We sat on a blanket under a big tree. We played football and ran on the grass. Children were riding bicycles and playing with a ball. We saw some people painting pictures and reading books. I took many photos with my camera. We drank cold lemonade to stay cool. In the afternoon, we went to the playground. I climbed the slides and swings many times. We laughed and talked about school and hobbies. The sun began to set, and it became cooler. We went home tired but happy. We talked about our favorite moments. I shared my photos with my family. We planned another visit next weekend. Everyone enjoyed the day. I felt relaxed and cheerful. The birds were singing in the trees. Some people were jogging in the park. We saw flowers blooming. The grass was green and fresh. We picked a few flowers. We watched squirrels playing. The clouds were white and fluffy. We said goodbye to the park. It was a wonderful day outdoors."
    },

    { "A Summer Trip to the Beach",
      "Last summer, I went to the beach with my family. We left home early in the morning. The sun was shining brightly. The sand was warm under our feet. We put our towels on the beach. I built a big sandcastle. My sister collected seashells. We swam in the sea. The water was cool and refreshing. We played beach volleyball. Some people were surfing. We drank cold drinks under the umbrella. My parents read books. I found a small crab near the rocks. We took many photos of the scenery. We had lunch at a small café near the beach. Ice cream was delicious. We watched the sunset. The sky turned orange and pink. We packed our things and went home. Everyone was tired but happy. We talked about the fun day. I enjoyed swimming the most. The waves were high but safe. We collected pebbles as souvenirs. I wrote a postcard to my friend. The seagulls were flying above. We listened to music on the beach. I will always remember this trip."
    }
};

        private string currentTextKey = "";

        public ReadingTaskWindow()
        {
            InitializeComponent();
            ShowTextSelectionCards();
        }

        private void ShowTextSelectionCards()
        {
            TextSelectionPanel.Children.Clear();

            foreach (var key in texts.Keys)
            {
                Button btn = new Button
                {
                    Content = key,
                    Width = 150,
                    Height = 100,
                    Margin = new Thickness(10),
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    Background = System.Windows.Media.Brushes.LightBlue,
                    Cursor = System.Windows.Input.Cursors.Hand
                };

                btn.Click += (s, e) => SelectText(key);
                TextSelectionPanel.Children.Add(btn);
            }
        }

        private void SelectText(string key)
        {
            currentTextKey = key;
            EnglishTextBox.Text = texts[key];

            TextSelectionPanel.Visibility = Visibility.Collapsed;
            TextDisplayGrid.Visibility = Visibility.Visible;
        }

        private void GoToExercises_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentTextKey))
            {
                MessageBox.Show("Оберіть текст перед переходом до завдань!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ReadingQuestionsWindow questionsWindow = new ReadingQuestionsWindow(currentTextKey, texts[currentTextKey]);
            questionsWindow.Owner = this;
            questionsWindow.ShowDialog();
        }
    }
}