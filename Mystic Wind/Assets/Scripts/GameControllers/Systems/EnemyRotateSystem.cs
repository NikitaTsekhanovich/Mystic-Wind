using GameControllers.Components;
using GameControllers.MonoBehHandlers;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class EnemyRotateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RotetableComponent> _rotateFilter = null;
        private EcsComponentRef<ModelComponent> _enemyModel;
        private SoundsContainer _soundsContainer;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var i in _rotateFilter)
            {
                ref var entity = ref _rotateFilter.GetEntity(i);
                ref var rotetableComponent = ref _rotateFilter.Get1(i);

                _enemyModel = entity.Ref<ModelComponent>();
                _world.NewEntity().Get<UpdaterScoreComponent>();
                _world.NewEntity().Get<UpdaterCoinComponent>();

                DoRotate(rotetableComponent.Transform, _enemyModel.Unref().ModelTransform);

                entity.Del<RotetableComponent>();
            }
        }

        private void DoRotate(Transform playerTransform, Transform modelTransform)
        {
            _soundsContainer.PushBubbleSound.Play();
            modelTransform.rotation = Quaternion.Euler(0, 0, 90f + playerTransform.localEulerAngles.z);
        }
    }
}
