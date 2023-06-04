using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRing : GameUnit
{
    public override void OnDespawn()
    {
        gameObject.SetActive(false);
    }
    public override void OnInit()
    {
        //throw new System.NotImplementedException();
    }
    public void DeactiveTargetRing()
    {
        transform.gameObject.SetActive(false);
    }
    public void ActiveTargetRing()
    {
        transform.gameObject.SetActive(true);
    }
}
