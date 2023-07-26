using LeaderBoards.Records;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeaderBoards.Views
{
    public class ApplyResultView : MonoBehaviour
    {
        [SerializeField] private LeaderBoardView leaderBoardView;
        [SerializeField] private Button applyButton;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private float assignedResult;

        private void Awake()
        {
            leaderBoardView.EnsureNotNull();
            applyButton.EnsureNotNull();
            inputField.EnsureNotNull();

            applyButton.onClick.AddListener(() =>
            {
                leaderBoardView.Apply(
                    new TimeResultRecord(
                        inputField.text,
                        assignedResult
                    )
                );
            });
        }

        public void Assign(float result)
        {
            assignedResult = result;
        }
    }
}