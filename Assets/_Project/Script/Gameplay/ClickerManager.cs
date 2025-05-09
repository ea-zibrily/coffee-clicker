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
        
        // Core
        public void AddPoint(int value = 1)
        {
            currentCoffee += value + IncrementPoint;
            _coffeeAllTime += value + IncrementPoint;
        }

        public void AddPointDirectly(int value = 1)
        {
            currentCoffee += value;
            _coffeeAllTime += value;
        }
        
        public void AddPointPerSecond(int value)
        {
            currentCoffee += value + IncrementPoint;
            
            _coffeePerSecond += value;
            _coffeeAllTime += value + IncrementPoint;
        }
        
        public void RemovePoint(int value)
        {
            if (currentCoffee < value) return;
            currentCoffee -= value;
        }
        
        private void ModifyPointText()
        {
            coffeeTextUI.text = currentCoffee.ToString();
            coffeeAllTimeTextUI.text = _coffeeAllTime.ToString();
            coffeePerClickTextUI.text = IncrementPoint.ToString();
            coffeePerSecondTextUI.text = _coffeePerSecond.ToString();
        }
        
        #endregion
    }
}