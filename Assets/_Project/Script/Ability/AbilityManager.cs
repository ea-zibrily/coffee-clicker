using System;
using Coffee.Shop;
using UnityEngine;

namespace Coffee.Ability
{
    public class AbilityManager : MonoBehaviour
    {
        [Header("Abilities")]
        [SerializeField] private AbilityBase[] clickerAbilities;

        #region Methods

        // Unity Callbacks
        private void Start()
        {
            foreach (var ability in clickerAbilities)
            {
                ability.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Mengaktifkan ability berdasarkan nama ability.
        /// Sebelum mengaktifkan, dilakukan validasi apakah ability tersebut ada atau tidak.
        /// </summary>
        /// <param name="abilityName">target nama ability yang diinginkan</param>
        public void ApplyAbility(ItemName abilityName)
        {
            var ability = GetAbilityByName(abilityName);
            if (ability == null)
            {
                Debug.LogWarning("ability null!");
                return;
            }
            
            ability.gameObject.SetActive(true);
            ability.AddAbility();
        }
        
        private AbilityBase GetAbilityByName(ItemName abilityName)
        {
            var ability = Array.Find(clickerAbilities, ability => ability.AbilityName == abilityName);
            return ability;
        }

        #endregion
    }
}