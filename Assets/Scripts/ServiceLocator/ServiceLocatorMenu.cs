using System.Collections;
using UnityEngine;

public class ServiceLocatorMenu : MonoBehaviour
{
    [SerializeField] MainTextScript mainTextObject;
    [SerializeField] MainObjectScript mainObject;
    
    [SerializeField] BackButtonScript backButton;

    EventBus eventBus;

    void Awake()
    {
        eventBus = new();

        RegisterServices();

        eventBus.menuButtonClicked += () => { backButton.gameObject.SetActive(true); };
    }

    void RegisterServices() 
    {
        ServiceLocator.Init();

        ServiceLocator.Current.Register(mainTextObject);
        ServiceLocator.Current.Register(mainObject);
        ServiceLocator.Current.Register(eventBus);
    }
}
