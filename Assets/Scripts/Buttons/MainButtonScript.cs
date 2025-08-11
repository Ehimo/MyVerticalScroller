using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainButtonScript : MonoBehaviour, IService
{
    [SerializeField] TextMeshProUGUI mainText;

    [SerializeField] List<GameObject> objectsToActive;

    void Start()
    {
        ServiceLocator.Current.Get<EventBus>().buttonClicked += OnButtonClicked;
    }

    void OnButtonClicked(EObjectToActiveName name)
    {
        GameObject objectToActive = null;

        foreach (var item in objectsToActive) 
        {
            if (name.ToString() == item.name)
                objectToActive = item;
            item.SetActive(false);
        }
        
        mainText.text = name.ToString();
        objectToActive.SetActive(true);
        
    }
}
