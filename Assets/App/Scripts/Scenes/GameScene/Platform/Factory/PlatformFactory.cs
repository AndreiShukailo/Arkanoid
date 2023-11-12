using App.Scripts.Libs.Factory;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Input;
using App.Scripts.Scenes.GameScene.Platform.Model;
using App.Scripts.Scenes.GameScene.Platform.View;

namespace App.Scripts.Scenes.GameScene.Platform.Factory
{
    public class PlatformFactory : IFactory<PlatformModel, PlatformSpawnContext>
    {
        private readonly PoolProviderMono<PlatformView> _poolProvider;
        private InputSystem _input;

        public PlatformFactory(PoolSetting<PlatformView> poolSetting, InputSystem inputSystem)
        {
            _poolProvider = new PoolProviderMono<PlatformView>(poolSetting);
            _input = inputSystem;
        }

        public PlatformModel Create(PlatformSpawnContext context)
        {
            var platformView = _poolProvider.ObjectPool.Spawn();
            platformView.Construct(context.Position);

            return new PlatformModel(platformView, context.StartSpeed, _input);
        }
    }
}