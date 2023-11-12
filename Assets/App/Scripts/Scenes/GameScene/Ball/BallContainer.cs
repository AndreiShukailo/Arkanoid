using System.Collections.Generic;
using App.Scripts.Scenes.GameScene.Ball.Model;

namespace App.Scripts.Scenes.GameScene.Ball
{
    public class BallContainer
    {
        public readonly List<BallModel> Balls = new ();

        public void AddBall(BallModel ballModel)
        {
            Balls.Add(ballModel);
        }

        public void RemoveBall(BallModel ballModel)
        {
            Balls.Remove(ballModel);
            ballModel.Remove();
        }

        public void Cleanup()
        {
            foreach (var ballModel in Balls) 
                ballModel.Remove();
            
            Balls.Clear();
        }
    }
}