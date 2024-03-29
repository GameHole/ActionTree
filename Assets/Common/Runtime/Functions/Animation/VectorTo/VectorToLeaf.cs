﻿using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class VectorTo:ATree
	{
        VecToData data;
        FloatValue draveData;
        Vector3Value output;
        public override void Do()
        {
            var dif = data.isFast ? data.dif : data.end - data.start;
            output.value = data.start + dif * draveData;
            //this.Log($"s {data.start} d {dif} c {curve.output}");
        }
    }
	public class VectorToLeaf: TreeProvider<VectorTo> { }
}
