using GameControllers.Components;
using Leopotam.Ecs;
using PlayerData;
using UnityEngine;

namespace GameControllers.Systems
{
    public class UpdaterCoinSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UpdaterCoinComponent> _updaterCoinFilter = null;
        private readonly EcsFilter<CoinComponent> _coinFilter = null;

        public void Run()
        {
            foreach (var i in _updaterCoinFilter)
            {
                ref var entity = ref _updaterCoinFilter.GetEntity(i);
                ref var coinComponent = ref _coinFilter.Get1(i);
                var currentCoins = coinComponent.CurrentCoins;

                currentCoins++;
                PlayerPrefs.SetInt(PlayerDataKeys.CoinsKey, currentCoins);

                entity.Del<UpdaterCoinComponent>();
            }
        }
    }
}

