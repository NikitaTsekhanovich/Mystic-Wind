using GameControllers.Components;
using GameControllers.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class EnemyMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EnemyTag, ModelComponent, MovableComponent, MovableByPointComponent> _movementFilter = null;
 
        public void Run()
        {
            foreach (var i in _movementFilter)
            {
                ref var modelComponent = ref _movementFilter.Get2(i);
                ref var movableComponent = ref _movementFilter.Get3(i);
                ref var movableByPointComponent = ref _movementFilter.Get4(i);

                ref var speed = ref movableComponent.Speed;
                ref var vector = ref modelComponent.ModelTransform;
                ref var directionPoint = ref movableByPointComponent.DirectionPoint;

                DoMoveToPoint(vector, speed, directionPoint);
            }
        }

        private void DoMoveToPoint(Transform currentPosition, float speed, Transform directionPoint)
        {
            currentPosition.position = Vector2.Lerp(currentPosition.position, directionPoint.position, Time.deltaTime  * speed);
        }
    }
}

