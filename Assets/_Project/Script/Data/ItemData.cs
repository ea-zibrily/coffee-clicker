using UnityEngine;
using Coffee.Shop;

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
        
        public string GetItemStringName()
        {
            return itemName switch
            {
                ItemName.Espresso_Express => "Espresso Express",
                ItemName.Brew_Booster => "Brew Booster",
                ItemName.Red_Eye => "Red Eye",
                ItemName.Latte_Surge => "Latte Surge",
                _ => "UNK"
            };
        }
    }
}