using System.Collections;
using System.Collections.Generic;
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

    [Header("Values")]
    [SerializeField]
    private float defaultTime;
    private float usedTime;
 
    [Header("Events")]
    [SerializeField]
    private VoidEvent deathEvent;

    private int gemCount;
    private bool isDeath;

    private void Start(){
        leftSideUI.Execute();
        rightSideUI.Execute();
    }

    public void SetTimer(float value){
        defaultTime = value;
    }

    private void Update(){
        float remainTime = defaultTime - usedTime;

        if(!(remainTime > 0.0f)){
            Death();
        }

        usedTime += Time.deltaTime;
        
        timerText.text = remainTime.ToString("F0");
        timerImage.fillAmount = 1 - (usedTime / defaultTime);
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
