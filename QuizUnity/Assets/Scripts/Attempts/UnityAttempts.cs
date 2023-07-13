using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Attempts
{
    [RequireComponent(typeof(TMP_Text))]
    public class UnityAttempts : AbstractAttempts
    {
        [SerializeField] private int currentCount;

        private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            text.SetText($"Attempts Remains: {currentCount}");
        }


        public override void Use()
        {
            currentCount--;
            UpdateText();
        }

        public override bool Over => currentCount <= 0;
    }
}