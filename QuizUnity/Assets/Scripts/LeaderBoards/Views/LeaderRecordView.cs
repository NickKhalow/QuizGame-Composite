using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;

namespace LeaderBoards.Views
{
    public class LeaderRecordView : MonoBehaviour
    {
        [SerializeField] private TMP_Text place, player, result;

        private void Awake()
        {
            place.EnsureNotNull();
            player.EnsureNotNull();
            result.EnsureNotNull();
        }

        [SuppressMessage("ReSharper", "ParameterHidesMember")]
        public void Apply(int place, string player, string result)
        {
            this.place.SetText($"#{place}");
            this.player.SetText(player);
            this.result.SetText(result);
        }
    }
}