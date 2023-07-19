using System.Collections.Generic;
using System.Linq;
using QuizGame.Contents;

namespace LevelContents.Single
{
    public class StringQuizContent : IQuizContent
    {
        private readonly string raw;
        private readonly string separator;

        public StringQuizContent(string raw, string separator = ";")
        {
            this.raw = raw;
            this.separator = separator;
        }

        public string Question => raw.Split(separator)[0];

        public string CorrectAnswer => raw.Split(separator)[1];

        public IReadOnlyList<string> FakeAnswers => raw.Split(separator)
            .Skip(2)
            .Where(e => string.IsNullOrWhiteSpace(e) == false)
            .ToList();
    }
}