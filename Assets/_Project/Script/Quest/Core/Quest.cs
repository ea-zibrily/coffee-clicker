using Coffee.Data;
using Coffee.Gameplay;
using TMPro;

namespace Coffee.Quest
{
    public abstract class Quest
    {
        // General Component
        protected readonly QuestData questData;
        protected readonly ClickerManager clickerManager;
        
        public bool IsQuestCompleted { get; protected set; }
        
        // Constructor
        protected Quest(QuestData questData)
        {
            this.questData = questData;
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