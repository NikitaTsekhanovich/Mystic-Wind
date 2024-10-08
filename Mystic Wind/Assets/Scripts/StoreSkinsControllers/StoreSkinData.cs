using UnityEngine;

namespace StoreSkinsContrllers
{
    [CreateAssetMenu(fileName = "StoreSkinData", menuName = "Store skin data/ skin")]
    public class StoreSkinData : ScriptableObject
    {
        [SerializeField] private int _index;
        [SerializeField] private Sprite _characterImage;
        [SerializeField] private int _price;

        public int Index => _index;
        public Sprite CharacterImage => _characterImage;
        public int Price => _price;
        public TypeStateStoreItem TypeState
        {
            get
            {
                return (TypeStateStoreItem)PlayerPrefs.GetInt($"{StateStoreItemDataKeys.StateItemKey}{_index}");
            }
        }
    }
}

