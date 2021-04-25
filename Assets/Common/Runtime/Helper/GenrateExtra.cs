using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ActionTree
{
	public class GenrateExtra : MonoBehaviour
	{
        public GameObject prefab;
        private void Awake()
        {
            if (prefab)
            {
                Instantiate(prefab);
            }
            Destroy(this);
        }
    }
}
