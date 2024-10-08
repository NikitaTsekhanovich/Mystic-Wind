using System.Collections.Generic;
using PlayerData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StoreSkinsContrllers
{
    public class SkinsStoreController : MonoBehaviour
    {
        [SerializeField] private AudioSource _purchaseSound;
        [SerializeField] private List<Image> _iconsItems = new();
        [SerializeField] private List<TMP_Text> _pricesTextItems = new();
        [SerializeField] private List<Image> _marksItems = new();
        [SerializeField] private List<GameObject> _priceFrames = new();
        [SerializeField] private GameObject _actionBlock;
        [SerializeField] private TMP_Text _actionButtonText;
        [SerializeField] private TMP_Text _currentCoinsText;
        private int _currentCoins;
        private StoreSkinData _currentItem;

        private void OnEnable()
        {   
            SceneDataLoader.OnLoadStoreSkinsData += InitStoreData;
        }

        private void OnDisable()
        {
            SceneDataLoader.OnLoadStoreSkinsData -= InitStoreData;
        }

        private void InitStoreData()
        {
            var index = 0;

            foreach (var skinData in SkinsDataContainer.SkinsData)
            {
                _iconsItems[index].sprite = skinData.CharacterImage;

                if (skinData.TypeState == TypeStateStoreItem.Selected)
                {
                    _marksItems[index].enabled = true;
                    _priceFrames[index].SetActive(false);
                }
                else if (skinData.TypeState == TypeStateStoreItem.Bought)
                {
                    _marksItems[index].enabled = false;
                    _priceFrames[index].SetActive(false);
                }
                else if (skinData.TypeState == TypeStateStoreItem.NotBought) 
                {
                    _marksItems[index].enabled = false;
                    _pricesTextItems[index].text = $"{skinData.Price}";
                }

                index++;
            }

            var coins = PlayerPrefs.GetInt(PlayerDataKeys.CoinsKey);
            _currentCoinsText.text = $"{coins}";
            _currentCoins = coins;
        }

        public void ChooseItem(int index)
        {
            _actionBlock.SetActive(true);
            _currentItem = SkinsDataContainer.SkinsData[index];

            if (SkinsDataContainer.SkinsData[index].TypeState == TypeStateStoreItem.Selected)
            {
                _actionButtonText.text = $"Selected";
            }
            else if (SkinsDataContainer.SkinsData[index].TypeState == TypeStateStoreItem.Bought)
            {
                _actionButtonText.text = $"Select";
            }
            else if (SkinsDataContainer.SkinsData[index].TypeState == TypeStateStoreItem.NotBought) 
            {
                _actionButtonText.text = $"Buy";
            }
        }

        public void BuyOrSelectItem()
        {
            if (_currentItem.TypeState == TypeStateStoreItem.Bought || _currentItem.TypeState == TypeStateStoreItem.Selected)
            {
                SelectItem();
            }
            else if (_currentItem.TypeState == TypeStateStoreItem.NotBought) 
            {
                if (_currentCoins - _currentItem.Price >= 0)
                {
                    _purchaseSound.Play();
                    _currentCoins -= _currentItem.Price;
                    PlayerPrefs.SetInt(PlayerDataKeys.CoinsKey, _currentCoins);
                    _currentCoinsText.text = $"{_currentCoins}";
                    _priceFrames[_currentItem.Index].SetActive(false);
                    SelectItem();
                }
            }
        }

        private void SelectItem()
        {
            _actionButtonText.text = $"Selected";
            var chosenItemIndex = PlayerPrefs.GetInt(StateStoreItemDataKeys.IndexChosenItemKey);
            PlayerPrefs.SetInt($"{StateStoreItemDataKeys.StateItemKey}{chosenItemIndex}", (int)TypeStateStoreItem.Bought);
            _marksItems[chosenItemIndex].enabled = false;
            PlayerPrefs.SetInt(StateStoreItemDataKeys.IndexChosenItemKey, _currentItem.Index);
            _marksItems[_currentItem.Index].enabled = true;
            PlayerPrefs.SetInt($"{StateStoreItemDataKeys.StateItemKey}{_currentItem.Index}", (int)TypeStateStoreItem.Selected);
        }
    }
}

