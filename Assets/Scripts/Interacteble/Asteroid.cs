using UnityEngine;

public class Asteroid : MonoBehaviour, IDispawnObject, IInteracteble, IService, ICanDestroyedByBullet
{
    [SerializeField] int collideDamage = 1;
    [SerializeField] int spawnedCoinValue = 1;

    public void OnCollisionWithProjectile()
    {
        SpawnCoin();
        DispawnAsteroid();
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
        if (!playerStats.PlayerHasShield)
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
        Debug.Log("Астероид спавнит монету после уничтожения.");

        eventBus.spawnCoin?.Invoke(transform.position, spawnedCoinValue);
    }
}

