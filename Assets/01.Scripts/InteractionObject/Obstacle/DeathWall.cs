using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : ObstacleObject
{
    public override void Interaction(){
        InGameManager.instance.Death();
    }
}
