using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : ObstacleObject
{
    public override void Interaction(){
        PlayerCharacterController.instance.ChangeDirection();
    }
}
