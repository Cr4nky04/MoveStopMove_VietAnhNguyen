using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Character : MonoBehaviour
{
    [SerializeField] public float atkRange=10f;
    [SerializeField] protected float sizeScale;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Transform m_Transform;
    [SerializeField] protected Weapon weapon;
    [SerializeField] protected Character character;

    public float atkSpeed; 
    private Vector3 direction;
    public Character Enemy;
    public List<Character> m_Enemies;
    protected float score;
    public Transform Transform
    {
        get
        {
            if(m_Transform==null)
                m_Transform = transform;
            return m_Transform;
        }
    }

    virtual public void Update()
    {
        //Attack();
    }

    virtual public void Attack()
    {
        if (m_Enemies == null) return;
        Enemy = m_Enemies[0];
        direction = Enemy.Transform.position - Transform.position;
        direction = direction.normalized;
        Weapon attackingWeapon = Instantiate(weapon, Transform.position + 1.5f*direction, Quaternion.identity);
        attackingWeapon.character = character;
        attackingWeapon.TargetPosition = Enemy.Transform.position;
    }
}
