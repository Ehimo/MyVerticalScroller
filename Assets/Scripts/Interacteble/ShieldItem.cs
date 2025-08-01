using System.Collections;
using UnityEngine;

public class ShieldItem : MonoBehaviour, IDispawnObject, IInteracteble
{
    public void OnInteract()
    {
        Debug.Log("Игрок взял щит");

        ServiceLocator.Current.Get<PlayerStats>().ActiveShield();
        
        gameObject.SetActive(false);
    }
}
