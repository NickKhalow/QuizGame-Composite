using UnityEngine;

namespace LeaderBoards.Records
{
    public class TimeResultRecord : IResultRecord<float>
    {
        public TimeResultRecord(string player, float? result = null)
        {
            Player = player;
            Result = result ?? Random.value;
        }

        public string Player { get; }
        public float Result { get; }
    }
}