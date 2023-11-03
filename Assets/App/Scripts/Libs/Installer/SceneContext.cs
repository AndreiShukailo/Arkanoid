using System.Collections.Generic;
using App.Scripts.Libs.ServiceLocator;

namespace App.Scripts.Libs.Installer
{
    public class SceneContext : MonoContext
    {
        private readonly List<IInitializable> _initializables = new();
        private readonly List<IUpdatable> _updatables = new();
        
        private void Start()
        {
            Setup();
            foreach (var initializable in _initializables) initializable.Init();
        }

        protected override ServiceContainer CreateContainer()
        {
            return new ServiceContainer(ProjectContext.Instance.ServiceContainer);
        }

        protected override void Setup()
        {
            var container = BuildContainer();
            _initializables.AddRange(container.GetServices<IInitializable>());
            _updatables.AddRange(container.GetServices<IUpdatable>());
        }

        private void Update()
        {
            foreach (var updatable in _updatables) updatable.Update();
        }
    }
}