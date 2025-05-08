using UnityEngine;
using TMPro;
using NaughtyAttributes;
using Coffee.UI;

namespace Coffee.Gameplay
{
    public class ClickerManager : MonoBehaviour
    {
        #region Fields & Properties

        [Header("Stats")] 
        [SerializeField] private int incrementPoint;
        [SerializeField] [ReadOnly] private int currentCoffee;
        
        private int _coffeeAllTime;
        private int _coffeePerClick;
        private int _coffeePerSecond;
        
        public int IncrementPoint
        {
            get => incrementPoint;
            set => incrementPoint = value;
        }
        
        public int CurrentCoffee
        {
            get => currentCoffee;
            set => currentCoffee = value;
        }
        
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
        public void AddPoint()
        {
            currentCoffee += incrementPoint;
            _coffeeAllTime += incrementPoint;
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
            coffeePerClickTextUI.text = _coffeePerClick.ToString();
            coffeePerSecondTextUI.text = _coffeePerSecond.ToString();
        }
        
        #endregion
    }
}