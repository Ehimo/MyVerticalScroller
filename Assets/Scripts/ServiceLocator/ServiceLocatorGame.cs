using TMPro;
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

        ServiceLocator.Current.Register(playerStats);
        ServiceLocator.Current.Register(eventBus);
        ServiceLocator.Current.Register(coin);
        ServiceLocator.Current.Register(data);
        ServiceLocator.Current.Register(asteroid);
    }

    void Init()
    {
        playerStats.Init();
        coin.Init();
        data.Init();
        asteroid.Init();
    }
}
