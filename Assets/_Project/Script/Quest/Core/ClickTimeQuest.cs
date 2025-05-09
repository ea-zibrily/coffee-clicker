using Coffee.Data;
using UnityEngine;

namespace Coffee.Quest
{
    public class ClickTimeQuest : Quest
    {
        // Internal fields
        private int _clickCount;
        private float _currentTime;
        private readonly int clickTarget;
        private readonly float clickDuration;

        public ClickTimeQuest(QuestData questData, int clickTarget, float clickDuration) : base(questData)
        {
            this.clickTarget = clickTarget;
            this.clickDuration = clickDuration;
        }
        
        public override void StartQuest()
        {
            base.StartQuest();
            _clickCount = 0;
            _currentTime = 0f;
        }
        
        public override void UpdateQuest()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime <= clickDuration)
            {
                if (_clickCount >= clickTarget)
                {
                    EndQuest(isSuccess: true);
                }
            }
            else
            { 
                EndQuest(isSuccess: false);
            }
        }
        
        public void OnClickCoffee()
        {
            if (IsQuestCompleted) return;
            _clickCount++;
        }
    }
}