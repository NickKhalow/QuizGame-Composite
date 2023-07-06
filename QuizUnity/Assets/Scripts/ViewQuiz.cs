using System.Linq;
using QuizGame;
using UnityEngine;

public class ViewQuiz : MonoBehaviour
{
    [SerializeField] private string question;
    [SerializeField] private string correct;
    [SerializeField] private string[] fakes;

    [SerializeField] private AnswerButton prefab;

    void Start()
    {
        IQuiz quiz = new ShuffledQuiz(
            new SimpleQuiz(question, correct, fakes)
        );
        foreach (var button in quiz.Answers.Select(NewButton))
        {
            button.clicked.AddListener(e =>
                {
                    Debug.Log($"Answer {e} is correct? {quiz.Answer(e)}");
                }
            );
        }
    }

    AnswerButton NewButton(string answer)
    {
        var button = Instantiate(prefab, transform);
        button.Construct(answer);
        return button;
    }
}