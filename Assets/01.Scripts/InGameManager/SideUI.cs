using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SideUI : MonoBehaviour
{
    [Header("Objects")]
    private Text text;
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Transform targetTransform;

    private void Awake(){
        text = gameObject.GetComponentInChildren<Text>();
        canvasGroup = gameObject.GetComponentInChildren<CanvasGroup>();
        
    }

    public void Execute(){
        // underLine.gameObject.transform.DOMoveX(targetTransform.position.x, 1.0f);
        // text.gameObject.transform.DOMoveX(targetTransform.position.x, 1.0f);
        gameObject.transform.DOLocalMoveX(0, 0.75f);

        canvasGroup.DOFade(1.0f, 1.0f);
    }

    public void SetText(string value){
        text.text = value;
    }
}
