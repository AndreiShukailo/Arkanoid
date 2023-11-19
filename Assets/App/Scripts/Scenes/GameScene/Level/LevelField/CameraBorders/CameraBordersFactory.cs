using App.Scripts.Libs.Components;
using App.Scripts.Libs.Factory;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.CameraBorders
{
    public class CameraBordersFactory : IFactory<ComponentContainer, ComponentContainer>
    {
        private readonly SystemsContainer _systemsContainer;

        public CameraBordersFactory(SystemsContainer systemsContainer)
        {
            _systemsContainer = systemsContainer;
        }

        public ComponentContainer Create(ComponentContainer componentContainer)
        {
            componentContainer.Register(_systemsContainer);

            return componentContainer;
        }
    }
}