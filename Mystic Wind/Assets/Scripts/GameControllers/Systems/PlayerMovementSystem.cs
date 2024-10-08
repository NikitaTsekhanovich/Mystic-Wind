using GameControllers.Components;
using GameControllers.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, ModelComponent, MovableComponent, DirectionComponent> _movableFilter = null;

        private float angle;

        public void Run()
        {
            foreach (var i in _movableFilter)
            {
                ref var modelComponent = ref _movableFilter.Get2(i);
                ref var movableComponent = ref _movableFilter.Get3(i);
                ref var directionComponent = ref _movableFilter.Get4(i);

                ref var radius = ref directionComponent.Radius;
                ref var isClick = ref directionComponent.IsClick;
                ref var speed = ref movableComponent.Speed;
                ref var transform = ref modelComponent.ModelTransform;

                if (isClick)
                    Movement(speed, radius, transform);
            }
        }

        private void Movement(float speed, float radius, Transform transform)
        {
            angle += speed * Time.deltaTime;

            var x = Mathf.Cos(angle) * radius;
            var y = Mathf.Sin(angle) * radius;

            RotatePlayer(transform);

            transform.position = new Vector2(x, y);
        }

        private void RotatePlayer(Transform transform)
        {
            float rotateAngle;

            if (transform.position.x < 0)
                rotateAngle = Vector3.Angle(transform.position, new Vector2(0, 1));
            else 
                rotateAngle = 0 - Vector3.Angle(transform.position, new Vector2(0, 1));

            transform.rotation = Quaternion.Euler(0, 0, 90 + rotateAngle);
        }
    }
}

