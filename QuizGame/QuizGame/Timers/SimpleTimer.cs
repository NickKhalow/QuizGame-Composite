using System;

namespace QuizGame.Timers
{

    public class SimpleTimer : ITimer
    {
        private readonly TimeSpan rewardTime;
        private readonly TimeSpan penaltyTime;
        private TimeSpan timeLefts;
        private DateTime previousCut;

        public SimpleTimer(TimeSpan timeLefts) : this(
            TimeSpan.FromSeconds(3),
            TimeSpan.FromSeconds(5),
            timeLefts
        )
        {
        }

        public SimpleTimer(TimeSpan rewardTime, TimeSpan penaltyTime, TimeSpan timeLefts) : this(
            rewardTime,
            penaltyTime,
            timeLefts,
            DateTime.Now
        )
        {
        }

        public SimpleTimer(
            TimeSpan rewardTime,
            TimeSpan penaltyTime,
            TimeSpan timeLefts,
            DateTime previousCut
        )
        {
            this.timeLefts = timeLefts;
            this.previousCut = previousCut;
            this.rewardTime = rewardTime;
            this.penaltyTime = penaltyTime;
        }

        public bool Over
        {
            get
            {
                var currentCut = DateTime.Now;
                return currentCut - previousCut >= timeLefts;
            }
        }

        public void RewardTime()
        {
            previousCut = DateTime.Now;
            timeLefts += rewardTime;
        }

        public void PenaltyTime()
        {
            previousCut = DateTime.Now;
            timeLefts -= penaltyTime;
        }
    }
}