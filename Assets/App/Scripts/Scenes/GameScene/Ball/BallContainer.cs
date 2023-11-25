using System.Collections.Generic;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Ball.Components;

namespace App.Scripts.Scenes.GameScene.Ball
{
    public class BallContainer
    {
        public readonly List<ComponentContainer> Balls = new ();

        public void AddBall(ComponentContainer ballModel)
        {
            Balls.Add(ballModel);
        }

        public void RemoveBall(ComponentContainer ballModel)
        {
            Balls.Remove(ballModel);
            ballModel.Remove();
        }

        public void SetFireBall(bool isFire)
        {
            foreach (var ball in Balls)
            {
                var ballComponent = ball.Get<BallComponent>();
                ballComponent.SetFire(isFire);
            }
        }

        public void SetSpeedFactor(float factor)
        {
            foreach (var ball in Balls)
            {
                var moving = ball.Get<MovingComponent>();
                moving.SetSpeedFactor(factor);
            }
        }

        public void Cleanup()
        {
            foreach (var ballModel in Balls) 
                ballModel.Remove();
            
            Balls.Clear();
        }
    }
}