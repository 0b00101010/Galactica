using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObject : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private VoidEvent directionChangeEvent;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("InteractionObject")){

        } else if(other.CompareTag("Obstacle")){
            directionChangeEvent?.Invoke();
        }
    }
}
