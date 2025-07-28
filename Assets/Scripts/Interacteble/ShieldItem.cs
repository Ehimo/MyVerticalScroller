using UnityEngine;

public class ShieldItem : MonoBehaviour, IDispawnObject, IInteracteble
{
    PlayerStats playerStats;

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
    }

    public void OnInteract()
    {
        Debug.Log("Shield need to be activete!");
        playerStats.ActiveShield();
        gameObject.SetActive(false);

    }
}
