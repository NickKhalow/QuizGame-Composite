namespace QuizBackend.Domain;

public class MemoryLeaderBoard : ILeaderBoard
{
    private readonly Dictionary<string, float> dictionary;

    public MemoryLeaderBoard() : this(new Dictionary<string, float>())
    {
    }

    public MemoryLeaderBoard(Dictionary<string, float> dictionary)
    {
        this.dictionary = dictionary;
    }

    public void Apply(string player, float result)
    {
        dictionary.Add(player, result);
    }

    public IReadOnlyList<(string player, float result)> All()
    {
        var list = dictionary.Select(e => (e.Key, e.Value)).ToList();
        list.Sort(new Comparer());
        return list;
    }

    private class Comparer : IComparer<(string player, float result)>
    {
        public int Compare((string player, float result) x, (string player, float result) y)
        {
            return x.result.CompareTo(y.result);
        }
    }
}