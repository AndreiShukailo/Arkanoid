using App.Scripts.Libs.Components;
using UnityEngine;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostAddBall
{
    public class BoostAddBallSystem : BoostSystem<BoostAddBallComponent>
    {
        private readonly LevelController _levelController;
        private readonly IBallCreator _ballCreator;

        public BoostAddBallSystem(LevelController levelController, IBallCreator ballCreator)
        {
            _levelController = levelController;
            _ballCreator = ballCreator;
        }

        protected override void OnUpdateAction()
        {
            
        }

        protected override void OnActivateAction(BoostAddBallComponent component)
        {
            var ball = _ballCreator.CreateBall(component.transform.position);
            var movement = ball.Get<MovingComponent>();
            movement.Rigidbody2D.velocity = GetRandomDirection();
            movement.SetSpeed(_levelController.BallContainer.Balls[0].Get<MovingComponent>().CurrentSpeed);
            _levelController.BallContainer.AddBall(ball);
        }

        protected override void OnDisableBoostAction()
        {
            _levelController.BallContainer.LeftOneBall();
        }

        private Vector3 GetRandomDirection()
        {
            float randomAngle = Random.Range(0f, 360f);
            var randomDirection=   Quaternion.Euler(0f, 0f,randomAngle) * Vector3.one;
            return randomDirection.normalized;
        }
    }
}