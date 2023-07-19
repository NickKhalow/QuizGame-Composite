using System.Collections.Generic;
using System.Linq;
using LevelContents.Single;
using QuizGame.Contents;
using UnityEngine;

namespace LevelContents
{
    public class CsvLevelContents : AbstractLevelContents
    {
        [SerializeField] private TextAsset text;

        public override IEnumerator<IQuizContent> GetEnumerator()
        {
            return text.text.Split('\n')
                .Skip(1)
                .Select(raw => new StringQuizContent(raw))
                .GetEnumerator();
        }
    }
}