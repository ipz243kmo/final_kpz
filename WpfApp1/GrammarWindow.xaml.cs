using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class GrammarWindow : Window
    {
        
        private User currentUser;
        private Dictionary<string, bool> completedLessons = new();

       

        public GrammarWindow(User user)
        {
            InitializeComponent();
            currentUser = user;

        }

        private void PresentSimple_Click(object sender, RoutedEventArgs e)
        {
            new GrammarExerciseWindow(presentSimpleExercises).ShowDialog();
        }

        private void PresentContinuous_Click(object sender, RoutedEventArgs e)
        {
            new GrammarExerciseWindow(presentContinuousExercises).ShowDialog();
        }

        private void PastSimple_Click(object sender, RoutedEventArgs e)
        {
            new GrammarExerciseWindow(pastSimpleExercises).ShowDialog();
        }

        private void FutureSimple_Click(object sender, RoutedEventArgs e)
        {
            new GrammarExerciseWindow(futureSimpleExercises).ShowDialog();
        }
        private List<GrammarExercise> presentSimpleExercises = new()
{
    new GrammarExercise{ SentenceTemplate="She ____ to school every day.", CorrectWords=new[]{"goes"}, Options=new[]{"go","goes","going"}, Explanation="Після she/he/it додається -s."},
    new GrammarExercise{ SentenceTemplate="They ____ football on Sundays.", CorrectWords=new[]{"play"}, Options=new[]{"play","plays","playing"}, Explanation="Після they використовується базова форма."},
    new GrammarExercise{ SentenceTemplate="He ____ coffee every morning.", CorrectWords=new[]{"drinks"}, Options=new[]{"drink","drinks","drinking"}, Explanation="Після he додається -s."},
    new GrammarExercise{ SentenceTemplate="I ____ English every day.", CorrectWords=new[]{"study"}, Options=new[]{"study","studies","studying"}, Explanation="Після I дієслово не змінюється."},
    new GrammarExercise{ SentenceTemplate="We ____ TV in the evening.", CorrectWords=new[]{"watch"}, Options=new[]{"watch","watches","watching"}, Explanation="Після we використовується базова форма."},
    new GrammarExercise{ SentenceTemplate="My father ____ a car.", CorrectWords=new[]{"drives"}, Options=new[]{"drive","drives","driving"}, Explanation="Father = he → додаємо -s."},
    new GrammarExercise{ SentenceTemplate="Children ____ in the park.", CorrectWords=new[]{"play"}, Options=new[]{"play","plays","playing"}, Explanation="Children — множина."},
    new GrammarExercise{ SentenceTemplate="She ____ a book every week.", CorrectWords=new[]{"reads"}, Options=new[]{"read","reads","reading"}, Explanation="She → дієслово + s."}
};
       
        private List<GrammarExercise> presentContinuousExercises = new()
{
    new GrammarExercise{ SentenceTemplate="She ____ a book now.", CorrectWords=new[]{"is reading"}, Options=new[]{"is reading","reads","read"}, Explanation="Present Continuous = am/is/are + V-ing."},
    new GrammarExercise{ SentenceTemplate="They ____ football now.", CorrectWords=new[]{"are playing"}, Options=new[]{"are playing","play","played"}, Explanation="They → are + дієслово-ing."},
    new GrammarExercise{ SentenceTemplate="I ____ dinner.", CorrectWords=new[]{"am cooking"}, Options=new[]{"am cooking","cook","cooked"}, Explanation="I → am + V-ing."},
    new GrammarExercise{ SentenceTemplate="He ____ TV.", CorrectWords=new[]{"is watching"}, Options=new[]{"is watching","watch","watched"}, Explanation="He → is + V-ing."},
    new GrammarExercise{ SentenceTemplate="We ____ music.", CorrectWords=new[]{"are listening"}, Options=new[]{"are listening","listen","listened"}, Explanation="We → are + V-ing."},
    new GrammarExercise{ SentenceTemplate="The baby ____.", CorrectWords=new[]{"is sleeping"}, Options=new[]{"is sleeping","sleep","slept"}, Explanation="Baby = it → is + V-ing."},
    new GrammarExercise{ SentenceTemplate="Students ____ English.", CorrectWords=new[]{"are studying"}, Options=new[]{"are studying","study","studied"}, Explanation="Students → are."},
    new GrammarExercise{ SentenceTemplate="She ____ a letter.", CorrectWords=new[]{"is writing"}, Options=new[]{"is writing","write","wrote"}, Explanation="She → is + V-ing."}
};
       
        private List<GrammarExercise> pastSimpleExercises = new()
{
    new GrammarExercise{ SentenceTemplate="I ____ to school yesterday.", CorrectWords=new[]{"went"}, Options=new[]{"go","went","gone"}, Explanation="Yesterday → Past Simple."},
    new GrammarExercise{ SentenceTemplate="She ____ a cake.", CorrectWords=new[]{"baked"}, Options=new[]{"bake","baked","baking"}, Explanation="Past Simple правильних дієслів = -ed."},
    new GrammarExercise{ SentenceTemplate="They ____ football.", CorrectWords=new[]{"played"}, Options=new[]{"play","played","playing"}, Explanation="Past Simple."},
    new GrammarExercise{ SentenceTemplate="We ____ a movie.", CorrectWords=new[]{"watched"}, Options=new[]{"watch","watched","watching"}, Explanation="Past Simple."},
    new GrammarExercise{ SentenceTemplate="He ____ a letter.", CorrectWords=new[]{"wrote"}, Options=new[]{"write","wrote","writing"}, Explanation="Неправильне дієслово."},
    new GrammarExercise{ SentenceTemplate="I ____ my homework.", CorrectWords=new[]{"did"}, Options=new[]{"do","did","done"}, Explanation="Do → did."},
    new GrammarExercise{ SentenceTemplate="She ____ the door.", CorrectWords=new[]{"opened"}, Options=new[]{"open","opened","opening"}, Explanation="Past Simple = -ed."},
    new GrammarExercise{ SentenceTemplate="They ____ dinner.", CorrectWords=new[]{"cooked"}, Options=new[]{"cook","cooked","cooking"}, Explanation="Past Simple."}
};
        
        private List<GrammarExercise> futureSimpleExercises = new()
{
    new GrammarExercise{ SentenceTemplate="I ____ my homework tomorrow.", CorrectWords=new[]{"will do"}, Options=new[]{"will do","do","did"}, Explanation="Future Simple = will + V."},
    new GrammarExercise{ SentenceTemplate="She ____ a book.", CorrectWords=new[]{"will read"}, Options=new[]{"will read","reads","read"}, Explanation="Will + базова форма."},
    new GrammarExercise{ SentenceTemplate="They ____ football.", CorrectWords=new[]{"will play"}, Options=new[]{"will play","play","played"}, Explanation="Future Simple."},
    new GrammarExercise{ SentenceTemplate="We ____ a movie.", CorrectWords=new[]{"will watch"}, Options=new[]{"will watch","watch","watched"}, Explanation="Future Simple."},
    new GrammarExercise{ SentenceTemplate="He ____ dinner.", CorrectWords=new[]{"will cook"}, Options=new[]{"will cook","cook","cooked"}, Explanation="Will + V."},
    new GrammarExercise{ SentenceTemplate="I ____ English.", CorrectWords=new[]{"will study"}, Options=new[]{"will study","study","studied"}, Explanation="Future Simple."},
    new GrammarExercise{ SentenceTemplate="She ____ tomorrow.", CorrectWords=new[]{"will come"}, Options=new[]{"will come","comes","came"}, Explanation="Will + V."},
    new GrammarExercise{ SentenceTemplate="They ____ the project.", CorrectWords=new[]{"will finish"}, Options=new[]{"will finish","finish","finished"}, Explanation="Future Simple."}
};
        private void ShowLesson(string lesson, string example)
        {
            MessageBox.Show($"{lesson}\n{example}", "Grammar Lesson", MessageBoxButton.OK, MessageBoxImage.Information);
            completedLessons[lesson] = true;
        }

        private void SaveProgress_Click(object sender, RoutedEventArgs e)
        {
            foreach (var lesson in completedLessons)
                currentUser.GrammarProgress[lesson.Key] = lesson.Value;

            MessageBox.Show("Progress saved!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}