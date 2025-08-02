using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] List<Transform> backgroundObjects;
    SwapIndexClass backgroundSwapIndexClass;
    const float backgroundPositionToSwap = 0;
    const float backgroundPositionToSpawn = 40.96f;
    

    [SerializeField] List<Transform> borderObjects;
    SwapIndexClass borderSwapIndexClass;
    const float borderPositionToSwap = 3.4f;
    const float borderPositionToSpawn = 59;

    
    [SerializeField] int backgroundSpeed = -1;


    [SerializeField] bool isWorking = false;

    void Start()
    {
        backgroundSwapIndexClass = new(0);
        borderSwapIndexClass = new(0);
    }

    void Update()
    {
        Mover(backgroundObjects, backgroundSwapIndexClass, backgroundPositionToSwap, backgroundPositionToSpawn);
        Mover(borderObjects, borderSwapIndexClass, borderPositionToSwap, borderPositionToSpawn);
    }


    void Mover(List<Transform> objects, SwapIndexClass swapIndexClass, float positionToSwap, float spawnPosition)
    {
        objects[0].Translate(0, backgroundSpeed * Time.deltaTime, 0);
        objects[1].Translate(0, backgroundSpeed * Time.deltaTime, 0);

        var otherObject = objects.Where(obj => objects.IndexOf(obj) != swapIndexClass.SwapIndex).First();
        if(otherObject.transform.position.y <= positionToSwap)
        {
            var objectToSwap = objects[swapIndexClass.SwapIndex];
            objectToSwap.position = new Vector3(objectToSwap.position.x, spawnPosition, objectToSwap.position.z);

            swapIndexClass.SwapIndex = swapIndexClass.SwapIndex == 0 ? 1 : 0;
        }
    }
}