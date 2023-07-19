using UnityEditor;
using UnityEngine;

namespace Editor
{
    //[CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public abstract class AbstractCompileFactory : ScriptableObject
    {
        public abstract void Compile(string path, BuildOptions options);
    }
}