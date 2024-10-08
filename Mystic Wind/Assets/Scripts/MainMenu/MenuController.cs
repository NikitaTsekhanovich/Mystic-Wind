using System;
using StoreSkinsContrllers;
using UnityEngine;

namespace MainMenu
{
    public class MenuController : MonoBehaviour
    {
        public static Action<StoreSkinData> OnStashSkinData;

        public void StartGame()
        {
            OnStashSkinData.Invoke(SkinsDataContainer.SkinsData[PlayerPrefs.GetInt(StateStoreItemDataKeys.IndexChosenItemKey)]);
            LoadingScreenController.Instance.ChangeScene("Levels");
        }
    }
}

