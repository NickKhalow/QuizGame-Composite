using CompileFactories;
using UnityEditor;
using UnityEngine;

namespace Editor.Structs
{
    [CreateAssetMenu(fileName = "Many Compile Factory", menuName = "Compile Factory/Struct/Many", order = 0)]
    public class ManyCompileFactory : AbstractCompileFactory
    {
        [SerializeField] private AbstractCompileFactory[] factories;

        public override void Compile(string path, BuildOptions options)
        {
            foreach (var factory in factories)
            {
                factory.Compile(path, options);
            }
        }
    }
}