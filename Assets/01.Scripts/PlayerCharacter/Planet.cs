using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Planet : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private GameObject guideLine;

    [SerializeField]
    private ParticleSystem deathParticle;

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

    public void ExecuteDeathAnimation(){
        guideLine.gameObject.SetActive(false);
        deathParticle.gameObject.SetActive(true);

        DeathAnimationCoroutine().Start(this);
    }

    private IEnumerator DeathAnimationCoroutine(){
        Tween executeTween = gameObject.transform.DOScale(2.0f, 0.3f);
        gameObject.GetComponent<SpriteRenderer>().DOFade(0, 0.5f);

        yield return executeTween.WaitForCompletion();

        InGameManager.instance.StageReStart();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("InteractionObject")){
            other.gameObject.GetComponent<InteractionObject>().Interaction();
        }
    }
}
