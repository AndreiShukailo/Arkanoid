using App.Scripts.Scenes.Game.Level.LevelField.Config;

namespace App.Scripts.Scenes.Game.Level.LevelField
{
    public interface IFieldProvider
    {
        public FieldInfo CreateField(LevelFieldConfig levelFieldConfig);
    }
}