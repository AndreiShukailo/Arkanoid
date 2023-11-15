using UnityEditor;
using UnityEngine;

namespace App.Scripts.Infrastructure.SaveLoad.Editor
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