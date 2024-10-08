using PlayerData;
using UnityEngine;

namespace GameControllers.Components
{
    public struct CoinComponent
    {
        [HideInInspector] public int CurrentCoins => PlayerPrefs.GetInt(PlayerDataKeys.CoinsKey);
    }
}

