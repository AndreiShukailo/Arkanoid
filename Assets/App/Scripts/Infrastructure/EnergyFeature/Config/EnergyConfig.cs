using System;

namespace App.Scripts.Infrastructure.EnergyFeature
{
    [Serializable]
    public class EnergyConfig
    {
        public int MaxEnergy = 100;
        public int TimeToRecoverInMinutes = 10;
        public int RestartLevelCoast = 30;
        public int VictoryLevelCoast = 40;
        public int HealthCoast = 60;
    }
}