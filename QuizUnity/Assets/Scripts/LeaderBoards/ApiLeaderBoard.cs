using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LeaderBoards.Records;
using Newtonsoft.Json;

namespace LeaderBoards
{
    public class ApiLeaderBoard : ILeaderBoard<float>
    {
        private readonly HttpClient client;
        private readonly string baseUrl;

        public ApiLeaderBoard(string baseUrl) : this(baseUrl, new HttpClient())
        {
        }

        public ApiLeaderBoard(string baseUrl, HttpClient client)
        {
            this.baseUrl = baseUrl;
            this.client = client;
        }

        public Task Apply(IResultRecord<float> record)
        {
            return client.PostAsync(
                baseUrl + $"LeaderBoards?player={record.Player}&result={record.Result}",
                new StringContent(string.Empty)
            );
        }

        public async Task<IReadOnlyList<IResultRecord<float>>> All()
        {
            var result = await client.GetAsync(baseUrl + "LeaderBoards");
            result.EnsureSuccessStatusCode();
            var raw = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Pair>>(raw)
                .Select(e => new TimeResultRecord(e.player, e.result))
                .ToList();
        }

        private class Pair
        {
            public string player { get; set; }
            public float result { get; set; }
        }
    }
}