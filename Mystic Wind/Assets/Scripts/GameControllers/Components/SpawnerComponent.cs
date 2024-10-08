using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameControllers.Components
{
    [Serializable]
    public struct SpawnerComponent
    {
        [HideInInspector] public GameObject BubblePrefab;
        [HideInInspector] public int AmountBubble;
        [HideInInspector] public List<Transform> SpawnPoinsBubble;
        [HideInInspector] public float DelaySpawnBubble;
        [HideInInspector] public GameObject EnemyPrefab;
        [HideInInspector] public int AmountEnemy;
        [HideInInspector] public List<Transform> SpawnPoinsEnemy; 
        [HideInInspector] public float DelaySpawnEnemy;
        [HideInInspector] public float TimerBubbleSpawn;
        [HideInInspector] public float TimerEnemySpawn;
    }
}

