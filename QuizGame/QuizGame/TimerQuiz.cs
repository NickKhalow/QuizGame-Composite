using System.Collections.Generic;
using QuizGame.Timers;

namespace QuizGame
{
    public class TimerQuiz : IQuiz
    {
        private readonly IQuiz origin;
        private readonly ITimer timer;

        public TimerQuiz(IQuiz origin, ITimer timer)
        {
            this.origin = origin;
            this.timer = timer;
        }

        public string Question => origin.Question;
        public IReadOnlyList<string> Answers => origin.Answers;

        public bool Answer(string answer)
        {
            if (timer.Over)
            {
                return false;
            }

            var result = origin.Answer(answer);
            if (result)
            {
                timer.RewardTime();
            }
            else
            {
                timer.PenaltyTime();
            }

            return result;
        }
    }
}