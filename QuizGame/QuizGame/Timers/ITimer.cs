namespace QuizGame.Timers
{
    public interface ITimer
    {
        bool Over { get; }

        void RewardTime();

        void PenaltyTime();
    }
}