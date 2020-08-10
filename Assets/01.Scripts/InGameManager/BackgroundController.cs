using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private GameObject[] backgroundObject;
    
    [Header("Values")]
    [SerializeField]
    private int scrollDuration;

    private float startPositionX;
    private float endPositionX;

    private Vector2 screenLeftVector;
    private Vector2 screenRightVector;

    private Vector2 scrollVector;

    private float firstFrameIndex;
    private float secondFrameIndex;

    private float FirstFrameIndex{
        get{
            return firstFrameIndex;
        }

        set{
            if(value == scrollDuration){
                firstFrameIndex = 0;
                return;
            }

            firstFrameIndex = value;
        }
    } 
    
    private float SecondFrameIndex{
        get{
            return secondFrameIndex;
        }

        set{
            if(value == scrollDuration){
                secondFrameIndex = 0;
                return;
            }

            secondFrameIndex = value;
        }
    }

    private void Start(){
        firstFrameIndex =  scrollDuration / 2.0f;
        secondFrameIndex = 0;

        screenLeftVector.x = -0.5f;
        screenRightVector.x = 1.5f;

        startPositionX = Camera.main.ViewportToWorldPoint(screenLeftVector).x;
        endPositionX = Camera.main.ViewportToWorldPoint(screenRightVector).x;
        
        backgroundObject[1].transform.SetPositionX(startPositionX);
    }

    private void Update(){
        startPositionX = Camera.main.ViewportToWorldPoint(screenLeftVector).x;
        endPositionX = Camera.main.ViewportToWorldPoint(screenRightVector).x;

        BackgroundScroll(0);
        BackgroundScroll(1);
    }

    private void BackgroundScroll(int index){
        float frameProperty;
        
        if(index == 0){
            FirstFrameIndex++;
            frameProperty = FirstFrameIndex;
        } else {
            SecondFrameIndex++;
            frameProperty = SecondFrameIndex;
        }

        float progressToPositionX = frameProperty / (float)scrollDuration;
        float overridePosition = Mathf.Lerp(startPositionX, endPositionX, progressToPositionX);

        backgroundObject[index].transform.SetPositionX(overridePosition);
    }
}
