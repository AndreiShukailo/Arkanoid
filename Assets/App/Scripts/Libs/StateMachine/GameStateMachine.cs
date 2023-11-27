using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Scripts.Libs.StateMachine
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, GameState> _states = new();
        private GameState _currentState;
        private GameState _stateToChange;
        private Task _changeSwitchState;

        public void AddState(GameState state)
        {
            state.StateMachine = this;
            _states[state.GetType()] = state;
        }

        public void ChangeState<T>()
        {
            var stateType = typeof(T);
            if (_states.TryGetValue(stateType, out var state)) _stateToChange = state;
        }

        public void Update()
        {
            if(_changeSwitchState == null || _changeSwitchState.IsCompleted)
                _changeSwitchState = CheckSwitchState();

            _currentState?.Update();
        }

        private async Task CheckSwitchState()
        {
            if (_stateToChange is null) return;

            var nextState = _stateToChange;
            _stateToChange = null;

            await ProcessChangeState(nextState);
        }

        private async Task ProcessChangeState(GameState value)
        {
            await ExitState();

            _currentState = value;
            _currentState.OnEnterState();
        }

        private async Task ExitState()
        {
            if (_currentState is null) return;

            await _currentState.OnExitState();
        }
    }
}