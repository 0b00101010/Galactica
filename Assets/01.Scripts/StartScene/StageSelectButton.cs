using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageSelectButton : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private Stage stageInformation;

    [SerializeField]
    private Stage nextStageInformation;

    [SerializeField]
    private Image[] gemImages;

    [SerializeField]
    private Image frameImage;

    [SerializeField]
    private Text stageText;

    [Header("Resources")]
    [SerializeField]
    private Sprite openSprite;

    [SerializeField]
    private Sprite fullGem;

    public void Execute(){
        if(stageInformation.isOpen){
            Setting();
        } 

        stageText.text = stageInformation.stageNumber.ToString();

        frameImage.DOFade(1.0f, 0.5f);
        stageText.DOFade(1.0f, 0.5f);

        for(int i = 0; i < gemImages.Length; i++){
            gemImages[i].DOFade(1.0f, 0.5f);
        } 
    }

    private void Setting(){
        frameImage.sprite = openSprite;

        if(stageInformation.isClear){
            nextStageInformation.isOpen = true;
        }

        for(int i = 0; i < stageInformation.gemCount; i++){
            gemImages[i].sprite = fullGem;
        }
    }
}
