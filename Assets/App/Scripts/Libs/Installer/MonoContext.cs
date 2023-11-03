using System.Collections.Generic;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Libs.Installer
{
    public abstract class MonoContext : MonoBehaviour
    {
        public List<MonoInstaller> Installers = new();

        protected abstract ServiceContainer CreateContainer();
        protected abstract void Setup();
        
        protected ServiceContainer BuildContainer()
        {
            var container = CreateContainer();
            foreach (var installer in Installers) installer.InstallBindings(container);

            return container;
        }
    }
}