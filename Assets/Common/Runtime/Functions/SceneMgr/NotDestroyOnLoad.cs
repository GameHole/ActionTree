using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class NotDestroyOnLoad:MonoBehaviour
	{
        private void Awake()
        {
            GetComponentInParent<UnityEntity>().notDestroyOnLoad = true;
        }
    }
}
