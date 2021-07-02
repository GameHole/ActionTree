namespace ActionTree
{
    public class SelectOne : ATreeCntr
    {
        public bool ignoreChildCondition;
        public override void Do()
        {
            trees[0].Do();
            if (trees[0].Condition)
            {
                //UnityEngine.Debug.Log($"true is {trees[1]}");
                if (ignoreChildCondition)
                    trees[1].Do();
                else
                    trees[1].TryDo();
                Condition = trees[1].Condition;
            }
            else
            {
                //UnityEngine.Debug.Log($"false is {trees[2]}");
                if (trees.Length > 2)
                {
                    if (ignoreChildCondition)
                        trees[2].Do();
                    else
                        trees[2].TryDo();
                    Condition = trees[2].Condition;
                }
            }
        }
        public override bool PreDo()
        {
            return trees[0].PreDo();
        }
    }
}

