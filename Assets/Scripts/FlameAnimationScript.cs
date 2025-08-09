using System.Collections;
using UnityEngine;

public class FlameAnimationScript : NeedToStopWhenPlayerDies
{
    [SerializeField] Sprite[] fireSprites;
    [SerializeField] float timeToChangeSprite = 0.5f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(FlameAnimationCoroutine());    
    }
    public override void Stop()
    {
        StopAllCoroutines();
        this.enabled = false;
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
