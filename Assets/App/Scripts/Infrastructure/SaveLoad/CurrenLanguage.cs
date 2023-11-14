using System;

namespace App.Scripts.Infrastructure.SaveLoad
{
    [Serializable]
    public class CurrenLanguage : Progress
    {
        public string Language;

        public CurrenLanguage(string language)
        {
            Key = typeof(CurrenLanguage).FullName;
            Language = language;
        }
    }
}