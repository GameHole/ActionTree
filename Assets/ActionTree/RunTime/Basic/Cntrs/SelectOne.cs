namespace ActionTree
{
    public class SelectOne : ATreeCntr
    {
        public override void Do()
        {
            trees[0].Do();
            if (trees[0].Condition)
            {
                //UnityEngine.Debug.Log($"true is {trees[1]}");
                trees[1].TryDo();
                Condition = trees[1].Condition;
            }
            else
            {
                //UnityEngine.Debug.Log($"false is {trees[2]}");
                if (trees.Length > 2)
                {
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

