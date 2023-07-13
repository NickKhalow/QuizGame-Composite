using System.Collections.Generic;
using QuizGame.Results;

namespace QuizGame
{
    public interface IQuiz
    {
        string Question { get; }

        IReadOnlyList<string> Answers { get; }

        AnswerResult Answer(string answer);
    }
}