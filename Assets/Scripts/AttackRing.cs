using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRing : MonoBehaviour
{
    [SerializeField] Character character;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Cache.TAG_CHARACTER))
        {
            Character enemy = Cache.EnemyList(other);
            character.AddCharacter(enemy);
        }
        
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(Cache.TAG_CHARACTER))
        {
            Character enemy = Cache.EnemyList(other);
            character.m_Enemies.Remove(enemy);
        }
        if(other.CompareTag(Cache.TAG_WEAPON) && other.GetComponent<Weapon>().parent == character)
        {
            other.GetComponent<Weapon>().OnDespawn();
        }
        
    }
    
}
