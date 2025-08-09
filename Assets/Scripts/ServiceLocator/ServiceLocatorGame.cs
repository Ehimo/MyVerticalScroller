using UnityEngine;

public class ServiceLocatorGame : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Coin coin;
    [SerializeField] GameData data;
    [SerializeField] Asteroid asteroid;
    [SerializeField] GameTimerClass gameTimer;
    [SerializeField] Game game;
    [SerializeField] PlayerMovementController playerMovementController;
    [SerializeField] PlayerShootController playerShootController;

    LevelDataContainer levelDataContainer;
    EventBus eventBus;

    void Awake()
    {
        eventBus = new();
        levelDataContainer = new();

        RegisterServices();
        Init();
    }

    void RegisterServices()
    {
        ServiceLocator.Init();

        ServiceLocator.Current.Register(playerMovementController);
        ServiceLocator.Current.Register(game);
        ServiceLocator.Current.Register(playerStats);
        ServiceLocator.Current.Register(eventBus);
        ServiceLocator.Current.Register(coin);
        ServiceLocator.Current.Register(data);
        ServiceLocator.Current.Register(asteroid);
        ServiceLocator.Current.Register(levelDataContainer);
        ServiceLocator.Current.Register(gameTimer);
        ServiceLocator.Current.Register(playerShootController);
    }

    void Init()
    {
        playerStats.Init();
        coin.Init();
        data.Init();
        asteroid.Init();
        game.Init();
        gameTimer.Init();
        playerMovementController.Init();
        playerShootController.Init();
    }
}
