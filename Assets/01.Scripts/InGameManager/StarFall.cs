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
    private IEnumerator timerCoroutine;

    private void Awake(){
        image = gameObject.GetComponent<Image>();
    }
    
    private void Start(){
        regenerateDuration = Random.Range(3.0f, 8.0f);
    }

    private Vector2 GetRandomPosition(){
        return Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 0));
    }

    private void Update(){
        if(regenerateDuration > 0){
            regenerateDuration -= Time.deltaTime;
        } else {
            gameObject.transform.position = GetRandomPosition();
            regenerateDuration = Random.Range(3.0f, 8.0f);

            StarFallCoroutine().Start();
        }
    }

    private IEnumerator StarFallCoroutine(){
        float fillDuration = Random.Range(0.75f, 1.5f);
        
        float newScaleValue = Random.Range(1.5f, 2.5f);
        var newScaleVector = new Vector2(newScaleValue, newScaleValue);
        
        gameObject.transform.localScale = newScaleVector;

        image.fillOrigin = 1;

        var fillAmountTween = image.DOFillAmount(1.0f, fillDuration);
        yield return fillAmountTween.WaitForCompletion();
        
        image.fillOrigin = 0;

        fillAmountTween.Kill();
        fillAmountTween = image.DOFillAmount(0.0f, 0.25f);
        yield return fillAmountTween.WaitForCompletion();
    }
}
