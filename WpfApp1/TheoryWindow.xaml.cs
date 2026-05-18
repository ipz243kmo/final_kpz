using System.Windows;

namespace WpfApp1
{
    public partial class TheoryWindow : Window
    {
        private string language = "EN";

        public TheoryWindow()
        {
            InitializeComponent();
        }

        private void PresentSimple_Click(object sender, RoutedEventArgs e)
        {
            if (language == "EN")
            {
                TitleText.Text = "Present Simple";

                RuleText.Text =
                "USE\n" +
                "Present Simple is used for:\n" +
                "• daily routines\n" +
                "• habits\n" +
                "• general facts\n\n" +

                "AFFIRMATIVE\n" +
                "Subject + verb\n\n" +
                "Examples:\n" +
                "I work every day.\n" +
                "She plays tennis.\n" +
                "They live in London.\n\n" +

                "NEGATIVE\n" +
                "Subject + do/does not + verb\n\n" +
                "Examples:\n" +
                "I do not like coffee.\n" +
                "She does not work here.\n\n" +

                "QUESTIONS\n" +
                "Do/Does + subject + verb?\n\n" +
                "Examples:\n" +
                "Do you play football?\n" +
                "Does she like music?\n\n" +

                "TIME EXPRESSIONS\n" +
                "always, usually, often, sometimes, every day";
            }
            else
            {
                TitleText.Text = "Present Simple";

                RuleText.Text =
                "ВИКОРИСТАННЯ\n" +
                "Present Simple використовується для:\n" +
                "• щоденних дій\n" +
                "• звичок\n" +
                "• фактів\n\n" +

                "СТВЕРДЖЕННЯ\n" +
                "Підмет + дієслово\n\n" +
                "Приклади:\n" +
                "I work every day.\n" +
                "She plays tennis.\n\n" +

                "ЗАПЕРЕЧЕННЯ\n" +
                "Підмет + do/does not + дієслово\n\n" +
                "Приклад:\n" +
                "I do not like coffee.\n" +
                "She does not work here.\n\n" +

                "ПИТАННЯ\n" +
                "Do/Does + підмет + дієслово?\n\n" +
                "Приклади:\n" +
                "Do you play football?\n" +
                "Does she like music?";
            }
        }

        private void PresentContinuous_Click(object sender, RoutedEventArgs e)
        {
            if (language == "EN")
            {
                TitleText.Text = "Present Continuous";

                RuleText.Text =
                "USE\n" +
                "Used for actions happening now.\n\n" +

                "AFFIRMATIVE\n" +
                "Subject + am/is/are + verb-ing\n\n" +
                "Examples:\n" +
                "I am studying English.\n" +
                "She is reading a book.\n" +
                "They are playing football.\n\n" +

                "NEGATIVE\n" +
                "Subject + am/is/are not + verb-ing\n\n" +
                "Examples:\n" +
                "I am not sleeping.\n" +
                "She is not working.\n\n" +

                "QUESTIONS\n" +
                "Am/Is/Are + subject + verb-ing?\n\n" +
                "Examples:\n" +
                "Are you studying?\n" +
                "Is she watching TV?\n\n" +

                "TIME EXPRESSIONS\n" +
                "now, at the moment, right now";
            }
            else
            {
                TitleText.Text = "Present Continuous";

                RuleText.Text =
                "ВИКОРИСТАННЯ\n" +
                "Дії, які відбуваються зараз.\n\n" +

                "СТВЕРДЖЕННЯ\n" +
                "Підмет + am/is/are + дієслово-ing\n\n" +

                "Приклади:\n" +
                "I am studying English.\n" +
                "She is reading a book.\n\n" +

                "ЗАПЕРЕЧЕННЯ\n" +
                "Підмет + am/is/are not + дієслово-ing\n\n" +

                "ПИТАННЯ\n" +
                "Am/Is/Are + підмет + дієслово-ing?";
            }
        }

        private void PastSimple_Click(object sender, RoutedEventArgs e)
        {
            if (language == "EN")
            {
                TitleText.Text = "Past Simple";

                RuleText.Text =
                "USE\n" +
                "Used for completed actions in the past.\n\n" +

                "AFFIRMATIVE\n" +
                "Subject + verb + ed\n\n" +
                "Examples:\n" +
                "I watched a movie.\n" +
                "She visited her friend.\n\n" +

                "NEGATIVE\n" +
                "Subject + did not + verb\n\n" +
                "Examples:\n" +
                "I did not go to school.\n" +
                "She did not like the film.\n\n" +

                "QUESTIONS\n" +
                "Did + subject + verb?\n\n" +
                "Examples:\n" +
                "Did you see the movie?\n" +
                "Did she call you?\n\n" +

                "TIME EXPRESSIONS\n" +
                "yesterday, last week, last year";
            }
            else
            {
                TitleText.Text = "Past Simple";

                RuleText.Text =
                "ВИКОРИСТАННЯ\n" +
                "Дії, які відбулися в минулому.\n\n" +

                "СТВЕРДЖЕННЯ\n" +
                "Підмет + дієслово + ed\n\n" +

                "Приклади:\n" +
                "I watched a movie.\n" +
                "She visited her friend.\n\n" +

                "ЗАПЕРЕЧЕННЯ\n" +
                "Підмет + did not + дієслово\n\n" +

                "ПИТАННЯ\n" +
                "Did + підмет + дієслово?";
            }
        }

        private void FutureSimple_Click(object sender, RoutedEventArgs e)
        {
            if (language == "EN")
            {
                TitleText.Text = "Future Simple";

                RuleText.Text =
                "USE\n" +
                "Used for future decisions and predictions.\n\n" +

                "AFFIRMATIVE\n" +
                "Subject + will + verb\n\n" +
                "Examples:\n" +
                "I will help you.\n" +
                "She will travel tomorrow.\n\n" +

                "NEGATIVE\n" +
                "Subject + will not + verb\n\n" +
                "Examples:\n" +
                "I will not go there.\n" +
                "She will not come.\n\n" +

                "QUESTIONS\n" +
                "Will + subject + verb?\n\n" +
                "Examples:\n" +
                "Will you help me?\n" +
                "Will she call you?";
            }
            else
            {
                TitleText.Text = "Future Simple";

                RuleText.Text =
                "ВИКОРИСТАННЯ\n" +
                "Майбутні дії або рішення.\n\n" +

                "СТВЕРДЖЕННЯ\n" +
                "Підмет + will + дієслово\n\n" +

                "ЗАПЕРЕЧЕННЯ\n" +
                "Підмет + will not + дієслово\n\n" +

                "ПИТАННЯ\n" +
                "Will + підмет + дієслово?";
            }
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {
            language = "EN";
        }

        private void Ukrainian_Click(object sender, RoutedEventArgs e)
        {
            language = "UA";
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}