using System;

namespace App.Scripts.Infrastructure.SaveLoad
{
    [Serializable]
    public class CompletedPack
    {
        public string PackKey;
        public int Level;

        public CompletedPack(string packKey, int level)
        {
            PackKey = packKey;
            Level = level;
        }
    }
}