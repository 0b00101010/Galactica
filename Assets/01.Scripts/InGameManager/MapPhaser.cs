using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPhaser : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private GameObject tileObject;

    [SerializeField]
    private GameObject wallObject;

    [SerializeField]
    private GameObject playerCharacter;

    [SerializeField]
    private GameObject portalObject;

    public void MapCreate(string mapName = "Test"){
        string mapText = Resources.Load<TextAsset>("/MapFile/" + mapName).text;
        string[] mapTextColumn = mapText.Split('\n');

        Vector2 objectGeneratePosition = Vector2.zero;
        
        for(int i = 0; i < mapTextColumn.Length; i++){
            string[] mapTextRow = mapTextColumn[i].Split(',');
            for(int j = 0; j < mapTextRow.Length; j++){
                int objectIndex = int.Parse(mapTextRow[j]);
                GameObject generateObject = null;

                switch(objectIndex){
                    case 0:
                    generateObject = tileObject;
                    break;

                    case 1:
                    generateObject = wallObject;
                    break;

                    case 2:
                    generateObject = playerCharacter;
                    break;

                    case 3:
                    generateObject = portalObject;
                    break;

                }

                objectGeneratePosition.x = j * 1.5f;
                objectGeneratePosition.y = i * 1.5f;

                Instantiate(generateObject, objectGeneratePosition, Quaternion.identity);
            }
        }
    }

}
