using System.Collections.Generic;
using App.Scripts.Infrastructure.Buttons.Factory;
using UnityEngine;

namespace App.Scripts.Infrastructure.Buttons.Container
{
    public class ButtonsViewContainer : MonoBehaviour
    {
        public Canvas Container => _container;
        [SerializeField] private List<ButtonPoolSetting> _buttonsPoolSetting;
        [SerializeField] private Canvas _parrent;
        private Dictionary<string, ButtonFactory> _keyButton = new ();
        private Canvas _container;

        public void Register()
        {
            _container = CreateContainer();

            foreach (var poolSetting in _buttonsPoolSetting)
            {
                poolSetting.Container = _container.transform;
                _keyButton[poolSetting.SpawnableItemMono.ButtonId] = new ButtonFactory(poolSetting);
            }
        }

        public void UpdateCamera()
        {
            _container.worldCamera = Camera.main;
        }

        public ButtonFactory GetFactory(string key)
        {
            return _keyButton[key];
        }

        private Canvas CreateContainer()
        {
            var parent = Instantiate(_parrent);
            DontDestroyOnLoad(parent);
            return parent;
        }
    }
}