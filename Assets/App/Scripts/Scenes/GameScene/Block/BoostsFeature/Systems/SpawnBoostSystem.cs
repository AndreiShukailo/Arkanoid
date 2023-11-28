using System.Collections.Generic;
using App.Scripts.Infrastructure.Effects;
using App.Scripts.Libs.Components;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems
{
    public class SpawnBoostSystem : ComponentSystem<SpawnBoostComponent>
    {
        private Dictionary<string, BoostFactory> _keyFactory = new ();
        private readonly SystemsContainer _systemsContainer;
        private readonly Transform _container;
        private readonly EffectViewFactory _effectViewFactory;


        public SpawnBoostSystem(SystemsContainer systemsContainer, Transform container, EffectViewFactory effectViewFactory)
        {
            _systemsContainer = systemsContainer;
            _container = container;
            _effectViewFactory = effectViewFactory;
        }

        public override void OnUpdate(SpawnBoostComponent component)
        {
            base.OnUpdate(component);
            var boost = CreateBoost(component);
            component.ComponentContainer.AddToSystem<DeathComponent>();
            Remove(component);
            _effectViewFactory.Create(component.transform.position);
            SetDownDirection(boost);
            boost.AddToSystem<DestroyWhenInvisibleComponent>();
        }

        private void SetDownDirection(ComponentContainer component)
        {
            var movingComponent = component.Get<MovingComponent>();
            if (movingComponent == null) return;

            movingComponent.Rigidbody2D.velocity = Vector2.down * movingComponent.CurrentSpeed;
        }
        
        private ComponentContainer CreateBoost(SpawnBoostComponent component)
        {
            return GetBoost(component).Create(component.transform.position);
        }

        private BoostFactory GetBoost(SpawnBoostComponent component)
        {
            var id = component.Boost.ID;
            if (_keyFactory.TryGetValue(id, out var boostFactory)) return boostFactory;

            var newFactory = new BoostFactory(new PoolSetting<ComponentContainer>(_container, component.Boost), _systemsContainer);
            _keyFactory[id] = newFactory;
            return newFactory;
        }
    }
}