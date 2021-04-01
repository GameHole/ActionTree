using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTexTake : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        var tex = image.sprite.texture;
        var rect = image.sprite.textureRect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
