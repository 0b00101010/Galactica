using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PauseUI : MonoBehaviour
{
    [Header("Objects")]
    private CanvasGroup canvasGroup;
    
    [SerializeField]
    private GameObject centerObject;
    private Vector2 centerObjectDefaultPosition;

    private Tween fadeTween;
    private bool doingCoroutine;
    private bool toMain ;

    private void Awake(){
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        centerObjectDefaultPosition = centerObject.gameObject.transform.localPosition;
    }

    public void Pause(){
        if(doingCoroutine || GameManager.instance.isPause){
            return;
        }

        doingCoroutine = true;
        GameManager.instance.isPause = true;
        gameObject.SetActive(true);
        PauseCoroutine().Start(this);
    }

    public void Resume(){
        if(doingCoroutine){
            return;
        }
        
        doingCoroutine = true;
        Time.timeScale = 1.0f;
        ResumeCoroutine().Start(this);
    }
    

    private IEnumerator PauseCoroutine(){
        centerObject.transform.localPosition = centerObjectDefaultPosition;
        centerObject.gameObject.transform.DOLocalMoveX(0, 0.75f);
        
        fadeTween?.Kill();

        fadeTween = canvasGroup.DOFade(1.0f, 1.0f);
        yield return fadeTween.WaitForCompletion();
        
        if(!toMain){
            Time.timeScale = 0.0f;
        }
        
        doingCoroutine = false;
    }

    private IEnumerator ResumeCoroutine(){
        fadeTween?.Kill();

        fadeTween = canvasGroup.DOFade(0.0f, 1.0f);
        yield return YieldInstructionCache.WaitingSeconds(1.0f);

        gameObject.SetActive(false);
        GameManager.instance.isPause = false;
        doingCoroutine = false;
    }

    public void ToMain(){
        Time.timeScale = 1.0f;
        GameManager.instance.isPause = false;
        toMain = true;
        InGameManager.instance.MainScene();
    }
}
