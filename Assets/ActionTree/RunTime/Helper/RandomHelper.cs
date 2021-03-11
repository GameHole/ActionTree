namespace ActionTree
{
    using System;
    public static class RandomHelper 
    {
        public static float Range(float min,float max)
        {
            Random random = new Random();
            return min + (float)random.NextDouble() * (max - min);
        }
        public static int Range(int min,int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}

