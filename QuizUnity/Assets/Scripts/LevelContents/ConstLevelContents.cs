using System.Collections.Generic;
using System.Linq;
using LevelContents.Single;
using QuizGame.Contents;
using UnityEngine;

namespace LevelContents
{
    public class ConstLevelContents : AbstractLevelContents
    {
        [SerializeField] private Content[] levels;

        public override IEnumerator<IQuizContent> GetEnumerator()
        {
            return levels.OfType<IQuizContent>().GetEnumerator();
        }
    }
}