using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SkinShop : UICanvas
{
    [SerializeField] SkinButton Button;
    [SerializeField] Transform Content;
    public HairData HairData;
    public HairDataList HairDataList;
    public HairList HairList;
    public Player Player;

    private Transform m_Transform;
    public Transform Transform
    {
        get
        {
            if (m_Transform == null)
                m_Transform = transform;
            return m_Transform;
        }
    }
    private void Start()
    {
        for(int i = 0; i < HairData.list.Count; i++)
        {
            SkinButton newButton = Instantiate(Button, Content);
            HairDataList = HairData.GetData((HairList)i);
            newButton.HairList = (HairList)i ;
            newButton.Setup(HairDataList.Sprite, HairDataList.Prefab, Transform);
        }    
        
    }
    
    public void ChangeHair()
    {
        Player.ChangeHair(HairList);
    }
}
