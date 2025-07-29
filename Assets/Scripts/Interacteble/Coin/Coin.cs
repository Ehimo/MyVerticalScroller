using UnityEngine;

public class Coin : MonoBehaviour, IDispawnObject, IInteracteble
{
    [SerializeField] int coinValue = 0;
    public int CoinValue { get => coinValue; }

    public void SetCoinValue(int coinValue)
    {
        this.coinValue = coinValue;
    }
    public void OnInteract()
    {
        EventBus.Get.inGameCoinCollected?.Invoke(coinValue);
        gameObject.SetActive(false);
    }

}