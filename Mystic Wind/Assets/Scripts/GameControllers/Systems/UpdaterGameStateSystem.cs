using GameControllers.Components;
using GameControllers.DataGames;
using GameControllers.MonoBehHandlers;
using GameControllers.MonoBehHandlers.UIControllers;
using Leopotam.Ecs;
using LevelsControllers;
using UnityEngine;

namespace GameControllers.Systems
{
    public class UpdaterGameStateSystem : IEcsRunSystem
    {
        private UIContainer _uiContainer;
        private SoundsContainer _soundsContainer;
        private LevelData _levelData;
        private RuntimeData _runtimeData;
        private readonly EcsFilter<UpdaterGameStateComponent> _updaterGameStateFilter = null;

        public void Run()
        {
            foreach (var i in _updaterGameStateFilter)
            {
                ref var entity = ref _updaterGameStateFilter.GetEntity(i);

                _soundsContainer.EndGameSound.Play();

                _uiContainer.EndGameScreen.ShowEndScreen(
                    _runtimeData.CurrentResult,
                    _runtimeData.FirstStarOpen,
                    _runtimeData.SecondStarOpen,
                    _runtimeData.ThirdStarOpen,
                    _levelData.Index);

                entity.Del<UpdaterGameStateComponent>();
            }
        }
    }
}

