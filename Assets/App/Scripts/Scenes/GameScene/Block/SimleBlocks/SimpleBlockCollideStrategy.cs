using App.Scripts.Infrastructure.Collider;
using App.Scripts.Scenes.GameScene.Block.Cracks;
using App.Scripts.Scenes.GameScene.Block.Model;

namespace App.Scripts.Scenes.GameScene.Block
{
    public class SimpleBlockCollideStrategy : ICollideStrategy<BlockModel>
    {
        private readonly ICrackCreator _crackCreator;
        private BlockModel _model;
        private int _health;

        public SimpleBlockCollideStrategy(ICrackCreator crackCreator, SimpleBlockSettings simpleBlockSettings)
        {
            _crackCreator = crackCreator;
            _health = simpleBlockSettings.StartHealth;
        }

        public void OnAddStrategy(BlockModel model)
        {
            _model = model;
        }

        public void OnCollide()
        {
            _health-= 1;
            if (_health <= 0)
            {
                _model.Remove();
                return;
            }
            
            _crackCreator.CreateCrack(_model, _health);
        }
    }
}