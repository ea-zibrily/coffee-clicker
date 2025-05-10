using UnityEngine;
using TMPro;
using NaughtyAttributes;

namespace Coffee.Gameplay
{
    public class ClickerManager : MonoBehaviour
    {
        #region Fields & Properties

        [Header("Stats")] 
        [SerializeField] [ReadOnly] private int currentCoffee;
        
        private int _coffeeAllTime;
        private int _coffeePerSecond;
        
        public int IncrementPoint { get; set; }
        public int CurrentCoffee => currentCoffee;
        
        [Header("UI")] 
        [SerializeField] private TextMeshProUGUI coffeeTextUI;
        [SerializeField] private TextMeshProUGUI coffeeAllTimeTextUI;
        [SerializeField] private TextMeshProUGUI coffeePerClickTextUI;
        [SerializeField] private TextMeshProUGUI coffeePerSecondTextUI;
        
        #endregion
        
        #region Methods
        
        // Unity Callbacks
        private void Update()
        {
            ModifyPointText();
        }
        
        /// <summary>
        /// Menambahkan point saat object coffee di-klik.
        /// </summary>
        /// <param name="value"></param>
        public void AddPoint()
        {
            currentCoffee += 1 + IncrementPoint;
            _coffeeAllTime += 1 + IncrementPoint;
        }

        /// <summary>
        /// Menambahkan point dengan jumlah tertentu secara langsung.
        /// </summary>
        /// <param name="value">berisi point yang akan ditambah</param>
        public void AddPointDirectly(int value)
        {
            currentCoffee += value;
            _coffeeAllTime += value;
        }
        
        /// <summary>
        /// Menambahkan point saat ability autoclick dihidupkan.
        /// </summary>
        /// <param name="value">point yang akan ditambah</param>
        public void AddPointPerSecond(int value)
        {
            currentCoffee += value + IncrementPoint;
            
            _coffeePerSecond += value;
            _coffeeAllTime += value + IncrementPoint;
        }
        
        /// <summary>
        /// Mengurangi point saat player akan membeli item.
        /// </summary>
        /// <param name="value">point yang akan ditambah</param>
        public void RemovePoint(int value)
        {
            if (currentCoffee < value) return;
            currentCoffee -= value;
        }
        
        private void ModifyPointText()
        {
            coffeeTextUI.text = currentCoffee.ToString();
            
            coffeeAllTimeTextUI.text = "Coffee All Time: " + _coffeeAllTime;
            coffeePerClickTextUI.text = "Coffee Per Click: " + (1 + IncrementPoint);
            coffeePerSecondTextUI.text = "Coffee Per Click: " + _coffeePerSecond;
        }
        
        #endregion
    }
}