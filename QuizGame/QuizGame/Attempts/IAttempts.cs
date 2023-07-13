namespace QuizGame.Attempts
{
    public interface IAttempts
    {
        bool Over { get; }

        void Use();
    }
}