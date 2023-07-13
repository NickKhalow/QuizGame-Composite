using UnityEngine;
using UnityEngine.UI;

namespace Timers
{
    [RequireComponent(typeof(Slider))]
    public class UnityTimer : AbstractTimer
    {
        [SerializeField] private float maxTime;
        [SerializeField] private float rewardTime;
        [SerializeField] private float penaltyTime;

        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
            slider.maxValue = maxTime;
            slider.value = maxTime;
        }

        private void Update()
        {
            slider.value -= Time.deltaTime;
        }

        public override void RewardTime()
        {
            slider.value += rewardTime;
        }

        public override void PenaltyTime()
        {
            slider.value -= rewardTime;
        }

        public override bool Over => Mathf.Approximately(slider.value, 0);
    }
}