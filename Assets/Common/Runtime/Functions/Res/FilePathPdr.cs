using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class FilePath : IComponent
	{
        public string value;
	}
	public class FilePathPdr: CmpProvider<FilePath> { }
}
