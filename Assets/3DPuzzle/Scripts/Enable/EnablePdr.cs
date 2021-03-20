using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class Enable : IComponent
	{
        public bool value;
	}
	public class EnablePdr: CmpProvider<Enable> { }
}
