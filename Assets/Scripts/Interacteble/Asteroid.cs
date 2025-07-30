using UnityEngine;

public class Asteroid : MonoBehaviour, IDispawnObject, IInteracteble, IService
{
    [SerializeField] int collideDamage = 1;
    [SerializeField] int coinToSpawn = 1;
    [SerializeField] int valueOfCoinToSpawn = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IDestroyAsteroid>() != null)
        {
            SpawnCoin();
            DispawnAsteroid();
            collision.gameObject.SetActive(false);
        }
    }

    static PlayerStats playerStats;
    static EventBus eventBus;

    public void Init()
    {
        playerStats = ServiceLocator.Current.Get<PlayerStats>();
        eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    [SerializeField] int collideHealthDamage = 1;
    public void OnInteract()
    {
        if (!playerStats.PlayerHasShield())
            playerStats.RemoveHealth(collideHealthDamage);

        DispawnAsteroid();
    }

    void DispawnAsteroid()
    {
        Debug.Log("Астероид задиспавнился");
        gameObject.SetActive(false);
    }

    void SpawnCoin()
    {
        Debug.Log("Астероид спавнит монеты после уничтожения.");

        for (int i = 0; i < coinToSpawn; i++)
        {
            eventBus.spawnCoin?.Invoke(transform.position, valueOfCoinToSpawn);
        }
    }
}

