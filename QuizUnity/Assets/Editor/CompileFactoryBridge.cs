using CompileFactories;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CreateAssetMenu(fileName = "Bridge Compile Factory", menuName = "Compile Factory/Tools/Bridge", order = 0)]
    public class CompileFactoryBridge : AbstractFactoryBridge
    {
        [SerializeField] private AbstractCompileFactory factory;

        public override void Compile(string path)
        {
            factory.Compile(
                path,
                BuildPlayerWindow.DefaultBuildMethods.GetBuildPlayerOptions(new BuildPlayerOptions()).options
            );
        }
    }
}