using App.Scripts.Scenes.GameScene.Block.Cracks.Container;
using App.Scripts.Scenes.GameScene.Block.Model;

namespace App.Scripts.Scenes.GameScene.Block.Cracks
{
    public class CrackCreator : ICrackCreator
    {
        private readonly CrackContainer _crackContainer;

        public CrackCreator(CrackContainer crackContainer)
        {
            _crackContainer = crackContainer;
        }

        public void CreateCrack(BlockModel blockModel, int health)
        {
            var factory = _crackContainer.GetCrackFactory(health);
            factory.Create(blockModel);
        }
    }
}