using System;
using System.Collections.Generic;
using System.Linq;
using QuizGame.Results;

namespace QuizGame
{
    [Obsolete]
    public class BrokenQuiz : IQuiz
    {
        public string Question { get; }

        public IReadOnlyList<string> Answers { get; }

        public BrokenQuiz(string question, IReadOnlyList<string> answers)
        {
            Question = question;
            Answers = answers;
        }

        public AnswerResult Answer(string answer)
        {
            return Answers.Any(e => e.Equals(
                    answer,
                    StringComparison.OrdinalIgnoreCase
                )
            )
                ? AnswerResult.correct as AnswerResult
                : new AnswerResult.Incorrect(answer);
        }
    }
}