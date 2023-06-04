using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "HairData")]
public class HairData : ScriptableObject
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
    public List<HairDataList> list;



    public HairDataList GetData(HairList skin)
    {
        return list[(int)skin];
    }


}
[Serializable]
public class HairDataList
{
    public GameObject Prefab;
    public Sprite Sprite;
    public string HatName;
    public float CoinIncrease;
}

public enum HairList
{
    Arrow,
    CowBoy,
    Crown,
    Ear,
    Hat,
    Hat_Cap,
    Hat_Yellow,
    Headphone,
    Horn,
    Rau
}
