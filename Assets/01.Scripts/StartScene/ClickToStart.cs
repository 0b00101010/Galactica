using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClickToStart : MonoBehaviour
{
    private Image image;
    private IEnumerator updateCoroutine;
    private Tween updateTween;

    private void Awake(){
        image = gameObject.GetComponent<Image>();
    }

    private void Start(){
        updateCoroutine = UpdateCoroutine().Start(this);
    }   

    public void CoroutineStop(){
        updateCoroutine.Stop(this);
        updateTween.Kill();
    }

    private IEnumerator UpdateCoroutine(){
        while(true){
            updateTween = image.DOFade(0.5f, 0.5f);
            yield return updateTween.WaitForCompletion();
            
            updateTween = image.DOFade(1.0f, 0.5f);
            yield return updateTween.WaitForCompletion();
        }
    } 
}
