using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    [SerializeField] private AudioClip impactSFX;
    [SerializeField] private Sprite newSprite;
    [SerializeField] private float switchBackDelay = 1f;
    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;

    private void Start()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();

      
        if (spriteRenderer != null)
        {
            originalSprite = spriteRenderer.sprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.tag == "PlayerBullet")
        {
            
            SoundFXManager.instance.PlaySFX(impactSFX, transform, 1f);

          
            if (newSprite != null && spriteRenderer != null)
            {
                spriteRenderer.sprite = newSprite;   

               
                StartCoroutine(SwitchBackToOriginal());
            }
        }
    }

    IEnumerator SwitchBackToOriginal()
    {
      
        yield return new WaitForSeconds(switchBackDelay);

       
        if (originalSprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = originalSprite;
        }
    }
}
