using System.Collections;
using UnityEngine;

public class ServiceLocatorMenu : MonoBehaviour
{
    [SerializeField] MainTextScript mainTextObject;
    [SerializeField] MainObjectScript mainObject;
    [SerializeField] BackButtonScript backButton;

    EventBus eventBus;
    LevelDataContainer levelDataContainer;
    Game game;
    void Awake()
    {
        eventBus = new();
        levelDataContainer = new();
        game = new();

        RegisterServices();

        eventBus.menuButtonClicked += () => { backButton.gameObject.SetActive(true); };
    }

    void RegisterServices() 
    {
        ServiceLocator.Init();

        ServiceLocator.Current.Register(mainTextObject);
        ServiceLocator.Current.Register(mainObject);
        ServiceLocator.Current.Register(eventBus);
        ServiceLocator.Current.Register(levelDataContainer);
        ServiceLocator.Current.Register(game);
    }
}
