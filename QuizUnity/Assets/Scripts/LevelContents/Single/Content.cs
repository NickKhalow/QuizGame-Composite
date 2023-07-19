using System;
using System.Collections.Generic;
using QuizGame.Contents;
using UnityEngine;

namespace LevelContents.Single
{
    [Serializable]
    public struct Content : IQuizContent
    {
        [SerializeField] private string question;
        [SerializeField] private string correct;
        [SerializeField] private string[] fakes;

        public string Question => question;
        public string CorrectAnswer => correct;
        public IReadOnlyList<string> FakeAnswers => fakes;
    }
}