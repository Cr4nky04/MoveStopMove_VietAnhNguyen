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


    public WeaponDataList GetData(int weaponIndex)
    {
        return list[weaponIndex];
    }


}
[Serializable]
public class WeaponDataList
{
    public GameObject Prefab;
    public string WeaponName;
    public float ATKRange;
    public float Damge;
}

public enum WeaponList
{
    hammer = 0,
    lollipop = 1,
    knife = 2,
    candycane = 3,
    boomerang = 4,
    smirlypop = 5,
    axe = 6,
    icecreamcone = 7,
    battleaxe = 8,
    z = 9,
    arrow = 10, 
    uzi = 11
}

//[Serializable]
//public class WeaponData 
//{
//    public GameObject Prefab;
//    public string WeaponName;
//    public float ATKrange;
//    public float Damge;
//}
