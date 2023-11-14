namespace App.Scripts.Infrastructure.SaveLoad.SaveLoadService
{
    public interface ISaveLoadService
    {
        public TProgress Load<TProgress>() where TProgress : Progress;
        public void Save<TProgress>(TProgress progress) where TProgress : Progress;
    }
}