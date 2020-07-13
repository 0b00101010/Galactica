using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private Image timerImage;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private SideUI leftSideUI;

    [SerializeField]
    private SideUI rightSideUI;

    [SerializeField]
    private ClearUI clearUI;

    [SerializeField]
    private Image fadeImage;

    [Header("Values")]
    [SerializeField]
    private float defaultTime;
    private float usedTime;
 
    [Header("Events")]
    [SerializeField]
    private VoidEvent deathEvent;

    private int gemCount;
    private bool isDeath;
    private bool isClear;

    public bool IsClear {
        get => isClear;

        set{
            isClear = value;
        }
    }
    
    private void Start(){
        leftSideUI.Execute();
        rightSideUI.Execute();
    }

    public void SetTimer(float value){
        defaultTime = value;
    }

    private void Update(){
        if(isClear){
            return;
        }

        float remainTime = defaultTime - usedTime;

        if(!(remainTime > 0.0f)){
            Death();
        }

        usedTime += Time.deltaTime;
        
        timerText.text = remainTime.ToString("F0");
        timerImage.fillAmount = 1 - (usedTime / defaultTime);
    }

    public void FadeIn(Action action){
        fadeImage.gameObject.SetActive(true);
        Tween fadeTween = fadeImage.DOFade(1.0f, 0.5f);
        fadeTween.OnComplete(() => action());
    }
    public void FadeOut(){
        Tween fadeTween = fadeImage.DOFade(0.0f, 0.5f);
        fadeTween.OnComplete(() => {fadeImage.gameObject.SetActive(false);});
    }

    public void Clear(){
        isClear = true;
        clearUI.Execute();
    }

    public void AddGemCount(){
        gemCount++;
        rightSideUI.SetText("Gem " + gemCount + " / 3");

        if(gemCount > GameManager.instance.selectStage.gemCount){
            GameManager.instance.selectStage.gemCount = gemCount;
        }
    }

    public void Death(){
        this.enabled = false;
        
        if(isDeath){
            return;
        }

        isDeath = true;
        deathEvent.Invoke();
    }
}
