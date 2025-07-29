using UnityEngine;

public class DispawnCollider : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IDispawnObject>() != null)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
