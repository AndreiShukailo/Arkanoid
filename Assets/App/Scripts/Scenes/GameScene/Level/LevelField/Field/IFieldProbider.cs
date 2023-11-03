using App.Scripts.Scenes.Game.Level.LevelField.Config;

namespace App.Scripts.Scenes.Game.Level.LevelField.Field
{
    public interface IFieldProvider
    {
        public FieldInfo CreateField(LevelFieldConfig levelFieldConfig);
    }
}