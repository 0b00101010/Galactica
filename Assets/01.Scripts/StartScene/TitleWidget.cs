using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleWidget : UIWidget
{
    [Header("Objects")]
    [SerializeField]
    private Image titleImage;

    [SerializeField]
    private Image clickToStartImage;

    public override void CloseWidget(Action action){
        titleImage.DOFade(0.0f, 0.75f);
        clickToStartImage.GetComponent<ClickToStart>().CoroutineStop();
        Tween executeTween = clickToStartImage.DOFade(0.0f, 0.75f);

        executeTween.OnComplete(() => {
            gameObject.SetActive(false); 
            action();
        });
    }
}
