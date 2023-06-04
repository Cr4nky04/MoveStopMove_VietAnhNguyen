using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    
    public void PrintCoin()
    {
        Debug.Log(PlayerPrefs.GetInt("PlayerGold"));
    }

}
