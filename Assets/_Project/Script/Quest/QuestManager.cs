using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Coffee.Data;
using Coffee.Shop;

using Random = UnityEngine.Random;

namespace Coffee.Quest
{
    public class QuestManager : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private QuestData[] questDatas;
        
        private List<Quest> _quests = new();
        public Quest CurrentQuest { get; private set; }
        
        [Header("Parameter")]
        [SerializeField] private int[] clickTargets;
        [SerializeField] private float clickDuration;
        [SerializeField] private int itemCountTarget;
        [SerializeField] private ItemName itemTarget;
        
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI questTextUI;
        
        private void Start()
        {
            _quests = new List<Quest>
            {
                new ClickQuest(questDatas[0], clickTargets[0]),
                new BuyManyItemQuest(questDatas[1], itemCountTarget),
                new ClickTimeQuest(questDatas[2], clickTargets[1], clickDuration),
                new BuyItemQuest(questDatas[3], itemTarget)
            };
            
            GenerateQuest();
        }
        
        private void Update()
        {
            if (CurrentQuest == null) return;
            CurrentQuest.UpdateQuest();
            if (CurrentQuest.IsQuestCompleted)
            {
                GenerateQuest();
            }
        }
        
        private void GenerateQuest()
        {
            var randomIndex = Random.Range(0, _quests.Count);
            
            questTextUI.text = questDatas[randomIndex].Description;
            CurrentQuest = _quests[randomIndex];
            CurrentQuest.StartQuest();
        }
        
        public void OnAttractClickQuest()
        {
            switch (CurrentQuest)
            {
                case ClickQuest clickQuest:
                    clickQuest.OnClickCoffee();
                    break;
                case ClickTimeQuest clickTimeQuest:
                    clickTimeQuest.OnClickCoffee();
                    break;
            }
        }
        
        public void OnAttractBuyItemQuest(ItemName target)
        {
            switch (CurrentQuest)
            {
                case BuyItemQuest buyItemQuest:
                    buyItemQuest.OnBuyItem(target);
                    break;
                case BuyManyItemQuest buyManyItemQuest:
                    buyManyItemQuest.OnBuyItem();
                    break;
            }
        }
    }
}