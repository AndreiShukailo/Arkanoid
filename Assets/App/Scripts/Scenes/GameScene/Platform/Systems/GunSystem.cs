using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Platform.Components;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform.Systems
{
    public class GunSystem : ComponentSystem<GunComponent>
    {
        private readonly BulletFactory _bulletFactory;
        private const float ShootDelay = 0.3f;
        private float _timer;

        public GunSystem(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public override void OnUpdate(GunComponent component)
        {
            base.OnUpdate(component);
            if(!component.IsActive) return;
            if (_timer >= ShootDelay)
            {
                Shoot(component);
                return;
            }

            _timer += Time.deltaTime;
        }

        private void Shoot(GunComponent gunComponent)
        {
            _timer = 0;
            var speed = gunComponent.Speed;
            CreateBullet(speed, gunComponent.LeftSpawnPoint);
            CreateBullet(speed, gunComponent.RightSpawnPoint);
        }

        private void CreateBullet(float speed, Vector2 position)
        {
            var bullet = _bulletFactory.Create();
            bullet.transform.position = position;
            var movement = bullet.Get<MovingComponent>();
            movement.Rigidbody2D.velocity = Vector2.up;
            movement.SetSpeed(speed);
        }
    }
}