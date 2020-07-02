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

    private int direction;

    private GameObject mainObject;
    private GameObject subObject;

    private void Awake(){
        mainObject = redObject;
        subObject = blueObject;

        direction = 1;
    }

    private void Update(){
        RotateSubObject();

        if(Input.GetKeyDown(KeyCode.A)){
            ChangeObject();
        }
    }

    private void RotateSubObject(){
        float angle = direction * (radiusValue + rotateSpeed);
        subObject.transform.RotateAround(mainObject.transform.Position(), Vector3.forward, angle);
    }

    private void ChangeObject(){
        GameObject temp = mainObject;

        mainObject = subObject;
        subObject = temp;
    }

    public void ChangeDirection(){
        direction *= -1;
    }
}
