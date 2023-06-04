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
    private Vector3 defaultScale;

    public Character parent;
    public float WeaponSpeed;
    public Vector3 TargetPosition;
    public float WeaponScale;
    public Transform Transform
    {
        get
        {
            if (m_Transform == null)
                m_Transform = transform;
            return m_Transform;
        }
    }

    private void Awake()
    {
        defaultScale = transform.localScale;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if(Transform==null)
            return;
        if (TargetPosition == null)
            return;
        
        Transform.position = Vector3.MoveTowards(Transform.position, TargetPosition, WeaponSpeed * Time.deltaTime);
        if(Vector3.Distance(Transform.position, TargetPosition)<0.1f)
        {
            OnDespawn();
        }
        OnRotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == parent_collider) return;
        if(other.CompareTag(Cache.TAG_CHARACTER) )
        {
            //TODO:
            SimplePool.Despawn(this);
            parent.KillUp();
            Cache.EnemyList(other).OnHit();
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
        WeaponSpeed = parent.WeaponSpeed;
        WeaponScale = parent.WeaponScale;
        transform.localScale = defaultScale * WeaponScale;
        //TargetPosition = Vector3.zero;
    }

}
