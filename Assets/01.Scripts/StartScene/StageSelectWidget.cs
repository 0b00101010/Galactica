using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageSelectWidget : UIWidget
{
    [Header("Objects")]
    [SerializeField]
    private Image titleImage;

    [SerializeField]
    private StageSelectButton[] buttons;

    public override void OpenWidget(){
        gameObject.SetActive(true);

        titleImage.DOFade(1.0f, 0.5f);
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].Execute();
        }
    }
}
