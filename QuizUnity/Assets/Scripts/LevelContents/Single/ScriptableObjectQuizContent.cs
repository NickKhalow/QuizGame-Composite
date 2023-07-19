using System.Collections.Generic;
using QuizGame.Contents;
using UnityEngine;

namespace LevelContents.Single
{
    [CreateAssetMenu(fileName = "QuizContent", menuName = "Quiz/Content", order = 0)]
    public class ScriptableObjectQuizContent : ScriptableObject, IQuizContent
    {
        [SerializeField] private string question;
        [SerializeField] private string correct;
        [SerializeField] private string[] fakes;

        public string Question => question;
        public string CorrectAnswer => correct;
        public IReadOnlyList<string> FakeAnswers => fakes;
    }
}