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
            Debug.Log("Shoot!");
            var projectile = pool.Get();
            projectile.transform.position = spawnPosition.position;
            canShoot = false;

            await Task.Delay(100);
            Debug.Log("Can shoot!");
            canShoot = true;
        }   
    }
}
