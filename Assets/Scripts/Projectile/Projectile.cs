using System.Threading.Tasks;
using UnityEngine;

public class TestProjectileScript : MonoBehaviour, IDestroyAsteroid, IProjectile    
{
    [SerializeField] float bulletSpeed = 100f;
    
    Rigidbody2D rb;

    Task releaseTask;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Start()
    {
        Release();
    }

    void OnEnable()
    {
        rb.velocity = Vector2.up * bulletSpeed * Time.fixedDeltaTime;
    }

    async void Release()
    {
        releaseTask = Task.Delay(10000);
        await releaseTask;

        if(releaseTask != null)
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        if (!gameObject.activeInHierarchy)
            releaseTask = null;
    }
}
