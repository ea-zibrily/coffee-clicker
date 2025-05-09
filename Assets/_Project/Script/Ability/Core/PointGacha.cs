using UnityEngine;
using UnityEngine.UI;
using Coffee.Data;

namespace Coffee.Ability
{
    public class PointGacha : AbilityBase
    {
        [Header("UI")] 
        [SerializeField] private Image coffeeImageUI;
        
        private int _levelIndex;
        private int _currentClick;
        private RedData _currentData;
        
        public override void AddAbility()
        {
            _levelIndex++;
            _currentClick = 0;
            _currentData = itemDataList[_levelIndex - 1] as RedData;
        }
        
        protected override void RunAbility()
        {
            base.RunAbility();
            if (_currentClick < _currentData.ClickCount) return;
            
            var earnPoint = Random.Range(_currentData.PointRange[0], _currentData.PointRange[1]);
            coffeeImageUI.sprite = _currentData.CoffeeSprite;
            clickerManager.AddPointDirectly(earnPoint);
            _currentClick = 0;
        }
        
        public void OnCoffeeClick()
        {
            if (!isAbilityApplied) return;
            _currentClick++;
        }
    }
}