using UnityEngine;

namespace Coffee.Data
{
    [CreateAssetMenu(fileName = "EspressoData", menuName = "Data/Item/Espresso Data", order = 0)]
    public class EspressoData : ItemData
    {
        [Header("Stats")]
        [SerializeField] private int coffeePoint;
        [SerializeField] private float incrementTime;
        
        // Getter
        public int CoffeePoint => coffeePoint;
        public float IncrementTime => incrementTime;
    }
}