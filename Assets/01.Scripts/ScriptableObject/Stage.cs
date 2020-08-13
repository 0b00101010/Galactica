using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName = "Setting/Stage", order = 0)]
public class Stage : ScriptableObject {
    public TextAsset mapFile;
    public int stageNumber;
    public int gemCount;
    public bool isOpen;
    public bool isClear;
}