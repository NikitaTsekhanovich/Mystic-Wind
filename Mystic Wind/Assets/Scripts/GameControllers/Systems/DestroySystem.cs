using GameControllers.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class DestroySystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private readonly EcsFilter<DestroyableComponent, ModelComponent, TypeObjectComponent> _deathFilter = null;

        public void Run()
        {
            foreach (var i in _deathFilter)
            {
                ref var entity = ref _deathFilter.GetEntity(i);
                ref var destroyableComponent = ref _deathFilter.Get3(i);
                ref var modelComponent = ref _deathFilter.Get2(i);

                ref var type = ref destroyableComponent.Type;

                if (type == DataGames.TypeGameObject.Bubble)
                    _world.NewEntity().Get<UpdaterGameStateComponent>();
                
                Object.Destroy(modelComponent.ModelTransform.gameObject);
                entity.Destroy();
            }
        }
    }
}
