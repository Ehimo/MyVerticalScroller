using UnityEngine;

public class ServiceLocatorGame : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Coin coin;
    [SerializeField] LevelInGameData data;
    [SerializeField] Asteroid asteroid;
    [SerializeField] GameTimerClass gameTimer;
    [SerializeField] Game game;

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

        ServiceLocator.Current.Register(playerStats);
        ServiceLocator.Current.Register(eventBus);
        ServiceLocator.Current.Register(coin);
        ServiceLocator.Current.Register(data);
        ServiceLocator.Current.Register(asteroid);
        ServiceLocator.Current.Register(levelDataContainer);
        ServiceLocator.Current.Register(gameTimer);
        ServiceLocator.Current.Register(game);
    }

    void Init()
    {
        playerStats.Init();
        coin.Init();
        data.Init();
        asteroid.Init();
        game.Init();
        gameTimer.Init();

    }
}
