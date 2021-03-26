using System.Reflection;

namespace ActionTree
{
    public abstract class ATree : ETree
    {
        public static float deltaTime { get; internal set; }
        //public bool Condition { get; set; }
        //public Entity Entity
        //{
        //    get => entity;
        //    set
        //    {
        //        SetEntity(value);
        //    }
        //}

        //public ITree Parent { get; set; }

        //Entity entity;
        public override void Clear()
        {
            Condition = false;
        }
        //public abstract void Do();
        //public void SetEntity(Entity entity)
        //{
        //    this.entity = entity;
        //    var m = typeof(IComponent);
        //    foreach (var item in GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
        //    {
        //        if (item.FieldType.IsClass && m.IsAssignableFrom(item.FieldType))
        //        {
        //            item.SetValue(this, entity.Get(item.FieldType));
        //        }
        //    }  
        //}
        public Driver driver;
        public override void Apply()
        {
            reflect((ETree)Parent);
        }
        void reflect(ETree p)
        {
            foreach (var item in GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                var ft = item.FieldType;
                if (ft.IsAbstract | ft.IsInterface | ft.IsValueType) continue;
                IComponent cmp = null;
                if (item.GetCustomAttribute<ParentAttribute>() == null)
                    cmp = FindType(ft);
                var parnet = p;
                while (cmp == null && parnet != null)
                {
                    //UnityEngine.Debug.Log($"finding {item.FieldType} ::{parnet}");
                    cmp = parnet.FindType(ft);
                    parnet = (ETree)parnet.Parent;
                }
                //if (cmp == null)
                //    throw new System.NullReferenceException($"this::{this} field::{item.Name},type::{ft} is not found");
                //UnityEngine.Debug.Log($"{item.Name} ::{cmp}");
                item.SetValue(this, cmp);
            }
        }
        public override bool PreDo() => false;
    }
}
