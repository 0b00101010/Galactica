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

    private void Awake(){
        if(instance == null){
            instance = this;
        }

        uiController = gameObject.GetComponent<UIController>();
        mapPhaser = gameObject.GetComponent<MapPhaser>();

        mapPhaser.MapCreate();
    }

    public void Death(){
        uiController.Death();
        PlayerCharacterController.instance.Death();
    }

    public void StageReStart(){
        SceneManager.LoadScene("01.InGameScene");
    }

    public void MainScene(){
        SceneManager.LoadScene("00.StartScene");
    }

    public void NextStage(){
        GameManager.instance.selectStage = GameManager.instance.stages[GameManager.instance.selectStage.stageNumber+1];
        SceneManager.LoadScene("01.InGameScene");
    }
    
    private void OnDestory(){
        instance = null;
    }
}
