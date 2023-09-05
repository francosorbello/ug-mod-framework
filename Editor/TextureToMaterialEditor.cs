using UnityEngine;
using UnityEditor;
using System;

namespace francosorbello.ugmodframework.Editor
{    
    /// <summary>
    /// Crea un material a partir de una textura.
    /// </summary>
    public class TextureToMaterialEditor
    {
        [MenuItem("Assets/Tools/Create Material from Texture")]
        public static void CreateMaterialFromTexture()
        {
            var selectedTexture = Selection.activeObject;
            if(selectedTexture.GetType() != typeof(Texture2D))
            {
                Debug.LogError("Make sure you are selecting a texture to use this option.");
                return;
            }

            Material newMaterial = new Material(Shader.Find("Standard"));
            newMaterial.mainTexture = (Texture2D) selectedTexture;
            newMaterial.SetFloat("_Glossiness",0.0f);
        
            string path = String.Format("{0}/mat_{1}.mat",GetMaterialsFolder(selectedTexture),GetTextureName((Texture2D)selectedTexture));
            AssetDatabase.CreateAsset(newMaterial,path);
        }
        
        /// <summary>
        /// Obtiene el nombre de una texture. Remueve el prefijo "tex_" en caso de encontrarlo.
        /// </summary>
        /// <param name="texture"> Textura de la que se extrae el nombre. </param> 
        /// <returns> Nombre de la textura sin prefijo.</returns>
        private static string GetTextureName(Texture2D texture)
        {
            string finalName = "";
            string texName = texture.name;

            var splitedIndex = texName.IndexOf('_');
            if( splitedIndex!=-1 )
            {
                string prefix = "";
                for (int i = 0; i < splitedIndex; i++)
                {
                    prefix += texName[i];
                }

                if(prefix == "tex")
                {
                    for (int i = splitedIndex+1; i < texName.Length; i++)
                    {
                        finalName += texName[i];
                    }
                } else {
                    finalName = texName;
                }
            }
            return finalName;
        }

        /// <summary>
        /// Retorna la carpeta donde guardar el material, usando la ubicacion de la textura como referencia.
        /// </summary>
        private static string GetMaterialsFolder(UnityEngine.Object texture)
        {
            string finalPath = "";
            string texturePath = AssetDatabase.GetAssetPath(texture);
            int lastSlashIndex = texturePath.LastIndexOf('/'); 

            for (int i = 0; i < lastSlashIndex; i++)
            {
                finalPath += texturePath[i];
            }

            return finalPath;
        }
    }
}
