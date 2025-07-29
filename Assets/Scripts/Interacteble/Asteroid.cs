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
        Debug.Log("�������� �������������");
        gameObject.SetActive(false);
    }

    void SpawnCoin()
    {
        Debug.Log("�������� ������� ������ ����� �����������.");

        for (int i = 0; i < coinToSpawn; i++)
        {
            EventBus.Get.spawnCoin?.Invoke(transform.position, valueOfCoinToSpawn);
        }
    }
}

