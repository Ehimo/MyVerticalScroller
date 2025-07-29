using UnityEngine;

public class ObjectSpawer : MonoBehaviour
{
    float xMinSpawnPosition = -5.2f;
    float xMaxSpawnPosition = 5.2f;

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

            int objectToSpawnCount = UnityEngine.Random.Range(2, 4);

            for(int i = 0; i < objectToSpawnCount; i++)
            {
                // Радномно сгенерировать типы обектов которые будут спавниться.
                var asteroid = pool.Get();
                asteroid.transform.position = GeneratePosition();
            }
            
        }
    }

    Vector3 GeneratePosition()
    {
        var xPosition = Random.Range(xMinSpawnPosition, xMaxSpawnPosition);
        var spawnPosition = new Vector3(xPosition, transform.position.y, 0);
        return spawnPosition;
    }
}
