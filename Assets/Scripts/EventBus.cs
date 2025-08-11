using System;
using UnityEngine;

public class EventBus : IService
{
    // public Action<Coin> coinReleased;
    public Action<Vector3, int> spawnCoin;

    public Action playerCompleteLevel;
    public Action stopAll;
    public Action playedDied;

    public Action<int> addThisCoinAndSave;
    public Action<int> inGameCoinCollected;

    public Action<EObjectToActiveName> buttonClicked;

    public Action activeShield;

}
