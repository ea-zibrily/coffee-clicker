using System;
using UnityEngine;
using Coffee.Data;
using Coffee.Shop;
using Coffee.Pattern.Singleton;

namespace Coffee.Database
{
    public class ItemDatabase : MonoSingleton<ItemDatabase>
    {
        // Struct
        [Serializable]
        private struct ItemContainer
        {
            public ItemName itemName;
            public ItemData[] itemDatas;
        }
        
        // Fields
        [SerializeField] private ItemContainer[] itemContainers;
        
        // Methods
        public ItemData GetItemData(ItemName itemName, int level)
        {
            var datas = FindItemDatas(itemName);
            if (datas == null)
            {
                Debug.LogWarning($"item data for '{itemName}' not found!");
                return null;
            }
            
            if (level < 0 || level >= datas.Length)
            {
                Debug.LogWarning($"requested level {level} is out of range for item '{itemName}'!");
                return null;
            }
            
            return datas[level];
        }
        
        public ItemData[] GetItemDatas(ItemName itemName)
        {
            var datas = FindItemDatas(itemName);
            if (datas == null)
            {
                Debug.LogWarning($"Item data for '{itemName}' not found!");
            }

            return datas;
        }
        
        private ItemData[] FindItemDatas(ItemName itemName)
        {
            foreach (var container in itemContainers)
            {
                if (container.itemName == itemName)
                {
                    return container.itemDatas;
                }
            }
            return null;
        }
    }
}
