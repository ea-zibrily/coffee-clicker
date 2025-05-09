using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using Coffee.Pattern.Observer;

namespace Coffee.Gameplay
{
    [RequireComponent(typeof(Button))]
    public class ClickerController : Subject, IPointerEnterHandler, IPointerExitHandler
    {
        #region Fields & Properties

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
        [SerializeField] private Button coffeeButtonUI;
        
        private RectTransform _rect;
        
        #endregion
        
        #region Methods

        // Unity Callbacks
        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }
        
        private void Start()
        {
            // Initialize
            InitClickers();
            AnimateRotate();
            
            coffeeButtonUI.onClick.AddListener(OnClicked);
        }
        
        // Initialize
        private void InitClickers()
        {
            canClick = true;
            
            _rotateAngle = -180f;
            _originalScale = coffeeButtonUI.transform.localScale;
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
            NotifyObserver();
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
