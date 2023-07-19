using System;
using UnityEngine;

namespace CompileFactories
{
    public class FacadeFactory : MonoBehaviour
    {
        [SerializeField] private AbstractFactoryBridge compileFactory;
        [SerializeField] private string path;

        [ContextMenu(nameof(Compile))]
        private void Compile()
        {
            try
            {
                compileFactory.Compile(path);
            }
            catch (Exception e)
            {
                e = new Exception($"Cannot compile to path '{path}'", e);
                Debug.LogError(e.Message);
                throw;
            }
        }
    }
}