using UnityEngine;

namespace Coffee.Data
{
    [CreateAssetMenu(fileName = "BrewData", menuName = "Data/Item/Brew Data", order = 1)]
    public class BrewData : ItemData
    {
        [Header("Stats")]
        [SerializeField] private float incrementalPoint;
        
        // Getter
        public float IncrementalPoint => incrementalPoint;
    }
}