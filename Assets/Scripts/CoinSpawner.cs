using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Transform objectParent;
    [SerializeField] Coin pfCoin;
    [SerializeField] int fistPoolInitCount = 10;
    CustomPool<Coin> coinPool;

    public void Start()
    {
        coinPool = new CustomPool<Coin>(pfCoin, fistPoolInitCount, objectParent);
        
        EventBus.Sus.spawnCoin += SpawnCoin;
    }


    public void SpawnCoin(Vector3 position, int moneyForThisCoin)
    {
        Debug.Log("Testing");

        var coin = coinPool.Get();

        coin.SetCoinValue(moneyForThisCoin);

        coin.transform.position = position;
        // Get Coin from CointPool.
    }
}