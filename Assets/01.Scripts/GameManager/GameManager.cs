using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager instance {
        get{ 
            if(_instance is null){
                var obj = GameObject.FindObjectOfType<GameManager>();

                if(obj is null){
                    var newGameManager = Instantiate(new GameObject("GameManager"), Vector2.zero, Quaternion.identity);
                    obj = newGameManager.AddComponent<GameManager>();
                }
            
                _instance = obj;
                DontDestroyOnLoad(obj);
            }

            return _instance;
        }
        
        set{
            if(_instance is null){
                _instance = value;
            }
        }
    }
    public Stage selectStage;

    private void Awake(){
        if(instance == null){
            instance = this;
        } else {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }   
}