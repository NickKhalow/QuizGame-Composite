using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QuizGame.Contents;
using UnityEngine;

namespace LevelContents
{
    public class JsonLevelContents : AbstractLevelContents
    {
        [JsonIgnore] [SerializeField] private TextAsset asset;

        public override IEnumerator<IQuizContent> GetEnumerator()
        {
            return JsonConvert.DeserializeObject<List<QuizContent>>(asset.text).GetEnumerator();
        }

        [ContextMenu(nameof(Hint))]
        public void Hint()
        {
            Debug.Log(JsonConvert.SerializeObject(
                    new List<QuizContent>
                    {
                        new()
                        {
                            Question = "", CorrectAnswer = "", FakeAnswers = new[] { "", "" }
                        }
                    }
                )
            );
        }

        [ContextMenu(nameof(Check))]
        public void Check()
        {
            using var _ = GetEnumerator();
        }

        [Serializable]
        private class QuizContent : IQuizContent
        {
            public string Question { get; set; }
            public string CorrectAnswer { get; set; }
            public IReadOnlyList<string> FakeAnswers { get; set; }
        }
    }
}