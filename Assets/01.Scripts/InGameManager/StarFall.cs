using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Tempus.CoroutineTools;

public class StarFall : MonoBehaviour
{
    private Image image;

    private float regenerateDuration;
    
    private void Awake(){
        image = gameObject.GetComponent<Image>();
    }
    
    private void Start(){
        regenerateDuration = Random.Range(3.0f, 8.0f);
        StarFallTimer().Start();
    }

    private Vector2 GetRandomPosition(){
        return Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 0));
    }

    private IEnumerator StarFallTimer(){
        float duration = regenerateDuration;
        
        while(true){
            if(duration > 0){
                duration -= Time.deltaTime;
            } else {
                regenerateDuration = Random.Range(3.0f, 8.0f);
                duration = regenerateDuration;
                gameObject.transform.position = GetRandomPosition();
                yield return StarFallCoroutine().Start();
            }

            yield return YieldInstructionCache.WaitUntil;
        }
    }

    private IEnumerator StarFallCoroutine(){
        float fillDuration = Random.Range(0.25f, 1.5f);
        
        float newScaleValue = Random.value;
        var newScaleVector = new Vector2(newScaleValue, newScaleValue);
        
        gameObject.transform.localScale = newScaleVector;

        yield return image.DOFillAmount(1.0f, fillDuration);
        yield return image.DOFillAmount(0.0f, 0.25f);
    }

}
