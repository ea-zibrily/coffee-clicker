using UnityEngine;
using TMPro;

namespace Coffee.Quest
{
    public class QuestTimer : MonoBehaviour
    {
        #region Fields

        [Header("Stats")]
        [SerializeField] private bool isTimerActive;
        [SerializeField] private float refreshTime;
        [SerializeField] private TextMeshProUGUI timerTextUI;
        
        private float _elapsedTime;
        
        [Header("Reference")]
        [SerializeField] private QuestManager questManager;
        
        #endregion

        #region Methods
        
        // Unity Callbacks
        private void Start()
        { 
            ResetTimer();
        }
        
        private void Update()
        {
            if (!isTimerActive) return;
            HandleTimer();
            HandleTimerText();
        }
        
        // Core
        public void ResetTimer()
        {
            _elapsedTime = refreshTime;
            isTimerActive = true;
        }
        
        private void HandleTimer()
        {
            _elapsedTime -= Time.deltaTime;
            if (_elapsedTime <= 0f)
            {
                _elapsedTime = refreshTime;
                questManager.GenerateQuest();
            }
        }
        
        private void HandleTimerText()
        {
            var minutes = Mathf.FloorToInt(_elapsedTime / 60);
            var seconds = Mathf.FloorToInt(_elapsedTime % 60);
            
            timerTextUI.text = $"{minutes:00}:{seconds:00}";
        }
        
        #endregion
    }
}