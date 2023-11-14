using UnityEngine;

namespace App.Scripts.Libs.AssetProvider
{
    public class ScriptableObjectDataProvider
    {
        public TObject Load<TObject>(string path) where TObject : ScriptableObject
        {
            return Resources.Load<TObject>(path);
        }
    }
}