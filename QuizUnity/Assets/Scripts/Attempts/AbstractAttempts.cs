using QuizGame.Attempts;
using UnityEngine;

namespace Attempts
{
    public abstract class AbstractAttempts : MonoBehaviour, IAttempts
    {
        public abstract void Use();

        public abstract bool Over { get; }
    }
}