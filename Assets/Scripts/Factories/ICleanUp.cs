using System.Collections.Generic;

namespace Assets.Scripts.EditorMenu
{
    public interface ICleanUp
    {
        IEnumerable<GameObjectFactory> Factories { get; }
        string SceneName { get; }
        void Cleanup();
    }
}
