using System.Collections;
using System.Collections.Generic;
using QuizGame.Contents;
using UnityEngine;

namespace LevelContents
{
    public abstract class AbstractLevelContents : MonoBehaviour, IEnumerable<IQuizContent>
    {
        public abstract IEnumerator<IQuizContent> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}