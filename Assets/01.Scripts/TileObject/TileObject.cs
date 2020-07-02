using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TileObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color defaultColor;

    private Tween blinkTween;
    private IEnumerator blinkCoroutine;
    
    private float fadeDuration;

    private void Awake(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;

        fadeDuration = 0.5f;
    }

    public void Execute(){
        blinkCoroutine?.Stop(this);
        blinkCoroutine = BlinkCoroutine().Start(this);
    }

    private IEnumerator BlinkCoroutine(){
        spriteRenderer.color = defaultColor;
        blinkTween?.Kill();

        blinkTween = spriteRenderer.DOColor(Color.white, fadeDuration);
        yield return blinkTween.WaitForCompletion();

        blinkTween = spriteRenderer.DOColor(defaultColor, fadeDuration);
        yield return blinkTween.WaitForCompletion();

        blinkTween = null;
    }
}
