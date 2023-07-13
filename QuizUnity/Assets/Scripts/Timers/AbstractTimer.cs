using QuizGame.Timers;
using UnityEngine;

namespace Timers
{
    public abstract class AbstractTimer : MonoBehaviour, ITimer
    {
        public abstract void RewardTime();

        public abstract void PenaltyTime();

        public abstract  bool Over { get; }
    }
}