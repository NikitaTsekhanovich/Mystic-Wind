using System;
using System.Collections.Generic;
using MainMenu;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsControllers
{
    public class LevelItem : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private TMP_Text _starsToOpenLevel;
        [SerializeField] private TMP_Text _numberLevel;
        [SerializeField] private GameObject _frameLockStar;
        [SerializeField] private GameObject _lockPlayButton;
        [SerializeField] private List<Image> _starsImages = new();

        public static Action<LevelData> OnStashLevelData;

        public void UpdateLevelItemData()
        {
            var stateLevel = LevelDataContainer.LevelsData[_index].TypeStateLevel;

            if (stateLevel == TypeStateObject.IsOpen)
            {
                _frameLockStar.SetActive(false);
                _lockPlayButton.SetActive(false);
                _numberLevel.text = $"{_index + 1}";
                UpdateStarsStats();
            }
            else 
            {
                _starsToOpenLevel.text = 
                    $"dial {LevelDataContainer.LevelsData[_index].StarsToOpenLevel - PlayerPrefs.GetInt(LevelDataKeys.AmountStarsKey)} more stars \nto unlock";
                _frameLockStar.SetActive(true);
                _lockPlayButton.SetActive(true);
            }
        }

        private void UpdateStarsStats()
        {
            if (LevelDataContainer.LevelsData[_index].TypeStateFirstStar == TypeStateObject.IsOpen)
            {
                _starsImages[0].enabled = true;
            }
            if (LevelDataContainer.LevelsData[_index].TypeStateSecondStar == TypeStateObject.IsOpen)
            {
                _starsImages[1].enabled = true;
            }
            if (LevelDataContainer.LevelsData[_index].TypeStateThirdStar == TypeStateObject.IsOpen)
            {
                _starsImages[2].enabled = true;
            }
        }

        public void PlayGame()
        {
            OnStashLevelData.Invoke(LevelDataContainer.LevelsData[_index]);
            LoadingScreenController.Instance.ChangeScene("Game");
        }
    }
}

