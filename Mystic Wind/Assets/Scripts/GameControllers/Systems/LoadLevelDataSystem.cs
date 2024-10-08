using GameControllers.DataGames;
using Leopotam.Ecs;
using LevelsControllers;

namespace GameControllers.Systems
{
    public class LoadLevelDataSystem : IEcsInitSystem
    {
        private SceneData _sceneData;
        private LevelData _levelData;

        public void Init()
        {
            _sceneData.Background.sprite = _levelData.Background;
        }
    }
}

