using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache 
{
    private static Dictionary<Collider, Character> m_EnemyList = new Dictionary<Collider, Character>();

    public static Character EnemyList(Collider key)
    {
        if (!m_EnemyList.ContainsKey(key))
        {
            Character character = key.GetComponent<Character>();

            if (character != null)
            {
                m_EnemyList.Add(key, character);
            }
            else
            {
                return null;
            }
        }

        return m_EnemyList[key];
    }
}
