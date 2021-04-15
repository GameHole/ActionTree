using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]
public class ReflectedPlane : MonoBehaviour
{
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
    public Vector3 normal = Vector3.up;
    public Vector3 q;
    public Vector2Int density = new Vector2Int(10, 10);
    public Texture font;
    public Texture back;
    void Start()
    {
        meshRenderer = GetOrAdd<MeshRenderer>();
        meshFilter = GetOrAdd<MeshFilter>();
        meshRenderer.material = new Material(Shader.Find("Custom/RefStand"));
        meshRenderer.material.SetTexture("_MainTex", font);
        meshRenderer.material.SetTexture("_BACK", back);
        meshFilter.mesh = GenMesh();
    }
    Mesh GenMesh()
    {
        Mesh mesh = new Mesh();
        Vector3[] points = new Vector3[density.x * density.y];
        Vector2[] uv = new Vector2[points.Length];
        Vector3[] normals = new Vector3[points.Length];
        for (int x = 0; x < density.x; x++)
        {
            for (int y = 0; y < density.y; y++)
            {
                int idx = toIndex(x, y);
                Vector2 u = new Vector2((float)x / (density.x - 1), (float)y / (density.y - 1));
                var p = u - Vector2.one * 0.5f;
                points[idx] = new Vector3(p.x, 0, p.y);
                //Debug.Log($"idx = {idx} x {p.x} y {p.y}");
                uv[idx] = u;
                normals[idx] = Vector3.up;
            }
        }
        int[] triIndexs = new int[(density.x - 1) * (density.y - 1) * 6];
        for (int x = 0; x < density.x - 1; x++)
        {
            for (int y = 0; y < density.y-1; y++)
            {
                int ptr = (x * (density.y - 1) + y) * 6;
                //Debug.Log($"idx {ptr} x {x} y {y}");
                triIndexs[ptr] = toIndex(x, y + 1);
                triIndexs[ptr + 1] = toIndex(x + 1, y + 1);
                triIndexs[ptr + 2] = toIndex(x, y);
                triIndexs[ptr + 3] = toIndex(x + 1, y + 1);
                triIndexs[ptr + 4] = toIndex(x + 1, y);
                triIndexs[ptr + 5] = toIndex(x, y);
            }
        }
        //Debug.Log(triIndexs.Length);
        //for (int i = 0,idx =0; i < triIndexs.Length; i += 6,idx++)
        //{
        //    Debug.Log(idx);
        //    Vector2Int p = Devided(idx);
        //    triIndexs[i] = toIndex(p.x, p.y + 1);
        //    triIndexs[i + 1] = toIndex(p.x + 1, p.y + 1);
        //    triIndexs[i + 2] = toIndex(p.x, p.y);
        //    triIndexs[i + 3] = toIndex(p.x + 1, p.y + 1);
        //    triIndexs[i + 4] = toIndex(p.x + 1, p.y);
        //    triIndexs[i + 5] = toIndex(p.x, p.y);
        //    //for (int n = 0; n < 6; n++)
        //    //{
        //    //    int idx = triIndexs[n + i];
        //    //    Debug.Log($"idx {idx} x {points[idx].x} y{points[idx].z}");
               
        //    //}
        //    //Debug.Log($"---------------------------");
        //}
        mesh.vertices = points;
        mesh.triangles = triIndexs;
        mesh.uv = uv;
        mesh.normals = normals;
        //mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        return mesh;
    }
    int toIndex(int x, int y) => x * density.y + y;
    Vector2Int Devided(int idx)
    {
        return new Vector2Int(idx / (density.y), idx % (density.y));
    }
    T GetOrAdd<T>()where T : Component
    {
        var t = GetComponent<T>();
        if (!t)
            t = gameObject.AddComponent<T>();
        return t;
    }
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
        meshRenderer.material.SetMatrix("refMtx", reflectMatrix);
        meshRenderer.material.SetVector("q", new Vector4(q.x, q.y, q.z, 1));
        meshRenderer.material.SetVector("n", n);
    }
    public static Vector3 mulp(Vector3 b, Matrix4x4 a)
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
    public static Matrix4x4 mulvalue(Matrix4x4 matrix4, float v)
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
