using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallObject : MonoBehaviour
{
    
    [Header("Objects")]
    [SerializeField]
    private GameObject guideLine;
    
    [SerializeField]
    private GameObject otherObject;

    [SerializeField]
    private VoidEvent directionChangeEvent;

    private int direction = 1;
    public int Direction {get => direction; set {direction = value;}}

    private float defaultSpeed;
    public float DefaultSpeed {get => defaultSpeed; set {defaultSpeed = value;}} 

    private Rigidbody2D rigidbody2D;
    private IEnumerator executeCoroutine;

    private Tween moveTween;

    private void Awake(){
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Execute(){
        guideLine.SetActive(true);
        BlinkTile();

        executeCoroutine = ExecuteCoroutine().Start(this);
    }

    private IEnumerator ExecuteCoroutine(){
        Vector2 newPosition;
    
        float firstPositionAngle;
        float secondPositionAngle;

        float distance = Vector2.Distance(otherObject.transform.position, gameObject.transform.position);

        while(true){
            firstPositionAngle = 
            Mathf.Atan2(otherObject.transform.position.y - gameObject.transform.position.y,
            otherObject.transform.position.x - gameObject.transform.position.x) * Mathf.Rad2Deg;

            firstPositionAngle.Log();

            secondPositionAngle = firstPositionAngle + 1; 
            secondPositionAngle = secondPositionAngle * Mathf.PI / 180;
            
            newPosition.x = distance * Mathf.Cos(secondPositionAngle * defaultSpeed);
            newPosition.y = distance * Mathf.Sin(secondPositionAngle * defaultSpeed);

            gameObject.transform.position = ((Vector2)otherObject.transform.position + newPosition) * direction;
        
            yield return YieldInstructionCache.WaitUntil;
        }
    }

    public void Exit(){
        guideLine.SetActive(false);
        executeCoroutine?.Stop(this);
    }

    public void BlinkTile(){
        Collider2D[] tiles;

        tiles = Physics2D.OverlapCircleAll(gameObject.transform.position, 0.5f);

        for(int i = 0; i < tiles.Length; i++){
            tiles[i].GetComponent<TileObject>()?.Execute();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("InteractionObject")){
            other.gameObject.GetComponent<InteractionObject>().Interaction();
        }

        if(other.CompareTag("Obstacle")){
            // directionChangeEvent.Invoke();
        }
    }    
}
