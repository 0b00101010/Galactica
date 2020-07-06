using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : InteractionObject
{
    public override void Interaction(){
        PlayerCharacterController.instance.Death();
    }
}
