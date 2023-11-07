using App.Scripts.Infrastructure.Collider;
using App.Scripts.Scenes.GameScene.Block.Model;

namespace App.Scripts.Scenes.GameScene.Block
{
    public class BlockCollideStrategy : ICollideStrategy<BlockModel>
    {
        private BlockModel _model;

        public void OnAddStrategy(BlockModel model)
        {
            _model = model;
        }

        public void OnCollide()
        {
            _model.Remove();
        }
    }
}