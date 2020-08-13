using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Tempus.CoroutineTools;

public class StarFallGenerator : MonoBehaviour
{
    private Queue<StarFall> starFallQueue = new Queue<StarFall>();

    private void Awake(){
        gameObject.GetComponentsInChildren<StarFall>(true).ToList().ForEach((item) => {
            starFallQueue.Enqueue(item);
        });
    }

    private void Start(){
        StarFallGenerateCoroutine().Start();
    }

    private IEnumerator StarFallGenerateCoroutine(){
        while(true){
            yield return YieldInstructionCache.WaitingSeconds(0.25f);
            GenerateStarFall();
        }
    }

    public void GenerateStarFall(){
        var starFall = starFallQueue.Dequeue();
        starFall.Execute();
        starFallQueue.Enqueue(starFall);
    }
}
