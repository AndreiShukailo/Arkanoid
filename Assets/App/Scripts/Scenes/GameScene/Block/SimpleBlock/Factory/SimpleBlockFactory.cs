using App.Scripts.Libs.Components;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.Factory;
using App.Scripts.Scenes.GameScene.Block.SimpleBlock.Components;

namespace App.Scripts.Scenes.GameScene.Block.SimpleBlock.Factory
{
    public class SimpleBlockFactory : BlockFactory
    {
        public SimpleBlockFactory(PoolSetting<ComponentContainer> poolSetting, SystemsContainer systemsContainer) :
            base(poolSetting, systemsContainer)
        {
        }

        protected override void BuildComponentContainer(ComponentContainer componentContainer)
        {
            componentContainer.Get<HealthViewComponent>().Construct();
            componentContainer.AddToSystem<HealthComponent>();
        }
    }
}