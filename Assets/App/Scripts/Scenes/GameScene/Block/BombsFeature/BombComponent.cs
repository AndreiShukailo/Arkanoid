using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.BombsFeature.BlocksGetter;
using App.Scripts.Scenes.GameScene.Block.BombsFeature.Info;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Block.BombsFeature
{
    public class BombComponent : Component
    {
        public int Damage => _damage;
        public CellComponent CellComponent => _cellComponent;
        public IBlocksGetter BlocksGetter => _blocksGetter;
        public IBlockDestroyPathInfo BlockDestroyPathInfo => _blockDestroyPathInfo;
        
        [SerializeField] private CellComponent _cellComponent;
        [SerializeReference] private IBlocksGetter _blocksGetter;
        [SerializeReference] private IBlockDestroyPathInfo _blockDestroyPathInfo;
        [SerializeField] private int _damage = 4;
    }
}