using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRing : AttackRing
{
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag(Cache.TAG_OBSTACLE))
        {
            ObjectTransparent obstacle = Cache.ObstacleList(other);
            obstacle.DoFade = true;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other); 
        if (other.CompareTag(Cache.TAG_OBSTACLE))
        {
            ObjectTransparent obstacle = Cache.ObstacleList(other);
            obstacle.DoFade = false;
        }
    }
}
