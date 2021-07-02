using System;

namespace ActionTree
{
    public enum UpdateType { Update,LateUpdate}
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MainThreadAttribute : Attribute
    {
        public UpdateType update = UpdateType.Update;
        public MainThreadAttribute() { }
        public MainThreadAttribute(UpdateType type)
        {
            this.update = type;
        }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class NotPreDoAttribute : Attribute
    {
    }
}
