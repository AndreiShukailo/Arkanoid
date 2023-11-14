using System;
using System.Collections.Generic;

namespace App.Scripts.Infrastructure.SaveLoad.SaveLoadService
{
    [Serializable]
    public class PlayerProgress : Progress
    {
        public PackInfo LastPack = new(1, 1);
        public List<PackInfo> CompletedPacks = new();
    }

    public class PackInfo
    {
        public int PackId;
        public int LastLevel;

        public PackInfo(int packId, int lastLevel)
        {
            PackId = packId;
            LastLevel = lastLevel;
        }
    }
}