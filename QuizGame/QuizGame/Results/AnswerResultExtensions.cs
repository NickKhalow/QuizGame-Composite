namespace QuizGame.Results
{
    public static class AnswerResultExtensions
    {
        public static bool IsCorrect(this AnswerResult answerResult)
        {
            return answerResult is AnswerResult.Correct;
        }
    }
}