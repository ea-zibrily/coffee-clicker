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
        
        /// <summary>
        /// Mengeksekusi kondisi saat quest dimulai.
        /// </summary>
        public virtual void StartQuest() { IsQuestCompleted = false; }
        
        /// <summary>
        /// Melakukan update progressi quest.
        /// </summary>
        public abstract void UpdateQuest();
        
        /// <summary>
        /// Mengeksekusi kondisi saat quest selesai.
        /// </summary>
        protected virtual void EndQuest(bool isSuccess)
        {
            IsQuestCompleted = true;
            if (!isSuccess) return;
            var reward = questData.CoffeeReward;
            clickerManager.AddPointDirectly(reward);
        }
    }
}