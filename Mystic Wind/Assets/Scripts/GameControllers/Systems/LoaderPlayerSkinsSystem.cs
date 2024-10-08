using GameControllers.Components;
using Leopotam.Ecs;
using StoreSkinsContrllers;
using UnityEngine;

namespace GameControllers.Systems
{
    public class LoaderPlayerSkinsSystem : IEcsInitSystem
    {
        private StoreSkinData _skinData;
        private readonly EcsFilter<LoaderPlayerSkinsComponent> _loaderPlayerSkinsFilter = null;

        public void Init()
        {
            foreach (var i in _loaderPlayerSkinsFilter)
            {
                ref var loaderPlayerSkinsComponent = ref _loaderPlayerSkinsFilter.Get1(i);
                ref var playerSkin = ref loaderPlayerSkinsComponent.PlayerSkin;

                playerSkin.sprite = _skinData.CharacterImage;
            }
        }
    }
}

