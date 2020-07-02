using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObject : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private GameObject guideLine;
    
    [Header("Events")]
    [SerializeField]
    private VoidEvent directionChangeEvent;


    public void Execute(){
        guideLine.SetActive(true);
    }

    public void Exit(){
        guideLine.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("InteractionObject")){
            other.gameObject.GetComponent<InteractionObject>().Interaction();
        } else if(other.CompareTag("Obstacle")){
            directionChangeEvent?.Invoke();
        }
    }
}
