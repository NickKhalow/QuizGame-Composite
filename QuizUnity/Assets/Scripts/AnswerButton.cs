using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnswerButton : MonoBehaviour
{
    public UnityEvent<string> clicked = new();

    [SerializeField] private Button button;
    [SerializeField] private TMP_Text text;
    [Header("Debug")] [SerializeField] private string value;

    private void Awake()
    {
        button.onClick.AddListener(() => clicked.Invoke(value));
    }

    public void Construct(string answer)
    {
        value = answer;
        text.SetText(answer);
    }
}