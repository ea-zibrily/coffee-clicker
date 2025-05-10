using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Coffee.Data;
using Coffee.Gameplay;
using Coffee.Shop;

using Random = UnityEngine.Random;

namespace Coffee.Quest
{
    public class QuestManager : MonoBehaviour
    {
        #region Fields & Properties

        [Header("Stats")]
        [SerializeField] private QuestData[] questDatas;
        
        private Quest _currentQuest;
        private List<Quest> _quests = new();
        
        [Header("Parameter")]
        [SerializeField] private int[] clickTargets;
        [SerializeField] private float clickDuration;
        [SerializeField] private int itemCountTarget;
        [SerializeField] private ItemName itemTarget;
        
        [Header("UI")]
        [SerializeField] private Button refreshButtonUI;
        [SerializeField] private TextMeshProUGUI descriptionTextUI;
        
        [Header("Reference")] 
        [SerializeField] private ClickerManager clickerManager;
        [SerializeField] private QuestTimer questTimer;
        
        #endregion

        #region Methods

        // Unity Callbacks
        private void Start()
        {
            InitQuests();
            GenerateQuest();
            refreshButtonUI.onClick.AddListener(GenerateQuest);
        }
        
        private void Update()
        {
            if (_currentQuest == null) return;
            
            _currentQuest.UpdateQuest();
            if (_currentQuest.IsQuestCompleted)
            {
                GenerateQuest();
            }
        }
        
        private void InitQuests()
        {
            _quests = new List<Quest>
            {
                new ClickQuest(questDatas[0], clickerManager, clickTargets[0]),
                new BuyManyItemQuest(questDatas[1], clickerManager, itemCountTarget),
                new ClickOvertimeQuest(questDatas[2], clickerManager, clickTargets[1], clickDuration),
                new BuyItemQuest(questDatas[3], clickerManager, itemTarget)
            };
        }
        
        /// <summary>
        /// Melakukan generate quest baru. Tiap generate, jenis quest yang muncul akan di-random,
        /// sehingga dapat memunculkan jenis quest yang berbeda.
        /// </summary>
        public void GenerateQuest()
        {
            var randomIndex = Random.Range(0, _quests.Count);
            
            descriptionTextUI.text = questDatas[randomIndex].Description;
            _currentQuest = _quests[randomIndex];
            _currentQuest.StartQuest();
            questTimer.ResetTimer();
        }
        
        /// <summary>
        /// Trigger progress quest yang berhubungan dengan clicker.
        /// </summary>
        public void OnAttractClickQuest()
        {
            switch (_currentQuest)
            {
                case ClickQuest clickQuest:
                    clickQuest.OnClickCoffee();
                    break;
                case ClickOvertimeQuest clickTimeQuest:
                    clickTimeQuest.OnClickCoffee();
                    break;
            }
        }
        
        /// <summary>
        /// Trigger progress quest yang item/shop.
        /// </summary>
        public void OnAttractBuyItemQuest(ItemName target)
        {
            switch (_currentQuest)
            {
                case BuyItemQuest buyItemQuest:
                    buyItemQuest.OnBuyItem(target);
                    break;
                case BuyManyItemQuest buyManyItemQuest:
                    buyManyItemQuest.OnBuyItem();
                    break;
            }
        }
        
        #endregion
    }
}