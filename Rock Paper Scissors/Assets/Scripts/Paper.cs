using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Creature
{
    [SerializeField]
    private GameObject newCreature;
    protected override void HandleCollision(Collision other)
    {
        base.HandleCollision(other);
        ReplaceTWithNewCreature<Rock>(other, newCreature);
    }

    protected override void HandleTrigger()
    {
        base.HandleTrigger();
        // GameManager.instance.paperCount--;
    }
}
