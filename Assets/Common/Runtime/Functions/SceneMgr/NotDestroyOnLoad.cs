using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class NotDestroyOnLoad:MonoBehaviour
	{
        private void Awake()
        {
            var ue = GetComponentInParent<UnityEntity>();
            if (ue)
                ue.notDestroyOnLoad = true;
            else
                DontDestroyOnLoad(gameObject);
        }
    }
}
