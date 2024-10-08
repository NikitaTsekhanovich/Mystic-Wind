using LevelsControllers;
using MainMenu;
using MusicSystem;
using PlayerData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.MonoBehHandlers.UIControllers
{
    public class EndGameScreen : Screen
    {
        [SerializeField] private TMP_Text _currentResult;
        [SerializeField] private TMP_Text _bestResult;
        [SerializeField] private TMP_Text _currentCoins;
        [SerializeField] private Image _firstStar;
        [SerializeField] private Image _secondStar;
        [SerializeField] private Image _thirdStar;
        [SerializeField] private Image _currentMusicImage;
        [SerializeField] private Image _currentEffectsImage;
        [SerializeField] private Sprite _musicOffImage;
        [SerializeField] private Sprite _effectsOffImage;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _walls;

        private void Start()
        {
            if (PlayerPrefs.GetInt("MusicIsOn") == 1)
                _currentMusicImage.sprite = _musicOffImage;
            if (PlayerPrefs.GetInt("EffectsIsOn") == 1)
                _currentEffectsImage.sprite = _effectsOffImage;
        }

        public void ShowEndScreen(
            float currentResult, 
            bool firstStarOpen,
            bool secondStarOpen,
            bool thirdStarOpen,
            int indexLevel)
        {
            Time.timeScale = 0f;
            _player.SetActive(false);
            _walls.SetActive(false);
            Show();
            UpdateStats(currentResult, firstStarOpen, secondStarOpen, thirdStarOpen, indexLevel);
        }

        private void UpdateStats(
            float currentResult, 
            bool firstStarOpen,
            bool secondStarOpen,
            bool thirdStarOpen,
            int indexLevel)
        {
            _currentResult.text = $"Result {currentResult}";
            _bestResult.text = $"{PlayerPrefs.GetInt($"{LevelDataKeys.BestScoreKey}{indexLevel}")}";
            _currentCoins.text = $"{PlayerPrefs.GetInt(PlayerDataKeys.CoinsKey)}";

            UpdateStarsStats(firstStarOpen, _firstStar);
            UpdateStarsStats(secondStarOpen, _secondStar);
            UpdateStarsStats(thirdStarOpen, _thirdStar);
        }

        private void UpdateStarsStats(bool starOpen, Image star)
        {
            if (starOpen)
            {
                star.enabled = true;
            }
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;
            LoadingScreenController.Instance.ChangeScene("Game");
        }

        public void BackToLevels()
        {
            Time.timeScale = 1f;
            LoadingScreenController.Instance.ChangeScene("Levels");
        }

        public void ChangeMusic()
        {
            MusicController.Instance.ChangeMusicState(_currentMusicImage);
        }

        public void ChangeEffects()
        {
            MusicController.Instance.ChangeEffectsState(_currentEffectsImage);
        }
    }
}

