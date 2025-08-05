using System;
using UnityEngine;

public class EventBus : IService
{
    // public Action<Coin> coinReleased;
    public Action<Vector3, int> spawnCoin;

    public Action gameEnd;

    public Action levelCompleted;
    public Action playedHasDead;

    public Action<int> addThisCoinAndSave;
    public Action<int> inGameCoinCollected;

    public Action backButtonClicked;
    public Action menuButtonClicked;

    public Action activeShield;
}
