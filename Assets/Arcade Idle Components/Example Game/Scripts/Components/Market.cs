using NaughtyAttributes;
using UnityEngine;

namespace BaranovskyStudio.SimpleGame
{
    public class Market : MonoBehaviour
    {
        [BoxGroup("LINKS")] [SerializeField] 
        private Placement _placement;
        [BoxGroup("LINKS")] [SerializeField] 
        private PriceItem _applePrice;
        [BoxGroup("LINKS")] [SerializeField] 
        private PriceItem _orangePrice;



        public MarketItemSettings AppleSettings;
        public MarketItemSettings OrangeSettings;

        private void Awake()
        {
            _placement.OnEnterPlacement.AddListener(TryBuyFruit);
        }

        private void Start()
        {
            _applePrice.SetPrice(AppleSettings.Price);
            _orangePrice.SetPrice(OrangeSettings.Price);
        }
        
        private void TryBuyFruit(GameObject go)
        {
            var backpack = go.GetComponentInChildren<SpecialBackpack>();

            int revenue;
            if (backpack.ShowedItemsType == SpecialBackpack.ResourceType.Apple)
            {
                revenue = backpack.ItemsCount * AppleSettings.Price;
            }
            else
            {
                revenue = backpack.ItemsCount * OrangeSettings.Price;
            }
            go.GetComponent<PlayerPurse>().AddMoney(revenue);
            
            backpack.RemoveItems(backpack.ItemsCount);
        }

        private void OnUpgradeApplePrice(int priceLevel)
        {
            AppleSettings.PriceLevel = priceLevel;
            _applePrice.SetPrice(AppleSettings.Price);
        }
        
        private void OnUpgradeOrangePrice(int priceLevel)
        {
            OrangeSettings.PriceLevel = priceLevel;
            _orangePrice.SetPrice(OrangeSettings.Price);
        }
    }
}