using GameControllers.Components;
using GameControllers.DataGames;
using GameControllers.MonoBehHandlers;
using GameControllers.MonoBehHandlers.UIControllers;
using Leopotam.Ecs;
using LevelsControllers;
using UnityEngine;

namespace GameControllers.Systems
{
    public class UpdaterScoreSystem : IEcsRunSystem
    {
        private SoundsContainer _soundsContainer;
        private UIContainer _uiContainer;
        private LevelData _levelData;
        private RuntimeData _runtimeData;
        private readonly EcsFilter<ScoreComponent> _scoreFilter = null;
        private readonly EcsFilter<UpdaterScoreComponent> _updaterScoreFilter = null;

        public void Run()
        {
            foreach (var i in _updaterScoreFilter)
            {
                ref var entity = ref _updaterScoreFilter.GetEntity(i);

                ref var scoreComponent = ref _scoreFilter.Get1(0);
                var maxScore = ScoreComponent.MaxScore;
                ref var currentScore = ref scoreComponent.CurrentScore;

                UpdateScore(maxScore, ref currentScore);

                entity.Del<UpdaterScoreComponent>();
            }
        }

        private void UpdateScore(float maxScore, ref float currentScore)
        {
            currentScore++;
            _runtimeData.CurrentResult = currentScore;
            SetBestScore(currentScore);

            var score = currentScore / maxScore;
            _uiContainer.ScoreScreen.UpdateScoreBar(score);

            if (currentScore >= maxScore && !_runtimeData.ThirdStarOpen)
            {
                _runtimeData.ThirdStarOpen = true;
                _uiContainer.ScoreScreen.FillStar(2);
                SetStarsData(LevelDataKeys.ThirdStarOpenKey);
            }   
            if (currentScore >= maxScore / 1.5f && !_runtimeData.SecondStarOpen)
            {
                _runtimeData.SecondStarOpen = true;
                _uiContainer.ScoreScreen.FillStar(1);
                SetStarsData(LevelDataKeys.SecondStarOpenKey);
            }
            if (currentScore >= maxScore / 3 && !_runtimeData.FirstStarOpen)
            {
                _runtimeData.FirstStarOpen = true;
                _uiContainer.ScoreScreen.FillStar(0);
                SetStarsData(LevelDataKeys.FirstStarOpenKey);
            }
        }

        private void SetStarsData(string starOpenKey)
        {
            _soundsContainer.GetStarSound.Play();

            if (PlayerPrefs.GetInt($"{starOpenKey}{_levelData.Index}") == (int)TypeStateObject.IsClosed)
            {
                var amountStars = PlayerPrefs.GetInt(LevelDataKeys.AmountStarsKey);
                PlayerPrefs.SetInt(LevelDataKeys.AmountStarsKey, amountStars + 1);
                PlayerPrefs.SetInt($"{starOpenKey}{_levelData.Index}", (int)TypeStateObject.IsOpen);
            }
        }

        private void SetBestScore(float currentScore)
        {
            var currentBestScore = PlayerPrefs.GetInt($"{LevelDataKeys.BestScoreKey}{_levelData.Index}");

            if (currentScore > currentBestScore)
            {
                PlayerPrefs.SetInt($"{LevelDataKeys.BestScoreKey}{_levelData.Index}", (int)currentScore);
            }
        }
    }
}

