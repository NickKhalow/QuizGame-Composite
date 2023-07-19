using System.Collections;
using UnityEngine.Events;

namespace Extensions
{
    public static class UnityEventExtensions
    {
        public static IEnumerator Wait(this UnityEvent unityEvent)
        {
            var done = false;
            unityEvent.AddListener(() => done = true);
            while (done == false)
            {
                yield return null;
            }
        }
    }
}