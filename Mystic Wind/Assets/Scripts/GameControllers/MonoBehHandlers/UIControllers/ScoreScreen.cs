using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.MonoBehHandlers.UIControllers
{
    public class ScoreScreen : Screen
    {
        [SerializeField] private Image _barScore;
        [SerializeField] private List<Image> _fullStart = new();

        public void UpdateScoreBar(float score)
        {
            _barScore.fillAmount = score;
        }

        public void FillStar(int index)
        {
            _fullStart[index].enabled = true;
        }
    }
}

