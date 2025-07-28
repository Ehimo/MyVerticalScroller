using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawer : MonoBehaviour
{
    float xMin = -5.2f;
    float xMax = 5.2f;

    [SerializeField] float spawnTimer = 0.5f;
    float timer = 0;

    [SerializeField] Transform objectParent;
    [SerializeField] Asteroid pfAsterodin;

    CustomPool<Asteroid> pool;

    [SerializeField] int firstPoolInitCount = 30;

    void Start()
    {
        pool = new CustomPool<Asteroid>(pfAsterodin, firstPoolInitCount, objectParent);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnTimer)
        {
            timer = 0;
            

            var asteroid = pool.Get();
            asteroid.transform.position = GeneratePosition();

            asteroid = pool.Get();
            asteroid.transform.position = GeneratePosition();
        }
    }

    Vector3 GeneratePosition()
    {
        var xPosition = Random.Range(xMin, xMax);
        var spawnPosition = new Vector3(xPosition, transform.position.y, 0);
        return spawnPosition;
    }
}
