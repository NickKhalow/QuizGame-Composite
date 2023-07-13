namespace QuizGame.Results
{
    public abstract class AnswerResult
    {
        public static readonly Correct correct = new Correct();

        public class Correct : AnswerResult
        {
        }

        public abstract class Wrong : AnswerResult
        {
        }

        public class Incorrect : Wrong
        {
            public string Answer { get; }

            public Incorrect(string answer)
            {
                Answer = answer;
            }
        }

        public class TimeOut : Wrong
        {
        }

        public class AttemptOut : Wrong
        {
        }
    }
}