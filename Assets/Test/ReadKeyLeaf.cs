//using ActionTree;
//using UnityEngine;
//namespace Default
//{
//	//[System.Serializable]
//	public sealed class ReadKey:ATree
//	{
//        internal WaitKey key;
//		public override void Do()
//        {
//            Condition = key.Condition;   
//        }
//	}
//	public class ReadKeyLeaf: TreeProvider<ReadKey>
//    {
//        public WaitKeyLeaf wait;
//        public override ITree GetTree()
//        {
//            value.key = wait.GetTree();
//            return base.GetTree();
//        }
//    }
//}
