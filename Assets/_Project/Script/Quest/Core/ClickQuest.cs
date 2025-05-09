using Coffee.Data;
using Coffee.Gameplay;

namespace Coffee.Quest
{
    public class ClickQuest : Quest
    {
        // Internal fields
        private int _clickCount;
        private readonly int clickTarget;

        // Constructor
        public ClickQuest(QuestData questData, ClickerManager clickerManager, int clickTarget) 
            : base(questData, clickerManager)
        {
            this.clickTarget = clickTarget;
        }
        
        // Methods
        public override void StartQuest()
        {
            base.StartQuest();
            _clickCount = 0;
        }
        
        public override void UpdateQuest()
        {
            if (_clickCount >= clickTarget)
            {
                EndQuest(isSuccess: true);
            }
        }
        
        public void OnClickCoffee()
        {
            if (IsQuestCompleted) return;
            _clickCount++;
        }
    }
}