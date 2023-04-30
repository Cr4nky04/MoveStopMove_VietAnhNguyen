using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRing : MonoBehaviour
{
    [SerializeField] Character character;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Character enemy = Cache.EnemyList(other);
            character.m_Enemies.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Character"))
        {
            Character enemy = Cache.EnemyList(other);
            character.m_Enemies.Remove(enemy);
        }
        if(other.CompareTag("Weapon"))
        {
            Destroy(other.gameObject);
        }
    }
}
