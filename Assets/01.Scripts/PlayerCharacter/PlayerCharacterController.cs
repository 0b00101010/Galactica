using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private BallObject redObject;

    [SerializeField]
    private BallObject blueObject;

    [Header("Values")]
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private int radiusValue;

    private int direction;

    private BallObject mainObject;
    private BallObject subObject;

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
        subObject.gameObject.transform.RotateAround(mainObject.gameObject.transform.Position(), Vector3.forward, angle);
    }

    private void ChangeObject(){
        BallObject temp = mainObject;

        mainObject.Exit();
        
        mainObject = subObject;
        subObject = temp;

        mainObject.Execute();
    }

    public void ChangeDirection(){
        direction *= -1;
    }
}
