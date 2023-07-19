using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Attempts;
using QuizGame;
using QuizGame.Contents;
using QuizGame.Results;
using Timers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ViewQuiz : MonoBehaviour
{
    public UnityEvent onWin = new();

    [Header("Dependencies")] [SerializeField]
    private TMP_Text questionText;

    [SerializeField] private AnswerButton prefab;
    [SerializeField] private Transform answerButtonsLayout;
    [SerializeField] private AbstractTimer timer;
    [SerializeField] private AbstractAttempts attempts;

    [SuppressMessage("ReSharper", "ParameterHidesMember")]
    public void Construct(AbstractTimer timer, AbstractAttempts attempts)
    {
        this.timer = timer;
        this.attempts = attempts;
        
        questionText.EnsureNotNull("question text is null");
        prefab.EnsureNotNull("answer button prefab is null");
        answerButtonsLayout.EnsureNotNull("answer button layout is null");
        timer.EnsureNotNull("timer is null");
        attempts.EnsureNotNull("attempts is null");
    }

    public void Play(IQuizContent content)
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
            button.clicked.AddListener(e =>
                {
                    var result = quiz.Answer(e);
                    Debug.Log($"Answer {e} is {result.GetType().Name}");
                    if (result is AnswerResult.Correct)
                    {
                        onWin?.Invoke();
                    }
                }
            );
        }
    }

    private AnswerButton NewButton(string answer)
    {
        var button = Instantiate(prefab, answerButtonsLayout);
        button.Construct(answer);
        return button;
    }
}