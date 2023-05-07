using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : GameUnit
{
    [SerializeField] protected Transform m_Transform;

    public Character parent;
    private Collider parent_collider;
    public Vector3 TargetPosition;
    public Transform Transform
    {
        get
        {
            if (m_Transform == null)
                m_Transform = transform;
            return m_Transform;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Transform.position = Vector3.MoveTowards(Transform.position, TargetPosition, parent.atkSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == parent_collider) return;
        if(other.CompareTag("Character") )
        {
            Character enemy = Cache.EnemyList(other);
            SimplePool.Despawn(this);
            enemy.currentState.ChangeState(new BotDeathState());
        }

    }

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
        
    }

    public override void OnInit()
    {
        parent_collider = parent.GetComponent<Collider>();
        //TargetPosition = Vector3.zero;
    }

}
