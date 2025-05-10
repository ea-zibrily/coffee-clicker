using UnityEngine;
using Coffee.UI;
using Coffee.Quest;
using Coffee.Ability;
using Coffee.Pattern.Observer;

namespace Coffee.Gameplay
{
    public class ClickerNarratorSystem : MonoBehaviour, IObserver
    {
        #region Fields

        [Header("Subject")]
        [SerializeField] private Subject clicker;
        
        [Header("Reference")]
        [SerializeField] private ClickerManager clickerManager;
        [SerializeField] private FloatingTextSpawner floatingSpawner;
        [SerializeField] private QuestManager questManager;
        [SerializeField] private PointGacha pointGachaAbility;

        #endregion

        #region Methods

        // Unity Callbacks
        private void OnEnable()
        {
            clicker.AddObserver(this);
        }
        
        private void OnDisable()
        {
            clicker.RemoveObserver(this);
        }
        
        /// <summary>
        /// Merespon notifikasi yang diterima dari subjek ClickerController.
        /// </summary>
        public void OnNotify()
        {
            var increment = 1 + clickerManager.IncrementPoint;
            
            clickerManager.AddPoint();
            floatingSpawner.SpawnFloatingText(increment);
            questManager.OnAttractClickQuest();
            pointGachaAbility.OnClickCoffee();
        }
        
        #endregion
    }
}