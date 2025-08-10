using UnityEngine;

public class ServiceLocatorMenu : MonoBehaviour
{
    [SerializeField] MainTextScript mainTextObject;
    [SerializeField] MainObjectScript mainObject;
    [SerializeField] BackButton backButton;

    PlayerStats playerStats;
    EventBus eventBus;
    LevelDataContainer levelDataContainer;
    Game game;
    
    void Awake()
    {
        eventBus = new();
        levelDataContainer = new();
        game = new();
        playerStats = new();

        RegisterServices();

        eventBus.menuButtonClicked += () => { backButton.gameObject.SetActive(true); };
    }

    void RegisterServices() 
    {
        ServiceLocator.Init();

        ServiceLocator.Current.Register(playerStats);
        ServiceLocator.Current.Register(mainTextObject);
        ServiceLocator.Current.Register(mainObject);
        ServiceLocator.Current.Register(eventBus);
        ServiceLocator.Current.Register(levelDataContainer);
        ServiceLocator.Current.Register(game);
    }
}
