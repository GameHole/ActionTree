using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class RenderTexDispose : System.IDisposable
    {
        public RenderTexture texture;

        public void Dispose()
        {
            RenderTexture.ReleaseTemporary(texture);
        }
    }
}

