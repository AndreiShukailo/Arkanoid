using App.Scripts.Scenes.GameScene.Level.LevelField.Config;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.Field
{
    public interface IFieldProvider
    {
        public FieldInfo CreateField(LevelFieldConfig levelFieldConfig);
    }
}