using System;
using System.Collections.Generic;
using System.Linq;
using QuizGame.Contents;
using QuizGame.Results;

namespace QuizGame
{
    public class SimpleQuiz : IQuiz
    {
        private readonly IQuizContent content;

        public string Question => content.Question;

        public IReadOnlyList<string> Answers => content.FakeAnswers.Append(content.CorrectAnswer).ToList();

        public SimpleQuiz((string question, string correctAnswer, IReadOnlyList<string> fakeAnswers) bundle) : this(
            bundle.question,
            bundle.correctAnswer,
            bundle.fakeAnswers
        )
        {
        }

        public SimpleQuiz(string question, string correctAnswer, IReadOnlyList<string> fakeAnswers) : this(
            new ConstQuizContent(question, correctAnswer, fakeAnswers)
        )
        {
        }

        public SimpleQuiz(IQuizContent content)
        {
            this.content = content;
        }

        public AnswerResult Answer(string answer)
        {
            return content.CorrectAnswer.Equals(
                answer,
                StringComparison.OrdinalIgnoreCase
            )
                ? AnswerResult.correct as AnswerResult
                : new AnswerResult.Incorrect(answer);
        }
    }
}