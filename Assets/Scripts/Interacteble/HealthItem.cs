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
        Debug.Log("Игрок взял хил");
        playerStats.AddHealth(healthToAdd);
        gameObject.SetActive(false);
    }
}