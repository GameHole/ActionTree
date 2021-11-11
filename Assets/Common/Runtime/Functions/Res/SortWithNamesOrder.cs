using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    public class SortWithNamesOrder<T> : ATree where T : Object
    {
        protected Array<T> objects;
        protected Array<string> strings;
        public override void Do()
        {
            var catche = objects.GetNameMap();
            for (int i = 0, c = Mathf.Min(objects.Length, strings.Length); i < c; i++)
            {
                if (catche.TryGetValue(strings[i], out var item))
                    objects[i] = item;
            }
            Condition = true;
        }
    }
}
