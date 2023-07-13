using System;
using System.Collections.Generic;
using System.Linq;
using QuizGame.Results;

namespace QuizGame
{

    public class ShuffledQuiz : IQuiz
    {
        private readonly IQuiz origin;
        private readonly Random random;

        public ShuffledQuiz(IQuiz origin) : this(
            origin,
            new Random(DateTime.Now.Millisecond)
        )
        {
        }

        public ShuffledQuiz(IQuiz origin, Random random)
        {
            this.origin = origin;
            this.random = random;
        }

        public string Question => origin.Question;

        public IReadOnlyList<string> Answers
        {
            get
            {
                var list = origin.Answers.ToList();
                for (var i = 0; i < list.Count; i++)
                {
                    var current = list[i];
                    var randomIndex = random.Next(0, list.Count);
                    var randomElement = list[randomIndex];
                    list[i] = randomElement;
                    list[randomIndex] = current;
                }

                return list;
            }
        }

        public AnswerResult Answer(string answer)
        {
            return origin.Answer(answer);
        }
    }
}