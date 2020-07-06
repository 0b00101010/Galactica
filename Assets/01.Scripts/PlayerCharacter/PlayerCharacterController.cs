using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    private Ray velocityRay;

    private BallObject mainObject;
    private BallObject subObject;

    private void Awake(){
        mainObject = redObject;
        subObject = blueObject;

        direction = 1;
    }

    private void Start(){
        Vector3 objectPosition = gameObject.transform.position;
        objectPosition.z = Camera.main.gameObject.transform.position.z; 

        Camera.main.gameObject.transform.position = objectPosition;
    }

    private void Update(){
        RotateSubObject();   
        CheckObstacleToRay();

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

        Camera.main.gameObject.transform.DOMoveX(mainObject.transform.position.x, 0.5f);
        Camera.main.gameObject.transform.DOMoveY(mainObject.transform.position.y, 0.5f);

        mainObject.Execute();
    }

    public void ChangeDirection(){
        direction *= -1;
    }

    private float GetCircleVelocity(){
        float angle = Mathf.Atan2(subObject.transform.position.y - mainObject.transform.position.y,
        subObject.transform.position.x - mainObject.transform.position.x) * 180 / Mathf.PI;

        return angle ;
    }

    private void CheckObstacleToRay(){
    float angle = (GetCircleVelocity() / 180 * Mathf.PI) + (90 * direction);
        float distance = Vector2.Distance(mainObject.transform.position, subObject.transform.position);
        
        Vector2 newVector;
        
        newVector.x = distance * Mathf.Cos(angle);
        newVector.y = distance * Mathf.Sin(angle);

        newVector = (Vector2)subObject.transform.position + newVector;

        velocityRay.origin = subObject.transform.position;
        velocityRay.direction = newVector - (Vector2)subObject.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(velocityRay.origin, velocityRay.direction, 0.5f, LayerMask.GetMask("Obstacle"));

        if(hit.collider != null){
            ChangeDirection();
        }
    }

    private void OnDrawGizmos() {
        Debug.DrawRay(velocityRay.origin, velocityRay.direction, Color.red);
    }
}
