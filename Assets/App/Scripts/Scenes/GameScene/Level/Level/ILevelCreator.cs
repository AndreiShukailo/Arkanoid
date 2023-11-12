namespace App.Scripts.Scenes.GameScene.Level.Level
{
    public interface ILevelCreator
    {
        LevelModel CreateLevel(int packId, int levelId);
    }
}