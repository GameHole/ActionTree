//using ActionTree;
//using UnityEngine;
//namespace Default
//{
//	//[System.Serializable]
//	public sealed class WaitDrag:ATree
//	{
//        CombinedUICntr uICntr;
//        SelectId Id;
//		public override void Do()
//        {
//            //Debug.Log("WaitDrag");
//            for (int i = 0; i < uICntr.clicks.Count; i++)
//            {
//                //Debug.Log(uICntr.clicks[i].isDown);
//                if (uICntr.clicks[i].isDown)
//                {
//                    Id.value = i;
//                    Condition = true;
//                    break;
//                }
//            }
//        }
//        public override void Clear()
//        {
//            base.Clear();
//            for (int i = 0; i < uICntr.clicks.Count; i++)
//            {
//                uICntr.clicks[i].isDown = false;
//            }
//        }
//    }
//	public class WaitDragLeaf: TreeProvider<WaitDrag> { }
//}
