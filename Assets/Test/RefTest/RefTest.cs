using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefTest : MonoBehaviour
{
    public Vector3 normal = Vector3.up;
    public Vector3 q;
    public Transform a;
    public Transform b;
    public MeshRenderer rend;
    void Start()
    {
     
        //b.position = reflectMatrix.transpose.MultiplyPoint(a.position);
        //Debug.Log(reflectMatrix);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 n = normal.normalized;
        Matrix4x4 refPart = new Matrix4x4();
        refPart.m00 = n.x * n.x;
        refPart.m01 = n.y * n.x;
        refPart.m02 = n.z * n.x;
        refPart.m10 = n.x * n.y;
        refPart.m11 = n.y * n.y;
        refPart.m12 = n.z * n.y;
        refPart.m20 = n.x * n.z;
        refPart.m21 = n.y * n.z;
        refPart.m22 = n.z * n.z;
        var reflectMatrix = sub(Matrix4x4.identity, mulvalue(refPart, 2));
        Vector3 m = 2 * Vector3.Dot(q, n) * n;
        reflectMatrix.m30 = m.x;
        reflectMatrix.m31 = m.y;
        reflectMatrix.m32 = m.z;
        b.position = mulp(a.position, reflectMatrix);
        rend.material.SetMatrix("refMtx", reflectMatrix);
        rend.material.SetVector("q", new Vector4(q.x,q.y,q.z,1));
        rend.material.SetVector("n", n);
    }
    public static Vector3 mulp(Vector3 b,Matrix4x4 a)
    {
        return new Vector3(b.x * a.m00 + b.y * a.m10 + b.z * a.m20 + 1 * a.m30,
                           b.x * a.m01 + b.y * a.m11 + b.z * a.m21 + 1 * a.m31,
                           b.x * a.m02 + b.y * a.m12 + b.z * a.m22 + 1 * a.m32);
    }
    public static Matrix4x4 sub(Matrix4x4 a, Matrix4x4 b)
    {
        a.m00 -= b.m00;
        a.m01 -= b.m01;
        a.m02 -= b.m02;
        a.m03 -= b.m03;
        a.m10 -= b.m10;
        a.m11 -= b.m11;
        a.m12 -= b.m12;
        a.m13 -= b.m13;
        a.m20 -= b.m20;
        a.m21 -= b.m21;
        a.m22 -= b.m22;
        a.m23 -= b.m23;
        a.m30 -= b.m30;
        a.m31 -= b.m31;
        a.m32 -= b.m32;
        a.m33 -= b.m33;
        return a;
    }
    public static Matrix4x4 mulvalue(Matrix4x4 matrix4,float v)
    {
        matrix4.m00 *= v;
        matrix4.m01 *= v;
        matrix4.m02 *= v;
        matrix4.m03 *= v;
        matrix4.m10 *= v;
        matrix4.m11 *= v;
        matrix4.m12 *= v;
        matrix4.m13 *= v;
        matrix4.m20 *= v;
        matrix4.m21 *= v;
        matrix4.m22 *= v;
        matrix4.m23 *= v;
        matrix4.m30 *= v;
        matrix4.m31 *= v;
        matrix4.m32 *= v;
        matrix4.m33 *= v;
        return matrix4;
    }
}
