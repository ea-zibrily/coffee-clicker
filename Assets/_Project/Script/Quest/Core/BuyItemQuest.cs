using Coffee.Data;
using Coffee.Shop;

namespace Coffee.Quest
{
    public class BuyItemQuest : Quest
    {
        private readonly ItemName itemName;
        private bool isGetItem;
        
        // Constructor
        public BuyItemQuest(QuestData questData, ItemName itemName) : base(questData)
        {
            this.itemName = itemName;
        }
        
        public override void StartQuest()
        {
            base.StartQuest();
            isGetItem = false;
        }
        
        public override void UpdateQuest()
        {
            if (!isGetItem) return; 
            EndQuest(isSuccess: true);
        }
        
        public void OnBuyItem(ItemName target)
        {
            if (itemName != target) return;
            isGetItem = true;
        }
    }
}