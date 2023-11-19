using System;
using System.Collections.Generic;

namespace App.Scripts.Infrastructure.SaveLoad
{
    [Serializable]
    public class PlayerProgress : Progress
    {
        public PackInfo LastPack;
        public List<PackInfo> CompletedPacks;

        public PlayerProgress()
        {
            LastPack = new PackInfo(1, 1);
            CompletedPacks = new List<PackInfo>();
            Key = typeof(PlayerProgress).FullName;
        }
    }

    [Serializable]
    public class PackInfo
    {
        public int PackId;
        public int LastLevel;

        public PackInfo(int packId, int lastLevel)
        {
            PackId = packId;
            LastLevel = lastLevel;
        }

        public PackInfo(PackInfo packInfo)
        {
            PackId = packInfo.PackId;
            LastLevel = packInfo.LastLevel;
        }
    }
}