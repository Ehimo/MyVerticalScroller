using UnityEngine;

public class Coin : MonoBehaviour, IDispawnObject, IInteracteble, IService
{
    [SerializeField] int coinValue = 0;
    public int CoinValue { get => coinValue; }

    static EventBus eventBus;

    public void Init() 
    {
        eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    public void SetCoinValue(int coinValue)
    {
        this.coinValue = coinValue;
    }
    public void OnInteract()
    {
        ServiceLocator.Current.Get<EventBus>().inGameCoinCollected?.Invoke(coinValue);
        gameObject.SetActive(false);
    }

}