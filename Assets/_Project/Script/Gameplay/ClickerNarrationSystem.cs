using UnityEngine;
using Coffee.UI;
using Coffee.Ability;
using Coffee.Pattern.Observer;

namespace Coffee.Gameplay
{
    public class ClickerNarrationSystem : MonoBehaviour, IObserver
    {
        [Header("Subject")]
        [SerializeField] private Subject clicker;
        
        [Header("Reference")]
        [SerializeField] private ClickerManager clickerManager;
        [SerializeField] private FloatingTextSpawner floatingSpawner;
        [SerializeField] private PointGacha pointGachaAbility;
        
        private void OnEnable()
        {
            clicker.AddObserver(this);
        }
        
        private void OnDisable()
        {
            clicker.RemoveObserver(this);
        }
        
        public void OnNotify()
        {
            var increment = clickerManager.IncrementPoint;
            
            clickerManager.AddPoint();
            floatingSpawner.SpawnFloatingText(increment);
            pointGachaAbility.OnCoffeeClick();
        }
    }
}