using GameControllers.Components;
using GameControllers.MonoBehHandlers;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class DamageSystem : IEcsRunSystem
    {
        private SoundsContainer _soundsContainer;
        private EcsWorld _world;
        private readonly EcsFilter<DamageComponent> _damageFilter;

        public void Run()
        {
            foreach (var i in _damageFilter)
            {
                ref var entity = ref _damageFilter.GetEntity(i);
                ref var damageComponent = ref _damageFilter.Get1(i);
                ref var canDealDamage = ref damageComponent.CanDealDamage;

                if (canDealDamage)
                {
                    _soundsContainer.EnemyAttackSound.Play();
                    _world.NewEntity().Get<UpdaterGameStateComponent>();
                }

                entity.Del<DamageComponent>();
            }
        }
    }
}

