using System.Collections.Generic;

namespace QuizGame.Contents
{
    public class ConstQuizContent : IQuizContent
    {
        public ConstQuizContent(string question, string correctAnswer, IReadOnlyList<string> fakeAnswers)
        {
            Question = question;
            CorrectAnswer = correctAnswer;
            FakeAnswers = fakeAnswers;
        }

        public string Question { get; }
        public string CorrectAnswer { get; }
        public IReadOnlyList<string> FakeAnswers { get; }
    }
}