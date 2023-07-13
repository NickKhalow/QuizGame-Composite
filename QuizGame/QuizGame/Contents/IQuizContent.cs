using System.Collections.Generic;

namespace QuizGame.Contents
{
    public interface IQuizContent
    {
        public string Question { get; }
        
        public string CorrectAnswer { get; }
        
        public IReadOnlyList<string> FakeAnswers { get; }
    }
}