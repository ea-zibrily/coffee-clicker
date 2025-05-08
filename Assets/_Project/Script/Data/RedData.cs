using UnityEngine;

namespace Coffee.Data
{
    [CreateAssetMenu(fileName = "RedData", menuName = "Data/Item/Red Data", order = 2)]
    public class RedData : ItemData
    {
        [Header("Stats")]
        [SerializeField] private int[] pointRange;
        [SerializeField] private int clickCount;
        [SerializeField] private Sprite coffeeSprite;
        
        // Getter
        public int[] PointRange => pointRange;
        public int ClickCount => clickCount;
        public Sprite CoffeeSprite => coffeeSprite;
    }
}