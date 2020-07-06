using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Tween fadeTween;
    private IEnumerator fadeCoroutine;
    private Color defaultColor;

    private void Awake(){
        defaultColor = Color.white;
        defaultColor.a = 0.5f;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public virtual void Interaction() { 
        fadeCoroutine?.Stop(this);
        fadeCoroutine = FadeCoroutine().Start(this);
    }

    private IEnumerator FadeCoroutine(){
        fadeTween?.Kill();
        spriteRenderer.color = defaultColor;

        fadeTween = spriteRenderer.DOFade(1.0f,0.3f);
        yield return fadeTween.WaitForCompletion();
        
        fadeTween.Kill();
        
        fadeTween = spriteRenderer.DOFade(0.5f,1.2f);
        yield return fadeTween.WaitForCompletion();

        spriteRenderer.color = defaultColor;
    }
}
