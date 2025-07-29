using UnityEngine;

public class ShieldItem : MonoBehaviour, IDispawnObject, IInteracteble
{
    PlayerStats playerStats;

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
    }

    public async void OnInteract()
    {
        Debug.Log("����� ���� ���");
        await playerStats.ActiveShield();
        gameObject.SetActive(false);
    }
}
