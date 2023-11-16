using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.Model;

namespace App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks
{
    public interface ICrackCreator
    {
        CracksModel CreateCrack(BlockModel blockModel, float health);
    }
}