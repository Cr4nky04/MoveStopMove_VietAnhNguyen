using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : GameUnit
{
    [SerializeField] protected Transform m_Transform;
    private WeaponDataList m_DataList;
    private Collider parent_collider;
    public Character parent;
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
        OnRotate();
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

    public void OnRotate()
    {
        Transform.Rotate( new Vector3(3f,0f,0f));
    }
    public override void OnInit()
    {
        parent_collider = parent.GetComponent<Collider>();
        //TargetPosition = Vector3.zero;
    }

}
