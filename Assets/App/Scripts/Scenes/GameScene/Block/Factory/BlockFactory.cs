using App.Scripts.Libs.Components;
using App.Scripts.Libs.Pool;

namespace App.Scripts.Scenes.GameScene.Block.Factory
{
    public class BlockFactory: PoolFactory<ComponentContainer, BlockContext>
    {
        private readonly SystemsContainer _systemsContainer;

        public BlockFactory(PoolSetting<ComponentContainer> poolSetting, SystemsContainer systemsContainer) : base(poolSetting)
        {
            _systemsContainer = systemsContainer;
        }

        public override ComponentContainer Create(BlockContext blockContext)
        {
            var componentContainer = _poolProvider.ObjectPool.Spawn();
            componentContainer.transform.position = blockContext.Position;
            componentContainer.Register(_systemsContainer);
            componentContainer.Get<ControlSizeComponent>().Construct(blockContext.Size);
            componentContainer.Get<CellComponent>().Construct(blockContext.GridPosition);

            BuildComponentContainer(componentContainer);
            
            return componentContainer;
        }

        protected virtual void BuildComponentContainer(ComponentContainer componentContainer)
        {
        }
    }
}