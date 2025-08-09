using System.Threading.Tasks;
using UnityEngine;

public class PlayerShootController : MonoBehaviour, IService
{
    [SerializeField] Transform projectileParent;
    [SerializeField] int firstPoolInitCount = 30;
    [SerializeField] Projectile pfProjectile;
    [SerializeField] Transform spawnPosition;
    CustomPool<Projectile> pool;

    bool canShoot = true;

    void Start()
    {
        pool = new CustomPool<Projectile>(pfProjectile, firstPoolInitCount, projectileParent);    
    }

    ShipStats shipStats;

    public void Init()
    {
        shipStats = ServiceLocator.Current.Get<PlayerStats>().ShipStat;
    }

    async void Update()
    {
        if (!canShoot)
            return;

        if(Input.GetKey(KeyCode.Space))
        {
            var projectile = pool.Get();
            projectile.transform.position = spawnPosition.position;
            canShoot = false;

            await Task.Delay((int)(shipStats.ShipReloadTime * 1000));
            Debug.Log("Игрок перезарядился");
            canShoot = true;
        }   
    }
}
