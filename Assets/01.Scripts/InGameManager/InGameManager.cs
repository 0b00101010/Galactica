using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private MapPhaser mapPhaser;

    private void Awake(){
        mapPhaser = gameObject.GetComponent<MapPhaser>();
        mapPhaser.MapCreate();
    }
}
