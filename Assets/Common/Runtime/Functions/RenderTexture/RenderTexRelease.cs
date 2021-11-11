using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class RenderTexRelease : System.IDisposable
    {
        public RenderTexture texture;

        public void Dispose()
        {
            texture.Release();
        }
    }
}

