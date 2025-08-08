using System.Collections;
using UnityEngine;

public class FlameAnimationScript : MonoBehaviour
{
    [SerializeField] Sprite[] fireSprites;
    [SerializeField] float timeToChangeSprite = 0.5f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(FlameAnimationCoroutine());    
    }

    IEnumerator FlameAnimationCoroutine()
    {
        int i = 0;
        while (true)
        {
            if (i >= fireSprites.Length)
                i = 0;

            spriteRenderer.sprite = fireSprites[i];

            yield return new WaitForSeconds(timeToChangeSprite);

            i++;
        }
    } 
}
