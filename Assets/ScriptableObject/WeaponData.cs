using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    //public struct Weapon
    //{
    //    public GameObject Prefab;
    //    public string WeaponName;
    //    public float ATKrange;
    //    public float Damge;
    //}
    //[SerializeField]
    //public Weapon[] WeaponList;
    [SerializeField] List<WeaponDataList> list;


    public WeaponDataList GetData(WeaponList weapon)
    {
        return list[(int)weapon];
    }
}
[Serializable]
public class WeaponDataList
{
    public GameObject Prefab;
    public string WeaponName;
    public float ATKRange;
}

public enum WeaponList
{
    hammer = 0,
    candycane = 1,
    boomerang = 2,
    smirlypop = 3,
    axe = 4,
    icecreamcone = 5,
    battleaxe = 6,
    z = 7,
    arrow = 8, 
    uzi = 9
}

//[Serializable]
//public class WeaponData 
//{
//    public GameObject Prefab;
//    public string WeaponName;
//    public float ATKrange;
//    public float Damge;
//}
