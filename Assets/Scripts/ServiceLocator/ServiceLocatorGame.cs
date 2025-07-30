using UnityEngine;

public class ServiceLocatorGame : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Coin coin;
    [SerializeField] LevelInGameData data;
    [SerializeField] Asteroid asteroid;

    EventBus eventBus;
    void Awake()
    {
        eventBus = new();

        RegisterServices();
        Init();
    }

    void RegisterServices()
    {
        ServiceLocator.Init();

        ServiceLocator.Current.Register<PlayerStats>(playerStats);
        ServiceLocator.Current.Register<EventBus>(eventBus);
        ServiceLocator.Current.Register<Coin>(coin);
        ServiceLocator.Current.Register<LevelInGameData>(data);
        ServiceLocator.Current.Register<Asteroid>(asteroid);
    }

    void Init()
    {
        playerStats.Init();
        coin.Init();
        data.Init();
        asteroid.Init();
    }
}
