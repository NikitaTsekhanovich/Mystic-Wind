using UnityEngine;
using UnityEngine.UI;

namespace GridExtension
{
    public class LevelsContentSize : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectCanvas;
        [SerializeField] private RectTransform _rectBackground;
        private const int countItems = 4;

        private void Start()
        {
            _rectBackground.sizeDelta = new Vector2(_rectCanvas.rect.width, _rectCanvas.rect.height * countItems);
        }
    }
}
