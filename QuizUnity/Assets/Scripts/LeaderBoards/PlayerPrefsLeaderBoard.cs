using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LeaderBoards.Records;
using Newtonsoft.Json;
using UnityEngine;

namespace LeaderBoards
{
    public class PlayerPrefsLeaderBoard<T> : ILeaderBoard<T> where T : IComparable<T>
    {
        private readonly string key;
        private readonly IComparer<IResultRecord<T>> comparer = new SimpleComparer();
        private readonly Func<IResultRecord<T>, string> serialize;
        private readonly Func<string, IResultRecord<T>> deserialize;

        public PlayerPrefsLeaderBoard(
            Func<IResultRecord<T>, string> serialize,
            Func<string, IResultRecord<T>> deserialize,
            string key = "leader_board"
        )
        {
            this.serialize = serialize;
            this.deserialize = deserialize;
            this.key = key;
        }

        public async Task Apply(IResultRecord<T> record)
        {
            var all = (await All())!.ToList();
            all.Add(record);
            all.Sort(comparer);
            PlayerPrefs.SetString(
                key,
                JsonConvert.SerializeObject(
                    all.Select(serialize).ToList()
                )
            );
        }

        [ItemCanBeNull]
        public Task<IReadOnlyList<IResultRecord<T>>> All()
        {
            var raw = PlayerPrefs.GetString(key, string.Empty);
            return Task.FromResult(string.IsNullOrEmpty(raw)
                ? new List<IResultRecord<T>>() as IReadOnlyList<IResultRecord<T>>
                : JsonConvert.DeserializeObject<List<string>>(raw)
                    .Select(deserialize)
                    .ToList()
            );
        }

        private class SimpleComparer : IComparer<IResultRecord<T>>
        {
            public int Compare(IResultRecord<T> x, IResultRecord<T> y)
            {
                if (y == null)
                {
                    return 0;
                }

                return x?.Result.CompareTo(y.Result) ?? 0;
            }
        }
    }
}