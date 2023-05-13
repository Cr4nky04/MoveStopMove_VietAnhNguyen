using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PantData")]
public class PantData : ScriptableObject
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
    [SerializeField] List<PantDataList> list;



    public PantDataList GetData(PantList skin)
    {
        return list[(int)skin];
    }


}
[Serializable]
public class PantDataList
{
    public Material Skin;
    public string SkinWeaponName;
    public float MoveSpeed;
}

public enum PantList
{
    Batman,
    Pink,
    Comy,
    DaBao,
    Onion,
    Pokemon,
    Rainbow,
    Skull,
    Vantim
}
