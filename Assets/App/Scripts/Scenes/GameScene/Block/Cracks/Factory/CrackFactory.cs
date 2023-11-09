using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.Breack.Model;
using App.Scripts.Scenes.GameScene.Block.Cracks.View;
using App.Scripts.Scenes.GameScene.Block.Model;

namespace App.Scripts.Scenes.GameScene.Block.Cracks.Factory
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