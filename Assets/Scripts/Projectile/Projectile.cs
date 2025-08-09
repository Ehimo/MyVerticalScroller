using System.Threading.Tasks;
using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    Rigidbody2D rb;

    Task releaseTask;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    ShipStats shipStats;

    void Start()
    {
        shipStats = ServiceLocator.Current.Get<PlayerStats>().ShipStat;
        Release();
    }

    int collisionCount = 0;
    void OnTriggerEnter2D(Collider2D collision)
    {
        ICanDestroyedByBullet canDestroyObject = collision.gameObject.GetComponent<ICanDestroyedByBullet>();
        if (canDestroyObject != null)
        {
            canDestroyObject.OnCollisionWithProjectile();

            collisionCount++;
            if (collisionCount == shipStats.ProjectilePassesThroughEnemy)
            {
                collisionCount = 0;
                gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        rb.velocity = Vector2.up * shipStats.BulletSpeed * Time.fixedDeltaTime;
    }

    int bulletTimeToDispawn = 10;

    async void Release()
    {
        releaseTask = Task.Delay(bulletTimeToDispawn * 1000);
        await releaseTask;

        if (releaseTask != null)
            gameObject.SetActive(false);
    }

    void OnDisable()
    {
        releaseTask = null;
    }
}
