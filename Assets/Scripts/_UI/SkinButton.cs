using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : UICanvas
{
    [SerializeField] GameObject Image;
    public GameObject SkinPrefab;
    public SkinShop SkinShop;
    public HairData HairData;
    public HairDataList HairDataList;
    public HairList HairList;
    public void Setup(Sprite sprite, GameObject skinindex, Transform transform)
    {
        Image.GetComponent<Image>().sprite = sprite;
        SkinPrefab = skinindex;
        SkinShop = transform.GetComponent<SkinShop>();
    }
    public void Changing()
    {
        SkinShop.HairList = HairList;
        Debug.Log("Changing");
    }
}
