using System.Collections.Generic;

namespace QuizGame
{
    public interface IQuiz
    {
        string Question { get; }

        IReadOnlyList<string> Answers { get; }

        bool Answer(string answer);
    }
}