using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ShieldData")]
public class ShieldData : ScriptableObject
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
    [SerializeField] List<ShieldDataList> list;



    public ShieldDataList GetData(ShieldList skin)
    {
        return list[(int)skin];
    }


}
[Serializable]
public class ShieldDataList
{
    public GameObject Prefab;
    public string ShieldName;
    public float CoinIncrease;
}

public enum ShieldList
{
    Shield,
    Khien
}
