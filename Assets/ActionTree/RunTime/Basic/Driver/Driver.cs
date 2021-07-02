using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Reflection;
namespace ActionTree
{
    public delegate void TreeAdded(ref ITree tree,int queueId);
    public class Driver
    {
        int idx = 0;
        Worker[] workers = new Worker[Environment.ProcessorCount - 1];
        public Worker[] Workers => workers;
        EntityCntr cntr = new EntityCntr();
        public event Action onBeforeRun;
        public event Action<Entity> onAddEntity;
        public event Action<Entity> onRemoveEntity;
        public List<TreeAdded> onTreeAdded = new List<TreeAdded>();
        internal bool useMulThread = true;
        List<Entity> addingEs = new List<Entity>();
        List<Entity> removingEs = new List<Entity>();
        struct AddTreeInfo
        {
            public int threadId;
            public ITree tree;
        }
        List<AddTreeInfo> addTrees = new List<AddTreeInfo>();
        public void Init()
        {
            //UnityEngine.Debug.Log("Init");
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Worker();
            }
            onTreeAdded.Add((ref ITree t, int i) =>
            {
                RepleaseFindedTree(ref t, null, i, 0);
            });
        }
        public void Run()
        {
            if (!isWorking())
            {
                OnEntityAddRemove();
                OnTreeAdd();
                onBeforeRun?.Invoke();
                //UnityEngine.Debug.Log("work do");
                Do();
            }
        }
        void OnTreeAdd()
        {
            for (int i = 0; i < addTrees.Count; i++)
            {
                var v = addTrees[i];
                v.tree.PreDo();
                workers[v.threadId].added.Add(v.tree);
            }
            addTrees.Clear();
        }
        void OnEntityAddRemove()
        {
            for (int i = 0; i < addingEs.Count; i++)
            {
                var e = addingEs[i];
                cntr.Add(e);
                onAddEntity?.Invoke(e);
            }
            for (int i = 0; i < removingEs.Count; i++)
            {
                var e = removingEs[i];
                cntr.Remove(e);
                onRemoveEntity?.Invoke(e);
            }
            addingEs.Clear();
            removingEs.Clear();
        }
        void Do()
        {
            if (useMulThread)
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    workers[i].Start();
                }
            }
            else
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    workers[i].Run();
                }
            }
        }
        bool isWorking()
        {
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].isRun)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddEntity(Entity entity)
        {
            addingEs.Add(entity);
            //cntr.Add(entity);
            //onAddEntity?.Invoke(entity);
        }
        public void RemoveEntity(Entity entity)
        {
            removingEs.Add(entity);
            //cntr.Remove(entity);
            //onRemoveEntity?.Invoke(entity);
        }
        public void AddTree(ITree v)
        {
            //UnityEngine.Debug.Log($"dr add {v.entity.Get<UnityEntity>()}");
            int i = idx++;
            var e = v.entity;
            if (e != null)
            {
                var tid = e.Get<ThreadId>();
                if (tid != null)
                {
                    i = tid.value;
                    e.Remove<ThreadId>();
                }
            }
            int id = i % workers.Length;
            //var worker = workers[id];
            v.Foreach((ref ITree x) =>
            {
                if (x is ATree aTree)
                    aTree.driver = this;
            });
            for (int c = 0; c < onTreeAdded.Count; c++)
            {
                onTreeAdded[c]?.Invoke(ref v, id);
            }
            addTrees.Add(new AddTreeInfo { tree = v, threadId = id });
            //RepleaseProxyTree(ref v, worker);
            //v.PreDo();
            //worker.added.Add(v);
            //UnityEngine.Debug.Log("driver add");
        }
        internal IComponent FindFirstCmp(Type type)
        {
            var ls = cntr.Find(type);
            if (ls.Count > 0)
            {
                //UnityEngine.Debug.Log($"firet  eid {ls[0].id}");
                return ls[0].Get(type);
            }
            return null;
        }
        public Entity FindEntityWith(params Type[] type)
        {
            var ls = cntr.Find(type);
            if (ls.Count > 0)
                return ls[0];
            return null;
        }
        public bool TryFindEntityWith(ref Entity entity,params Type[] type)
        {
            if (entity != null)
            {
                return true;
            }
            entity = FindEntityWith(type);
            return entity != null;
        }
        public IList<Entity> FindEntitysWith(params Type[] type)
        {
            return cntr.Find(type);
        }
        public Entity FindEntityWith<T>() where T : class, IComponent
        {
            return FindEntityWith(typeof(T));
        }
        public T FindFirstCmp<T>()where T:class,IComponent
        {
            return FindFirstCmp(typeof(T)) as T;
        }
        public bool TryFindFirstCmp<T>(ref T v) where T : class, IComponent
        {
            if (v != null)
            {
                return true;
            }
            v = FindFirstCmp(typeof(T)) as T;
            return v != null;
        }
        public List<T> Find<T>() where T : class, IComponent
        {
            var type = typeof(T);
            var ret = new List<T>();
            var es = cntr.Find(type);
            for (int i = 0; i < es.Count; i++)
            {
                ret.Add(es[i].Get<T>());
            }
            return ret;
        }
        
        internal void RepleaseFindedTree(ref ITree tree, ATreeCntr cntr,int workerId, int index)
        {
            if (tree is ATreeCntr treeCntr)
            {
                for (int i = 0; i < treeCntr.Count; i++)
                {
                    RepleaseFindedTree(ref treeCntr.trees[i], treeCntr, workerId, i);
                }
            }
            else
            {
                var opTree = tree;
                if(tree is ProxyTree proxyTree)
                {
                    opTree = proxyTree.tree;
                }
                var at = opTree as ATree;
                if ( at != null && at.needFindInfo != null)
                {
                    if (cntr != null)
                    {
                        var findTree = new FindableTree();
                        findTree.injectedTree = at;
                        findTree.repleasedTree = tree;
                        findTree.index = index;
                        findTree.cntr = cntr;
                        cntr.trees[index] = new NoneAction();
                        workers[workerId].added.Add(findTree);
                    }
                    else
                    {
                        throw new ArgumentException($"Findedable tree {tree.Name} must be a child node,you need to add a 'ATreeCntr' node to parent");
                    }
                }
            }
        }
        public void Destroy()
        {
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i].Stop();
            }
            cntr.Clear();
        }
    }
}
