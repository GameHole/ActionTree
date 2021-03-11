using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 dir;
    void Update()
    {
        float dx = Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            dir.x += Time.deltaTime;
        else if (Input.GetKey(KeyCode.A))
            dir.x -= Time.deltaTime;
        else
        {
            if (Mathf.Abs(dir.x) < dx)
            {
                dir.x = 0;
            }
            else
            {
                float v = dir.x;
                float sign = -Mathf.Sign(v);
                dir.x += sign * dx;
            }
        }
        if (Input.GetKey(KeyCode.S))
            dir.z -= Time.deltaTime;
        else if (Input.GetKey(KeyCode.W))
            dir.z += Time.deltaTime;
        else
        {
            if (Mathf.Abs(dir.z) < dx)
            {
                dir.z = 0;
            }
            else
            {
                float v = dir.z;
                float sign = -Mathf.Sign(v);
                dir.z += sign * dx;
            }
        }
        transform.position += dir*Time.deltaTime;
    }
}
