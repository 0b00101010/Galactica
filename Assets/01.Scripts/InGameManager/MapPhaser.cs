using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    [SerializeField]
    private GameObject deathWall;


    public void MapCreate(string mapName = "Test"){
        string mapText = Resources.Load<TextAsset>("MapFile/" + mapName).text;
        string[] mapTextColumn = mapText.Split('\n');
        
        mapTextColumn.Reverse();

        Vector2 objectGeneratePosition = Vector2.zero;
        
        for(int i = 0; i < mapTextColumn.Length; i++){
            string[] mapTextRow = mapTextColumn[i].Split(',');
            for(int j = 0; j < mapTextRow.Length; j++){
                int objectIndex = int.Parse(mapTextRow[j]);
                GameObject generateObject = null;

                if(objectIndex != 0){
                    Instantiate(tileObject, objectGeneratePosition, Quaternion.identity);                
                }

                switch(objectIndex){
                    case -1:
                    generateObject = playerCharacter;
                    break;

                    case 0:
                    break;

                    case 1:
                    break;

                    case 2:
                    generateObject = wallObject;
                    break;

                    case 3:
                    generateObject = deathWall;
                    break;

                    case 4:
                    break;

                    case 5:
                    generateObject = portalObject;
                    break;

                }

                objectGeneratePosition.x = j * 1.5f;
                objectGeneratePosition.y = i * 1.5f;

                if(objectIndex.Equals(0) || objectIndex.Equals(1)){
                    continue;
                }

                Instantiate(generateObject, objectGeneratePosition, Quaternion.identity);
            }
        }
    }

}
