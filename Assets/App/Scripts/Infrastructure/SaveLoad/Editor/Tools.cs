using UnityEditor;
using UnityEngine;

namespace App.Scripts.Scenes.Editor
{
    public class Tools
    {
        [MenuItem("Arkanoid/ClearProgress")]
        public static void ClearProgress()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}