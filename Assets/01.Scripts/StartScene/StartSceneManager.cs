using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public static StartSceneManager instance;
    
    [SerializeField]
    private UIWidget titlePanel;

    [SerializeField]
    private UIWidget stagePanel;

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

        }
    }    

    public void StartGame(Stage selectStage){
        GameManager.instance.selectStage = selectStage;
        SceneManager.LoadScene("01.InGameScene");
    }

    private void OnDestroy() {
        instance = null;    
    }
}
