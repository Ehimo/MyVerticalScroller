using UnityEngine;

public class ShieldItem : MonoBehaviour, IDispawnObject, IInteracteble
{

    public void OnInteract()
    {
        Debug.Log("Игрок взял щит");

        ServiceLocator.Current.Get<EventBus>()?.activeShield.Invoke();
        
        gameObject.SetActive(false);
    }
}
