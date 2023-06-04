using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache 
{

    private static Dictionary<float, WaitForSeconds> m_WFS = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWFS(float key)
    {
        if (!m_WFS.ContainsKey(key))
        {
            m_WFS[key] = new WaitForSeconds(key);
        }

        return m_WFS[key];
    }

    //----------------------------------------------------------------------------------------------------

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
    //----------------------------------------------------------------------------------------------------

    public const string ANIM_RUN = "IsRun";
    public const string ANIM_IDLE = "IsIdle";
    public const string ANIM_DEAD = "IsDead";
    public const string ANIM_ATTACK = "IsAttack";
    public const string TAG_CHARACTER = "Character";
    public const string TAG_WEAPON = "Weapon";
    public const string TAG_OBSTACLE = "Obstacle";

    private static Dictionary<string, string> m_AnimName = new Dictionary<string, string>();
    public static string AnimName(string anim)
    {
        if(!m_AnimName.ContainsKey(anim))
        {
            string name = anim;
            m_AnimName.Add(anim, name);
        }
        return m_AnimName[anim];
    }
    private static Dictionary<Character, Character> m_CharacterList = new Dictionary<Character, Character>();
    //----------------------------------------------------------------------------------------------------

    public static Character CharacterList(Character key)
    {
        if (!m_CharacterList.ContainsKey(key))
        {
            

            if (key != null)
            {
                m_CharacterList.Add(key, key);
            }
            else
            {
                return null;
            }
        }

        return m_CharacterList[key];
    }
    //----------------------------------------------------------------------------------------------
    private static Dictionary<Collider, ObjectTransparent> m_ObstacleList = new Dictionary<Collider, ObjectTransparent>();

    public static ObjectTransparent ObstacleList(Collider key)
    {
        if (!m_ObstacleList.ContainsKey(key))
        {
            ObjectTransparent obstacle = key.GetComponent<ObjectTransparent>();

            if (obstacle != null)
            {
                m_ObstacleList.Add(key, obstacle);
            }
            else
            {
                return null;
            }
        }

        return m_ObstacleList[key];
    }
}
