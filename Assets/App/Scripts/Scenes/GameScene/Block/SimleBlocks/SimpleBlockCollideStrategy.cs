using App.Scripts.Infrastructure.Collider;
using App.Scripts.Scenes.GameScene.Block.Cracks;
using App.Scripts.Scenes.GameScene.Block.Model;

namespace App.Scripts.Scenes.GameScene.Block
{
    public class SimpleBlockCollideStrategy : ICollideStrategy<BlockModel>
    {
        private readonly ICrackCreator _crackCreator;
        private BlockModel _model;

        public SimpleBlockCollideStrategy(ICrackCreator crackCreator)
        {
            _crackCreator = crackCreator;
        }

        public void OnAddStrategy(BlockModel model)
        {
            _model = model;
        }

        public void OnCollide()
        {
            _model.RemoveHealth();
            if (_model.Health <= 0)
            {
                _model.Remove();
                return;
            }
            
            _crackCreator.CreateCrack(_model);
        }
    }
}