using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ActionTree;
public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Load()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
