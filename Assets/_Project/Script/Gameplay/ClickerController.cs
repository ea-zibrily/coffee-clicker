using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Coffee.Gameplay
{
    [RequireComponent(typeof(Button))]
    public class ClickerController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Settings")] 
        [SerializeField] private bool canClick;
        
        [Header("Animation")] 
        [SerializeField] private Ease easeType;
        [SerializeField] private float bounceDuration;
        [SerializeField] private float rotateDuration;
        [SerializeField] private Vector3 clickScale;
        [SerializeField] private Vector3 highlightScale;
        
        private float _rotateAngle;
        private Vector3 _originalScale;
        
        [Header("UI")] 
        [SerializeField] private Image coffeeImageUI;
        
        private Button _button;
        private RectTransform _rect;

        [Header("Reference")] 
        [SerializeField] private ClickerManager clickerManager;
        
        #region Methods

        // Unity Callbacks
        private void Awake()
        {
            _button = GetComponent<Button>();
            _rect = GetComponent<RectTransform>();
        }
        
        private void Start()
        {
            // Initialize
            canClick = true;

            _rotateAngle = -180f;
            _originalScale = _button.transform.localScale;
            _button.onClick.AddListener(OnClicked);
            
            AnimateRotate();
        }
        
        // Core
        public void OnPointerEnter(PointerEventData eventData)
        {
            _rect.DOScale(highlightScale, bounceDuration).SetEase(easeType);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _rect.DOScale(_originalScale, bounceDuration).SetEase(easeType);
        }
        
        private void OnClicked()
        {
            if (!canClick) return;
            AnimateBounce();
            clickerManager.AddPoint();
        }
        
        private void AnimateBounce()
        {
            canClick = false;
            _rect.DOScale(clickScale, bounceDuration).SetEase(easeType);
            _rect.DOScale(highlightScale, bounceDuration)
                .SetEase(easeType)
                .SetDelay(bounceDuration)
                .OnComplete(() => canClick = true);
        }
        
        private void AnimateRotate()
        {
            coffeeImageUI.transform.DORotate(new Vector3(0f, 0f, _rotateAngle), rotateDuration)
                .SetEase(easeType)
                .SetRelative()
                .SetLoops(-1, LoopType.Incremental);
        }
        
        #endregion
    }
}
