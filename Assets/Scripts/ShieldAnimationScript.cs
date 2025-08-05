using System.Collections;
using UnityEngine;

public class ShieldAnimationScript : MonoBehaviour
{
    [SerializeField] int shieldTime = 0;
    [SerializeField] int rotateSpeed = 10;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void Start()
    {
        ServiceLocator.Current.Get<EventBus>().activeShield += () => 
        {
            spriteRenderer.enabled = true;
            StartCoroutine(ShieldAnimation());        
        };    
    }

    IEnumerator ShieldAnimation()
    {

        for(float i = 0; i <= shieldTime; i += Time.deltaTime)
        {

            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);

            yield return null;
        }

        spriteRenderer.enabled = false;
    }
}
