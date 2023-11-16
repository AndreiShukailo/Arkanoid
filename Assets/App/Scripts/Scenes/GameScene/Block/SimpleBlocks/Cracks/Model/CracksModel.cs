using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.View;

namespace App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.Model
{
    public class CracksModel
    {
        private readonly CrackView _crackView;
        private readonly BlockModel _blockModel;

        public CracksModel(CrackView crackView, BlockModel blockModel)
        {
            _crackView = crackView;
            _blockModel = blockModel;
            _blockModel.OnRemove += Remove;
        }

        public void Remove()
        {
            _crackView.Remove();
            _blockModel.OnRemove -= Remove;
        }
    }
}