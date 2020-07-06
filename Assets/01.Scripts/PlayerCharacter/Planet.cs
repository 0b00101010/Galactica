using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private GameObject guideLine;

    public bool Execute(){
        if(!BlinkTile()){
            return false;
        }

        guideLine.SetActive(true);
        return true;
    }

    public void Exit(){
        guideLine.SetActive(false);
    }

    public bool BlinkTile(){
        bool isBlink = false;
        Collider2D[] tiles;

        tiles = Physics2D.OverlapCircleAll(gameObject.transform.position, 0.3f);

        for(int i = 0; i < tiles.Length; i++){
            TileObject tileObject = tiles[i].GetComponentInParent<TileObject>() ?? null;
            
            if(tileObject != null){
                tileObject.Execute();
                isBlink = true;
            }
        }

        return isBlink;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("InteractionObject")){
            other.gameObject.GetComponent<InteractionObject>().Interaction();
        }
    }
}
