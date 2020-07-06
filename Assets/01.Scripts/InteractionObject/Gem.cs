using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gem : InteractionObject
{
    private Tween interactionTween;
    private bool isInteraction;
    
    [Header("Resources")]
    [SerializeField]
    private Sprite activeSprite;
    
    private SpriteRenderer spriteRenderer;

    private void Awake(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Interaction(){
        if(!isInteraction){
            isInteraction = true;
            InteractionCoroutine().Start(this);
        }
    }

    private IEnumerator InteractionCoroutine(){
        spriteRenderer.sprite = activeSprite;

        interactionTween = gameObject.transform.DOScale(1.5f, 0.5f);
        yield return interactionTween.WaitForCompletion();

        gameObject.SetActive(false);
    }
    
}
