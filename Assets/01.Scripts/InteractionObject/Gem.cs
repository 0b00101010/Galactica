using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gem : InteractionObject
{
    private Tween interactionTween;
    private bool isInteraction;
    
    public override void Interaction(){
        if(!isInteraction){
            isInteraction = true;
            InteractionCoroutine().Start(this);
        }
    }

    private IEnumerator InteractionCoroutine(){
        interactionTween = gameObject.transform.DOScale(1.5f, 1.0f);
        yield return interactionTween.WaitForCompletion();

        gameObject.SetActive(false);
    }
    
}
