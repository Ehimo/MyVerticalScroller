using UnityEngine;

public class ServiceLocatorMenu : MonoBehaviour
{

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
    }

    void RegisterServices() 
    {
        ServiceLocator.Init();

        ServiceLocator.Current.Register(playerStats);
        ServiceLocator.Current.Register(eventBus);
        ServiceLocator.Current.Register(levelDataContainer);
        ServiceLocator.Current.Register(game);
    }
}
