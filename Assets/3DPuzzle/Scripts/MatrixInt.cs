using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Default
{
    public struct Vector4Int
    {
        public int x, y, z, w;
        public Vector4Int(Vector3Int v,int p)
        {
            x = v.x;
            y = v.y;
            z = v.z;
            w = p;
        }
    }
    public struct MatrixInt
    {
        public int m00;
        public int m01;
        public int m02;
        public int m03;
        public int m10;
        public int m11;
        public int m12;
        public int m13;
        public int m20;
        public int m21;
        public int m22;
        public int m23;
        public int m30;
        public int m31;
        public int m32;
        public int m33;
        public readonly static MatrixInt PositiveX = new MatrixInt(
            1, 0, 0, 0,
            0, 0, -1, 0,
            0, 1, 0, 0,
            0, 0, 0, 1);
        public readonly static MatrixInt NegativeX = new MatrixInt(1, 0, 0, 0, 0, 0, 1, 0, 0, -1, 0, 0, 0, 0, 0, 1);
        public readonly static MatrixInt PositiveY = new MatrixInt(0, 0, -1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1);
        public readonly static MatrixInt NegativeY = new MatrixInt(0, 0, 1,0, 0, 1, 0,0, -1, 0, 0,0, 0, 0, 0, 1);
        public readonly static MatrixInt PositiveZ = new MatrixInt(0, -1, 0,0, 1, 0, 0,0, 0, 0, 1,0,0, 0, 0, 1);
        public readonly static MatrixInt NegativeZ = new MatrixInt(0, 1, 0,0, -1, 0, 0,0, 0, 0, 1,0,0, 0, 0, 1);
        public static Vector3Int operator *(MatrixInt matrix, Vector4Int vector)
        {
            return new Vector3Int(matrix.m00 * vector.x + matrix.m01 * vector.y + matrix.m02 * vector.z+ matrix.m03 * vector.w,
                                  matrix.m10 * vector.x + matrix.m11 * vector.y + matrix.m12 * vector.z + matrix.m13 * vector.w,
                                  matrix.m20 * vector.x + matrix.m21 * vector.y + matrix.m22 * vector.z + matrix.m23 * vector.w);
        }
        public static Vector3Int operator *(Vector4Int vector,MatrixInt matrix)
        {
            return new Vector3Int(matrix.m00 * vector.x + matrix.m10 * vector.y + matrix.m20 * vector.z + matrix.m30 * vector.w,
                                  matrix.m01 * vector.x + matrix.m11 * vector.y + matrix.m21 * vector.z + matrix.m31 * vector.w,
                                  matrix.m02 * vector.x + matrix.m12 * vector.y + matrix.m22 * vector.z + matrix.m32 * vector.w);
        }
        public static MatrixInt operator *(MatrixInt matrix, int scale)
        {
            matrix.m00 *= scale;
            matrix.m01 *= scale;
            matrix.m02 *= scale;
            matrix.m03 *= scale;
            matrix.m10 *= scale;
            matrix.m11 *= scale;
            matrix.m12 *= scale;
            matrix.m13 *= scale;
            matrix.m20 *= scale;
            matrix.m21 *= scale;
            matrix.m22 *= scale;
            matrix.m23 *= scale;
            matrix.m30 *= scale;
            matrix.m31 *= scale;
            matrix.m32 *= scale;
            matrix.m33 *= scale;
            return matrix;
        }
        public static MatrixInt operator *(int scale,MatrixInt matrix)
        {
            matrix.m00 *= scale;
            matrix.m01 *= scale;
            matrix.m02 *= scale;
            matrix.m03 *= scale;
            matrix.m10 *= scale;
            matrix.m11 *= scale;
            matrix.m12 *= scale;
            matrix.m13 *= scale;
            matrix.m20 *= scale;
            matrix.m21 *= scale;
            matrix.m22 *= scale;
            matrix.m23 *= scale;
            matrix.m30 *= scale;
            matrix.m31 *= scale;
            matrix.m32 *= scale;
            matrix.m33 *= scale;
            return matrix;
        }
        public static MatrixInt operator *(MatrixInt matrixl, MatrixInt matrixr)
        {
            MatrixInt r;
            r.m00 = matrixl.m00 * matrixr.m00 + matrixl.m01 * matrixr.m10 + matrixl.m02 * matrixr.m20 + matrixl.m03 * matrixr.m30;
            r.m01 = matrixl.m00 * matrixr.m01 + matrixl.m01 * matrixr.m11 + matrixl.m02 * matrixr.m21 + matrixl.m03 * matrixr.m31;
            r.m02 = matrixl.m00 * matrixr.m02 + matrixl.m01 * matrixr.m12 + matrixl.m02 * matrixr.m22 + matrixl.m03 * matrixr.m32;
            r.m03 = matrixl.m00 * matrixr.m03 + matrixl.m01 * matrixr.m13 + matrixl.m02 * matrixr.m23 + matrixl.m03 * matrixr.m33;
            r.m10 = matrixl.m10 * matrixr.m00 + matrixl.m11 * matrixr.m10 + matrixl.m12 * matrixr.m20 + matrixl.m13 * matrixr.m30;
            r.m11 = matrixl.m10 * matrixr.m01 + matrixl.m11 * matrixr.m11 + matrixl.m12 * matrixr.m21 + matrixl.m13 * matrixr.m31;
            r.m12 = matrixl.m10 * matrixr.m02 + matrixl.m11 * matrixr.m12 + matrixl.m12 * matrixr.m22 + matrixl.m13 * matrixr.m32;
            r.m13 = matrixl.m10 * matrixr.m03 + matrixl.m11 * matrixr.m13 + matrixl.m12 * matrixr.m23 + matrixl.m13 * matrixr.m33;
            r.m20 = matrixl.m20 * matrixr.m00 + matrixl.m21 * matrixr.m10 + matrixl.m22 * matrixr.m20 + matrixl.m23 * matrixr.m30;
            r.m21 = matrixl.m20 * matrixr.m01 + matrixl.m21 * matrixr.m11 + matrixl.m22 * matrixr.m21 + matrixl.m23 * matrixr.m31;
            r.m22 = matrixl.m20 * matrixr.m02 + matrixl.m21 * matrixr.m12 + matrixl.m22 * matrixr.m22 + matrixl.m23 * matrixr.m32;
            r.m23 = matrixl.m20 * matrixr.m03 + matrixl.m21 * matrixr.m13 + matrixl.m22 * matrixr.m23 + matrixl.m23 * matrixr.m33;
            r.m30 = matrixl.m30 * matrixr.m00 + matrixl.m31 * matrixr.m10 + matrixl.m32 * matrixr.m20 + matrixl.m33 * matrixr.m30;
            r.m31 = matrixl.m30 * matrixr.m01 + matrixl.m31 * matrixr.m11 + matrixl.m32 * matrixr.m21 + matrixl.m33 * matrixr.m31;
            r.m32 = matrixl.m30 * matrixr.m02 + matrixl.m31 * matrixr.m12 + matrixl.m32 * matrixr.m22 + matrixl.m33 * matrixr.m32;
            r.m33 = matrixl.m30 * matrixr.m03 + matrixl.m31 * matrixr.m13 + matrixl.m32 * matrixr.m23 + matrixl.m33 * matrixr.m33;
            return r;
        }
        public MatrixInt(
         int M00,
         int M01,
         int M02,
         int M03,
         int M10,
         int M11,
         int M12,
         int M13,
         int M20,
         int M21,
         int M22,
         int M23,
         int M30,
         int M31,
         int M32,
         int M33)
        {
            m00 = M00;
            m01 = M01;
            m02 = M02;
            m03 = M03;
            m10 = M10;
            m11 = M11;
            m12 = M12;
            m13 = M13;
            m20 = M20;
            m21 = M21;
            m22 = M22;
            m23 = M23;
            m30 = M30;
            m31 = M31;
            m32 = M32;
            m33 = M33;
        }
    }
}
