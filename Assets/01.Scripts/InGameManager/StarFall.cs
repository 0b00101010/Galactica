using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Tempus.CoroutineTools;

public class StarFall : MonoBehaviour
{
    private Image image;
    private IEnumerator timerCoroutine;

    private void Awake(){
        image = gameObject.GetComponent<Image>();
    }

    private Vector2 GetRandomPosition(){
        return Camera.main.ViewportToWorldPoint(new Vector3(Random.value + 0.25f, 1.0f, 0));
    }

    public void Execute(){
        gameObject.SetActive(true);
        gameObject.transform.position = GetRandomPosition();
        StarFallCoroutine().Start();
    }

    private IEnumerator StarFallCoroutine(){
        float fillDuration = Random.Range(1.0f, 1.5f);
        
        float newScaleValue = Random.Range(1.5f, 3.0f);
        var newScaleVector = new Vector2(newScaleValue, newScaleValue);
        
        gameObject.transform.localScale = newScaleVector;
        
        var targetPosition = gameObject.transform.position - new Vector3(10, 10, 0);
        gameObject.transform.DOMove(targetPosition, fillDuration + 0.25f);

        image.fillOrigin = 1;

        var fillAmountTween = image.DOFillAmount(1.0f, fillDuration);
        yield return fillAmountTween.WaitForCompletion();
        
        image.fillOrigin = 0;

        fillAmountTween.Kill();
        fillAmountTween = image.DOFillAmount(0.0f, 0.25f);
        yield return fillAmountTween.WaitForCompletion();

        gameObject.SetActive(false);
    }
}
