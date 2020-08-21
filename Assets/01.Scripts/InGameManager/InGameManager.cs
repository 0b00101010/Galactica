using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    private MapPhaser mapPhaser;
    
    [HideInInspector]
    public UIController uiController;
    private bool toMain;

    private void Awake(){
        if(instance == null){
            instance = this;
        }

        uiController = gameObject.GetComponent<UIController>();
        mapPhaser = gameObject.GetComponent<MapPhaser>();

        mapPhaser.MapCreate();
    }

    private void Start(){
        uiController.FadeOut();
        UpdateCoroutine().Start(this);
    }

    private IEnumerator UpdateCoroutine(){        
        while(true){
            uiController.ChangeBackgroundColor();
            yield return YieldInstructionCache.WaitingSeconds(5.0f);
        }
    }

    public void Death(){
        uiController.Death();
        PlayerCharacterController.instance.Death();
    }

    public void StageReStart(){
        uiController.FadeIn(() => SceneManager.LoadScene("01.InGameScene"));
        
    }

    public void MainScene(){
        if(toMain){
            return;
        }
        toMain = true;
        Time.timeScale = 1.0f;
        GameManager.instance.isPause = false;
        uiController.FadeIn(() => SceneManager.LoadScene("00.StartScene"));
    }

    public void NextStage(){
        GameManager.instance.selectStage = GameManager.instance.stages[GameManager.instance.selectStage.stageNumber+1];
        uiController.FadeIn(() => SceneManager.LoadScene("01.InGameScene"));
    }
    
    private void OnDestory(){
        instance = null;
    }
}
