using System.Collections.Generic;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Libs.Installer
{
    public class MonoContext : MonoBehaviour
    {
        public List<MonoInstaller> Installers = new();
        private readonly List<IInitializable> _initializables = new();
        private readonly List<IUpdatable> _updatables = new();
        
        private void Start()
        {
            Setup();
            foreach (var initializable in _initializables) initializable.Init();
        }

        public void Setup()
        {
            var container = BuildContainer();
            _initializables.AddRange(container.GetServices<IInitializable>());
            _updatables.AddRange(container.GetServices<IUpdatable>());
        }

        private void Update()
        {
            foreach (var updatable in _updatables) updatable.Update();
        }

        private ServiceContainer BuildContainer()
        {
            var container = new ServiceContainer();
            foreach (var installer in Installers) installer.InstallBindings(container);

            return container;
        }
    }
}