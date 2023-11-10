using System;
using App.Scripts.Infrastructure.Collider;
using App.Scripts.Scenes.GameScene.Block.View;

namespace App.Scripts.Scenes.GameScene.Block.Model
{
    public class BlockModel : ICollidedModel
    {
        public Action OnRemove;
        public BlockView BlockView => _blockView;
        
        private readonly BlockView _blockView;
        private readonly ICollideStrategy<BlockModel> _collideStrategy;

        public BlockModel(BlockView blockView, ICollideStrategy<BlockModel> collideStrategy)
        {
            _blockView = blockView;
            _collideStrategy = collideStrategy;
            blockView.AddModel(this);
            collideStrategy.OnAddStrategy(this);
        }

        public void OnCollide()
        {
            _collideStrategy.OnCollide();
        }

        public void Remove()
        {
            _blockView.Remove();
            OnRemove?.Invoke();
        }
    }
}