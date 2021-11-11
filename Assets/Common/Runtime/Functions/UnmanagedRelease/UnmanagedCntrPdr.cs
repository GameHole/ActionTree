using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class UnmanagedCntr : IComponent
    {
        public List<System.IDisposable> disposables = new List<System.IDisposable>();
        public void Add(System.IDisposable v)
        {
            disposables.Add(v);
        }
    }
    public class UnmanagedCntrPdr : CmpProvider<UnmanagedCntr>
    {
        protected override bool DestroySelfWhenInReleaseMode => false;
        private void OnDestroy()
        {
            foreach (var item in value.disposables)
            {
                item?.Dispose();
            }
            value.disposables.Clear();
        }
    }
}

