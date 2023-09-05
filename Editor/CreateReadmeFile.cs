using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace francosorbello.ugmodframework.Editor
{
    /// <summary>
    /// Creates a README.md file inside the folder the option was selected from.
    /// </summary>
    public class CreateReadmeFile
    {
        [MenuItem("Assets/Tools/Create Readme File")]
        public static void CreateReadme()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "")
            {
                path = "Assets";
            } else if (System.IO.Path.GetExtension(path) != "")
            {
                path = path.Replace(System.IO.Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }

            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/README.md");

            System.IO.File.WriteAllText(assetPathAndName, "");
            AssetDatabase.Refresh();
        }
    }
}

