using Coffee.Data;
using UnityEngine;

namespace Coffee.Ability
{
    public class AutoclickerAbility : AbilityBase
    {
        private int _levelIndex;
        private float _currentTime;
        private EspressoData _currentData;
        
        public override void AddAbility()
        {
            _levelIndex++;
            _currentData = itemDataList[_levelIndex - 1] as EspressoData;
        }
        
        protected override void RunAbility()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _currentData.IncrementTime)
            {
                _currentTime = 0f;
                clickerManager.AddPointPerSecond(_currentData.CoffeePoint);
            }
        }
    }
}