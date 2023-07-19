using UnityEngine;

namespace CompileFactories
{
    //[CreateAssetMenu(fileName = "Bridge Compile Factory", menuName = "Compile Factory/Tools/Bridge", order = 0)]
    public abstract class AbstractFactoryBridge : ScriptableObject
    {
        public abstract void Compile(string path);
    }
}