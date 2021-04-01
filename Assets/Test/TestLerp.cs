using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLerp : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform m;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m.rotation = Quaternion.Slerp(a.rotation, b.rotation, t);
    }
}
