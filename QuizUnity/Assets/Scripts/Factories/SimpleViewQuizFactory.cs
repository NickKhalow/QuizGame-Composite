using Attempts;
using Timers;
using UnityEngine;

namespace Factories
{
    public class SimpleViewQuizFactory : AbstractViewQuizFactory
    {
        [SerializeField] private ViewQuiz prefab;
        [SerializeField] private Transform parentForInstances;

        [Header("Dependencies")] [SerializeField]
        private AbstractTimer timer;

        [SerializeField] private AbstractAttempts attempts;

        public override ViewQuiz Quiz()
        {
            var quiz = Instantiate(prefab, parentForInstances);
            quiz.Construct(timer, attempts);
            return quiz;
        }
    }
}