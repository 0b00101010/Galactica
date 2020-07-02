﻿using System.Collections;
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
        BlinkTile();
    }

    public void Exit(){
        guideLine.SetActive(false);
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
        } else if(other.CompareTag("Obstacle")){
            directionChangeEvent?.Invoke();
        }
    }

}
