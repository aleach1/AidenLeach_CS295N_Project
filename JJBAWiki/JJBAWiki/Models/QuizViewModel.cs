namespace JJBAWiki.Models
{
    public class QuizViewModel
    {
        public List<QuestionModel> Questions { get; set; } = new List<QuestionModel>();

        public int CalculateScore()
        {
            int score = 0;
            foreach (var question in Questions)
            {
                if (question.UserAnswer < 0 || question.UserAnswer >= question.Answers.Count)
                {
                    question.IsCorrect = false;
                }
                else
                {
                    question.IsCorrect = question.UserAnswer == question.CorrectAnswer;
                    if (question.IsCorrect)
                    {
                        score++;
                    }
                }
            }
            return score;
        }
    }

    public class QuestionModel
    {
        public string Text { get; set; } = string.Empty;
        public List<string> Answers { get; set; } = new List<string>();
        public int CorrectAnswer { get; set; }
        public int UserAnswer { get; set; } = -1;
        public bool IsCorrect { get; set; }
    }
}
