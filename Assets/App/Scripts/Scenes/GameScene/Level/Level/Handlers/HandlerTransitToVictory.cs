using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Level.View;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerTransitToVictory : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly ConfettiEffectView _confettiEffectView;
        private readonly SystemsContainer _systemsContainer;
        private const float SpeedStep = 0.5f;

        public HandlerTransitToVictory(LevelController levelController, ConfettiEffectView confettiEffectView,
            SystemsContainer systemsContainer)
        {
            _levelController = levelController;
            _confettiEffectView = confettiEffectView;
            _systemsContainer = systemsContainer;
        }

        public async Task Process()
        {
            _systemsContainer.CleanupSystems();
            _confettiEffectView.PlayEffect();
            _levelController.Platform.Get<MovingComponent>().SetSpeed(0);
            await SlowDownBalls();
            _confettiEffectView.StopEffect();
        }

        private async Task SlowDownBalls()
        {
            var currentSpeed = _levelController.BallContainer.Balls[0].Get<MovingComponent>().CurrentSpeed;
            while (currentSpeed > 0)
            {
                await Task.Delay(50);
                currentSpeed -= SpeedStep;
                foreach (var ball in _levelController.BallContainer.Balls)
                    ball.Get<MovingComponent>().SetSpeed(currentSpeed);
            }
        }
    }
}