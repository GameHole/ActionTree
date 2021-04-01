using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActionTree;
public class Testaa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MatrixInt a = new MatrixInt(1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        Vector3Int d = new Vector3Int(1, 1, 1);
        Debug.Log(a * new Vector4Int(d, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
