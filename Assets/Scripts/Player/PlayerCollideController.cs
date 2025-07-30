using UnityEngine;

public class PlayerCollideController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        IInteracteble interacteble = collision.gameObject.GetComponent<IInteracteble>();
        if (interacteble != null)
        {
            interacteble.OnInteract();
        }
    }

}