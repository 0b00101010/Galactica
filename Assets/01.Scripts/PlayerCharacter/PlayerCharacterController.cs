using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private GameObject redObject;

    [SerializeField]
    private GameObject blueObject;

    [Header("Values")]
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private int radiusValue;

    private GameObject mainObject;
    private GameObject subObject;

    private void Awake(){
        mainObject = redObject;
        subObject = blueObject;
    }

    private void Update(){
        RotateSubObject();

        if(Input.GetKeyDown(KeyCode.A)){
            ChangeObject();
        }
    }

    private void RotateSubObject(){
        subObject.transform.RotateAround(mainObject.transform.Position(), Vector3.forward, radiusValue + (rotateSpeed));
    }

    private void ChangeObject(){
        GameObject temp = mainObject;

        mainObject = subObject;
        subObject = temp;
    }
}
