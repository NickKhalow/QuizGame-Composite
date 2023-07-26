using System.Diagnostics.CodeAnalysis;
using System.Linq;
using LeaderBoards.Records;
using UnityEngine;

namespace LeaderBoards.Views
{
    [SuppressMessage("ReSharper", "SpecifyACultureInStringConversionExplicitly")]
    public class LeaderBoardView : MonoBehaviour
    {
        [SerializeField] private Transform recordsParent;
        [SerializeField] private LeaderRecordView prefabRecordView;
        [SerializeField] private TimerLeaderBoard timerLeader;
        [SerializeField] private GameObject emptyListMock;

        private void Awake()
        {
            recordsParent.EnsureNotNull();
            prefabRecordView.EnsureNotNull();
            timerLeader.EnsureNotNull();
            emptyListMock.EnsureNotNull();
        }

        private void Start()
        {
            Render();
        }

        public void Apply(IResultRecord<float> record)
        {
            timerLeader.Apply(record);
            Render();
        }

        private async void Render()
        {
            for (var i = 0; i < recordsParent.childCount; i++)
            {
                Destroy(recordsParent.GetChild(i).gameObject);
            }

            var list = (await timerLeader.All()).Reverse().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                var recordView = Instantiate(prefabRecordView, recordsParent);
                var record = list[i];
                recordView.Apply(
                    i + 1,
                    record.Player,
                    record.Result.ToString()
                );
            }

            emptyListMock.SetActive(list.Count == 0);
        }
    }
}