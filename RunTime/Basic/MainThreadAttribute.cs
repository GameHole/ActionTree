using System;

namespace ActionTree
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MainThreadAttribute : Attribute
    {
    }
}
