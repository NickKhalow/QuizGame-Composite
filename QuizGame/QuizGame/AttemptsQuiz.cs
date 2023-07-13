using System.Collections.Generic;
using QuizGame.Attempts;
using QuizGame.Results;

namespace QuizGame
{
    public class AttemptsQuiz : IQuiz
    {
        private readonly IQuiz origin;
        private readonly IAttempts attempts;

        public AttemptsQuiz(IQuiz origin, int max = 5) : this(origin, new SimpleAttempts(max))
        {
        }

        public AttemptsQuiz(IQuiz origin, IAttempts attempts)
        {
            this.origin = origin;
            this.attempts = attempts;
        }

        public string Question => origin.Question;
        public IReadOnlyList<string> Answers => origin.Answers;

        public AnswerResult Answer(string answer)
        {
            if (attempts.Over)
            {
                return new AnswerResult.AttemptOut();
            }

            var result = origin.Answer(answer);
            if (result is AnswerResult.Correct == false)
            {
                attempts.Use();
            }

            return result;
        }
    }
}