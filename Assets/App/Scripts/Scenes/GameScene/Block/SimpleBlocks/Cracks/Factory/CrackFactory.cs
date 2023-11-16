using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.Model;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.View;

namespace App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.Factory
{
    public class CrackFactory : PoolFactory<CracksModel, CrackView, BlockModel>
    {
        public CrackFactory(PoolSetting<CrackView> poolSetting) : base(poolSetting)
        {
        }

        public override CracksModel Create(BlockModel blockModel)
        {
            var crackView = _poolProvider.ObjectPool.Spawn();
            crackView.Construct(blockModel.BlockView.SpriteRenderer);
            return new CracksModel(crackView, blockModel);
        }
    }
}