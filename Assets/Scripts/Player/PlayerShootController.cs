using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] Transform bulletParent;
    [SerializeField] int firstPoolInitCount = 30;
    [SerializeField] TestProjectileScript pfProjectile;
    [SerializeField] Transform spawnPosition;
    bool canShoot = true;

    [SerializeField] int reloadTimeInMilliseconds = 100;
    CustomPool<TestProjectileScript> pool;
    
    void Start()
    {
        pool = new CustomPool<TestProjectileScript>(pfProjectile, firstPoolInitCount, bulletParent);    
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

            await Task.Delay(reloadTimeInMilliseconds);
            Debug.Log("Игрок перезарядился");
            canShoot = true;
        }   
    }
}
