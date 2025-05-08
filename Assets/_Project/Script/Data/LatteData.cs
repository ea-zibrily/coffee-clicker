using UnityEngine;

namespace Coffee.Data
{
    [CreateAssetMenu(fileName = "LatteData", menuName = "Data/Item/Latte Data", order = 3)]
    public class LatteData : ItemData
    {
        [Header("Stats")]
        [SerializeField] private int coffeePoint;
        
        // Getter
        public int CoffeePoint => coffeePoint;
    }
}