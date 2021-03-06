using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefTest : MonoBehaviour
{
    public Vector3 axis = Vector3.up;
    public Vector3 q;
    public float angle;
    public MeshRenderer rend;
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        //b.position = reflectMatrix.transpose.MultiplyPoint(a.position);
        //Debug.Log(reflectMatrix);
    }

    // Update is called once per frame
    void Update()
    {
        float cos = Mathf.Cos(angle * Mathf.Deg2Rad);
        float sin = Mathf.Sin(angle * Mathf.Deg2Rad);
        Vector3 nAxis = axis.normalized;
        Matrix4x4 crossPart = new Matrix4x4();
        crossPart.m01 = nAxis.z;
        crossPart.m02 = -nAxis.y;
        crossPart.m10 = -nAxis.z;
        crossPart.m12 = nAxis.x;
        crossPart.m20 = nAxis.y;
        crossPart.m21 = -nAxis.x;
        Matrix4x4 croPart = new Matrix4x4();
        croPart.m00 = nAxis.x * nAxis.x;
        croPart.m01 = nAxis.y * nAxis.x;
        croPart.m02 = nAxis.z * nAxis.x;
        croPart.m10 = nAxis.x * nAxis.y;
        croPart.m11 = nAxis.y * nAxis.y;
        croPart.m12 = nAxis.z * nAxis.y;
        croPart.m20 = nAxis.x * nAxis.z;
        croPart.m21 = nAxis.y * nAxis.z;
        croPart.m22 = nAxis.z * nAxis.z;
        var rotMatrix = add(mulvalue(crossPart, sin), add(mulvalue(Matrix4x4.identity, cos), mulvalue(croPart, 1 - cos)));
        rotMatrix.m30 = 0;
        rotMatrix.m31 = 0;
        rotMatrix.m32 = 0;
        rotMatrix.m32 = 0;
        Vector3 m = q - mulp(q, rotMatrix);
        rotMatrix.m30 = m.x;
        rotMatrix.m31 = m.y;
        rotMatrix.m32 = m.z;
        //b.position = mulp(a.position, reflectMatrix);
        rend.material.SetMatrix("refMtx", rotMatrix);
        rend.material.SetVector("q", new Vector4(q.x, q.y, q.z, 1));
        rend.material.SetVector("n", nAxis);
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
    public static Matrix4x4 add(Matrix4x4 a, Matrix4x4 b)
    {
        a.m00 += b.m00;
        a.m01 += b.m01;
        a.m02 += b.m02;
        a.m03 += b.m03;
        a.m10 += b.m10;
        a.m11 += b.m11;
        a.m12 += b.m12;
        a.m13 += b.m13;
        a.m20 += b.m20;
        a.m21 += b.m21;
        a.m22 += b.m22;
        a.m23 += b.m23;
        a.m30 += b.m30;
        a.m31 += b.m31;
        a.m32 += b.m32;
        a.m33 += b.m33;
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
