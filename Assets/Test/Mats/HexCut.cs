using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class HexCut : MonoBehaviour
{
    Image image;
    Canvas can;
    RectTransform rectTran;
    Material material;
    public Color bg = new Color(0.7f, 0.7f, 0.7f, 1);
    public Vector2 offset;
    void Start()
    {
        image = GetComponent<Image>();
        can = GetComponentInParent<Canvas>();
        rectTran = GetComponent<RectTransform>();
        material = new Material(Shader.Find("MYUI/CUT"));
        image.material = material;
        var tex = image.sprite.texture;
        var rect = image.sprite.textureRect;
        Vector4 orionAndSize = new Vector4();
        orionAndSize.x = rect.xMin / tex.width;
        orionAndSize.y = rect.yMin / tex.height;
        orionAndSize.z = (rect.xMax ) / tex.width;
        orionAndSize.w = (rect.yMax ) / tex.height;
        material.SetVector("_OrgionAndSize", orionAndSize);
        //Debug.Log(orionAndSize);
    }
    void Update()
    {
        image.material.SetMatrix("_localworld", can.transform.localToWorldMatrix);
        image.material.SetMatrix("_world2local", transform.worldToLocalMatrix);
        image.material.SetFloat("_w", rectTran.rect.width);
        image.material.SetFloat("_h", rectTran.rect.height);
        material.SetVector("_MainTex_ST", new Vector4(1, 1, offset.x, offset.y));
        material.SetColor("_BGColor", bg);
    }
}
