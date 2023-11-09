using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.GameScene.Block.Cracks;
using App.Scripts.Scenes.GameScene.Block.Cracks.Container;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class CrackCreatorInstaller : MonoInstaller
    {
        [SerializeField] private CrackContainer _crackContainer;
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var crackCreator = new CrackCreator(_crackContainer);
            serviceContainer.SetService<ICrackCreator, CrackCreator>(crackCreator);
        }
    }
}