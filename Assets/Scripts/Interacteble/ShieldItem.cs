using UnityEngine;

public class ShieldItem : MonoBehaviour, IDispawnObject, IInteracteble
{

    public void OnInteract()
    {
        Debug.Log("����� ���� ���");

        ServiceLocator.Current.Get<EventBus>()?.activeShield.Invoke();
        
        gameObject.SetActive(false);
    }
}
