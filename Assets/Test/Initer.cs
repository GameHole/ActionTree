//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using ActionTree;
//namespace Default
//{
//    public class Initer : EntityIniter
//    {
//        protected override void AddCmp(Entity entity)
//        {
//            entity.AddComponent<Position>().value = transform.position;
//            entity.AddComponent<Direction>();
//            entity.AddComponent<Speed>().value = 5;
//        }

//        protected override ITree MainTree()
//        {
//            var ser = new Serial();
//            {
//                var pall = new Parallel();
//                {
//                    {
//                        var one = new WaitOne();
//                        {
//                            var ser1 = new Serial();

//                            ser1.Add(new WaitKey { key = KeyCode.W });
//                            ser1.Add(new IncAxis { axis = 2, sign = 1 });

//                            one.Add(ser1);
//                        }

//                        {
//                            var ser1 = new Serial();

//                            ser1.Add(new WaitKey { key = KeyCode.S });
//                            ser1.Add(new IncAxis { axis = 2, sign = -1 });

//                            one.Add(ser1);
//                        }
//                        one.Add(new DecAxis { axis = 2 });

//                        pall.Add(one);
//                    }

//                    {
//                        var one = new WaitOne();
//                        {
//                            var ser1 = new Serial();

//                            ser1.Add(new WaitKey { key = KeyCode.D });
//                            ser1.Add(new IncAxis { axis = 0, sign = 1 });

//                            one.Add(ser1);
//                        }

//                        {
//                            var ser1 = new Serial();

//                            ser1.Add(new WaitKey { key = KeyCode.A });
//                            ser1.Add(new IncAxis { axis = 0, sign = -1 });

//                            one.Add(ser1);
//                        }
//                        one.Add(new DecAxis { axis = 0 });

//                        pall.Add(one);
//                    }
//                }
//                ser.Add(pall);
//            }
//            ser.Add(new Move());
//            ser.Add(new SyncP());
//            ser.Add(new Loop { tree = ser });
//            return ser;
//        }
//    }
//}

