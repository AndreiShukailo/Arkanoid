using App.Scripts.Libs.StateMachine;

namespace App.Scripts.Infrastructure.States
{
    public class CommandChangeState
    {
        private GameStateMachine _gameStateMachine;

        public void AddStateMachine(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void ChangeState<TState>()
        {
            _gameStateMachine?.ChangeState<TState>();
            _gameStateMachine?.Update();
        }
    }
}