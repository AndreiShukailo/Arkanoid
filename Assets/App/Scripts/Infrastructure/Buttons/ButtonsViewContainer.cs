using System.Collections.Generic;
using App.Scripts.Infrastructure.Buttons.Factory;
using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts.Infrastructure.Buttons
{
    public class ButtonsViewContainer : MonoBehaviour
    {
        [SerializeField] private List<ButtonPoolSetting> _buttonsPoolSetting;
        [SerializeField] private Canvas _parrent;
        private Dictionary<string, ButtonFactory> _keyButton = new ();

        public void Register()
        {
            var container = CreateContainer();

            foreach (var poolSetting in _buttonsPoolSetting)
            {
                poolSetting.Container = container;
                _keyButton[poolSetting.SpawnableItemMono.ButtonId] = new ButtonFactory(poolSetting);
            }
        }

        public ButtonFactory GetFactory(string key)
        {
            return _keyButton[key];
        }

        private Transform CreateContainer()
        {
            var parent = Instantiate(_parrent);
            parent.worldCamera = Camera.main;
            DontDestroyOnLoad(parent);
            return parent.transform;
        }
    }
}