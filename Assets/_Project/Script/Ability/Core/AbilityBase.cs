using UnityEngine;
using Coffee.Data;
using Coffee.Shop;
using Coffee.Database;
using Coffee.Gameplay;

namespace Coffee.Ability
{
    public abstract class AbilityBase : MonoBehaviour
    {
        #region Fields & Properties

        [Header("Stats")]
        [SerializeField] protected ItemName abilityName;
        [SerializeField] private bool isRunable;
        [SerializeField] protected ClickerManager clickerManager;
        
        protected bool isAbilityApplied;
        protected ItemData[] itemDataList;
        public ItemName AbilityName => abilityName;

        #endregion
        
        #region Methods
        
        // Unity Callbacks
        private void OnEnable()
        {
            isAbilityApplied = true;
            itemDataList = ItemDatabase.Instance.GetItemDatas(abilityName);
        }
        
        private void Update()
        {
            if (!isRunable && !isAbilityApplied) return;
            RunAbility();
        }
        
        // Core
        public abstract void AddAbility();
        protected virtual void RunAbility() { }
        
        #endregion
    }
}