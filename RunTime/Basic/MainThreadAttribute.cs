using System;

namespace ActionTree
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MainThreadAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class NotPreDoAttribute : Attribute
    {
    }
}
