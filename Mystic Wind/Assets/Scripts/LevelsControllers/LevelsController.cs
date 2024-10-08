using System.Collections.Generic;
using MainMenu;
using PlayerData;
using TMPro;
using UnityEngine;

namespace LevelsControllers
{
    public class LevelsController : MonoBehaviour
    {
        [SerializeField] private List<LevelItem> _levelsItems = new();
        [SerializeField] private TMP_Text _currentCoins;

        private void OnEnable()
        {
            SceneDataLoader.OnLoadLevelsData += InitLevelsData;
        }

        private void OnDisable()
        {
            SceneDataLoader.OnLoadLevelsData -= InitLevelsData;
        }

        private void InitLevelsData()
        {
            _currentCoins.text = $"{PlayerPrefs.GetInt(PlayerDataKeys.CoinsKey)}";
            foreach (var levelItem in _levelsItems)
            {
                levelItem.UpdateLevelItemData();
            }
        }

        public void BackToMenu()
        {
            LoadingScreenController.Instance.ChangeScene("Menu");
        }
    }
}

