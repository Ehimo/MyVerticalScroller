using UnityEngine;

public class Asteroid : MonoBehaviour, IDispawnObject, IInteracteble
{
    [SerializeField] int collideDamage = 1;
    [SerializeField] int coinToSpawn = 1;
    [SerializeField] int valueOfCoinToSpawn = 1;

    PlayerStats stats;

    void Start()
    {
        stats = FindFirstObjectByType<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IDestroyAsteroid>() != null)
        {
            SpawnCoin();
            DispawnAsteroid();
            collision.gameObject.SetActive(false);
        }
    }

    [SerializeField] int collideHealthDamage = 1;
    public void OnInteract()
    {
        if(!stats.PlayerHasShield())
            stats.RemoveHealth(collideHealthDamage);
        
        DispawnAsteroid();
    }

    void DispawnAsteroid()
    {
        Debug.Log("Asteroid has been dispawned!");
        gameObject.SetActive(false);
    }

    void SpawnCoin()
    {
        Debug.Log("SpawnCoin");

        for (int i = 0; i < coinToSpawn; i++)
        {
            EventBus.Sus.spawnCoin?.Invoke(transform.position, valueOfCoinToSpawn);
        }
    }
}

