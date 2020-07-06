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

    [Header("Values")]
    [SerializeField]
    private float defaultTime;
    private float usedTime;
 
    [Header("Events")]
    [SerializeField]
    private VoidEvent deathEvent;

    public void SetTimer(float value){
        defaultTime = value;
    }

    private void Update(){
        float remainTime = defaultTime - usedTime;

        if(!(remainTime > 0.0f)){
            deathEvent.Invoke();
            this.enabled = false;

        }

        usedTime += Time.deltaTime;
        
        timerText.text = remainTime.ToString("F0");
        timerImage.fillAmount = 1 - (usedTime / defaultTime);
    }
}
