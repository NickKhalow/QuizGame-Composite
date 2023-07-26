using System;

namespace LeaderBoards.Records
{
    public interface IResultRecord<T> where T : IComparable<T>
    {
        string Player { get; }
        T Result { get; }
    }
}