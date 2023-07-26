using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeaderBoards.Records;

namespace LeaderBoards
{
    public interface ILeaderBoard<T> where T : IComparable<T>
    {
        Task Apply(IResultRecord<T> record);

        Task<IReadOnlyList<IResultRecord<T>>> All();
    }
}