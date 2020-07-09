using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    private MapPhaser mapPhaser;
    
    [HideInInspector]
    public UIController uiController;

    private void Awake(){
        if(instance is null){
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

    private void OnDestory(){
        instance = null;
    }
}
