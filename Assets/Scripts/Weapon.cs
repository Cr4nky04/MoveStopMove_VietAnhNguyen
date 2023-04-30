using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform m_Transform;
    [SerializeField] Player player;

    public Character parent;
    private Collider parent_collider;
    private float timeExist = 4f;
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
        parent_collider = parent.GetComponent<Collider>();  
    }

    private void Update()
    {
        Transform.position = Vector3.MoveTowards(Transform.position, TargetPosition, parent.atkSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == parent_collider) return;
        if(other.CompareTag("Character") )
        {
            Character enemy = Cache.EnemyList(other);
            Destroy(other.gameObject);
            parent.m_Enemies.Remove(enemy);
            DestroyWeapon();
        }
    }

    public void DestroyWeapon()
    {
        Destroy(Transform.gameObject);
    }

}
