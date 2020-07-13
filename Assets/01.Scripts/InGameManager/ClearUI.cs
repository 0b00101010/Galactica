using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClearUI : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private Image backgroundImage;

    [SerializeField]
    private Text stageNameText;

    [SerializeField]
    private Image stageNameUnderline;

    [SerializeField]
    private GameObject textObject;

    [SerializeField]
    private Image[] gemImages;

    [SerializeField]
    private Image[] buttons;

    [Header("Resources")]
    [SerializeField]
    private Sprite fullGemSprite;

    public void Execute(){
        gameObject.SetActive(true);
        stageNameText.text = "Stage" + GameManager.instance.selectStage.stageNumber.ToString("D2");
        for(int i = 0; i < GameManager.instance.selectStage.gemCount; i++){
            gemImages[i].sprite = fullGemSprite;
        }

        ExecuteCoroutine().Start(this);
    }

    private IEnumerator ExecuteCoroutine(){
        Tween executeTween = backgroundImage.DOFade(0.3f,0.1f);
        yield return executeTween.WaitForCompletion();

        stageNameText.DOFade(1.0f, 0.25f);
        stageNameUnderline.DOFade(1.0f, 0.25f);
        executeTween = textObject.gameObject.transform.DOLocalMoveX(0, 0.5f);

        yield return executeTween.WaitForCompletion();

        gemImages[0].DOFade(1.0f, 0.2f);
        gemImages[1].DOFade(1.0f, 0.2f);
        executeTween = gemImages[2].DOFade(1.0f, 0.2f);
        
        yield return executeTween.WaitForCompletion();

        buttons[0].DOFade(1.0f, 0.5f);
        buttons[1].DOFade(1.0f, 0.5f);
        buttons[2].DOFade(1.0f, 0.5f);
    }
}
