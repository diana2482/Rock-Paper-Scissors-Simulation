using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : Creature
{
    [SerializeField]
    private GameObject newCreature;
    protected override void HandleCollision(Collision other)
    {
        base.HandleCollision(other);
        ReplaceTWithNewCreature<Paper>(other, newCreature);
    }
    protected override void HandleTrigger()
    {
        base.HandleTrigger();
        // GameManager.instance.scissorsCount--;
    }
}