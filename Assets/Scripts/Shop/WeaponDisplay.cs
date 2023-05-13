using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public Sprite WeaponSprite;
    public Image WeaponImage;
    public IconData IconData;
    public IconDataList IconDataList;
    public IconList IconList;
    public IconList weaponIcon;
    public Player Player;
    public TMP_Text WeaponName;
    public TMP_Text BuffDescription;

    private void OnEnable()
    {
        
        weaponIcon = (IconList)0;

    }
    private void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log(weaponIcon);
        DisplayWeapon();
    }
    public void DisplayWeapon()
    {
        IconDataList = IconData.GetData(weaponIcon);
        WeaponImage.sprite = IconDataList.WeaponIcon;
        WeaponName.text = IconDataList.IconName;
        BuffDescription.text = IconDataList.BuffDescription;   
    }
    public void NextWeaponIcon()
    {
        Debug.Log("Next");
        weaponIcon += 1;
   
    }
    public void PrevWeaponIcon()
    {
        Debug.Log("Prev");
        weaponIcon -= 1;
        
    }
    public void SelectWeapon()
    {
        IconDataList = IconData.GetData(weaponIcon);
        Player.ChangeWeapon(IconDataList.WeaponList);
    }
}
