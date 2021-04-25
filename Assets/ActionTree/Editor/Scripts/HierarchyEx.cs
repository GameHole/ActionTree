using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace ActionTree
{
    public partial class HierarchyEx 
    {
        [MenuItem("GameObject/Tree/Entity", false, 0)]
        public static void GenE()
        {
            genrateGo("Entity", typeof(UnityEntity));
        }
        [MenuItem("GameObject/Tree/Serial",false,0)]
        public static void Gen0()
        {
            genrateGo<SerialPdr>("Serial");
        }
        [MenuItem("GameObject/Tree/Parallel", false, 0)]
        public static void Gen1()
        {
            genrateGo<ParallelPdr>("Parallel");
        }
        [MenuItem("GameObject/Tree/WaitAll", false, 0)]
        public static void Gen2()
        {
            genrateGo<WaitAllPdr>("WaitAll");
        }
        [MenuItem("GameObject/Tree/WaitOne", false, 0)]
        public static void Gen3()
        {
            genrateGo<WaitOnePdr>("WaitOne");
        }
        [MenuItem("GameObject/Tree/SelectOne", false, 0)]
        public static void Gen4()
        {
            genrateGo<SelectOnePdr>("SelectOne");
        }
        [MenuItem("GameObject/Tree/OR", false, 0)]
        public static void Gen5()
        {
            genrateGo<ORProvider>("OR");
        }
        [MenuItem("GameObject/Tree/And", false, 0)]
        public static void Gen8()
        {
            genrateGo<AndProvider>("And");
        }
        [MenuItem("GameObject/Tree/Loop", false, 0)]
        public static void Gen6()
        {
            genrateGo<LoopPdr>("Loop");
        }
        static void genrateGo(string name,Type type)
        {
            var select = Selection.activeTransform;
            GameObject game = new GameObject(name);
            Undo.RegisterCreatedObjectUndo(game, "创建单个Cube : " + game.name);
            Undo.AddComponent(game, type);
            if (select != null)
            {
                
                game.transform.SetParent(select);
                game.transform.localPosition = Vector3.zero;
                //Undo.RegisterFullObjectHierarchyUndo(select, "set child" + select.name);
                //Undo.RegisterFullObjectHierarchyUndo(game, "set parent" + game.name);
            }
            //EditorGUIUtility.PingObject(game);
            Selection.activeGameObject = game;
         
        }
        static void genrateGo<T>(string name)where T : TreeProvider
        {
            genrateGo(name, typeof(T));
        }
    }
}

