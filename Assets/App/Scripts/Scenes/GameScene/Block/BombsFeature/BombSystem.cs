using App.Scripts.Libs.Components;
using App.Scripts.Libs.Coroutine;

namespace App.Scripts.Scenes.GameScene.Block.BombsFeature
{
    public class BombSystem : ComponentSystem<BombComponent>
    {
        private readonly CommandBombBlocks _commandBombBlocks;
        private readonly ICoroutineRunner _coroutineRunner;

        public BombSystem(CommandBombBlocks commandBombBlocks, ICoroutineRunner coroutineRunner)
        {
            _commandBombBlocks = commandBombBlocks;
            _coroutineRunner = coroutineRunner;
        }

        public override void OnUpdate(BombComponent component)
        {
            base.OnUpdate(component);
            component.ComponentContainer.AddToSystem<DeathComponent>();
            Remove(component);
            _coroutineRunner.StartCoroutine(_commandBombBlocks.Process(component));
        }
    }
}