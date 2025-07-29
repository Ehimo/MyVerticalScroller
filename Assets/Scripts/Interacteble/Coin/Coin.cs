using UnityEngine;

public class Coin : MonoBehaviour, IDispawnObject, IInteracteble
{
    [SerializeField] int coinValue = 0;
    public int CoinValue { get => coinValue; }

    public void SetCoinValue(int coinValue)
    {
        this.coinValue = coinValue;
    }

    PlayerStats playerStats;
    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
    }
    
    public void OnInteract()
    {
        playerStats.Money += coinValue;
        gameObject.SetActive(false);
    }

}