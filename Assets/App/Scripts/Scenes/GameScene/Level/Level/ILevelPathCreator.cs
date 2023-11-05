namespace App.Scripts.Scenes.GameScene.Level.Level
{
    public interface ILevelPathCreator
    {
        string CreatePath(int packId, int levelId);
    }
}