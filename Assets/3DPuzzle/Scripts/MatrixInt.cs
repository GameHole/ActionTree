using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Default
{
    public struct MatrixInt
    {
        public int m0;
        public int m1;
        public int m2;
        public int m3;
        public int m4;
        public int m5;
        public int m6;
        public int m7;
        public int m8;
        public readonly static MatrixInt PositiveX = new MatrixInt(new Vector3Int(1, 0, 0), new Vector3Int(0, 0, -1), new Vector3Int(0, 1, 0));
        public readonly static MatrixInt NegativeX = new MatrixInt(new Vector3Int(1, 0, 0), new Vector3Int(0, 0, 1), new Vector3Int(0, -1, 0));
        public readonly static MatrixInt PositiveY = new MatrixInt(new Vector3Int(0, 0, -1), new Vector3Int(0, 1, 0), new Vector3Int(1, 0, 0));
        public readonly static MatrixInt NegativeY = new MatrixInt(new Vector3Int(0, 0, 1), new Vector3Int(0, 1, 0), new Vector3Int(-1, 0, 0));
        public readonly static MatrixInt PositiveZ = new MatrixInt(new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 0, 1));
        public readonly static MatrixInt NegativeZ = new MatrixInt(new Vector3Int(0, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(0, 0, 1));
        public static Vector3Int operator*(MatrixInt matrix,Vector3Int vector)
        {
            return new Vector3Int(matrix.m0 * vector.x + matrix.m1 * vector.y + matrix.m2 * vector.z,
                                  matrix.m3 * vector.x + matrix.m4 * vector.y + matrix.m5 * vector.z,
                                  matrix.m6 * vector.x + matrix.m7 * vector.y + matrix.m8 * vector.z);
        }
        public static MatrixInt operator *(MatrixInt matrixl, MatrixInt matrixr)
        {
            MatrixInt r;
            r.m0 = matrixl.m0 * matrixr.m0 + matrixl.m1 * matrixr.m3 + matrixl.m2 * matrixr.m6;
            r.m1 = matrixl.m0 * matrixr.m1 + matrixl.m1 * matrixr.m4 + matrixl.m2 * matrixr.m7;
            r.m2 = matrixl.m0 * matrixr.m2 + matrixl.m1 * matrixr.m5 + matrixl.m2 * matrixr.m8;
            r.m3 = matrixl.m3 * matrixr.m0 + matrixl.m4 * matrixr.m3 + matrixl.m5 * matrixr.m6;
            r.m4 = matrixl.m3 * matrixr.m1 + matrixl.m4 * matrixr.m4 + matrixl.m5 * matrixr.m7;
            r.m5 = matrixl.m3 * matrixr.m2 + matrixl.m4 * matrixr.m5 + matrixl.m5 * matrixr.m8;
            r.m6 = matrixl.m6 * matrixr.m0 + matrixl.m7 * matrixr.m3 + matrixl.m8 * matrixr.m6;
            r.m7 = matrixl.m6 * matrixr.m1 + matrixl.m7 * matrixr.m4 + matrixl.m8 * matrixr.m7;
            r.m8 = matrixl.m6 * matrixr.m2 + matrixl.m7 * matrixr.m5 + matrixl.m8 * matrixr.m8;
            return r;
        }
        public MatrixInt(Vector3Int r0,Vector3Int r1,Vector3Int r2)
        {
            m0 = r0.x;
            m1 = r0.y;
            m2 = r0.z;
            m3 = r1.x;
            m4 = r1.y;
            m5 = r1.z;
            m6 = r2.x;
            m7 = r2.y;
            m8 = r2.z;
        }
    }
}
