using CompileFactories;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;

namespace Editor
{
    [CreateAssetMenu(fileName = "Desktop Compile Factory", menuName = "Compile Factory/Desktop", order = 0)]
    public class DesktopCompileFactory : AbstractCompileFactory
    {
        public override void Compile(string path, BuildOptions options)
        {
            // var player = BuildPlayerWindow.DefaultBuildMethods.GetBuildPlayerOptions(new BuildPlayerOptions());
            // player.scenes = EditorBuildSettings.scenes.Select(e => e.path).ToArray();
            // player.target = BuildTarget.Android;
            File.Create(path);
            BuildPipeline.BuildPlayer(
                EditorBuildSettings.scenes,
                path,
                BuildTarget.StandaloneOSX,
                options
            );
        }
    }
}