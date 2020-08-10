using UnityEngine;

public class GameManager : DontDestroySingleton<GameManager> {
    [HideInInspector]
    public Stage selectStage;
    public Stage[] stages;
}