using UnityEngine;
using TMPro;
using DG.Tweening;

using Random = UnityEngine.Random;

namespace Coffee.UI
{
    public class FloatingText : MonoBehaviour
    {
        #region Fields & Properties

        [Header("Animation")]
        [SerializeField] private Ease easeType;
        [SerializeField] private float tweenDuration;
        [SerializeField] private float[] jumpHeights;
        [SerializeField] private Vector2[] jumpPoints;
        
        private float _jumpHeight;
        private Vector2 _jumpPoint;
        
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI floatingTextUI;
        [SerializeField] private CanvasGroup canvasGroup;
        
        private RectTransform _rect;
        
        #endregion

        #region Methods
        
        // Unity Callbacks
        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }
        
        private void OnEnable()
        {
            // Initiate
            var xPoint = Random.Range(jumpPoints[0].x, jumpPoints[1].x);
            var yPoint = Random.Range(jumpPoints[0].y, jumpPoints[1].y);
            
            _jumpPoint = new Vector2(xPoint, yPoint);
            _jumpHeight = Random.Range(jumpHeights[0], jumpHeights[1]);
            
            canvasGroup.DOFade(1f, 0f);
        }
        
        /// <summary>
        /// Mengeksekusi animasi floating text ketika player melakukan klik.
        /// </summary>
        public void AnimateFloatingText(int value)
        {
            floatingTextUI.text = value.ToString();
            canvasGroup.DOFade(0f, tweenDuration * 2f);
            _rect.DOJumpAnchorPos(_jumpPoint, _jumpHeight, 1, tweenDuration)
                .SetEase(easeType)
                .OnComplete(() =>
                {
                    // Release
                    _rect.anchoredPosition = Vector3.zero;
                    gameObject.SetActive(false);
                });
        }
        
        #endregion
    }
}