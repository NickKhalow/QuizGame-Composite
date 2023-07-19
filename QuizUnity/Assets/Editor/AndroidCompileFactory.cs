using CompileFactories;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;

namespace Editor
{
    [CreateAssetMenu(fileName = "Android Compile Factory", menuName = "Compile Factory/Android", order = 0)]
    public class AndroidCompileFactory : AbstractCompileFactory
    {
        public override void Compile(string path, BuildOptions options)
        {
            File.Create(path);
            BuildPipeline.BuildPlayer(
                EditorBuildSettings.scenes,
                path,
                BuildTarget.Android,
                options
            );
        }
    }
}