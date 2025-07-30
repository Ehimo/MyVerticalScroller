using System;
using UnityEngine;

public class EventBus : IService
{
    // public Action<Coin> coinReleased;
    public Action<Vector3, int> spawnCoin;

    public Action gameEnd;

    public Action<int> addThisCoinAndSave;
    public Action<int> inGameCoinCollected;
}
