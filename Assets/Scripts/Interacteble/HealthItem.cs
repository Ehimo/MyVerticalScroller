using UnityEngine;

public class HealthItem : MonoBehaviour, IInteracteble, IDispawnObject
{
    [SerializeField] int healthToAdd = 1;
    public void OnInteract()
    {
        Debug.Log("����� ���� ���");
        ServiceLocator.Current.Get<PlayerStats>().AddHealth(healthToAdd);
        gameObject.SetActive(false);
    }
}