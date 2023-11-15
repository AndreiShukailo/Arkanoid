using UnityEngine;

namespace App.Scripts.Infrastructure.PackManagement
{
    [CreateAssetMenu(fileName = "Pack", menuName = "App/Resources/Level Pack")]
    public class Pack : ScriptableObject
    {
        public Sprite Icon;
        public string Key;
        public int LevelsCount;
    }
}