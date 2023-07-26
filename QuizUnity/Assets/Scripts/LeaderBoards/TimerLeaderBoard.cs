using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaderBoards.Records;
using UnityEngine;

namespace LeaderBoards
{
    public class TimerLeaderBoard : MonoBehaviour, ILeaderBoard<float>
    {
        [SerializeField] private string url;

        private ILeaderBoard<float> timeLeaderBoard;

        private void Awake()
        {
            // timeLeaderBoard = new PlayerPrefsLeaderBoard<float>(
            //     r => $"{r.Player}:{r.Result}",
            //     s =>
            //     {
            //         var raw = s.Split(':');
            //         return new TimeResultRecord(raw.First(), float.Parse(raw.Last()));
            //     },
            //     "time_leader_board"
            // );
            timeLeaderBoard = new ApiLeaderBoard(url);
        }

        public Task Apply(IResultRecord<float> record)
        {
            return timeLeaderBoard.Apply(record);
        }

        public Task<IReadOnlyList<IResultRecord<float>>> All()
        {
            return timeLeaderBoard.All();
        }
    }
}