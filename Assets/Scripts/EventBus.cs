using System;
using UnityEngine;

public class EventBus
{
    static EventBus get;
    public static EventBus Get 
    {
        get
        {
            if(get == null)
            {
                get = new EventBus();
            }

            return get;
        }
    }
    // public Action<Coin> coinReleased;
    public Action<Vector3, int> spawnCoin;

    public Action onGameEnd;

    public Action<int> addThisCoinAndSave;
    public Action<int> inGameCoinCollected;
}
