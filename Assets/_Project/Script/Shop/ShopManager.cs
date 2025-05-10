using UnityEngine;
using Coffee.Gameplay;

namespace Coffee.Shop
{
    public class ShopManager : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private ItemButtonHandler[] itemHandlers;
        [SerializeField] private ClickerManager clickerManager;
        
        private int _currentIndex;
        
        private void Start()
        {
            // Validate
            if (itemHandlers.Length < 1)
            {
                Debug.LogWarning("item button handler is empty!");
                return;
            }
            
            foreach (var handler in itemHandlers)
            {
                handler.gameObject.SetActive(true);
            }
        }
        
        /// <summary>
        /// Melakukan pengecekan awal item dalam Shop.
        /// Jika jumlah point sudah mencukupi, maka item akan diaktifkan.
        /// Dilakukan untuk mengurangi looping tiap item button.
        /// </summary>
        private void Update()
        {
            if (_currentIndex >= itemHandlers.Length) return;
            
            var handler = itemHandlers[_currentIndex];
            var itemCost = handler.CurrentData.ItemCost;
            if (clickerManager.CurrentCoffee >= itemCost)
            {
                _currentIndex++;
                handler.ActivateItemButton();
            }
        }
    }
}