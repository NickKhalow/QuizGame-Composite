using System.Collections.Generic;

namespace QuizGame
{
    public class AttemptsQuiz : IQuiz
    {
        private readonly IQuiz origin;
        private readonly int max;
        private int current = 0;

        public AttemptsQuiz(IQuiz origin, int max = 5)
        {
            this.origin = origin;
            this.max = max;
        }

        public string Question => origin.Question;
        public IReadOnlyList<string> Answers => origin.Answers;

        public bool Answer(string answer)
        {
            if (current >= max)
            {
                return false;
            }

            var result = origin.Answer(answer);
            if (result == false)
            {
                current++;
            }

            return result;
        }
    }
}