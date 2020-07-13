using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SideUI : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private Image underLine;
    
    [SerializeField]
    private Text text;

    [SerializeField]
    private Transform targetTransform;

    public void Execute(){
        // underLine.gameObject.transform.DOMoveX(targetTransform.position.x, 1.0f);
        // text.gameObject.transform.DOMoveX(targetTransform.position.x, 1.0f);
        gameObject.transform.DOLocalMoveX(0, 0.75f);

        underLine.DOFade(1.0f, 1.0f);
        text.DOFade(1.0f, 1.0f);
    }

    public void SetText(string value){
        text.text = value;
    }
}
