using System.Threading.Tasks;
using App.Scripts.Infrastructure.TimeManagement;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.Systems;
using UnityEngine;

namespace App.Scripts.Infrastructure.States
{
    public class StateProcessGame : GameState
    {
        private readonly SystemsGroup _gameSystems;
        private readonly TimeManager _timeManager;

        public StateProcessGame(SystemsGroup gameSystems, TimeManager timeManager)
        {
            _gameSystems = gameSystems;
            _timeManager = timeManager;
        }

        public override void OnEnterState()
        {
            _timeManager.SetPause(false);
            _gameSystems.Init();
        }

        public override void Update()
        {
            _gameSystems.Update(Time.deltaTime);
        }

        public override Task OnExitState()
        {
            _gameSystems.Cleanup();
            return Task.CompletedTask;
        }
    }
}