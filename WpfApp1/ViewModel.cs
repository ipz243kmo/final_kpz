using System.Collections.ObjectModel;

public class LessonViewModel
{
    public ObservableCollection<Lesson> Lessons { get; set; }

    public LessonViewModel()
    {
        Lessons = new ObservableCollection<Lesson>
        {
            new Lesson { Title = "Present Simple", Content = "..." },
            new Lesson { Title = "Past Simple", Content = "..." }
        };
    }
}