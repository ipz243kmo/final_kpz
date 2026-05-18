public class Test
{
    public Lesson Lesson { get; set; }
    public List<Question> Questions { get; set; } = new();

    public int CalculateScore(List<int> answers)
    {
        int score = 0;
        for (int i = 0; i < Questions.Count; i++)
            if (answers[i] == Questions[i].CorrectAnswerIndex)
                score++;
        return score;
    }
}