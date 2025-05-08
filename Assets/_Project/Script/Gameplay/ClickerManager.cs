using NaughtyAttributes;
using UnityEngine;
using TMPro;

namespace Coffee.Gameplay
{
    public class ClickerManager : MonoBehaviour
    {
        [Header("Stats")] 
        [SerializeField] private int incrementPoint;
        [SerializeField] [ReadOnly] private int currentCoffee;
        
        private int _coffeeAllTime;
        private int _coffeePerClick;
        private int _coffeePerSecond;
        
        [Header("UI")] 
        [SerializeField] private TextMeshProUGUI coffeeTextUI;
        [SerializeField] private TextMeshProUGUI coffeeAllTimeTextUI;
        [SerializeField] private TextMeshProUGUI coffeePerClickTextUI;
        [SerializeField] private TextMeshProUGUI coffeePerSecondTextUI;

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
    }
}