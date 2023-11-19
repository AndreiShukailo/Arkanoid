using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public class TimeManager
    {
        public bool IsPaused { get; private set; }

        public void SetPause(bool isPause)
        {
            IsPaused = isPause;
            Time.timeScale = isPause ? 0 : 1;
        }
    }
}