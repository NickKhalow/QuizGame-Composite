using System;
using System.Collections.Generic;
using System.Linq;
using Attempts;
using QuizGame;
using QuizGame.Contents;
using Timers;
using TMPro;
using UnityEngine;

public class ViewQuiz : MonoBehaviour
{
    [SerializeField] private Content content;

    [Header("Dependencies")] [SerializeField]
    private TMP_Text questionText;

    [SerializeField] private AnswerButton prefab;
    [SerializeField] private Transform answerButtonsLayout;
    [SerializeField] private AbstractTimer timer;
    [SerializeField] private AbstractAttempts attempts;

    private void Awake()
    {
        questionText.EnsureNotNull("question text is null");
        prefab.EnsureNotNull("answer button prefab is null");
        answerButtonsLayout.EnsureNotNull("answer button layout is null");
        timer.EnsureNotNull("timer is null");
        attempts.EnsureNotNull("attempts is null");
    }

    private void Start()
    {
        IQuiz quiz = new AttemptsQuiz(
            new TimerQuiz(
                new ShuffledQuiz(
                    new SimpleQuiz(content)
                ),
                timer
            ),
            attempts
        );
        questionText.SetText(quiz.Question);
        foreach (var button in quiz.Answers.Select(NewButton)) // string[] -> AnswerButton[]
        {
            button.clicked.AddListener(e => Debug.Log($"Answer {e} is {quiz.Answer(e).GetType().Name}"));
        }
    }

    private AnswerButton NewButton(string answer)
    {
        var button = Instantiate(prefab, answerButtonsLayout);
        button.Construct(answer);
        return button;
    }

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