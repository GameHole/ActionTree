using System.Reflection;

namespace ActionTree
{
    public abstract class ATree : ITree
    {
        public static float deltaTime { get; internal set; }
        public bool Condition { get; set; }
        public Entity Entity
        {
            get => entity;
            set
            {
                SetEntity(value);
            }
        }
        Entity entity;
        public virtual void Clear()
        {
            Condition = false;
        }
        public abstract void Do();
        public void SetEntity(Entity entity)
        {
            this.entity = entity;
            var m = typeof(IComponent);
            foreach (var item in GetType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
            {
                if (item.FieldType.IsClass && m.IsAssignableFrom(item.FieldType))
                {
                    item.SetValue(this,entity.Get(item.FieldType));
                }
            }  
        }

        public virtual void PreDo() { }
    }
}
