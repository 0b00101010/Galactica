using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClearPortal : InteractionObject
{   
    [SerializeField]
    private GameObject effectObject;

    public override void Interaction(){
        if(GameManager.instance.selectStage.gemCount < 2){
            return;
        }
        
        effectObject.transform.DOScale(5.0f, 0.5f);
        effectObject.GetComponent<SpriteRenderer>().DOFade(0.0f, 0.75f);
        InGameManager.instance.uiController.Clear();
    }
}
