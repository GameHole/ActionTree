using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class ToAlpha:ATree
	{
        FloatValue value;
        MaterialProxy material;
		public override void Do()
        {
            var c = material.material.color;
            c.a = value.value;
            material.material.color = c;
        }
	}
	public class ToAlphaLeaf: TreeProvider<ToAlpha> { }
}
