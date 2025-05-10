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
        /// <summary>
        /// Memanggil array data item berdasarkan nama item.
        /// </summary>
        /// <param name="itemName">target nama item yang diinginkan</param>
        public ItemData[] GetItemDatas(ItemName itemName)
        {
            var datas = FindItemDatas(itemName);
            if (datas == null)
            {
                Debug.LogWarning($"Item data for '{itemName}' not found!");
            }

            return datas;
        }
        
        /// <summary>
        /// Mencari array data item berdasarkan nama item.
        /// Dikarenakan ItemContainer merupakan struct, maka dilakukan secara manual
        /// menggunakan loop-foreach.
        /// </summary>
        /// <param name="itemName">target nama item yang diinginkan</param>
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
