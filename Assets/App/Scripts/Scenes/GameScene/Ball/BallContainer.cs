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

        public void LeftOneBall()
        {
            if(Balls.Count < 2) return;

            for (int i = Balls.Count - 1 ; i >= 1; i--)
            {
                Balls[i].Remove();
                Balls.Remove(Balls[i]);
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