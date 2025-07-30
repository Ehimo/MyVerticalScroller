using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Transform objectParent;
    [SerializeField] Coin pfCoin;
    [SerializeField] int fistPoolInitCount = 10;
    CustomPool<Coin> coinPool;

    void Start()
    {
        coinPool = new CustomPool<Coin>(pfCoin, fistPoolInitCount, objectParent);
        
        ServiceLocator.Current.Get<EventBus>().spawnCoin += SpawnCoin;
    }


    public void SpawnCoin(Vector3 position, int moneyForThisCoin)
    {
        Debug.Log("Монета заспавнена");

        var coin = coinPool.Get();
        coin.transform.position = position;

        coin.SetCoinValue(moneyForThisCoin);
    }
}