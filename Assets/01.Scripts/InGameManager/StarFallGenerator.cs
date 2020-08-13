using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StarFallGenerator : MonoBehaviour
{
    private Queue<StarFall> starFallQueue = new Queue<StarFall>();
    private IEnumerator generateCoroutine;

    private void Awake(){
        gameObject.GetComponentsInChildren<StarFall>(true).ToList().ForEach((item) => {
            starFallQueue.Enqueue(item);
        });
    }

    private void Start(){
        generateCoroutine = StarFallGenerateCoroutine().Start(this);
    }

    private IEnumerator StarFallGenerateCoroutine(){
        while(true){
            yield return YieldInstructionCache.WaitingSeconds(0.75f);
            GenerateStarFall();
        }
    }

    public void GenerateStarFall(){
        var starFall = starFallQueue.Dequeue();
        starFall.Execute();
        starFallQueue.Enqueue(starFall);
    }

    private void OnDestory(){
        generateCoroutine.Stop(this);
    }
}
