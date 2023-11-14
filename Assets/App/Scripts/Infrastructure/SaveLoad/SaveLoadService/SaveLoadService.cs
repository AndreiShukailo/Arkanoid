using UnityEngine;

namespace App.Scripts.Infrastructure.SaveLoad.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        public TProgress Load<TProgress>() where TProgress : Progress
        {
            return JsonUtility.FromJson<TProgress>(PlayerPrefs.GetString(typeof(TProgress).FullName));
        }
        
        public void Save<TProgress>(TProgress progress) where TProgress : Progress
        {
            PlayerPrefs.SetString(progress.Key, JsonUtility.ToJson(progress));
        }

    }
}