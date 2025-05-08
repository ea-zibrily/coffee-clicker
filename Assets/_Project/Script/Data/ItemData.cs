using Coffee.Shop;
using UnityEngine;
using UnityEngine.Serialization;

namespace Coffee.Data
{
    public class ItemData : ScriptableObject
    {
        [Header("General")]
        [SerializeField] private ItemName itemName;
        [SerializeField] private string itemEffect;
        [SerializeField] private int itemCost;
        [SerializeField] [TextArea(0, 3)] private string itemDescription;
        
        // Getter
        public ItemName ItemName => itemName;
        public string ItemEffect => itemEffect;
        public int ItemCost => itemCost;
        public string ItemDescription => itemDescription;
    }
}