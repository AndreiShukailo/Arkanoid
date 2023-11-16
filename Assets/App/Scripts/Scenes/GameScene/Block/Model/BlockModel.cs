using System;
using App.Scripts.Infrastructure.Collider;
using App.Scripts.Scenes.GameScene.Block.View;
using App.Scripts.Scenes.GameScene.Level.Level;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Block.Model
{
    public class BlockModel : ICollidedModel
    {
        public Action<BlockModel> OnRemove;
        public BlockView BlockView => _blockView;

        private readonly BlockView _blockView;
        private readonly ICollideStrategy<BlockModel> _collideStrategy;
        private readonly LevelModel _levelModel;

        public BlockModel(BlockView blockView, ICollideStrategy<BlockModel> collideStrategy,
            LevelModel levelModel)
        {
            _blockView = blockView;
            _collideStrategy = collideStrategy;
            _levelModel = levelModel;
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
            OnRemove?.Invoke(this);
        }
    }
}