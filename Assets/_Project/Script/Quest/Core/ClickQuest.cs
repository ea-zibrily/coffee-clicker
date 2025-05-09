using System;
using Coffee.Data;

namespace Coffee.Quest
{
    public class ClickQuest : Quest
    {
        // Internal fields
        private int _clickCount;
        private readonly int clickTarget;

        public ClickQuest(QuestData questData, int clickTarget) : base(questData)
        {
            this.clickTarget = clickTarget;
        }
        
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