using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionUIAnimation : MonoBehaviour
{
    [SerializeField]
    Image suspicionGauge;

    [SerializeField]
    PlayerSuspicion suspicion;

    [SerializeField]
    List<Sprite> suspicionSprites;


    // Update is called once per frame
    void Update()
    {
        SetSprite();
    }

    void SetSprite()
    {
        int spriteIndex = (int)(suspicion.Progress * suspicionSprites.Count);

        if (spriteIndex >= suspicionSprites.Count)
        {
            suspicionGauge.sprite = suspicionSprites[suspicionSprites.Count - 1];
        }
        else if (spriteIndex < 0)
        {
            suspicionGauge.sprite = suspicionSprites[0];
        }
        else
        {
            suspicionGauge.sprite = suspicionSprites[spriteIndex];
        }
    }
}
