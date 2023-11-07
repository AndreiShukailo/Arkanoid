using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.GameScene.Block.Model;

namespace App.Scripts.Scenes.GameScene.Block.Factory
{
    public interface IBlockFactory : IFactory<BlockModel, BlockContext>
    {
    }
}