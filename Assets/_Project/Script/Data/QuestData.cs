using UnityEngine;

namespace Coffee.Data
{
    [CreateAssetMenu(fileName = "QuestData", menuName = "Data/Quest Data", order = 0)]
    public class QuestData : ScriptableObject
    {
        [Header("Stats")]
        [SerializeField] private string questName;
        [SerializeField] [TextArea(0, 2)] private string description;
        [SerializeField] [Range(10, 100)] private int coffeeReward;
        
        // Getter
        public string QuestName => questName;
        public string Description => description;
        public int CoffeeReward => coffeeReward;
    }
}