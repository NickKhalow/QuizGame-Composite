using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizGame
{
    public class SimpleQuiz : IQuiz
    {
        private readonly string correctAnswer;
        private readonly IReadOnlyList<string> fakeAnswers;

        public string Question { get; }

        public IReadOnlyList<string> Answers => fakeAnswers.Append(correctAnswer).ToList();

        public SimpleQuiz((string question, string correctAnswer, IReadOnlyList<string> fakeAnswers) bundle) : this(
            bundle.question,
            bundle.correctAnswer,
            bundle.fakeAnswers
        )
        {
        }

        public SimpleQuiz(string question, string correctAnswer, IReadOnlyList<string> fakeAnswers)
        {
            Question = question;
            this.correctAnswer = correctAnswer;
            this.fakeAnswers = fakeAnswers;
        }

        public bool Answer(string answer)
        {
            return correctAnswer.Equals(
                answer,
                StringComparison.OrdinalIgnoreCase
            );
        }
    }
}