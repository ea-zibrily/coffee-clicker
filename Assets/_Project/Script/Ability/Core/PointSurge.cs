using UnityEngine;
using Coffee.Data;

namespace Coffee.Ability
{
    public class PointSurge : AbilityBase
    {
        private LatteData _currentData;
        
        public override void AddAbility()
        {
            _currentData = itemDataList[0] as LatteData;
            
            if (_currentData == null)
            {
                Debug.LogWarning("point surge data is null!");
                return;
            } 
            
            clickerManager.AddPointDirectly(_currentData.CoffeePoint);
            isAbilityApplied = false;
            gameObject.SetActive(false);
        }
    }
}