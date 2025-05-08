using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UI
{
    public class FloatingTextSpawner : MonoBehaviour
    {
        #region Fields
        
        [Header("Components")]
        [SerializeField] private List<FloatingText> floatingTexts;
        
        #endregion
        
        #region Methods
        
        // Unity Callbacks
        private void Start()
        {
            foreach (var text in floatingTexts)
            {
                text.gameObject.SetActive(false);
            }
        }
        
        // Core
        public void SpawnFloatingText(int value)
        {
            var floatingText = GetText();
            floatingText.AnimateFloatingText(value);
        }
        
        private FloatingText GetText()
        {
            for (var i = 0; i < floatingTexts.Count; i++)
            {
                var text = floatingTexts[i];
                if (!text.gameObject.activeSelf)
                {
                    text.gameObject.SetActive(true);
                    return text;
                }
            }
            
            var newFloatingText = Instantiate(floatingTexts[0], transform);
            newFloatingText.gameObject.SetActive(true);
            floatingTexts.Add(newFloatingText);
            return newFloatingText;
        }
        
        #endregion
    }
}