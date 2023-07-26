namespace QuizBackend.Domain
{
    public interface ILeaderBoard
    {
        void Apply(string player, float result);

        IReadOnlyList<(string player, float result)> All();
    }
}