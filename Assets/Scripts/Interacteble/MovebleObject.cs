using UnityEngine;

public class MovebleObject : MonoBehaviour
{
    float speedMultiplayer = 1;
    int moveSpeed = 10;

    void Start()
    {
        ServiceLocator.Current.Get<EventBus>().stopAll += () => { needToMove = false; };      
    }

    bool needToMove = true;

    void Update()
    {
        if (needToMove)
        {
            transform.Translate(0,-moveSpeed * speedMultiplayer * Time.deltaTime,0);
        }
    }
}
