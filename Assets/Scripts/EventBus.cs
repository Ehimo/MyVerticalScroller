using System;
using UnityEngine;

public class EventBus
{
    static EventBus sus;
    public static EventBus Sus 
    {
        get
        {
            if(sus == null)
            {
                sus = new EventBus();
            }

            return sus;
        }
    }
    // public Action<Coin> coinReleased;
    public Action<Vector3, int> spawnCoin;
}
