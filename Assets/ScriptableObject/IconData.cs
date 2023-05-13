using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "IconData")]
public class IconData : ScriptableObject
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
    [SerializeField] List<IconDataList> list;



    public IconDataList GetData(IconList skin)
    {
        return list[(int)skin];
    }


}
[Serializable]
public class IconDataList
{
    public Sprite WeaponIcon;
    public string IconName;
    public WeaponList WeaponList;
    public string BuffDescription;
}

public enum IconList
{
    hammer = 0,
    candycane = 1,
    boomerang = 2,
    swirlypop = 3,
    axe = 4,
    icecreamcone = 5,
    battleaxe = 6,
    z = 7,
    arrow = 8,
    uzi = 9
}
