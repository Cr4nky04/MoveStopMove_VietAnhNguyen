using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlay : UICanvas
{
    public TMP_Text coinText;
    public TMP_Text enemyAlive;
    public FloatingJoystick floatingJoystick;

    private void Start()
    {
        
        //UIManager.Ins.OpenUI<WaypointMissionCanvas>();
    }

    public void WinButton()
    {
        UIManager.Ins.OpenUI<Win>().score.text = Random.Range(100, 200).ToString();
        Close(0);
    }

    public void LoseButton()
    {
        UIManager.Ins.OpenUI<Lose>().score.text = Random.Range(0, 100).ToString(); 
        Close(0);
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
        ((Player)LevelManager.Ins.player).floatingJoystick = null; 
    }
}
