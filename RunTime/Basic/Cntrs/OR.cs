namespace ActionTree
{
    public class OR : ATreeCntr
    {
        public override void Do()
        {
            bool condition = false;
            for (int i = 0; i < Count; i++)
            {
                trees[i].TryDo();
                condition |= trees[i].Condition;
            }
            Condition = condition;
        }
    }
}

