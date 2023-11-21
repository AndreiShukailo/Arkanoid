using System;
using System.Globalization;

namespace App.Scripts.Infrastructure.SaveLoad
{
    [Serializable]
    public class PlayerEnergy : Progress
    {
        public int Energy;
        public string LastTime;

        public PlayerEnergy(int maxEnergy, DateTime dateTime)
        {
            Key = typeof(PlayerEnergy).FullName;
            Energy = maxEnergy;
            LastTime = dateTime.ToString(CultureInfo.CurrentCulture);
        }
    }
}