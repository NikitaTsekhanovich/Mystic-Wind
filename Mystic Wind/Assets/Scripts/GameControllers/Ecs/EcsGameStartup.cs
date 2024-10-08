using GameControllers.DataGames;
using GameControllers.MonoBehHandlers;
using GameControllers.MonoBehHandlers.UIControllers;
using GameControllers.Systems;
using Leopotam.Ecs;
using LevelsControllers;
using StoreSkinsContrllers;
using UnityEngine;
using Voody.UniLeo;

namespace GameControllers.Ecs
{
    public sealed class EcsGameStartup : MonoBehaviour
    {
        [SerializeField] private UIContainer _uiContainer;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private SoundsContainer _soundsContainer;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void OnEnable()
        {
            SceneDataLoader.OnInitEcsWorld += InitEcsWorld;
        }

        private void OnDisable()
        {
            SceneDataLoader.OnInitEcsWorld -= InitEcsWorld;
        }

        public void InitEcsWorld(StoreSkinData skinData, LevelData levelData)
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            var runtimeData = new RuntimeData();

            _systems.ConvertScene();

            AddInjections(skinData, levelData, runtimeData);
            AddOneFrames();
            AddSystems();

            _systems.Init();
        }

        private void AddInjections(StoreSkinData skinData, LevelData levelData, RuntimeData runtimeData)
        {
            _systems
                .Inject(_soundsContainer)
                .Inject(runtimeData)
                .Inject(skinData)
                .Inject(levelData)
                .Inject(_sceneData)
                .Inject(_uiContainer);
        }

        private void AddSystems()
        {
            _systems
                .Add(new LoadLevelDataSystem())
                .Add(new LoaderPlayerSkinsSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerMovementSystem())
                .Add(new SpawnSystem())
                .Add(new EntityInitializeSystem())
                .Add(new EnemyMovementSystem())
                .Add(new EnemyRotateSystem())
                .Add(new DamageSystem())
                .Add(new UpdaterScoreSystem())
                .Add(new UpdaterCoinSystem())
                .Add(new DestroySystem())
                .Add(new UpdaterGameStateSystem());
        }

        private void AddOneFrames()
        {
 
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null) return;

            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}
