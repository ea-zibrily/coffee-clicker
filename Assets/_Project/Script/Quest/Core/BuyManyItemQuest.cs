using Coffee.Data;
using Coffee.Gameplay;

namespace Coffee.Quest
{
    public class BuyManyItemQuest : Quest
    {
        private int _currentItemCount;
        private readonly int itemCount;
        
        // Constructor
        public BuyManyItemQuest(QuestData questData, ClickerManager clickerManager, int itemCount) 
            : base(questData, clickerManager)
        {
            this.itemCount = itemCount;
        }
        
        public override void StartQuest()
        {
            base.StartQuest();
            _currentItemCount = 0;
        }
        
        public override void UpdateQuest()
        {
            if (_currentItemCount >= itemCount)
            {
                EndQuest(isSuccess: true);
            }
        }
        
        public void OnBuyItem()
        {
            if (IsQuestCompleted) return;
            _currentItemCount++;
        }
    }
}