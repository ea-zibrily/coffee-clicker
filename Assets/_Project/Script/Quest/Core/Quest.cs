using Coffee.Data;
using Coffee.Gameplay;
using TMPro;

namespace Coffee.Quest
{
    public abstract class Quest
    {
        // General Component
        private readonly QuestData questData;
        private readonly ClickerManager clickerManager;
        
        public bool IsQuestCompleted { get; private set; }
        
        // Constructor
        protected Quest(QuestData questData, ClickerManager clickerManager)
        {
            this.questData = questData;
            this.clickerManager = clickerManager;
        }
        
        // Methods
        public virtual void StartQuest() { IsQuestCompleted = false; }
        public abstract void UpdateQuest();
        protected virtual void EndQuest(bool isSuccess)
        {
            IsQuestCompleted = true;
            if (!isSuccess) return;
            var reward = questData.CoffeeReward;
            clickerManager.AddPointDirectly(reward);
        }
    }
}