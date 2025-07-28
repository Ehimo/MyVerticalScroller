using UnityEngine;

public class HealthItem : MonoBehaviour, IInteracteble, IDispawnObject
{
    [SerializeField] int healthToAdd = 1;

    PlayerStats playerStats;

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();    
    }

    public void OnInteract()
    {
        Debug.Log("Health item");
        playerStats.AddHealth(healthToAdd);
        gameObject.SetActive(false);
    }
}