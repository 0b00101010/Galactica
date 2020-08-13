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

    [Header("Values")]
    [SerializeField]
    private float fadeTime = 0.5f;

    [SerializeField]
    private float changeScaleValue = 1.5f;

    [Header("Events")]
    [SerializeField]
    private VoidEvent gemInteractionEvent;

    private void Awake(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Interaction(){
        if(!isInteraction){
            isInteraction = true;
            InGameManager.instance.uiController.AddGemCount();

            InteractionCoroutine().Start(this);
        }
    }

    private IEnumerator InteractionCoroutine(){
        spriteRenderer.sprite = activeSprite;

        interactionTween = gameObject.transform.DOScale(changeScaleValue, 0.5f);
        spriteRenderer.DOFade(0.0f, fadeTime);
        yield return interactionTween.WaitForCompletion();

        gameObject.SetActive(false);
    }
    
}
