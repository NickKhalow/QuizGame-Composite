using QuizGame.Contents;
using UnityEngine;

namespace Factories
{
    public abstract class AbstractViewQuizFactory : MonoBehaviour
    {
        public abstract ViewQuiz Quiz();
    }
}