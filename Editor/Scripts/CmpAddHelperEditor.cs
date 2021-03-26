using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace ActionTree
{
    [InitializeOnLoad]
    public class CmpAddHelperEditor
    {
        static CmpAddHelperEditor()
        {
            ObjectFactory.componentWasAdded += (v) =>
            {
                //Debug.Log($"{v} v is TreeProvider {v is TreeProvider}");
                if (v is TreeProvider tp)
                {
                    tp.AddCmps();
                }
            };
        }
    }
}

