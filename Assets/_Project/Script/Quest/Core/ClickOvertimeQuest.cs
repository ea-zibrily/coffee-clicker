using Coffee.Data;
using Coffee.Gameplay;
using UnityEngine;

namespace Coffee.Quest
{
    public class ClickOvertimeQuest : Quest
    {
        // Internal fields
        private int _clickCount;
        private float _currentTime;
        private bool _isStartTimer;
        
        private readonly int clickTarget;
        private readonly float clickDuration;
        
        // Constructor
        public ClickOvertimeQuest(QuestData questData, ClickerManager clickerManager, int clickTarget, 
            float clickDuration) : base(questData, clickerManager)
        {
            this.clickTarget = clickTarget;
            this.clickDuration = clickDuration;
        }
        
        public override void StartQuest()
        {
            base.StartQuest();
            _clickCount = 0;
            _currentTime = 0f;
            _isStartTimer = false;
        }
        
        public override void UpdateQuest()
        {
            if (!_isStartTimer) return;
            
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
            _isStartTimer = true;
        }
    }
}