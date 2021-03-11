namespace ActionTree
{
    using System;
    struct RandomLFSR
    {
        public static readonly uint AUTO = 0;
        private static readonly float value = 1f / uint.MaxValue;
        uint z1, z2, z3, z4;
        public RandomLFSR(uint seed)
        {
            if (seed == AUTO)
                seed = (uint)Environment.TickCount;
            z1 = z2 = z3 = z4 = seed;
        }
        public uint Next()
        {
            uint b = ((z1 << 6) ^ z1) >> 13;
            z1 = ((z1 & 4294967294) << 18) ^ b;
            b = ((z2 << 2) ^ z2) >> 27;
            z2 = ((z2 & 4294967288) << 2) ^ b;
            b = ((z3 << 13) ^ z3) >> 21;
            z3 = ((z3 & 4294967280) << 7) ^ b;
            b = ((z4 << 3) ^ z4) >> 12;
            z4 = ((z4 & 4294967168) << 13) ^ b;
            return z1 ^ z2 ^ z3 ^ z4;
        }

        public int Range(int min, int max)
        {
            return min + (int)((max - min) * Nextf32());
        }
        public float Nextf32()
        {
            return Next() * value;
        }
        public float Range(float min, float max)
        {
            return min + (max - min) * Nextf32();
        }
    }
}
