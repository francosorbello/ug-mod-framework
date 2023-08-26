using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace francosorbello.ugmodframework.Editor
{
    /// <summary>
    /// Instantiates a prefab in the origin of the world.
    /// </summary>
    public class InstanciateInOrigin : MonoBehaviour
    {
        [MenuItem("Assets/Tools/Instantiate Prefab in Origin")]
        public static void DoInstantiateInOrigin()
        {
            var selectedObject = Selection.activeObject;
            Debug.Log(selectedObject.GetType());
            
            if(selectedObject.GetType() == typeof(GameObject))
            {
                GameObject instatiatedPrefab =(GameObject) PrefabUtility.InstantiatePrefab(selectedObject as GameObject);
                instatiatedPrefab.transform.SetPositionAndRotation(Vector3.zero,Quaternion.identity);
            }
        }
    }

}
