using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private Image[] heartSprites;

    [SerializeField]
    private Sprite fullHeart;

    [SerializeField]
    private Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    public void ShowHealth()
    {
        for (int i = 0; i < heartSprites.Length; i++)
        {
            if (i < player.GetStartingHealth())
            {
                heartSprites[i].enabled = true;
            }
            else
            {
                heartSprites[i].enabled = false;
            }
        }
        UpdateHealth();
    }
    public void UpdateHealth()
    {
        for (int i = 0; i < heartSprites.Length; i++)
        {
            if (i < player.GetCurrentHealth())
            {
                heartSprites[i].sprite = fullHeart;
            }
            else
            {
                heartSprites[i].sprite = emptyHeart;
            }
        }
    }
}
