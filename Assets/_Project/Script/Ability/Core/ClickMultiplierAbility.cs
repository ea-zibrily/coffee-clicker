using UnityEngine;
using Coffee.Data;

namespace Coffee.Ability
{
    public class ClickMultiplierAbility : AbilityBase
    {
        private int _levelIndex;
        private BrewData _currentData;
        
        public override void AddAbility()
        {
            _levelIndex++;
            _currentData = itemDataList[_levelIndex - 1] as BrewData;
            
            if (_currentData == null)
            {
                Debug.LogWarning("click multiplier data is null!");
                return;
            } 
            clickerManager.IncrementPoint = _currentData.IncrementalPoint;
        }
    }
}