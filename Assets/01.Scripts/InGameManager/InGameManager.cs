using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private MapPhaser mapPhaser;
    private UIController uiController;

    private void Awake(){
        uiController = gameObject.GetComponent<UIController>();
        mapPhaser = gameObject.GetComponent<MapPhaser>();

        mapPhaser.MapCreate();
    }

    public void Death(){

    }
}
