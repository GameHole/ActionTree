using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, Random.Range(0, 180), 0);
        speed = Random.Range(1, 2);
    }
    float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0);
    }
}
