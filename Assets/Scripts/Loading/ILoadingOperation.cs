using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Loading 
{
    public interface ILoadingOperation
    {
        string Description { get; }

        Task Load(Action<float> onProgress);
    }
}

