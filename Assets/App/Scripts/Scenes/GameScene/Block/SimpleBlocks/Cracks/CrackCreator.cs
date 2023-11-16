using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.Container;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.Model;

namespace App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks
{
    public class CrackCreator : ICrackCreator
    {
        private readonly CrackContainer _crackContainer;

        public CrackCreator(CrackContainer crackContainer)
        {
            _crackContainer = crackContainer;
        }

        public CracksModel CreateCrack(BlockModel blockModel, float health)
        {
            var factory = _crackContainer.GetCrackFactory(health);
            return factory?.Create(blockModel);
        }
    }
}