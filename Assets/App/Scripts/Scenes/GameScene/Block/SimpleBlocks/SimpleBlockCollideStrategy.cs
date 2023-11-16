using App.Scripts.Infrastructure.Collider;
using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.Model;

namespace App.Scripts.Scenes.GameScene.Block.SimleBlocks
{
    public class SimpleBlockCollideStrategy : ICollideStrategy<BlockModel>
    {
        private readonly ICrackCreator _crackCreator;
        private readonly float _healthOnCollide;
        
        private BlockModel _model;
        private float _health;
        private CracksModel _currentCrack;

        public SimpleBlockCollideStrategy(ICrackCreator crackCreator, SimpleBlockSettings simpleBlockSettings)
        {
            _crackCreator = crackCreator;
            _health = 1f;
            _healthOnCollide = _health / simpleBlockSettings.StartHealth;
        }

        public void OnAddStrategy(BlockModel model)
        {
            _model = model;
        }

        public void OnCollide()
        {
            _health -= _healthOnCollide;
            if (_health <= 0)
            {
                _model.Remove();
                return;
            }

            SwitchCrack();
        }

        private void SwitchCrack()
        {
            _currentCrack?.Remove(_model);
            _currentCrack = _crackCreator.CreateCrack(_model, _health);
        }
    }
}