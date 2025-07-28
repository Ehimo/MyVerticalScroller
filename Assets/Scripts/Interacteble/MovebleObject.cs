using UnityEngine;

public class MovebleObject : MonoBehaviour
{
    float speedMultiplayer = 1;
    int moveSpeed = 10;


    void Update()
    {
        transform.Translate(0,-moveSpeed * speedMultiplayer * Time.deltaTime,0);
    }

}
