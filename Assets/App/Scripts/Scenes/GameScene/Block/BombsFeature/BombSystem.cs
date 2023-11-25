using System.Collections.Generic;
using App.Scripts.Libs.Components;
using App.Scripts.Libs.Coroutine;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.BombsFeature
{
    public class BombSystem : ComponentSystem<BombComponent>
    {
        private readonly CommandBombBlocks _commandBombBlocks;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly List<Coroutine> _explosions = new();

        public BombSystem(CommandBombBlocks commandBombBlocks, ICoroutineRunner coroutineRunner)
        {
            _commandBombBlocks = commandBombBlocks;
            _coroutineRunner = coroutineRunner;
        }

        public override void OnUpdate(BombComponent component)
        {
            base.OnUpdate(component);
            component.ComponentContainer.AddToSystem<DeathComponent>();
            _explosions.Add(_coroutineRunner.StartCoroutine(_commandBombBlocks.Process(component)));
        }

        public override void ClearSystem()
        {
            foreach (var explosion in _explosions)
                _coroutineRunner.StopCoroutine(explosion);
        }
    }
}