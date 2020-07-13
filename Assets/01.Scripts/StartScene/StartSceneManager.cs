using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class StartSceneManager : MonoBehaviour
{
    public static StartSceneManager instance;
    
    [Header("Objects")]
    [SerializeField]
    private UIWidget titlePanel;

    [SerializeField]
    private UIWidget stagePanel;

    [SerializeField]
    private Image blackBackground;

    private bool isTitle;

    private void Awake(){
        instance = instance is null ? this : instance;
    }

    private void Update(){
        if(!isTitle){
            if(Input.GetMouseButtonDown(0)){
                titlePanel.CloseWidget(stagePanel.OpenWidget);
                isTitle = true;
            }
        } else {
            this.enabled = false;
        }
    }    

    public void StartGame(Stage selectStage){
        GameManager.instance.selectStage = selectStage;

        blackBackground.gameObject.SetActive(true);
        Tween fadeTween = blackBackground.DOFade(1.0f, 0.75f);
        fadeTween.OnComplete(() => SceneManager.LoadScene("01.InGameScene"));
    }

    private void OnDestroy() {
        instance = null;
    }
}
