using UnityEngine;
using Leopotam.Ecs;
using GameControllers.Components;
using LevelsControllers;
using MonoBehHandlers;
using System.Collections.Generic;
using GameControllers.MonoBehHandlers;

namespace GameControllers.Systems
{
    sealed class SpawnSystem : IEcsRunSystem, IEcsInitSystem
    {
        private LevelData _levelData;
        private SoundsContainer _soundsContainer;
        private readonly EcsFilter<SpawnerComponent> _spawnerFilter = null;

        public void Init()
        {
            foreach (var i in _spawnerFilter)
            {
                ref var spawnerComponent = ref _spawnerFilter.Get1(i);

                ref var bubblePrefab = ref spawnerComponent.BubblePrefab;
                ref var amountBubble = ref spawnerComponent.AmountBubble;
                ref var spawnPoinsBubble = ref spawnerComponent.SpawnPoinsBubble;
                ref var delaySpawnBubble = ref spawnerComponent.DelaySpawnBubble;
                ref var enemyPrefab = ref spawnerComponent.EnemyPrefab;
                ref var amountEnemy = ref spawnerComponent.AmountEnemy;
                ref var spawnPoinsEnemy = ref spawnerComponent.SpawnPoinsEnemy;
                ref var delaySpawnEnemy = ref spawnerComponent.DelaySpawnEnemy;

                bubblePrefab = _levelData.BubblePrefab;
                amountBubble = _levelData.AmountBubble;
                spawnPoinsBubble = _levelData.SpawnPoinsBubble;
                delaySpawnBubble = _levelData.DelaySpawnBubble;

                if (_levelData.EnemyPrefab != null)
                {
                    enemyPrefab = _levelData.EnemyPrefab;
                    amountEnemy = _levelData.AmountEnemy;
                    spawnPoinsEnemy = _levelData.SpawnPoinsEnemy;
                    delaySpawnEnemy = _levelData.DelaySpawnEnemy;
                }
            }
        }

        public void Run()
        {
            foreach (var i in _spawnerFilter)
            {
                ref var spawnerComponent = ref _spawnerFilter.Get1(i);
                
                ref var bubblePrefab = ref spawnerComponent.BubblePrefab;
                ref var amountBubble = ref spawnerComponent.AmountBubble;
                ref var spawnPoinsBubble = ref spawnerComponent.SpawnPoinsBubble;
                ref var delaySpawnBubble = ref spawnerComponent.DelaySpawnBubble;
                ref var enemyPrefab = ref spawnerComponent.EnemyPrefab;
                ref var amountEnemy = ref spawnerComponent.AmountEnemy;
                ref var spawnPoinsEnemy = ref spawnerComponent.SpawnPoinsEnemy;
                ref var delaySpawnEnemy = ref spawnerComponent.DelaySpawnEnemy;
                ref var timerBubbleSpawn = ref spawnerComponent.TimerBubbleSpawn;
                ref var timerEnemySpawn = ref spawnerComponent.TimerEnemySpawn;

                SpawnObjects(
                    ref timerBubbleSpawn, 
                    ref amountBubble, 
                    ref delaySpawnBubble, 
                    ref spawnPoinsBubble,
                    ref bubblePrefab,
                    _soundsContainer.SpawnBubbleSound);

                SpawnObjects(
                    ref timerEnemySpawn, 
                    ref amountEnemy, 
                    ref delaySpawnEnemy, 
                    ref spawnPoinsEnemy,
                    ref enemyPrefab,
                    _soundsContainer.SpawnEnemySound);
            }
        }

        private void SpawnObjects(
            ref float timer, 
            ref int amountObject, 
            ref float delaySpawn,
            ref List<Transform> spawnPoins,
            ref GameObject prefab,
            AudioSource spawnSound)
        {
            timer -= Time.deltaTime;

            if (timer <= 0 && amountObject > 0)
            {
                timer = delaySpawn;
                amountObject--;

                var randomIndex = Random.Range(0, spawnPoins.Count);
                SpawnerGameObjects.GetInstatinateObject(
                    prefab,
                    spawnPoins[randomIndex],
                    spawnPoins[randomIndex].rotation);
                spawnSound.Play();
            }
        }
    }
}
