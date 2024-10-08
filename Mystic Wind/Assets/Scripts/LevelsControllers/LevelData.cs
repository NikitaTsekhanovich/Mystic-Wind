using System.Collections.Generic;
using UnityEngine;

namespace LevelsControllers
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Levels data/ Level")]
    public class LevelData : ScriptableObject
    {
        [Header("Level info")]
        [SerializeField] private int _index;
        [SerializeField] private Sprite _background;
        [SerializeField] private int _starsToOpenLevel;
        [Header("Bubble info")]
        [SerializeField] private GameObject _bubblePrefab;
        [SerializeField] private int _amountBubble;
        [SerializeField] private List<Transform> _spawnPoinsBubble = new();
        [SerializeField] private float _delaySpawnBubble;
        [Header("Enemy info")]
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _amountEnemy;
        [SerializeField] private List<Transform> _spawnPoinsEnemy = new(); 
        [SerializeField] private float _delaySpawnEnemy;       

        public int Index => _index;
        public Sprite Background => _background;
        public int StarsToOpenLevel => _starsToOpenLevel;
        public GameObject BubblePrefab => _bubblePrefab;
        public int AmountBubble => _amountBubble;
        public List<Transform> SpawnPoinsBubble => _spawnPoinsBubble;
        public float DelaySpawnBubble => _delaySpawnBubble;
        public GameObject EnemyPrefab => _enemyPrefab;
        public int AmountEnemy => _amountEnemy;
        public List<Transform> SpawnPoinsEnemy => _spawnPoinsEnemy;
        public float DelaySpawnEnemy => _delaySpawnEnemy;   
        public TypeStateObject TypeStateLevel 
        {
            get
            {
                if (_starsToOpenLevel - PlayerPrefs.GetInt(LevelDataKeys.AmountStarsKey) <= 0)
                    return TypeStateObject.IsOpen;

                return PlayerPrefs.GetInt($"{LevelDataKeys.LevelOpenKey}{_index}") == (int)TypeStateObject.IsClosed ? 
                    TypeStateObject.IsClosed : TypeStateObject.IsOpen;
            }
        }
        public TypeStateObject TypeStateFirstStar
        {
            get
            {
                return PlayerPrefs.GetInt($"{LevelDataKeys.FirstStarOpenKey}{_index}") == (int)TypeStateObject.IsClosed ? 
                    TypeStateObject.IsClosed : TypeStateObject.IsOpen;
            }
        }
        public TypeStateObject TypeStateSecondStar
        {
            get
            {
                return PlayerPrefs.GetInt($"{LevelDataKeys.SecondStarOpenKey}{_index}") == (int)TypeStateObject.IsClosed ? 
                    TypeStateObject.IsClosed : TypeStateObject.IsOpen;
            }
        }
        public TypeStateObject TypeStateThirdStar
        {
            get
            {
                return PlayerPrefs.GetInt($"{LevelDataKeys.ThirdStarOpenKey}{_index}") == (int)TypeStateObject.IsClosed ? 
                    TypeStateObject.IsClosed : TypeStateObject.IsOpen;
            }
        }
    }
}

