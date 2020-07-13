using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClearPortal : InteractionObject
{   
    [SerializeField]
    private GameObject effectObject;
    
    public override void Interaction(){
        effectObject.transform.DOScale(2.0f, 0.25f);
        effectObject.GetComponent<SpriteRenderer>().DOFade(0.0f, 0.5f);
        InGameManager.instance.uiController.Clear();
    }
}
