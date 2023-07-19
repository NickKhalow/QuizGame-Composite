using System.Collections;
using Extensions;
using Factories;
using LevelContents;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private AbstractViewQuizFactory factory;
    [SerializeField] private AbstractLevelContents levelContents;

    private IEnumerator Start()
    {
        foreach (var content in levelContents)
        {
            Debug.Log(
                $"Content is {content.Question}; {content.CorrectAnswer}; {string.Join(", ", content.FakeAnswers)}"
            );
            var quiz = factory.Quiz();
            quiz.Play(content);
            yield return quiz.onWin.Wait();
        }

        Debug.Log("Level finished");
    }
}