using UnityEngine;

public class DispawnProjectileCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IProjectile>() != null)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
